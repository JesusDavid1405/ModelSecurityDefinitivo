using Microsoft.AspNetCore.Mvc;
using Business.Services;
using Entity.DTOs.Write;
using Utilities.Helpers;
using Business.JWT;
using Data.Repository;
using Microsoft.AspNetCore.Authorization;
using Google.Apis.Auth;
using Utilities.Notification.Email;

namespace Web.Controllers;

[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
public class AuthController : ControllerBase
{
    private readonly AuthServices _authServices;
    private readonly ILogger<AuthController> _logger;
    private readonly IConfiguration _configuration;
    private readonly JWTGenerate _jwt;
    private readonly AuthRepository _repository;
    private readonly NotificationEmail _email;

    public AuthController(
        AuthServices authServices, 
    ILogger<AuthController> logger, 
    JWTGenerate jWT, 
    IConfiguration configuration, 
    AuthRepository repository,
    NotificationEmail email
    )
    {
        _authServices = authServices;
        _logger = logger;
        _jwt = jWT;
        _configuration = configuration;
        _repository = repository;
        _email = email;
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> Login([FromBody] LoginDTO dto)
    {
        try
        {
            if (!ValitadionHelpers.IsValidEmail(dto.Email))
            {
                return BadRequest(new { message = "El correo electrónico proporcionado no es válido." });
            }

            if (!ValitadionHelpers.IsValidPassword(dto.Password))
            {
                return BadRequest(new { message = "La contraseña debe tener al menos 8 caracteres, un número y un carácter especial (_ . -)." });
            }

            var result = await _authServices.Login(dto);

            if (result == null)
            {
                return Unauthorized(new { message = "Credenciales inválidas" });
            }
            
            var token = _jwt.GenerateJWT(result);

            var email = _email.SendWelcomeEmailAsync(result.Email);

            return StatusCode(StatusCodes.Status200OK, new
            {
                isSuccess = true,
                token = token
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al procesar el login.");
            return StatusCode(500, new { message = "Error interno del servidor" });
        }
    }

    [HttpPost("google")]
    public async Task<IActionResult> LoginGoogle([FromBody] GoogleDTO tokenDto)
    {
        try 
        { 
        
            var payload = await GoogleJsonWebSignature.ValidateAsync(tokenDto.Token, new GoogleJsonWebSignature.ValidationSettings
            {
                Audience = new[] { _configuration["Google:ClientId"] }
            });

            var user = await _repository.GetByEmail(payload.Email);

            if(user == null)
            {
                return NotFound(new
                {
                    isSuccess = false,
                    message = "El usuario no existe"
                });
            }

            _email.SendWelcomeEmailAsync(user.Email);

            var dto = new LoginDTO
            {
                Email = user.Email,
                Password = user.Password
            };

            var token = await _jwt.GenerateJWT(dto);

            return Ok(new { isSuccess = true, token });
        }
        catch(Exception ex)
        {
            _logger.LogWarning(ex, "Error en login con google");
            return BadRequest(new
            {
                isSuccess = false,
                message = ex.Message
            });
        }
    } 
}

using Microsoft.AspNetCore.Mvc;
using Business.Services;
using Utilities;
using Entity.DTOs.Write;
using Entity.Enums;
using Utilities.Helpers;
using Business.JWT;
using Entity.Model;

namespace Web.Controllers;

[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
public class AuthController : ControllerBase
{
    private readonly AuthServices _authServices;
    private readonly ILogger<AuthController> _logger;
    private readonly JWTGenerate _jwt;

    public AuthController(AuthServices authServices, ILogger<AuthController> logger, JWTGenerate jWT)
    {
        _authServices = authServices;
        _logger = logger;
        _jwt = jWT;
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

            var rol = await _authServices.getRolUserWithId(result.Id);
            var token = _jwt.GenerateJWT(result, rol.RolName);

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
}

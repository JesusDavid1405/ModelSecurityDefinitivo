using AutoMapper;
using Data.Repository;
using Entity.DTOs.Read;
using Entity.DTOs.Write;
using Entity.Model;
using Microsoft.Extensions.Logging;

namespace Business.Services;

public class AuthServices
{
    private readonly AuthRepository _AuthRepository;
    private readonly UserRepository _userRepository;
    private readonly ILogger<AuthServices> _logger;
    private readonly IMapper _mapper;

    public AuthServices(AuthRepository AuthRepository, ILogger<AuthServices> logger, IMapper mapper, UserRepository userRepository)
    {
        _AuthRepository = AuthRepository;
        _logger = logger; 
        _mapper = mapper;
        _userRepository = userRepository;
    }

    async public Task<User> Login(LoginDTO loginDTO)
    {
        try
        {
            var exists = await _AuthRepository.Login(loginDTO.Email, loginDTO.Password);

            var user = _mapper.Map<User>(exists);
            return user;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al validar las credenciales");
            throw;
        }
    }

   public async Task<RolUserDTO> getRolUserWithId(int id)
   {
       try
       {
           var result = await _AuthRepository.getRolUserWithId(id);
           var rolUser = _mapper.Map<RolUserDTO>(result);
           return rolUser;
       }
       catch (Exception ex)
       {
           // Loguear o manejar el error adecuadamente
           throw new Exception("Error al obtener el rol del usuario", ex);
       }
   }

}

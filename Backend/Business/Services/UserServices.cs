using AutoMapper;
using Business.Core;
using Data.Core;
using Data.Repository;
using Entity.DTOs.Read;
using Entity.DTOs.Write;
using Entity.Model;
using Microsoft.Extensions.Logging;

namespace Business.Services;

public class UserServices : ServiceBase<UserDTO, User>
{
    private readonly UserRepository _user;
    private readonly ILogger<UserServices> _logger;
    private readonly IMapper _mapper;

    public UserServices(DataBase<User> data, UserRepository user,ILogger<UserServices> logger,IMapper mapper)
        :base(data, logger,mapper)
    {
        _user = user;
        _logger = logger;
        _mapper = mapper;
    }

    public override async Task<IEnumerable<UserDTO>> GetAll()
    {
        try
        {
            var entities = await _user.GetAll();
            return _mapper.Map<IEnumerable<UserDTO>>(entities);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener todos los registros de {Entity}", typeof(User).Name);
            throw;
        }
    }

    public override async Task<UserDTO?> getById(int id)
    {
        try
        {
            var entities = await _user.GetById(id);
            return _mapper.Map<UserDTO>(entities);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener el registro con ID {Id} de {Entity}", id, typeof(User).Name);
            throw;
        }
    }

    public async Task<UserWriteDTO> Create(UserWriteDTO dto)
    {
        try
        {
            var entity = _mapper.Map<User>(dto);
            var entities = await _user.Add(entity);
            return _mapper.Map<UserWriteDTO>(entities);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al crear entidad {Entity}", typeof(User).Name);
            throw;
        }
    }
    
    public async Task<UserWriteDTO> Update(UserWriteDTO dto)
    {
        try
        {
            var entity = _mapper.Map<User>(dto);
            var entities = await _user.Update(entity);
            return _mapper.Map<UserWriteDTO>(entities);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al actualizar entidad {Entity}", typeof(User).Name);
            throw;
        }
    }

}

using AutoMapper;
using Business.Core;
using Data.Core;
using Data.Repository;
using Entity.DTOs.Read;
using Entity.DTOs.Write;
using Entity.Model;
using Microsoft.Extensions.Logging;

namespace Business.Services;

public class RolFormPermissionServices : ServiceBase<RolFormPermissionDTO, RolFormPermission>
{
    private readonly RolFormPermissionRepository _rolFormPermission;
    private readonly ILogger<RolFormPermissionServices> _logger;
    private readonly IMapper _mapper;

    public RolFormPermissionServices(DataBase<RolFormPermission> data, RolFormPermissionRepository rolFormPermission,ILogger<RolFormPermissionServices> logger,IMapper mapper)
        :base(data, logger,mapper)
    {
        _rolFormPermission = rolFormPermission;
        _logger = logger;
        _mapper = mapper;
    }

    public override async Task<IEnumerable<RolFormPermissionDTO>> GetAll()
    {
        try
        {
            var entities = await _rolFormPermission.GetAll();
            return _mapper.Map<IEnumerable<RolFormPermissionDTO>>(entities);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener todos los registros de {Entity}", typeof(RolFormPermission).Name);
            throw;
        }
    }

    public override async Task<RolFormPermissionDTO?> getById(int id)
    {
        try
        {
            var entities = await _rolFormPermission.GetById(id);
            return _mapper.Map<RolFormPermissionDTO>(entities);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener el registro con ID {Id} de {Entity}", id, typeof(RolFormPermission).Name);
            throw;
        }
    }

    public async Task<RolFormPermissionWriteDTO> Create(RolFormPermissionWriteDTO dto)
    {
        try
        {
            var entity = _mapper.Map<RolFormPermission>(dto);
            var entities = await _rolFormPermission.Add(entity);
            return _mapper.Map<RolFormPermissionWriteDTO>(entities);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al crear entidad {Entity}", typeof(RolFormPermission).Name);
            throw;
        }
    }
    
    public async Task<RolFormPermissionWriteDTO> Update(RolFormPermissionWriteDTO dto)
    {
        try
        {
            var entity = _mapper.Map<RolFormPermission>(dto);
            var entities = await _rolFormPermission.Update(entity);
            return _mapper.Map<RolFormPermissionWriteDTO>(entities);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al actualizar entidad {Entity}", typeof(RolFormPermission).Name);
            throw;
        }
    }

}

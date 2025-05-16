using AutoMapper;
using Data.Core;
using Entity.Enums;
using Microsoft.Extensions.Logging;

namespace Business.Core;

public class ServiceBase<TDto, TEntity> where TEntity : class
{
    private readonly DataBase<TEntity> _data;
    private readonly ILogger _logger;
    private readonly IMapper _mapper;

    public ServiceBase(DataBase<TEntity> data, ILogger logger, IMapper mapper)
    {
        _data = data;
        _logger = logger;
        _mapper = mapper;
    }

    public virtual async Task<IEnumerable<TDto>> GetAll()
    {
        try
        {
            var entities = await _data.GetAll();
            return _mapper.Map<IEnumerable<TDto>>(entities);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener todos los registros de {Entity}", typeof(TEntity).Name);
            throw;
        }
    }

    public virtual async Task<TDto?> getById(int id)
    {
        try
        {
            var entities = await _data.GetById(id);
            return _mapper.Map<TDto>(entities);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener el registro con ID {Id} de {Entity}", id, typeof(TEntity).Name);
            throw;
        }
    }

    public virtual async Task<TDto> Create(TDto dto)
    {
        try
        {
            var entity = _mapper.Map<TEntity>(dto);
            var entities = await _data.Add(entity);
            return _mapper.Map<TDto>(entities);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al crear entidad {Entity}", typeof(TEntity).Name);
            throw;
        }
    }
    
    public virtual async Task<bool> Update(TDto dto)
    {
        try
        {
            var entity = _mapper.Map<TEntity>(dto);
            var entities = await _data.Update(entity);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al actualizar entidad {Entity}", typeof(TEntity).Name);
            throw;
        }
    }


    /// <summary>
    /// Aqui esta des-eliminando la entidad T, cambiando la propiedad IsDeleted de true a false
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Retorna en caso de que todo este bien true, y si falla lanza una exception</returns>
    public virtual async Task<bool> Reactivate(int id)
    {
        try
        {
            return await _data.Reactivate(id); 
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al Des-Elimnar el registro con ID {Id} de {Entity}", id, typeof(TEntity).Name);
            throw;
        }
    }
}

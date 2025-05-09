using AutoMapper;
using Business.Core;
using Data.Core;
using Data.Repository;
using Entity.DTOs.Read;
using Entity.Model;
using Microsoft.Extensions.Logging;

namespace Business.Services;

public class PermissionServices : ServiceBase<PermissionDTO, Permission>
{
    private readonly PermissionRepository _permission;
    private readonly ILogger<PermissionServices> _logger;
    private readonly IMapper _mapper;

    public PermissionServices(DataBase<Permission> data, PermissionRepository permission,ILogger<PermissionServices> logger,IMapper mapper)
        :base(data, logger,mapper)
    {
        _permission = permission;
        _logger = logger;
        _mapper = mapper;
    }

}

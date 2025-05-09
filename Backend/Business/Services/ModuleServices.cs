using AutoMapper;
using Business.Core;
using Data.Core;
using Data.Repository;
using Entity.DTOs.Read;
using Entity.Model;
using Microsoft.Extensions.Logging;

namespace Business.Services;

public class ModuleServices : ServiceBase<ModuleDTO, Module>
{
    private readonly ModuleRepository _module;
    private readonly ILogger<ModuleServices> _logger;
    private readonly IMapper _mapper;

    public ModuleServices(DataBase<Module> data, ModuleRepository module,ILogger<ModuleServices> logger,IMapper mapper)
        :base(data, logger,mapper)
    {
        _module = module;
        _logger = logger;
        _mapper = mapper;
    }

}


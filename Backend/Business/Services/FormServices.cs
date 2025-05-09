using AutoMapper;
using Business.Core;
using Data.Core;
using Data.Repository;
using Entity.DTOs.Read;
using Entity.Model;
using Microsoft.Extensions.Logging;

namespace Business.Services;

public class FormServices : ServiceBase<FormDTO, Form>
{
    private readonly FormRepository _form;
    private readonly ILogger<FormServices> _logger;
    private readonly IMapper _mapper;

    public FormServices(DataBase<Form> data, FormRepository form,ILogger<FormServices> logger,IMapper mapper)
        :base(data, logger,mapper)
    {
        _form = form;
        _logger = logger;
        _mapper = mapper;
    }

}

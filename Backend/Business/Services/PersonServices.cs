using AutoMapper;
using Business.Core;
using Data.Core;
using Data.Repository;
using Entity.DTOs.Read;
using Entity.Model;
using Microsoft.Extensions.Logging;

namespace Business.Services;

public class PersonServices : ServiceBase<PersonDTO, Person>
{
    private readonly PersonRepository _persona;
    private readonly ILogger<PersonServices> _logger;
    private readonly IMapper _mapper;

    public PersonServices(DataBase<Person> data, PersonRepository persona,ILogger<PersonServices> logger,IMapper mapper)
        :base(data, logger,mapper)
    {
        _persona = persona;
        _logger = logger;
        _mapper = mapper;
    }

}

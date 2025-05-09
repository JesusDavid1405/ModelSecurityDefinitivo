using Data.Core;
using Entity.Model;
using Entity.Context;

namespace Data.Repository;

public class PersonRepository : DataBase<Person>
{
    public PersonRepository(ApplicationDbContext context)
    : base(context) {}

}

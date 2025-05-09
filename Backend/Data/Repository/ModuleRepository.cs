using Data.Core;
using Entity.Context;
using Entity.Model;

namespace Data.Repository;

public class ModuleRepository : DataBase<Module>
{

    public ModuleRepository(ApplicationDbContext context)
    : base(context) {}

}

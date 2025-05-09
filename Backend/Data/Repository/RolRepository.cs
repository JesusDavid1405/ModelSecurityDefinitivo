using Data.Core;
using Entity.Context;
using Entity.Model;

namespace Data.Repository;

public class RolRepository : DataBase<Rol>
{
    public RolRepository(ApplicationDbContext context)
    : base(context) {}
}

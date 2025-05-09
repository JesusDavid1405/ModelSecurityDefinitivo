using Data.Core;
using Entity.Model;
using Entity.Context;

namespace Data.Repository;

public class PermissionRepository : DataBase<Permission>
{
    public PermissionRepository(ApplicationDbContext context)
    : base(context) {}
}

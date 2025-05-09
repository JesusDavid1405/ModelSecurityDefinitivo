using Data.Core;
using Entity.Context;
using Entity.Model;

namespace Data.Repository;

public class FormRepository : DataBase<Form>
{
    public FormRepository(ApplicationDbContext context)
    : base(context) {}

}

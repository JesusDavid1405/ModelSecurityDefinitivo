using Data.Core;
using Entity.Context;
using Entity.Model;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository;

public class UserRepository : DataBase<User>
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
        : base(context) 
    {
        _context = context;
    }

    public override async Task<IEnumerable<User>> GetAll()
    {
        return await _context.Set<User>()
                        .Where(u => !u.IsDeleted)
                        .Include(u => u.Person)
                        .ToListAsync();   
    }

    public override async Task<User?> GetById(int id)
    {
        return await _context.Set<User>()
                        .Where(u => !u.IsDeleted)
                        .Include(u => u.Person)
                        .FirstOrDefaultAsync(u => u.Id == id);
    }
}

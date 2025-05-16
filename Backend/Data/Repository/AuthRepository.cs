using Data.Interface;
using Entity.Context;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data.Repository;

public class AuthRepository : IAuthRepository
{
    private readonly ILogger<AuthRepository> _logger;  
    private readonly ApplicationDbContext _context;

    public AuthRepository(ILogger<AuthRepository> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

   // En el Repository:
    public async Task<User?> Login(string email, string password)
    {
        try
        {
            var user = await _context.Set<User>()
                .FirstOrDefaultAsync(u =>
                    u.Email == email &&
                    u.Password == password &&
                    u.Active);

            return user;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al intentar validar las credenciales para el email {email}", email);
            throw;
        }
    }

    public async Task<RolUser> getRolUserWithId(int id)
    {
        var rolUser = await _context.RolUser
            .Include(r => r.Rol)
            .Where(r => r.UserId == id && !r.IsDeleted)
            .FirstOrDefaultAsync();

        return rolUser;

    }

    public async Task<User?> GetByEmail(string email)
    {
        try
        {
            return await _context.Set<User>()
                .FirstOrDefaultAsync(u => u.Email == email); // o sin el IsDeleted si no lo usas
        }
        catch (Exception ex)
        {
            // Aquí puedes loguear el error si tienes un ILogger
            throw new Exception("Error al buscar el usuario por email", ex);
        }
    }

}

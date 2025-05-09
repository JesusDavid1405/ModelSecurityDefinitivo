using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Entity.Context;

public class ApplicationDbContext : DbContext
{
    protected readonly IConfiguration _configuration;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration) 
        : base(options)
    {
        _configuration = configuration;
    }

    public DbSet<Person> Person { get; set; }
    public DbSet<Form> Form { get; set; }
    public DbSet<Rol> Rol { get; set; }
    public DbSet<Permission> Permission { get; set; }
    public DbSet<Module> Module { get; set; }
    public DbSet<RolUser> RolUser { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<FormModule> FormModule { get; set; }
    public DbSet<RolFormPermission> RolFormPermission { get; set; }

}

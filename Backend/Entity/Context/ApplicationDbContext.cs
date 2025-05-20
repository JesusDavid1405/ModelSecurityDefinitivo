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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Rol>().ToTable("Rol", schema: "seguridad");
        modelBuilder.Entity<Module>().ToTable("Module", schema: "seguridad");
        modelBuilder.Entity<Permission>().ToTable("Permission", schema: "seguridad");
        modelBuilder.Entity<Form>().ToTable("Form", schema: "seguridad");
        modelBuilder.Entity<Person>().ToTable("Person", schema: "seguridad");
        modelBuilder.Entity<User>().ToTable("User", schema: "seguridad");
        modelBuilder.Entity<RolUser>().ToTable("RolUser", schema: "seguridad");
        modelBuilder.Entity<FormModule>().ToTable("FormModule", schema: "seguridad");
        modelBuilder.Entity<RolFormPermission>().ToTable("RolFormPermission", schema: "seguridad");
    }

}

using Entity.Context;
using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DataInit
{
    public class DataInit
    {
        private readonly ApplicationDbContext _context;

        public DataInit(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Initialize()
        {
            if (!_context.Rol.Any())
            {
                var Roles = new[]
                {
                    new Rol {Name = "Administrador", Description = "Rol con todos los permisos del sistema"},
                };
                await _context.Rol.AddRangeAsync(Roles);
            }

            if (!_context.Module.Any())
            {
                var Modules = new[]
                {
                    new Module {Name = "User", Description = "Entorno de user"},
                    new Module {Name = "Module", Description = "Entorno de Module"},
                };
                await _context.Module.AddRangeAsync(Modules);
            }

            if (_context.Person.Any())
            {
                var Persons = new[]
                {
                    new Person
                    {
                        Name = "Juan",
                        LastName = "Pérez",
                        TypeDocument = "DNI",
                        DocumentNumber = "12345678",
                        Phone = "123-456-7890",
                        Address = "Calle Falsa 123",
                        IsDeleted = false
                    }
                };

                await _context.Person.AddRangeAsync(Persons);
            }

            if (!_context.User.Any())
            {
                var usuarios = new[]
                {
                    new User {Email = "juan@ejemplo.com", 
                        Password = "juan1234_", 
                        CreatedDate = DateTime.UtcNow, 
                        Active = true, 
                        IsDeleted = false
                    },
                };

                await _context.User.AddRangeAsync(usuarios);
            }
            
        }
    }
}

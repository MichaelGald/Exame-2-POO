using Examen_2_de_POO.Databases.Entities;
using Microsoft.EntityFrameworkCore;

namespace Examen_2_de_POO.Databases
{
    public class ContextClientes :DbContext
    {
     
        public ContextClientes(DbContextOptions options)
              : base(options)
        {
        }

        public DbSet<ClienteEntity> Clientes { get; set; }
        public DbSet<PlanamortizacionEntity> PlanamortizacionEntities { get; set; }
    }
}
    

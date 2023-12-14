using ApiGateway.SQLServer.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiGateway.SQLServer.Models
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<Producto> Productos { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Venta> Ventas { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;

namespace Prueba.Modelos.Datos
{
    public class DemoContext : DbContext
    {
        
            public DemoContext(DbContextOptions<DemoContext> options) : base(options)
            {
            }
            public DbSet<Producto> Productos { get; set; }
        
    }
}

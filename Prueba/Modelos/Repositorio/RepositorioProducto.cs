using Microsoft.EntityFrameworkCore;
using Prueba.Modelos.Datos;

namespace Prueba.Modelos.Repositorio
{
        public class RepositorioProducto : IRepositorioProducto
        {
        protected readonly DemoContext _context;
        public RepositorioProducto(DemoContext context) => _context = context;

        public IEnumerable<Producto> GetProductos()
        {
            return _context.Productos.ToList();
        }

        public Producto GetProductoById(int id)
        {
            return _context.Productos.Find(id);
            
        }
        public async Task<Producto> CreateProductoAsync(Producto producto)
        {
            await _context.Set<Producto>().AddAsync(producto);
            await _context.SaveChangesAsync();
            return producto;
        }

        public async Task<bool> UpdateProductoAsync(Producto producto)
        {
            _context.Entry(producto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProductoAsync(Producto producto)
        {
            
            if (producto is null)
            {
                return false;
            }
            _context.Set<Producto>().Remove(producto);
            await _context.SaveChangesAsync();

            return true;
        }
    }
    
}

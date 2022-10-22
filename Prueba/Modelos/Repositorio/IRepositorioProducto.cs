using Prueba.Modelos.Datos;

namespace Prueba.Modelos.Repositorio
{
    public interface IRepositorioProducto
    {
        
        Task<Producto> CreateProductoAsync(Producto producto);
        Task<bool> DeleteProductoAsync(Producto producto);
        Producto GetProductoById(int id);
        IEnumerable<Producto> GetProductos();
        Task<bool> UpdateProductoAsync(Producto producto);
    }
}

using Microsoft.AspNetCore.Mvc;
using Prueba.Modelos.Repositorio;
using Prueba.Modelos.Datos;
using Microsoft.AspNetCore.Cors;

namespace Prueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
       
        public class ProductoController : ControllerBase
        {
            private IRepositorioProducto _repositorioProducto;

            public ProductoController(IRepositorioProducto repositorioProducto)
            {
                _repositorioProducto = repositorioProducto;
            }

            [HttpGet]
            [ActionName(nameof(GetProductsAsync))]
            public IEnumerable<Producto> GetProductsAsync()
            {
                return _repositorioProducto.GetProductos();
            }

            [HttpGet("{id}")]
            [ActionName(nameof(GetProductoById))]
            public ActionResult<Producto> GetProductoById(int id)
            {
                var productByID = _repositorioProducto.GetProductoById(id);
                if (productByID == null)
                {
                    return NotFound();
                }
                return productByID;
            }

            [HttpPost]
            
        [ActionName(nameof(CreateProductoAsync))]
            public async Task<ActionResult<Producto>> CreateProductoAsync(Producto producto)
            {
                await _repositorioProducto.CreateProductoAsync(producto);
                return CreatedAtAction(nameof(GetProductoById), new { id = producto.Id }, producto);
            }

            [HttpPut("{id}")]
            [ActionName(nameof(UpdateProducto))]
            public async Task<ActionResult> UpdateProducto(int id, Producto producto)
            {
                if (id != producto.Id)
                {
                    return BadRequest();
                }

                await _repositorioProducto.UpdateProductoAsync(producto);

                return NoContent();

            }

            [HttpDelete("{id}")]
            [ActionName(nameof(DeleteProducto))]
            public async Task<IActionResult> DeleteProducto(int id)
            {
                var producto = _repositorioProducto.GetProductoById(id);
                if (producto == null)
                {
                    return NotFound();
                }

                await _repositorioProducto.DeleteProductoAsync(producto);

                return NoContent();
            }


        }
    
}
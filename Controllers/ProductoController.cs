using Microsoft.AspNetCore.Mvc;
using MoreLinq;
using SistemaKPI_API.Context;
using SistemaKPI_API.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaKPI_API.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/[controller]")]
    public class ProductoController
    {
        private readonly SistemaKPIContext _context;
        private readonly ContpaqContext _contpaqContext;

        public ProductoController(SistemaKPIContext ctx, ContpaqContext ctxContpaq)
        {
            _context = ctx;
            _contpaqContext = ctxContpaq;
        }
        [HttpGet]
        public ActionResult GetAllProductos()
        {
            return new OkObjectResult(_context.Productos.ToList());
        }

        [HttpGet("{idProducto}")]
        public IActionResult GetProducto([FromRoute] Guid IdProducto)
        {
            // Obtiene el producto desde el contexto.
            var producto = _context.Productos.FirstOrDefault(p => p.IdProducto == IdProducto);

            // Regresa el producto si lo encuentra, si no regresa NotFound.
            if (producto == null) return new NotFoundResult();

            return new OkObjectResult(producto);
        }

        [HttpGet]
        [Route("GetContpaqProducts")]
        public IActionResult GetContpaq()
        {
            var productosInventario = _contpaqContext.ProductosInventario
                .DistinctBy(i => i.CodigoProducto)
                .ToList();

            return new OkObjectResult(productosInventario);
        }

        [HttpPost]
        public async Task<IActionResult> AgregarProducto([FromBody] Producto producto)
        {
            // Flujo nuevo producto.
            if (producto.IdProducto == Guid.Empty)
            {
                // Se añade el producto al contexto.
                await _context.Productos.AddAsync(producto);
            }
            // Flujo editar producto.
            else
            {
                // Obtiene el producto desde el contexto.
                var prodbd = _context.Productos.FirstOrDefault(p => p.IdProducto == producto.IdProducto);

                // Proceso de mapeo (puedes usar AutoMapper)
                prodbd.Descripcion = producto.Descripcion;
                producto.Precio = producto.Precio;
            }

            // Se guarda el estado del contexto para reflejar cambios.
            await _context.SaveChangesAsync();

            // Regresa un código de status 200 (OK) con un mensaje dentro del body.
            return new OkObjectResult(producto);
        }

        [HttpDelete("{idProducto}")]
        public IActionResult DeleteProducto([FromRoute] Guid IdProducto)
        {
            // Obtiene el producto desde el contexto.
            var producto = _context.Productos.FirstOrDefault(p => p.IdProducto == IdProducto);

            // Elimina si lo encuentra, si no regresa NotFound.
            if (producto == null) return new NotFoundResult();

            _context.Productos.Remove(producto);

            // Regresa un código de status 200 (OK) sin mensaje dentro del body.
            return new OkResult();
        }
    }
}

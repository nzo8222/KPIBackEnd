using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoreLinq;
using SistemaKPI_API.Context;
using SistemaKPI_API.Entities;
using SistemaKPI_API.Models;
using SistemaKPI_API.DTOs;
using System;
using System.Collections.Generic;
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
        [Route("GetContpaqProducts")]
        public IActionResult GetContpaq()
        {
            var productosInventario = _contpaqContext.ProductosInventario
                 .DistinctBy(i => i.CodigoProducto)
                 .ToList();

            return new OkObjectResult(productosInventario);
            //ProductoInventarioContpaq productoPrueba =  new ProductoInventarioContpaq();
            //productoPrueba.CodigoProducto = "1234";
            //productoPrueba.NombreProducto = "Nombre prueba";
            //productoPrueba.RazonSocial = "Razon prueba";
            //return new OkObjectResult(productoPrueba);
        }

        [HttpPost]
        [Route("PostProducto")]
        public IActionResult PostProducto([FromBody] ProductoDTOConCliente productoDTOConCliente)
        {
            //Se obtiene la lista de todos los productos
            var productos = _context.Productos.ToList();
            //Se itera la lista de productos
            foreach(var prod in productos)
            {
                //Si encuentra un producto con el mismo nombre del
                //producto que se intenta agregar marca error
                if(prod.NombreProducto == productoDTOConCliente.NombreProducto)
                {
                    //Manda notificacion al usuario
                    return new OkObjectResult(new RespuetaServidor
                    { Exitoso = false, MensajeError = "Ya existe un producto con ese nombre" });
                }
                //Si encuentra un producto con el mismo codigo
                //marca error y notifica al usuario
                if (prod.CodigoProducto == productoDTOConCliente.CodigoProducto)
                {
                    //Manda notificacion al usuario
                    return new OkObjectResult(new RespuetaServidor
                    { Exitoso = false, MensajeError = "Ya existe un producto con ese codigo" });
                }
            }
            //Si no existe un producto con el nombre y codigo especificado
            //Inicializa un objeto producto 
            Producto producto = new Producto();
            //Asigna los atributos del DTO al producto inicializado
            producto.CodigoProducto = productoDTOConCliente.CodigoProducto;
            producto.NombreProducto = productoDTOConCliente.NombreProducto;
            //Le asigna el cliente
            producto.Cliente = _context.Clientes
                .FirstOrDefault(c => c.IdCliente == productoDTOConCliente.idCliente);
            //Intenta añadirlo a la base de datos
            try
            {
                
                _context.Productos.Add(producto);
                _context.SaveChanges();
            }
            //Si hay un error notifica al usuario
            catch(Exception ex)
            {
                return new OkObjectResult(new RespuetaServidor
                { Exitoso = false, MensajeError = ex.Message });
            }
            //Si fue exitoso notifica al usuario
            return new OkObjectResult(new RespuetaServidor
            { Exitoso = true, MensajeError = string.Empty });
        }

        [HttpPost]
        [Route("PutProductoPedido")]
        public async Task<IActionResult> ModificarProductoPedido([FromBody] ProductoInventarioDTO productoPedidoDTO)
        {
            //var prodBD = _context.ProductosInventario.FirstOrDefault(p => p.IdProductoInventario == productoPedidoDTO.IdProductoInventario);
            //if (prodBD != null)
            //{
            //    prodBD.CodigoProducto = productoPedidoDTO.CodigoProducto;
            //    prodBD.NombreProducto = productoPedidoDTO.NombreProducto;
            //    prodBD.RazonSocial = productoPedidoDTO.RazonSocial;
            //    prodBD.CantidadBolsas = productoPedidoDTO.CantidadBolsas;
            //    prodBD.Cumplimiento = productoPedidoDTO.Cumplimiento;
            //    prodBD.Devoluciones = productoPedidoDTO.Devoluciones;

            //    _context.ProductosInventario.Update(prodBD);
            //}
            //else
            //{
            //    return new OkObjectResult(new RespuetaServidor
            //    { Exitoso = false, MensajeError = "No se encontro el producto" });
            //    //return new OkObjectResult("No se encontro el producto");
            //}
            // Proceso de mapeo (puedes usar AutoMapper)

            //}
            CalcularKPIAlmacenCumplimiento();
            // Se guarda el estado del contexto para reflejar cambios.
            await _context.SaveChangesAsync();

            // Regresa un código de status 200 (OK) con un mensaje dentro del body.
            return new OkObjectResult(new RespuetaServidor
            { Exitoso = true, MensajeError = string.Empty });
            //return new OkObjectResult(prodBD);
        }
        //Metodo para obtener los productos con el ID del cliente especificado
        [HttpGet("{id}")]
        [Route("{id:guid}")]
        public IActionResult GetProductosPorID(Guid id)
        {
           
            //Se obtienen todos los productos de la BD
            var productos = _context
                .Productos
                .Include(p => p.Cliente)
                .ToList();
            //Se instancia una lista de productos
            var productosDelMismoCliente = new List<Producto>();
            //Se Itera la lista de productos de la BD
            foreach (var producto in productos)
            {
                //Si el producto tiene cliente se guarda el id para compararla
                //con el id que se dio en la ruta
                if (producto.Cliente != null)
                {


                    //se compara el id del producto con el id de la ruta
                    if (id == producto.Cliente.IdCliente)
                    {
                        //si coincide se guarda
                        productosDelMismoCliente.Add(producto);
                    }
                }
            }
            //si no se encontro ningun producto se regresa un mensaje
            if(productosDelMismoCliente.Count == 0)
            {
                //mensaje
                return new OkObjectResult("No hay productos.");
            }
            //se regresa una lista con los productos del mismo cliente
            return new OkObjectResult(productosDelMismoCliente);
        }

        private void CalcularKPIAlmacenCumplimiento()
        {
            //var pedidos = _context.PedidosCliente.Include(p => p.ProductosContpaq).ToArray();

            //double cumplimiento = 0.0;
            //foreach (var productoPedido in pedidos)
            //{
            //    foreach (var producto in productoPedido.ProductosContpaq)
            //    {
            //        // Obtiene todos los movimientos.
            //        var movimientos = _context.MovimientosAlmacen.ToArray();

            //        var movimientoAlmacen = _context.MovimientosAlmacen.Where(a => a.CodigoProducto == producto.CodigoProducto
            //        && a.TipoMovimiento == "Salida"
            //        && a.FechaMovimiento >= productoPedido.FechaRegistro
            //        && a.FechaMovimiento <= productoPedido.FechaEntrega).FirstOrDefault();

            //        // Si no se encuentra un movimiento en esa fecha continua.
            //        if (movimientoAlmacen == null) continue;

            //        // Si ya fue calculado no lo vuelvas a calcular.
            //        //if (producto.Cumplimiento == null) return Convert.ToDouble(producto.Cumplimiento);

            //        var parsedNumeroBolsasMovimiento = Convert.ToInt32(movimientoAlmacen.NumBolsas);
            //        var parsedNumberobolsasProducto = Convert.ToInt32(producto.CantidadBolsas);
            //        var parsedNumerobolsasDevuelto = 0;
            //        if (producto.Devoluciones!=null)
            //        {
            //            parsedNumerobolsasDevuelto = Convert.ToInt32(producto.Devoluciones);
            //        }
                    
            //        var diferenciaBolsas = parsedNumberobolsasProducto - parsedNumeroBolsasMovimiento;

            //        cumplimiento = ( (parsedNumeroBolsasMovimiento - parsedNumerobolsasDevuelto) * 100 / parsedNumberobolsasProducto) * .01;

            //        producto.Cumplimiento = cumplimiento.ToString();
            //        _context.SaveChanges();
            //    }
            //}

            //return cumplimiento;
        }
    }
}

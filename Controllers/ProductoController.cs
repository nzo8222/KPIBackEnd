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
        }

       
        [HttpPost]
        [Route("PutProductoPedido")]
        public async Task<IActionResult> ModificarProductoPedido([FromBody] ProductoInventarioDTO productoPedidoDTO)
        {
            var prodBD = _context.ProductosInventario.FirstOrDefault(p => p.IdProductoInventario == productoPedidoDTO.IdProductoInventario);
            if (prodBD != null)
            {
                prodBD.CodigoProducto = productoPedidoDTO.CodigoProducto;
                prodBD.NombreProducto = productoPedidoDTO.NombreProducto;
                prodBD.RazonSocial = productoPedidoDTO.RazonSocial;
                prodBD.CantidadBolsas = productoPedidoDTO.CantidadBolsas;
                prodBD.Cumplimiento = productoPedidoDTO.Cumplimiento;
                prodBD.Devoluciones = productoPedidoDTO.Devoluciones;

                _context.ProductosInventario.Update(prodBD);
            }
            else
            {
                return new OkObjectResult("No se encontro el producto");
            }
            // Proceso de mapeo (puedes usar AutoMapper)

            //}
            CalcularKPIAlmacenCumplimiento();
            // Se guarda el estado del contexto para reflejar cambios.
            await _context.SaveChangesAsync();

            // Regresa un código de status 200 (OK) con un mensaje dentro del body.
            return new OkObjectResult(prodBD);
        }
       

        private void CalcularKPIAlmacenCumplimiento()
        {
            var pedidos = _context.PedidosCliente.Include(p => p.ProductosContpaq).ToArray();

            double cumplimiento = 0.0;
            foreach (var productoPedido in pedidos)
            {
                foreach (var producto in productoPedido.ProductosContpaq)
                {
                    // Obtiene todos los movimientos.
                    var movimientos = _context.MovimientosAlmacen.ToArray();

                    var movimientoAlmacen = _context.MovimientosAlmacen.Where(a => a.CodigoProducto == producto.CodigoProducto
                    && a.TipoMovimiento == "Salida"
                    && a.FechaMovimiento >= productoPedido.FechaRegistro
                    && a.FechaMovimiento <= productoPedido.FechaEntrega).FirstOrDefault();

                    // Si no se encuentra un movimiento en esa fecha continua.
                    if (movimientoAlmacen == null) continue;

                    // Si ya fue calculado no lo vuelvas a calcular.
                    //if (producto.Cumplimiento == null) return Convert.ToDouble(producto.Cumplimiento);

                    var parsedNumeroBolsasMovimiento = Convert.ToInt32(movimientoAlmacen.NumBolsas);
                    var parsedNumberobolsasProducto = Convert.ToInt32(producto.CantidadBolsas);
                    var parsedNumerobolsasDevuelto = 0;
                    if (producto.Devoluciones!=null)
                    {
                        parsedNumerobolsasDevuelto = Convert.ToInt32(producto.Devoluciones);
                    }
                    
                    var diferenciaBolsas = parsedNumberobolsasProducto - parsedNumeroBolsasMovimiento;

                    cumplimiento = ( (parsedNumeroBolsasMovimiento - parsedNumerobolsasDevuelto) * 100 / parsedNumberobolsasProducto) * .01;

                    producto.Cumplimiento = cumplimiento.ToString();
                    _context.SaveChanges();
                }
            }

            //return cumplimiento;
        }
    }
}

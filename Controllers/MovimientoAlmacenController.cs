﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using SistemaKPI_API.Context;
using SistemaKPI_API.DTOs;
using SistemaKPI_API.Entities;
using SistemaKPI_API.Models;

namespace SistemaKPI_API.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientoAlmacenController : ControllerBase
    {
        private readonly SistemaKPIContext _context;
        public MovimientoAlmacenController(SistemaKPIContext ctx)
        {
            _context = ctx;
        }
        [HttpDelete("{id}")]
        [Route("DeleteMovimientoAlmacen/{id:guid}")]
        public IActionResult DeleteMovimientoAlmacen(Guid id)
        {
            try
            {
                var movmientobd = _context.MovimientosAlmacen.FirstOrDefault(p => p.IdMovimientoAlmacen == id);
                if (movmientobd != null)
                {
                    _context.MovimientosAlmacen.Remove(movmientobd);
                    _context.SaveChanges();
                }
                else
                {
                    return new OkObjectResult(new RespuestaServidor
                    { Exitoso = false, MensajeError = "No se encontro el Movimiento Almacen en la bd." });
                }
                return new OkObjectResult(new RespuestaServidor
                { Exitoso = true, MensajeError = string.Empty });
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new RespuestaServidor
                { Exitoso = false, MensajeError = ex.Message });
            }
        }
        [HttpGet]
        [Route("GetMovimientosAlmacen")]
        public async Task<IActionResult> GetMovimientosAlmacen()
        {
            try
            {
                var movimientos = await _context.MovimientosAlmacen.ToListAsync();
                if(movimientos != null)
                {
                    return new OkObjectResult(new RespuestaServidor
                    { Exitoso = true, MensajeError = string.Empty, Payload = movimientos });
                }
                else
                {
                    return new OkObjectResult(new RespuestaServidor
                    { Exitoso = false, MensajeError = "No se encontraron movimientos." });
                }
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new RespuestaServidor
                { Exitoso = false, MensajeError = ex.Message });
            }
        }
        [HttpPost]
        [Route("PostMovimiento")]
        public async Task<IActionResult> AgregarMovimiento([FromBody] MovimientoAlmacenDTO movimientoAlmacenDTO)
        {
            //// Flujo nuevo producto.
            //if (movimientoAlmacen.IdMovimientoAlmacen == Guid.Empty)
            //{
            //    // Se añade el producto al contexto.
            MovimientosAlmacen2 movimientoAlmacen = new MovimientosAlmacen2();
            movimientoAlmacen.CodigoProducto = movimientoAlmacenDTO.CodigoProducto;
            movimientoAlmacen.NombreProducto = movimientoAlmacenDTO.NombreProducto;
            movimientoAlmacen.TipoMovimiento = movimientoAlmacenDTO.TipoMovimiento;
            movimientoAlmacen.NumBolsas = movimientoAlmacenDTO.NumBolsas;
            movimientoAlmacen.Turno = movimientoAlmacenDTO.Turno;
            movimientoAlmacen.FechaMovimiento = DateTime.Now;
            movimientoAlmacen.FolioRemision = movimientoAlmacenDTO.FolioRemision;

            try
            {
                await _context.MovimientosAlmacen.AddAsync(movimientoAlmacen);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new RespuestaServidor
                { Exitoso = false, MensajeError = ex.Message });
            }
            CalcularKPIAlmacenCumplimiento(movimientoAlmacen);
            return new OkObjectResult(new RespuestaServidor
            { Exitoso = true, MensajeError = string.Empty }
            );
        }

        [HttpPost]
        [Route("PutMovimientoAlmacen")]
        public async Task<IActionResult> ModificarMovimientoAlmacen([FromBody] MovimientoAlmacenEditDTO movimientoAlmacen)
        {
            try
            {
                var movbd = await _context.MovimientosAlmacen.FirstOrDefaultAsync(p => p.IdMovimientoAlmacen == movimientoAlmacen.IdMovimientoAlmacen);
                if (movbd != null)
                {
                    var producto = await _context.Productos.FirstOrDefaultAsync(p => p.IdProducto == movimientoAlmacen.IdProducto);
                    movbd.CodigoProducto = producto.CodigoProducto.ToString();
                    movbd.NombreProducto = producto.NombreProducto;
                    movbd.TipoMovimiento = movimientoAlmacen.TipoMovimiento;
                    movbd.NumBolsas = movimientoAlmacen.NumBolsas.ToString();
                    movbd.FechaMovimiento = movimientoAlmacen.FechaMovimiento;
                    movbd.Turno = movimientoAlmacen.Turno;
                    _context.MovimientosAlmacen.Update(movbd);
                }
                else
                {
                    return new OkObjectResult(new RespuestaServidor
                    { Exitoso = false, MensajeError = "No se encontro el Movimiento" });
                }
            }
            catch(Exception ex)
            {
                return new OkObjectResult(new RespuestaServidor
                { Exitoso = false, MensajeError = ex.ToString() });
            }
            // Se guarda el estado del contexto para reflejar cambios.
            await _context.SaveChangesAsync();

            // Regresa un código de status 200 (OK) con un mensaje dentro del body.
            return new OkObjectResult(new RespuestaServidor
            { Exitoso = true, MensajeError = string.Empty }
           );
        }
        private void CalcularKPIAlmacenCumplimiento(MovimientosAlmacen2 mov)
        {

            //var pedidos = _context.PedidosCliente.Include(p => p.ProductosContpaq).ToArray();
            var fecha = new DateTime(2019, 04, 28).Date;
            var pedidos = _context.PedidoSemanal
                .Include(pd => pd.LstPedidosDiario)
                .Where(pd => pd.FechaInicioSemana.Date > fecha)
                .ToArray();

            foreach(var pedido in pedidos)
            {
                //foreach (var producto in productoPedido.ProductosContpaq)
                foreach(var producto in pedido.LstPedidosDiario)
                {

                    var prod = _context.PedidoDiario
                        .Include(pd => pd.Producto)
                        .Where(p => p.IdPedidoDiario == producto.IdPedidoDiario).FirstOrDefault();
                    producto.Producto = prod.Producto;
                    var fechaInicioSemana = pedido.FechaInicioSemana.AddDays(producto.NumDia).Date;
                    var fechaMovimiento = mov.FechaMovimiento.Date;
                    if (mov.CodigoProducto == Convert.ToString(producto.Producto.CodigoProducto)
                        && fechaMovimiento == fechaInicioSemana
                        && mov.TipoMovimiento == "Salida")
                    {

                    
                    //var movimientoAlmacen = _context.MovimientosAlmacen
                    //    .Where(a => a.CodigoProducto == Convert.ToString(producto.Producto.CodigoProducto)
                    //    && a.TipoMovimiento == "Salida"
                    //    && a.FechaMovimiento.Date == pedido.FechaInicioSemana.AddDays(producto.NumDia+1).Date
                    //).FirstOrDefault();

                    //// Si no se encuentra un movimiento en esa fecha continua.
                    //if (movimientoAlmacen == null) continue;

                    // Si ya fue calculado no lo vuelvas a calcular.
                    //if (producto.Cumplimiento == null) return Convert.ToDouble(producto.Cumplimiento);

                    var parsedNumeroBolsasMovimiento = Convert.ToInt32(mov.NumBolsas);
                    var parsedNumberobolsasProducto = producto.NumBolsas;
                    var parsedNumerobolsasDevuelto = 0;
                    //if (producto.Devoluciones != null)
                    //{
                    //    parsedNumerobolsasDevuelto = Convert.ToInt32(producto.Devoluciones);
                    //}

                    var diferenciaBolsas = parsedNumberobolsasProducto - parsedNumeroBolsasMovimiento;

                    var cumplimiento = ((parsedNumeroBolsasMovimiento - parsedNumerobolsasDevuelto) * 100 / parsedNumberobolsasProducto) * .01;

                    producto.Cumplimiento = Convert.ToDecimal(cumplimiento);
                    _context.SaveChanges();
                    }
                }
               
            }
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
            //        if (producto.Devoluciones != null)
            //        {
            //            parsedNumerobolsasDevuelto = Convert.ToInt32(producto.Devoluciones);
            //        }

            //        var diferenciaBolsas = parsedNumberobolsasProducto - parsedNumeroBolsasMovimiento;

            //        cumplimiento = ((parsedNumeroBolsasMovimiento - parsedNumerobolsasDevuelto) * 100 / parsedNumberobolsasProducto) * .01;

            //        producto.Cumplimiento = cumplimiento.ToString();
            //        _context.SaveChanges();
            //    }
            //}

            //return cumplimiento;
        }
    }
}
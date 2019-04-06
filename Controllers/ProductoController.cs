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
        //Caga de CSV[HttpGet]
        //public ActionResult GetAllProductos()
        //{
            //using (var reader = new System.IO.StreamReader("C:\\Users\\gonzo\\Documents\\sistemaKPIBackEnd\\reporteDiario.csv"))
            //using (var csv = new CsvReader(reader))
            //{
            //    csv.Configuration.PrepareHeaderForMatch = (string header, int index) => header.ToLower();
            //    csv.Configuration.HasHeaderRecord = false;
            //    var records = csv.GetRecords<ReporteCSVsinID>().ToList();

            //    foreach (var item in records)
            //    {
            //        ReporteDiarioPedidosClienteCSV CSVtoDb = new ReporteDiarioPedidosClienteCSV();
            //        CSVtoDb.CodigoNuevo = item.CodigoNuevo;
            //        CSVtoDb.Cliente = item.Cliente;
            //        CSVtoDb.Capacidad = item.Capacidad;
            //        CSVtoDb.Presentacion = item.Presentacion;
            //        CSVtoDb.NumPzBol = item.NumPzBol;
            //        CSVtoDb.NumBolzXTarima = item.NumBolzXTarima;
            //        CSVtoDb.NumPzXTarima = item.NumPzXTarima;
            //        CSVtoDb.DiaDelMes = item.DiaDelMes;
            //        CSVtoDb.DiaDeSemana = item.DiaDeSemana;
            //        CSVtoDb.SemanaAnual = item.SemanaAnual;
            //        CSVtoDb.NumDeDia = item.NumDeDia;
            //        CSVtoDb.SemanaMes = item.SemanaMes;
            //        CSVtoDb.NombreMes = item.NombreMes;
            //        CSVtoDb.Anho = item.Anho;
            //        CSVtoDb.PedidoPorBolsa = item.PedidoPorBolsa;
            //        CSVtoDb.SurtidoPorBolsa = item.SurtidoPorBolsa;
            //        CSVtoDb.PedidoPorPieza = item.PedidoPorPieza;
            //        CSVtoDb.SurtidoPorPz = item.SurtidoPorPz;
            //        CSVtoDb.PorcentajeCumplimiento = item.PorcentajeCumplimiento;
            //        CSVtoDb.CodigoChofer = item.CodigoChofer;
            //        CSVtoDb.NombreDelChofer = item.NombreDelChofer;
            //        CSVtoDb.NumeroDeCaja = item.NumeroDeCaja;
            //        CSVtoDb.Flete = item.Flete;
            //        CSVtoDb.CodigoCargadores = item.CodigoCargadores;
            //        CSVtoDb.Cargadores = item.Cargadores;
            //        CSVtoDb.TiempoDeCarga = item.TiempoDeCarga;
            //        CSVtoDb.IdPedido = Guid.NewGuid();
            //        _context.ReporteDiarioPedidosClienteCSV.Add(CSVtoDb);
            //        _context.Add(CSVtoDb);
            //    };
            //    _context.SaveChanges();
                //_context.SaveChanges();


                //    using (var reader = new System.IO.StreamReader("C:\\Users\\gonzo\\Documents\\ReporteProduccionCSV.csv"))
                //    using (var csv = new CsvReader(reader))
                //    {
                //        csv.Configuration.PrepareHeaderForMatch = (string header, int index) => header.ToLower();
                //        csv.Configuration.HasHeaderRecord = false;
                //        var records = csv.GetRecords<ReporteProduccionSinID>().ToList();

                //        foreach (var item in records)
                //        {
                //            ReporteProduccion reporteProduccion = new ReporteProduccion();
                //            reporteProduccion.CodigoNuevo = item.CodigoNuevo;
                //            reporteProduccion.Presentacion = item.Presentacion;
                //            reporteProduccion.Dia = item.Dia;
                //            reporteProduccion.Mes = item.Mes;
                //            reporteProduccion.Anho = item.Anho;
                //            reporteProduccion.Semana = item.Semana;
                //            reporteProduccion.Familia = item.Familia;
                //            reporteProduccion.Capacidad = item.Capacidad;
                //            reporteProduccion.Cliente = item.Cliente;
                //            reporteProduccion.Maquina = item.Maquina;
                //            reporteProduccion.TotalDeCavidades = item.TotalDeCavidades;
                //            reporteProduccion.CantidadBolsas = item.CantidadBolsas;
                //            reporteProduccion.CantidadPiezas = item.CantidadPiezas;
                //            reporteProduccion.Turno = item.Turno;
                //            reporteProduccion.Supervisor = item.Supervisor;
                //            reporteProduccion.HRUsadas = item.HRUsadas;
                //            reporteProduccion.MinutosUsados = item.MinutosUsados;
                //            reporteProduccion.TiempoDecimal = item.TiempoDecimal;
                //            reporteProduccion.ScrapBolsa = item.ScrapBolsa;
                //            reporteProduccion.ScrapPolietilenoGr = item.ScrapPolietilenoGr;
                //            reporteProduccion.Poletileno = item.Poletileno;
                //            reporteProduccion.Eficiencia = item.Eficiencia;
                //            reporteProduccion.IdProduccion = Guid.NewGuid();
                //            _context.ReporteProduccion.Add(reporteProduccion);
                //        }
                //        //_context.SaveChanges();
                //        return new OkObjectResult(records.ToList());
            
        //        return new OkObjectResult("");
        //}

        [HttpGet]
        [Route("GetPedidosProducto")]
        public IActionResult GetProducto()
        {
           var pedidos = _context.PedidosCliente.Include(p => p.ProductosContpaq).ToArray();
            // Calcular el cumplimiento.

            //var cumplimiento = CalcularKPIAlmacenCumplimiento();

            // Inserta datos.
            //_context.PedidosCliente.Add(new PedidoCliente
            //{
            //    FechaEntrega = new DateTime(2018, 12, 12),
            //    FechaRegistro = new DateTime(2018, 11, 11),
            //    ProductosContpaq = new List<ProductoInventario>
            //    {
            //        new ProductoInventario{ CantidadBolsas = "11", CodigoProducto = "1111"},
            //        new ProductoInventario{ CantidadBolsas = "22", CodigoProducto = "2222"},
            //        new ProductoInventario{ CantidadBolsas = "33", CodigoProducto = "3333"},
            //    }
            //});

            //_context.MovimientosAlmacen.Add(new MovimientosAlmacen2 {
            //    CodigoProducto = "1111",
            //    FechaMovimiento = new DateTime(2018, 11, 25),
            //    NombreProducto = "Quesadillas deliciosas",
            //    NumBolsas = "22",
            //    TipoMovimiento = "Demo"
            //});

            //_context.SaveChanges();


            //var pedidoProducto = _context.PedidoProductoKPI.ToList();
            // Obtiene el producto desde el contexto.
            //var producto = _context.Productos.FirstOrDefault(p => p.IdProducto == IdProducto);

            // Regresa el producto si lo encuentra, si no regresa NotFound.
            //if (producto == null) return new NotFoundResult();

            return new OkObjectResult(pedidos);
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
                return new OkObjectResult(new RespuetaServidor
                { Exitoso = false, MensajeError = ex.Message });
            }
            CalcularKPIAlmacenCumplimiento();
            return new OkObjectResult(new RespuetaServidor
            { Exitoso = true, MensajeError = string.Empty }
            );

            //}
            //// Flujo editar producto.
            //else
            //{
            //    // Obtiene el producto desde el contexto.
            //    var movbd = _context.MovimientosAlmacen.FirstOrDefault(p => p.IdMovimientoAlmacen == movimientoAlmacen.IdMovimientoAlmacen);

            //    if(movbd != null)
            //    {
            //        movbd.CodigoProducto = movimientoAlmacen.CodigoProducto;
            //        movbd.NombreProducto = movimientoAlmacen.NombreProducto;
            //        movbd.TipoMovimiento = movimientoAlmacen.TipoMovimiento;
            //        movbd.NumBolsas = movimientoAlmacen.NumBolsas;
            //        movbd.FechaMovimiento = movimientoAlmacen.FechaMovimiento;
            //        movbd.Turno = movimientoAlmacen.Turno;
            //        _context.MovimientosAlmacen.Update(movbd);
            //    }
            //    else
            //    {
            //return new OkObjectResult("No se encontro el movimiento");
            //}
            // Proceso de mapeo (puedes usar AutoMapper)

            //}

            // Se guarda el estado del contexto para reflejar cambios.

            //// Flujo nuevo producto.
            //if (movimientoAlmacen.IdMovimientoAlmacen == Guid.Empty)
            //{
            //    // Se añade el producto al contexto.
            //    await _context.MovimientosAlmacen.AddAsync(movimientoAlmacen);
            //}
            //// Flujo editar producto.
            //else
            //{
            //    // Obtiene el producto desde el contexto.
            // Regresa un código de status 200 (OK) con un mensaje dentro del body.

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
        [HttpPut("{IdMovimientoAlmacen}")]
        public async Task<IActionResult> ModificarMovimientoAlmacen([FromBody] MovimientosAlmacen2 movimientoAlmacen)
        {
            //// Flujo nuevo producto.
            //if (movimientoAlmacen.IdMovimientoAlmacen == Guid.Empty)
            //{
            //    // Se añade el producto al contexto.
            //    await _context.MovimientosAlmacen.AddAsync(movimientoAlmacen);
            //}
            //// Flujo editar producto.
            //else
            //{
            //    // Obtiene el producto desde el contexto.
            var movbd = _context.MovimientosAlmacen.FirstOrDefault(p => p.IdMovimientoAlmacen == movimientoAlmacen.IdMovimientoAlmacen);

            if (movbd != null)
                {
                    movbd.CodigoProducto = movimientoAlmacen.CodigoProducto;
                    movbd.NombreProducto = movimientoAlmacen.NombreProducto;
                    movbd.TipoMovimiento = movimientoAlmacen.TipoMovimiento;
                    movbd.NumBolsas = movimientoAlmacen.NumBolsas;
                    movbd.FechaMovimiento = movimientoAlmacen.FechaMovimiento;
                    movbd.Turno = movimientoAlmacen.Turno;
                    _context.MovimientosAlmacen.Update(movbd);
                }
                else
                {
                    return new OkObjectResult("No se encontro el movimiento");
            }
            // Proceso de mapeo (puedes usar AutoMapper)

        //}

            // Se guarda el estado del contexto para reflejar cambios.
            await _context.SaveChangesAsync();

            // Regresa un código de status 200 (OK) con un mensaje dentro del body.
            return new OkObjectResult(movimientoAlmacen);
        }

        //[HttpDelete("{idProducto}")]
        //public IActionResult DeleteProducto([FromRoute] Guid IdProducto)
        //{
        //    // Obtiene el producto desde el contexto.
        //    //var producto = _context.Productos.FirstOrDefault(p => p.IdProducto == IdProducto);

        //    // Elimina si lo encuentra, si no regresa NotFound.
        //    //if (producto == null) return new NotFoundResult();

        //    //_context.Productos.Remove(producto);

        //    // Regresa un código de status 200 (OK) sin mensaje dentro del body.
        //    return new OkResult();
        //}

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

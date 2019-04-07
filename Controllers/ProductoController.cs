using CsvHelper;
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
            //    //_context.SaveChanges();

            
            using (var reader = new System.IO.StreamReader("C:\\Users\\gonzo\\Documents\\ReporteProduccionCSV.csv"))
            using (var csv = new CsvReader(reader))
            {
                csv.Configuration.PrepareHeaderForMatch = (string header, int index) => header.ToLower();
                csv.Configuration.HasHeaderRecord = false;
                var records = csv.GetRecords<ReporteProduccionSinID>().ToList();

                foreach (var item in records)
                {
                    ReporteProduccion reporteProduccion = new ReporteProduccion();
                    reporteProduccion.CodigoNuevo = item.CodigoNuevo;
                    reporteProduccion.Presentacion = item.Presentacion;
                    reporteProduccion.Dia = item.Dia;
                    reporteProduccion.Mes = item.Mes;
                    reporteProduccion.Anho = item.Anho;
                    reporteProduccion.Semana = item.Semana;
                    reporteProduccion.Familia = item.Familia;
                    reporteProduccion.Capacidad = item.Capacidad;
                    reporteProduccion.Cliente = item.Cliente;
                    reporteProduccion.Maquina = item.Maquina;
                    reporteProduccion.TotalDeCavidades = item.TotalDeCavidades;
                    reporteProduccion.CantidadBolsas = item.CantidadBolsas;
                    reporteProduccion.CantidadPiezas = item.CantidadPiezas;
                    reporteProduccion.Turno = item.Turno;
                    reporteProduccion.Supervisor = item.Supervisor;
                    reporteProduccion.HRUsadas = item.HRUsadas;
                    reporteProduccion.MinutosUsados = item.MinutosUsados;
                    reporteProduccion.TiempoDecimal = item.TiempoDecimal;
                    reporteProduccion.ScrapBolsa = item.ScrapBolsa;
                    reporteProduccion.ScrapPolietilenoGr = item.ScrapPolietilenoGr;
                    reporteProduccion.Poletileno = item.Poletileno;
                    reporteProduccion.Eficiencia = item.Eficiencia;
                    reporteProduccion.IdProduccion = Guid.NewGuid();
                    _context.ReporteProduccion.Add(reporteProduccion);
                }
                //_context.SaveChanges();
                return new OkObjectResult(records.ToList());
            }
            
        }
        //return new OkObjectResult(_context.Productos.ToList());


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

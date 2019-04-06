using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaKPI_API.Context;
using SistemaKPI_API.Entities;

namespace SistemaKPI_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReporteCSVController : ControllerBase
    {
        private readonly SistemaKPIContext _context;
        public ReporteCSVController(SistemaKPIContext ctx)
        {
            _context = ctx;
        }

        //Carga de CSV[HttpGet]
        [HttpGet]
        [Route("GetReporteDiarioPedidosCliente")]
        public ActionResult ReporteDiarioPedidosCliente()
        {
            using (var reader = new System.IO.StreamReader("C:\\Users\\gonzo\\Documents\\sistemaKPIBackEnd\\reporteDiario.csv"))
            using (var csv = new CsvReader(reader))
            {
                csv.Configuration.PrepareHeaderForMatch = (string header, int index) => header.ToLower();
                csv.Configuration.HasHeaderRecord = false;
                var records = csv.GetRecords<ReporteCSVsinID>().ToList();

                foreach (var item in records)
                {
                    ReporteDiarioPedidosClienteCSV CSVtoDb = new ReporteDiarioPedidosClienteCSV();
                    CSVtoDb.CodigoNuevo = item.CodigoNuevo;
                    CSVtoDb.Cliente = item.Cliente;
                    CSVtoDb.Capacidad = item.Capacidad;
                    CSVtoDb.Presentacion = item.Presentacion;
                    CSVtoDb.NumPzBol = item.NumPzBol;
                    CSVtoDb.NumBolzXTarima = item.NumBolzXTarima;
                    CSVtoDb.NumPzXTarima = item.NumPzXTarima;
                    CSVtoDb.DiaDelMes = item.DiaDelMes;
                    CSVtoDb.DiaDeSemana = item.DiaDeSemana;
                    CSVtoDb.SemanaAnual = item.SemanaAnual;
                    CSVtoDb.NumDeDia = item.NumDeDia;
                    CSVtoDb.SemanaMes = item.SemanaMes;
                    CSVtoDb.NombreMes = item.NombreMes;
                    CSVtoDb.Anho = item.Anho;
                    CSVtoDb.PedidoPorBolsa = item.PedidoPorBolsa;
                    CSVtoDb.SurtidoPorBolsa = item.SurtidoPorBolsa;
                    CSVtoDb.PedidoPorPieza = item.PedidoPorPieza;
                    CSVtoDb.SurtidoPorPz = item.SurtidoPorPz;
                    CSVtoDb.PorcentajeCumplimiento = item.PorcentajeCumplimiento;
                    CSVtoDb.CodigoChofer = item.CodigoChofer;
                    CSVtoDb.NombreDelChofer = item.NombreDelChofer;
                    CSVtoDb.NumeroDeCaja = item.NumeroDeCaja;
                    CSVtoDb.Flete = item.Flete;
                    CSVtoDb.CodigoCargadores = item.CodigoCargadores;
                    CSVtoDb.Cargadores = item.Cargadores;
                    CSVtoDb.TiempoDeCarga = item.TiempoDeCarga;
                    CSVtoDb.IdPedido = Guid.NewGuid();
                    _context.ReporteDiarioPedidosClienteCSV.Add(CSVtoDb);
                    _context.Add(CSVtoDb);
                };
                _context.SaveChanges();

                return new OkObjectResult(records.ToList());
            }
        }

        [HttpGet]
        [Route("GetReporteProduccionDiaria")]
        public ActionResult ReporteProduccionDiaria()
        {
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
                _context.SaveChanges();
                return new OkObjectResult(records.ToList());
            }
        }
    }
}
        
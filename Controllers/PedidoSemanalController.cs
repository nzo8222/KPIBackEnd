using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaKPI_API.Context;
using SistemaKPI_API.DTOs;
using MoreLinq;
using Microsoft.EntityFrameworkCore;
using SistemaKPI_API.Models;

namespace SistemaKPI_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoSemanalController : ControllerBase
    {
        private readonly SistemaKPIContext _context;
        public PedidoSemanalController(SistemaKPIContext ctx)
        {
            _context = ctx;
        }
        [HttpDelete("{id}")]
        [Route("DeletePedidoSemanal/{id:guid}")]
        public IActionResult DeletePedidoSemanal(Guid id)
        {
            try
            {
                var pedidoSemanalBD = _context.PedidoSemanal
                    .Include(pd => pd.LstPedidosDiario)
                    .FirstOrDefault(p => p.IdPedidoSemanal == id);
                if(pedidoSemanalBD != null)
                {
                    foreach(var pedido in pedidoSemanalBD.LstPedidosDiario)
                    {
                        _context.PedidoDiario.Remove(pedido);
                    }
                    _context.PedidoSemanal.Remove(pedidoSemanalBD);
                    _context.SaveChanges();
                }
                else
                {
                    return new OkObjectResult(new RespuestaServidor
                    { Exitoso = false, MensajeError = "No se encontro el pedido semanal." });
                }
                    
            }
            catch(Exception ex)
            {
                return new OkObjectResult(new RespuestaServidor
                { Exitoso = false, MensajeError = ex.ToString() });
            }
            return new OkObjectResult(new RespuestaServidor
            { Exitoso = true, MensajeError = string.Empty });
        }

        [HttpPost]
        [Route("PutPedidoSemanal")]
        public IActionResult PutPedidoSemanal ([FromBody] PedidoSemanalEditDTO PedidoDTO)
        {
            try
            {
                var pedidosSemanalesbd = _context.PedidoSemanal
                    .Include(p => p.LstPedidosDiario)
                        .ThenInclude(pr => pr.Producto)
                            .ToList();
                var producto = _context.Productos.FirstOrDefault(p => p.IdProducto == PedidoDTO.IdProducto);
                foreach (var pedido in pedidosSemanalesbd)
                {
                    if(pedido.IdPedidoSemanal == PedidoDTO.IdPedidoSemanal)
                    {
                        pedido.FechaInicioSemana = PedidoDTO.FechaInicio;
                        pedido.FechaFinSemana = PedidoDTO.FechaFin;
                        if(producto != null)
                        {
                            pedido.LstPedidosDiario.ElementAt(0).Producto = producto;
                            pedido.LstPedidosDiario.ElementAt(1).Producto = producto;
                            pedido.LstPedidosDiario.ElementAt(2).Producto = producto;
                            pedido.LstPedidosDiario.ElementAt(3).Producto = producto;
                            pedido.LstPedidosDiario.ElementAt(4).Producto = producto;
                            pedido.LstPedidosDiario.ElementAt(5).Producto = producto;
                            pedido.LstPedidosDiario.ElementAt(6).Producto = producto;
                        }
                        pedido.LstPedidosDiario.ElementAt(0).NumBolsas = PedidoDTO.NumBolLunes;
                        
                        pedido.LstPedidosDiario.ElementAt(1).NumBolsas = PedidoDTO.NumBolMartes;
                        
                        pedido.LstPedidosDiario.ElementAt(2).NumBolsas = PedidoDTO.NumBolMiercoles;
                        
                        pedido.LstPedidosDiario.ElementAt(3).NumBolsas = PedidoDTO.NumBolJueves;
                       
                        pedido.LstPedidosDiario.ElementAt(4).NumBolsas = PedidoDTO.NumBolViernes;
                        
                        pedido.LstPedidosDiario.ElementAt(5).NumBolsas = PedidoDTO.NumBolSabado;
                        
                        pedido.LstPedidosDiario.ElementAt(6).NumBolsas = PedidoDTO.NumBolDomingo;
                        _context.PedidoSemanal.Update(pedido);
                        _context.SaveChanges();
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new RespuestaServidor
                { Exitoso = false, MensajeError = ex.ToString() });
            }
            return new OkObjectResult(new RespuestaServidor
            { Exitoso = true, MensajeError = string.Empty });
        }

        [HttpGet("{id}")]
        [Route("GetPedidoSemanalPorIdCliente/{id:guid}")]
        public IActionResult GetPedidosSemanalesPorIDDelCliente(Guid id)
        {
            try
            {
                var pedidosSemanalesbd = _context.PedidoSemanal
                    .Include(p => p.LstPedidosDiario)
                        .ThenInclude(pr => pr.Producto)
                            .ThenInclude(c => c.Cliente)
                            .ToList();
                List<PedidosSemanalesGridDTOPorIdDelCliente> listaPedidosSemanales = new List<PedidosSemanalesGridDTOPorIdDelCliente>();
                foreach (var pedido in pedidosSemanalesbd)
                {
                    if(pedido.LstPedidosDiario.ElementAt(0).Producto.Cliente.IdCliente == id)
                    {
                        PedidosSemanalesGridDTOPorIdDelCliente ps = new PedidosSemanalesGridDTOPorIdDelCliente();
                        ps.IdPedidoSemanal = pedido.IdPedidoSemanal;
                        ps.NombreProducto = pedido.LstPedidosDiario.ElementAt(0).Producto.NombreProducto;
                        ps.CodigoProducto = pedido.LstPedidosDiario.ElementAt(0).Producto.CodigoProducto;
                        ps.Cliente = pedido.LstPedidosDiario.ElementAt(0).Producto.Cliente.RazonSocial;
                        ps.FechaInicio = pedido.FechaInicioSemana;
                        ps.FechaFin = pedido.FechaFinSemana;
                        ps.NumBolLunes = pedido.LstPedidosDiario.ElementAt(0).NumBolsas;
                        ps.NumBolMartes = pedido.LstPedidosDiario.ElementAt(1).NumBolsas;
                        ps.NumBolMiercoles = pedido.LstPedidosDiario.ElementAt(2).NumBolsas;
                        ps.NumBolJueves = pedido.LstPedidosDiario.ElementAt(3).NumBolsas;
                        ps.NumBolViernes = pedido.LstPedidosDiario.ElementAt(4).NumBolsas;
                        ps.NumBolSabado = pedido.LstPedidosDiario.ElementAt(5).NumBolsas;
                        ps.NumBolDomingo = pedido.LstPedidosDiario.ElementAt(6).NumBolsas;
                        listaPedidosSemanales.Add(ps);
                    }
                }
                if (listaPedidosSemanales.Any())
                {
                    return new OkObjectResult(new RespuestaServidor
                    { Exitoso = true, MensajeError = string.Empty, Payload = listaPedidosSemanales });
                }
                else
                {
                    return new OkObjectResult(new RespuestaServidor
                    { Exitoso = false, MensajeError = "No se encontraron pedidos" });
                }

            }
            catch (Exception ex)
            {
                return new OkObjectResult(new RespuestaServidor
                { Exitoso = false, MensajeError = ex.Message });
            }
        }


        //Metodo para obtener lista de pedidos semanales con nombre de producto y numero de bolsas
        [HttpPost]
        [Route("GetPedidosSemanal")]
        public IActionResult GetPedidosSemanales([FromBody] SolicitudGraficaDTO solicitudGraficaDTO )
        {
            try
            {
                //Se obtiene una lista de pedidos semanales dentro del rango de fechas 
                //Donde se incluyen los pedidos diarios, producto y cliente (p => p.Producto.Cliente)
                var lstPedidosSemanales = _context
                    .PedidoSemanal
                    .Include(d => d.LstPedidosDiario)
                        .ThenInclude(p => p.Producto)
                            .ThenInclude(c => c.Cliente)
                    .Where(
                    p => p.FechaInicioSemana.Date > solicitudGraficaDTO.FechaInicio.Date &&
                    p.FechaFinSemana.Date < solicitudGraficaDTO.FechaFin.Date)
                    .DistinctBy(p => p.IdPedidoSemanal)
                    .ToList();

                //lstPedidosSemanales.ElementAt(0).LstPedidosDiario.ElementAt(0).Producto.Cliente.IdCliente
                //Se declara una lista de pedidos que coinciden con el cliente especificado
                List<PedidosSemanalesDTOGrafica> listaPedido = new List<PedidosSemanalesDTOGrafica>();
                //Se declara un objeto para asignarle valores y añadirlo a la lista

                //Se itera la lista de pedidos semanales
                foreach (var pedido in lstPedidosSemanales)
                {
                    PedidosSemanalesDTOGrafica pedidoDTO = new PedidosSemanalesDTOGrafica();
                    if (pedido.LstPedidosDiario.ElementAt(0).Producto.Cliente.IdCliente != solicitudGraficaDTO.idCliente)
                    {
                        continue;
                    }
                    pedidoDTO.IdPedidoSemanal = pedido.IdPedidoSemanal;
                    pedidoDTO.NombreProducto = pedido.LstPedidosDiario.ElementAt(0).Producto.NombreProducto;
                    pedidoDTO.FechaInicio = pedido.FechaInicioSemana;
                    pedidoDTO.FechaFin = pedido.FechaFinSemana;
                    //Se itera la lista de pedidos diarios dentro de un pedido semanal
                    foreach (var p in pedido.LstPedidosDiario)
                    {
                        pedidoDTO.NumBolsas += p.NumBolsas;
                        pedidoDTO.promedioCumplimiento += p.Cumplimiento;
                        ////Se buscan los pedidos con el cliente especificado
                        //if(p.Producto.Cliente.IdCliente == solicitudGraficaDTO.idCliente)
                        //{
                        //    pedidoDTO.IdPedidoSemanal = pedido.IdPedidoSemanal;
                        //    pedidoDTO.NombreProducto = p.Producto.NombreProducto;
                        //    pedidoDTO.NumBolsas = p.NumBolsas;
                        //    pedidoDTO.FechaInicio = pedido.FechaInicioSemana;
                        //    pedidoDTO.FechaFin = pedido.FechaFinSemana;
                        //}

                    }
                    pedidoDTO.promedioCumplimiento = pedidoDTO.promedioCumplimiento / 7;
                    listaPedido.Add(pedidoDTO);
                }
                if (listaPedido.Any())
                {
                    return new OkObjectResult(new RespuestaServidor
                    { Exitoso = true, MensajeError = string.Empty, Payload = listaPedido });
                }
            }
            catch(Exception ex)
            {
                return new OkObjectResult(new RespuestaServidor
                { Exitoso = false, MensajeError = ex.Message });
            }
            return new OkObjectResult(new RespuestaServidor
            { Exitoso = false, MensajeError = "No se encontro pedidos que coincida con los datos especificados." });
        }
        
    }
}
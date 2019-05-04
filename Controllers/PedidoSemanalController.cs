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
        //Metodo para obtener lista de pedidos semanales con nombre de producto y numero de bolsas
        [HttpPost]
        [Route("GetPedidosSemanal")]
        public IActionResult GetPedidosSemanales([FromBody] SolicitudGraficaDTO solicitudGraficaDTO )
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
                p.FechaFinSemana.Date < solicitudGraficaDTO.FechaFin.Date  )
                .ToList();
           
            //lstPedidosSemanales.ElementAt(0).LstPedidosDiario.ElementAt(0).Producto.Cliente.IdCliente
            //Se declara una lista de pedidos que coinciden con el cliente especificado
            List<PedidosSemanalesDTOGrafica> listaPedido = new List<PedidosSemanalesDTOGrafica>();
            //Se declara un objeto para asignarle valores y añadirlo a la lista
            PedidosSemanalesDTOGrafica pedidoDTO = new PedidosSemanalesDTOGrafica();
            //Se itera la lista de pedidos semanales
            foreach (var pedido in lstPedidosSemanales)
            {
                if (pedido.LstPedidosDiario.ElementAt(0).Producto.Cliente.IdCliente != solicitudGraficaDTO.idCliente)
                {
                    continue;
                }
                pedidoDTO.IdPedidoSemanal = pedido.IdPedidoSemanal;
                pedidoDTO.NombreProducto = pedido.LstPedidosDiario.ElementAt(0).Producto.NombreProducto;
                pedidoDTO.FechaInicio = pedido.FechaInicioSemana;
                pedidoDTO.FechaFin = pedido.FechaFinSemana;
                //Se itera la lista de pedidos diarios dentro de un pedido semanal
                foreach(var p in pedido.LstPedidosDiario)
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
            return new OkObjectResult(listaPedido);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaKPI_API.Context;
using SistemaKPI_API.DTOs;
using SistemaKPI_API.Entities;
using SistemaKPI_API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SistemaKPI_API.Controllers
{
    [Route("api/[controller]")]
    public class PedidoClienteController : Controller
    {
        private readonly SistemaKPIContext _context;

        public PedidoClienteController(SistemaKPIContext ctx)
        {
            _context = ctx;
        }

        [HttpPost]
        public IActionResult AddPedidoCliente([FromBody] PedidoClienteDTO pedidoClienteDTO)
        {
            //se pasan los pedidos diarios a una variable local en forma de arreglo
            var pedidos = pedidoClienteDTO.PedidoDiarioDTO.ToArray();
            //se declara una lista de pedidosDiarios para guardar 
            //los pedidos diarios con id que se vayan generando
            List<PedidoDiario> listaPedido = new List<PedidoDiario>();
            //se declara un pedido semanal nuevo
            PedidoSemanal ps = new PedidoSemanal();
            //se Itera la lista de pedidos diarios para guardarlos con GUID
            //se declara un pedido diario nuevo
            
            Producto p = new Producto();
            foreach (var pedido in pedidos)
            {
                PedidoDiario pd = new PedidoDiario(new Guid(), pedido.NumBolsas, pedido.NumDia);
                //pd.IdPedidoDiario = Guid.NewGuid();

                //var prodBD = _context.ProductosInventario.FirstOrDefault(p => p.IdProductoInventario == productoPedidoDTO.IdProductoInventario);
                //se asignan los valores del DTO (sin id) al pedido diario (con ID auto generada)
                var Guid = new Guid(pedido.IdProducto);
                pd.Producto = _context.Productos
                    .Include(c => c.Cliente)
                    .FirstOrDefault(pr => pr.IdProducto == Guid)
                    ;
                //pd.NumBolsas = pedido.NumBolsas;
                //pd.NumDia = pedido.NumDia;
                //se agregan los pedidos diarios a la lista
                listaPedido.Add(pd);
            }
            ps.FechaInicioSemana = pedidoClienteDTO.FechaI;
            ps.FechaFinSemana = pedidoClienteDTO.FechaF;
            ps.LstPedidosDiario = listaPedido;
            _context.PedidoSemanal.Add(ps);
            _context.SaveChanges();

            return new OkObjectResult(new RespuestaServidor
            { Exitoso = true, MensajeError = string.Empty }
            );
        }

        [HttpGet]
        [Route("GetClientesPedido")]
        public IActionResult GetClientes()
        {
            try
            {
                var clientes = _context.Clientes.ToList();
                return new OkObjectResult(new RespuestaServidor
                { Exitoso = true, MensajeError = string.Empty, Payload = clientes }
            );
            }
            catch(Exception ex)
            {
                return new OkObjectResult(new RespuestaServidor
                { Exitoso = true, MensajeError = ex.Message  });
            }

        }


        [HttpGet]
        [Route("GetPedidosProducto")]
        public IActionResult GetProductos()
        {
            //Cliente clienteNuevo = new Cliente();
            //clienteNuevo.RazonSocial = "Cliente prueba 2";
            //Producto productoNuevo = new Producto();
            //productoNuevo.CodigoProducto = 1112;
            //productoNuevo.IdCliente = clienteNuevo;
            //productoNuevo.NombreProducto = "producto prueba 3";
            //Producto productoNuevo2 = new Producto();
            //productoNuevo.CodigoProducto = 1113;
            //productoNuevo.IdCliente = clienteNuevo;
            //productoNuevo.NombreProducto = "producto prueba 3";
            //PedidoDiario pedidoDiarioNuevo = new PedidoDiario();
            //PedidoDiario pedidoDiarioNuevo2 = new PedidoDiario();
            ////List<Producto> nuevaListaProducto = new List<Producto>();
            ////nuevaListaProducto.Add(productoNuevo);
            //pedidoDiarioNuevo.Producto = productoNuevo;
            //pedidoDiarioNuevo.NumBolsas = 100;
            //pedidoDiarioNuevo.NumDia = 3;
            //pedidoDiarioNuevo2.Producto = productoNuevo2;
            //pedidoDiarioNuevo2.NumBolsas = 200;
            //pedidoDiarioNuevo2.NumDia = 4;
            //PedidoSemanal pedidoSemanalNuevo = new PedidoSemanal();
            //List<PedidoDiario> nuevaListaPedidoDiario = new List<PedidoDiario>();
            //nuevaListaPedidoDiario.Add(pedidoDiarioNuevo);
            //nuevaListaPedidoDiario.Add(pedidoDiarioNuevo2);
            //pedidoSemanalNuevo.IdPedidoDiario = nuevaListaPedidoDiario;
            //pedidoSemanalNuevo.FechaInicioSemana = new DateTime().Date;
            //_context.Clientes.Add(clienteNuevo);
            //_context.Productos.Add(productoNuevo);
            //_context.PedidoDiario.Add(pedidoDiarioNuevo);
            //_context.PedidoSemanal.Add(pedidoSemanalNuevo);
            //_context.SaveChanges();
            //var pedidos = _context.PedidoProductoKPI.ToList();
                //_context.PedidosCliente.Include(p => p.ProductosContpaq).ToArray();

            return new OkObjectResult("");
        }

        [HttpPost]
        [Route("GetGraficaLineaCumplimiento")]
        public async Task<IActionResult> GetDatosGraficaCumplimiento([FromBody]SolicitudGrafica sol)
        {
            try
            {
                // Crea diccionario con label del producto y sus cumplimientos.
                var lstCumplimientos = new List<GraficaCumplimientoModel>();

                // Se hace la busqueda de los pedidos dentro del periodo
                var pedidosSemanales = await _context.PedidoSemanal
                    .Include(p => p.LstPedidosDiario)
                    .Where(p => 
                    p.IdPedidoSemanal == sol.IdPedidoSemanal)
                    .ToArrayAsync();
                // Se itera la lista de pedidos para obtener los productos de cada pedido
                foreach (var pedido in pedidosSemanales)
                {
                    var lstCumplimientosValue = new List<decimal>();
                    string nombreProducto = "";

                    // Se itera la lista de productos para obtener el producto individual
                    foreach (var producto in pedido.LstPedidosDiario)
                    {
                        var prod = _context.PedidoDiario
                       .Include(pd => pd.Producto)
                       .Where(p => p.IdPedidoDiario == producto.IdPedidoDiario).FirstOrDefault();
                        producto.Producto = prod.Producto;
                        // Se Guardan en variables locales los valores de cada producto
                        lstCumplimientosValue.Add(Convert.ToDecimal(producto.Cumplimiento) * 100);
                        nombreProducto = producto.Producto.NombreProducto;
                    }
                    // Se agregan los valores a la lista de cumplimiento
                    lstCumplimientos.Add(new GraficaCumplimientoModel { NombreProducto = nombreProducto, Cumplimientos = lstCumplimientosValue });
                }
                // Se regresan los datos encontrados
                return new OkObjectResult(lstCumplimientos.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost]
        [Route("GetGraficaBarrasCumplimiento")]
        public async Task<IActionResult> GetDatosGraficaBarraCumplimiento([FromBody]SolicitudGrafica sol)
        {
            try
            {
                // Crea diccionario con label del producto y sus cumplimientos.
                var lstCumplimientos = new List<GraficaBarrasCumplimientoModel>();

                // Se hace la busqueda de los pedidos dentro del periodo
                var pedidosSemanales = await _context.PedidoSemanal
                    .Include(d => d.LstPedidosDiario)
                      .ThenInclude(p => p.Producto)
                    .Where(p =>
                    p.IdPedidoSemanal == sol.IdPedidoSemanal)
                    .ToArrayAsync();
                // Se itera la lista de pedidos para obtener los productos de cada pedido
                var lstNumBolsasPedido = new List<int>();
                int numBolsasPedido;
                foreach (var pedido in pedidosSemanales)
                {
                    var numBolsasCumplidas = new List<decimal>();
                    string nombreProducto = "";

                    // Se itera la lista de productos para obtener el producto individual
                    foreach (var producto in pedido.LstPedidosDiario)
                    {
                       // var prod = _context.PedidoDiario
                       //.Include(pd => pd.Producto)
                       //.Where(p => p.IdPedidoDiario == producto.IdPedidoDiario).FirstOrDefault();
                       // producto.Producto = prod.Producto;
                        
                        // Se Guardan en variables locales los valores de cada producto
                        numBolsasCumplidas.Add(Convert.ToDecimal((producto.NumBolsas) * (producto.Cumplimiento)) );
                        nombreProducto = producto.Producto.NombreProducto;
                        numBolsasPedido = producto.NumBolsas;
                        lstNumBolsasPedido.Add(numBolsasPedido);
                    }
                    // Se agregan los valores a la lista de cumplimiento
                    lstCumplimientos.Add(new GraficaBarrasCumplimientoModel {
                        NombreProducto = nombreProducto,
                        NumBolsasEntregadas = numBolsasCumplidas,
                        numBolsasPedidoDiario = lstNumBolsasPedido
                    });
                }
                // Se regresan los datos encontrados
                return new OkObjectResult(lstCumplimientos.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}

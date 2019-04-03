using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaKPI_API.Context;
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
        public IActionResult AddPedidoCliente([FromBody] PedidoCliente pedidoCliente)
        {
            // Agrega la fecha de hoy.
            pedidoCliente.FechaRegistro = DateTime.Now; 
             
            // Agrega el pedido al contexto.
            _context.PedidosCliente.Add(pedidoCliente);

            // Guarda los cambios en el contexto.
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new RespuetaServidor
                { Exitoso = false, MensajeError = ex.Message });
            }

            return new OkObjectResult(new RespuetaServidor
            { Exitoso = true, MensajeError = string.Empty }
            );
        }

  
    }
}

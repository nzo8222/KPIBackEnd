using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaKPI_API.Context;
using SistemaKPI_API.DTOs;
using SistemaKPI_API.Entities;
using SistemaKPI_API.Models;

namespace SistemaKPI_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly SistemaKPIContext _context;

        public ClienteController(SistemaKPIContext ctx)
        {
            _context = ctx;
        }

        [HttpPost]
        [Route("PostCliente")]
        public IActionResult AddPedidoCliente([FromBody] ClienteDTO ClienteDTO)
        {
            //Se obtienen todos los clientes existentes
            var clientes = _context.Clientes.ToList();
            //Se itera la lista de clientes
            foreach(var cliente in clientes)
            {
                //Se compara con el cliente que se intenta agregar
                if(ClienteDTO.RazonSocial == cliente.RazonSocial )
                {
                    //Si ya existe un cliente con esa razon social regresa un mensaje de error.
                    return new OkObjectResult(new RespuetaServidor
                    { Exitoso = false, MensajeError = "Ya existe un cliente con ese nombre." });
                }
            }
            //Si no hubo uno se inicializa un objeto cliente igual a la entidad
            Cliente clienteParaGuardar = new Cliente();
            //Se le asigna el nombre que se mando desde el front end atravez del ClienteDTO
            clienteParaGuardar.RazonSocial = ClienteDTO.RazonSocial;
            //se abre un bloque de excepcion
            try
            {
                //Se agrega el cliente a la base de datos
                _context.Clientes.Add(clienteParaGuardar);
                //Se guardan los cambios
                _context.SaveChanges();
                //Regresa un mensaje con el estad de la operacion
                return new OkObjectResult(new RespuetaServidor
                { Exitoso = true, MensajeError = string.Empty });

            }
            catch(Exception ex)
            {
                //Si falla regresa un mensaje con el resultado de la operacion
                return new OkObjectResult(new RespuetaServidor
                { Exitoso = false, MensajeError = ex.Message });
            }
            
        }
        [HttpGet]
        [Route("GetClientes")]
        public IActionResult GetClientes()
        {
            var clientes = _context.Clientes.ToList();
            return new OkObjectResult(clientes);
        }
    }
}
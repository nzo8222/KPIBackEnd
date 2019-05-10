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
    public class InventarioFisicoController : ControllerBase
    {
        private readonly SistemaKPIContext _context;

        public InventarioFisicoController(SistemaKPIContext ctx)
        {
            _context = ctx;
        }

        [HttpGet]
        [Route("GetRegistroInventarioFisico")]
        public IActionResult GetContpaq()
        {
            //var productosInventario = _contpaqContext.ProductosInventario
            //     .DistinctBy(i => i.CodigoProducto)
            //     .ToList();

            //return new OkObjectResult(productosInventario);
            //ProductoInventarioContpaq productoPrueba = new ProductoInventarioContpaq();
            //productoPrueba.CodigoProducto = "1234";
            //productoPrueba.NombreProducto = "Nombre prueba";
            //productoPrueba.RazonSocial = "Razon prueba";
            var inventarioFisico = _context.InventarioFisico.ToList();
            return new OkObjectResult(inventarioFisico);
        }

        [HttpPost]
        [Route("PostInventarioFisico")]
        public async Task<IActionResult> PostInventarioFisico([FromBody] InventarioFisicoDTO inventarioFisicoDTO)
        {
            var inventBD = new InventarioFisico();
            inventBD.CodigoProducto = inventarioFisicoDTO.CodigoProducto;
            inventBD.NombreProducto = inventarioFisicoDTO.NombreProducto;
            inventBD.NumBolsas = inventarioFisicoDTO.NumBolsas;
            inventBD.FechaInventario = inventarioFisicoDTO.FechaInventario;
            inventBD.FolioRemision = inventarioFisicoDTO.FolioRemision;
            _context.InventarioFisico.Add(inventBD);
            try
            {
                await _context.SaveChangesAsync();
            } 
            catch (Exception ex)
            {
                return new OkObjectResult(new RespuestaServidor
                { Exitoso = false, MensajeError = ex.Message });
            }
            // Regresa un código de status 200 (OK) con un mensaje dentro del body.
            return new OkObjectResult(new RespuestaServidor
            { Exitoso = true, MensajeError = string.Empty });
            //return new OkObjectResult(prodBD);
        }
    }
}
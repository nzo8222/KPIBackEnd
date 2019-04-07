using Microsoft.EntityFrameworkCore;
using SistemaKPI_API.Entities;
using SistemaKPI_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaKPI_API.Context
{
    public class SistemaKPIContext : DbContext
    {
        public SistemaKPIContext(DbContextOptions<SistemaKPIContext> options) : base(options)
        {

        }

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<ProductoDetalle> ProductosDetalles { get; set; }
        public DbSet<PedidoCliente> PedidosCliente { get; set; }
        public DbSet<ProductoInventario> ProductosInventario { get; set; }
        public DbSet<ReporteDiarioPedidosClienteCSV> ReporteDiarioPedidosClienteCSV { get; set; }
        public DbSet<ReporteProduccion> ReporteProduccion { get; set; }
    }
}

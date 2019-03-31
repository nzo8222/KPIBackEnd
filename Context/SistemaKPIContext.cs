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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<MovimientosAlmacen>()
            //    .HasOne(p => p.IdProducto)
            //    .WithOne()
            //    .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder
                .Query<PedidoProductoKPI>().ToView("View_PedidoProducto")
                .Property(v => v.RazonSocial).HasColumnName("RazonSocial");

            modelBuilder
                .Query<PedidoProductoKPI>().ToView("View_PedidoProducto")
                .Property(v => v.NombreProducto).HasColumnName("NombreProducto");

            modelBuilder
                .Query<PedidoProductoKPI>().ToView("View_PedidoProducto")
                .Property(v => v.CodigoProducto).HasColumnName("CodigoProducto");
            modelBuilder
               .Query<PedidoProductoKPI>().ToView("View_PedidoProducto")
               .Property(v => v.CantidadPiezas).HasColumnName("CantidadPiezas");

            modelBuilder
                .Query<PedidoProductoKPI>().ToView("View_PedidoProducto")
                .Property(v => v.Cumplimiento).HasColumnName("Cumplimiento");

            modelBuilder
                .Query<PedidoProductoKPI>().ToView("View_PedidoProducto")
                .Property(v => v.Devoluciones).HasColumnName("Devoluciones");

            modelBuilder
              .Query<PedidoProductoKPI>().ToView("View_PedidoProducto")
              .Property(v => v.Discrepancia).HasColumnName("Discrepancia");

            modelBuilder
                .Query<PedidoProductoKPI>().ToView("View_PedidoProducto")
                .Property(v => v.FechaRegistro).HasColumnName("FechaRegistro");

            modelBuilder
                .Query<PedidoProductoKPI>().ToView("View_PedidoProducto")
                .Property(v => v.FechaEntrega).HasColumnName("FechaEntrega");
        }

        public DbQuery<PedidoProductoKPI> PedidoProductoKPI { get; set; }

        //public DbSet<Pedido> Pedidos { get; set; }
        //public DbSet<Cliente> Clientes { get; set; }
        //public DbSet<Producto> Productos { get; set; }
        //public DbSet<ProductoDetalle> ProductosDetalles { get; set; }
        public DbSet<PedidoCliente> PedidosCliente { get; set; }
        public DbSet<ProductoInventario> ProductosInventario { get; set; }
        public DbSet<ReporteDiarioPedidosClienteCSV> ReporteDiarioPedidosClienteCSV { get; set; }
        public DbSet<ReporteProduccion> ReporteProduccion { get; set; }
        public DbSet<MovimientosAlmacen2> MovimientosAlmacen { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using SistemaKPI_API.Models;

namespace SistemaKPI_API.Context
{
    public class ContpaqContext : DbContext
    {
        public ContpaqContext(DbContextOptions<ContpaqContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Query<ProductoInventarioContpaq>().ToView("View_ProductosInventario")
                .Property(v => v.CodigoProducto).HasColumnName("CCODIGOPRODUCTO");

            modelBuilder
                .Query<ProductoInventarioContpaq>().ToView("View_ProductosInventario")
                .Property(v => v.RazonSocial).HasColumnName("CRAZONSOCIAL");

            modelBuilder
                .Query<ProductoInventarioContpaq>().ToView("View_ProductosInventario")
                .Property(v => v.NombreProducto).HasColumnName("CNOMBREPRODUCTO");

        }

        public DbQuery<ProductoInventarioContpaq> ProductosInventario { get; set; }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaKPI_API.Context;

namespace SistemaKPI_API.Migrations
{
    [DbContext(typeof(SistemaKPIContext))]
    [Migration("20190329230137_TablaMovimientosAlmacen5")]
    partial class TablaMovimientosAlmacen5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SistemaKPI_API.Entities.Cliente", b =>
                {
                    b.Property<Guid>("IdCliente")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nombre");

                    b.HasKey("IdCliente");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("SistemaKPI_API.Entities.MovimientosAlmacen", b =>
                {
                    b.Property<Guid>("IdMovimientoAlmacen")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("FechaMovimiento");

                    b.Property<string>("NumBolsas");

                    b.Property<Guid?>("ProductoIdProductoInventario");

                    b.Property<string>("TipoMovimiento");

                    b.HasKey("IdMovimientoAlmacen");

                    b.HasIndex("ProductoIdProductoInventario");

                    b.ToTable("MovimientosAlmacen");
                });

            modelBuilder.Entity("SistemaKPI_API.Entities.Pedido", b =>
                {
                    b.Property<Guid>("IdPedido")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("IdCliente");

                    b.HasKey("IdPedido");

                    b.HasIndex("IdCliente");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("SistemaKPI_API.Entities.PedidoCliente", b =>
                {
                    b.Property<Guid>("IdPedidoCliente")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("FechaEntrega");

                    b.Property<DateTime>("FechaRegistro");

                    b.HasKey("IdPedidoCliente");

                    b.ToTable("PedidosCliente");
                });

            modelBuilder.Entity("SistemaKPI_API.Entities.Producto", b =>
                {
                    b.Property<Guid>("IdProducto")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CodigoProducto");

                    b.Property<string>("Descripcion");

                    b.Property<decimal>("Precio");

                    b.HasKey("IdProducto");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("SistemaKPI_API.Entities.ProductoDetalle", b =>
                {
                    b.Property<Guid>("IdProductoDetalle")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Cantidad");

                    b.Property<decimal>("CostoUnitario");

                    b.Property<Guid?>("IdProducto");

                    b.Property<decimal>("Total");

                    b.HasKey("IdProductoDetalle");

                    b.HasIndex("IdProducto");

                    b.ToTable("ProductosDetalles");
                });

            modelBuilder.Entity("SistemaKPI_API.Entities.ProductoInventario", b =>
                {
                    b.Property<Guid>("IdProductoInventario")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CantidadPiezas");

                    b.Property<string>("CodigoProducto");

                    b.Property<string>("Cumplimiento");

                    b.Property<string>("Devoluciones");

                    b.Property<string>("Discrepancia");

                    b.Property<Guid>("IdPedidoCliente");

                    b.Property<string>("NombreProducto");

                    b.Property<string>("RazonSocial");

                    b.HasKey("IdProductoInventario");

                    b.HasIndex("IdPedidoCliente");

                    b.ToTable("ProductosInventario");
                });

            modelBuilder.Entity("SistemaKPI_API.Entities.ReporteDiarioPedidosClienteCSV", b =>
                {
                    b.Property<Guid>("IdPedido")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Anho");

                    b.Property<string>("Capacidad");

                    b.Property<string>("Cargadores");

                    b.Property<string>("Cliente");

                    b.Property<string>("CodigoCargadores");

                    b.Property<string>("CodigoChofer");

                    b.Property<string>("CodigoNuevo");

                    b.Property<string>("DiaDeSemana");

                    b.Property<string>("DiaDelMes");

                    b.Property<string>("Flete");

                    b.Property<string>("NombreDelChofer");

                    b.Property<string>("NombreMes");

                    b.Property<string>("NumBolzXTarima");

                    b.Property<string>("NumDeDia");

                    b.Property<string>("NumPzBol");

                    b.Property<string>("NumPzXTarima");

                    b.Property<string>("NumeroDeCaja");

                    b.Property<string>("PedidoPorBolsa");

                    b.Property<string>("PedidoPorPieza");

                    b.Property<string>("PorcentajeCumplimiento");

                    b.Property<string>("Presentacion");

                    b.Property<string>("SemanaAnual");

                    b.Property<string>("SemanaMes");

                    b.Property<string>("SurtidoPorBolsa");

                    b.Property<string>("SurtidoPorPz");

                    b.Property<string>("TiempoDeCarga");

                    b.HasKey("IdPedido");

                    b.ToTable("ReporteDiarioPedidosClienteCSV");
                });

            modelBuilder.Entity("SistemaKPI_API.Entities.ReporteProduccion", b =>
                {
                    b.Property<Guid>("IdProduccion")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Anho");

                    b.Property<string>("CantidadBolsas");

                    b.Property<string>("CantidadPiezas");

                    b.Property<string>("Capacidad");

                    b.Property<string>("Cliente");

                    b.Property<string>("CodigoNuevo");

                    b.Property<string>("Dia");

                    b.Property<string>("Eficiencia");

                    b.Property<string>("Familia");

                    b.Property<string>("HRUsadas");

                    b.Property<string>("Maquina");

                    b.Property<string>("Mes");

                    b.Property<string>("MinutosUsados");

                    b.Property<string>("Poletileno");

                    b.Property<string>("Presentacion");

                    b.Property<string>("ScrapBolsa");

                    b.Property<string>("ScrapPolietilenoGr");

                    b.Property<string>("Semana");

                    b.Property<string>("Supervisor");

                    b.Property<string>("TiempoDecimal");

                    b.Property<string>("TotalDeCavidades");

                    b.Property<string>("Turno");

                    b.HasKey("IdProduccion");

                    b.ToTable("ReporteProduccion");
                });

            modelBuilder.Entity("SistemaKPI_API.Entities.MovimientosAlmacen", b =>
                {
                    b.HasOne("SistemaKPI_API.Entities.ProductoInventario", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoIdProductoInventario");
                });

            modelBuilder.Entity("SistemaKPI_API.Entities.Pedido", b =>
                {
                    b.HasOne("SistemaKPI_API.Entities.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("IdCliente");
                });

            modelBuilder.Entity("SistemaKPI_API.Entities.ProductoDetalle", b =>
                {
                    b.HasOne("SistemaKPI_API.Entities.Pedido")
                        .WithMany("Productos")
                        .HasForeignKey("IdProducto");

                    b.HasOne("SistemaKPI_API.Entities.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("IdProducto");
                });

            modelBuilder.Entity("SistemaKPI_API.Entities.ProductoInventario", b =>
                {
                    b.HasOne("SistemaKPI_API.Entities.PedidoCliente")
                        .WithMany("ProductosContpaq")
                        .HasForeignKey("IdPedidoCliente")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
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
    [Migration("20190325180441_ReporteDiarioPedidosClienteCSV2")]
    partial class ReporteDiarioPedidosClienteCSV2
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

                    b.Property<int>("CantidadPiezas");

                    b.Property<string>("CodigoProducto");

                    b.Property<Guid>("IdPedidoCliente");

                    b.Property<string>("NombreProducto");

                    b.Property<string>("RazonSocial");

                    b.HasKey("IdProductoInventario");

                    b.HasIndex("IdPedidoCliente");

                    b.ToTable("ProductosInventario");
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
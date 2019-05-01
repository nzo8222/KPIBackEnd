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
    [Migration("20190501175538_updateEntities3")]
    partial class updateEntities3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<Guid>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<Guid>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SistemaKPI_API.Entities.Cliente", b =>
                {
                    b.Property<Guid>("IdCliente")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("RazonSocial");

                    b.HasKey("IdCliente");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("SistemaKPI_API.Entities.InventarioFisico", b =>
                {
                    b.Property<Guid>("IdInventarioFisico")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CodigoProducto");

                    b.Property<DateTime>("FechaInventario");

                    b.Property<string>("FolioRemision");

                    b.Property<string>("NombreProducto");

                    b.Property<string>("NumBolsas");

                    b.HasKey("IdInventarioFisico");

                    b.ToTable("InventarioFisico");
                });

            modelBuilder.Entity("SistemaKPI_API.Entities.MovimientosAlmacen2", b =>
                {
                    b.Property<Guid>("IdMovimientoAlmacen")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CodigoProducto");

                    b.Property<DateTime>("FechaMovimiento");

                    b.Property<string>("FolioRemision");

                    b.Property<string>("NombreProducto");

                    b.Property<string>("NumBolsas");

                    b.Property<string>("TipoMovimiento");

                    b.Property<string>("Turno");

                    b.HasKey("IdMovimientoAlmacen");

                    b.ToTable("MovimientosAlmacen");
                });

            modelBuilder.Entity("SistemaKPI_API.Entities.NewEntities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<Guid>("IdRole");

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("SistemaKPI_API.Entities.NewEntities.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<Guid>("IdUsuario");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasAlternateKey("IdUsuario");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("SistemaKPI_API.Entities.PedidoDiario", b =>
                {
                    b.Property<Guid>("IdPedidoDiario");

                    b.Property<decimal>("Cumplimiento");

                    b.Property<Guid?>("IdProducto");

                    b.Property<int>("NumBolsas");

                    b.Property<int>("NumDia");

                    b.HasKey("IdPedidoDiario");

                    b.HasIndex("IdProducto");

                    b.ToTable("PedidoDiario");
                });

            modelBuilder.Entity("SistemaKPI_API.Entities.PedidoSemanal", b =>
                {
                    b.Property<Guid>("IdPedidoSemanal")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("FechaFinSemana");

                    b.Property<DateTime>("FechaInicioSemana");

                    b.HasKey("IdPedidoSemanal");

                    b.ToTable("PedidoSemanal");
                });

            modelBuilder.Entity("SistemaKPI_API.Entities.Producto", b =>
                {
                    b.Property<Guid>("IdProducto")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CodigoProducto");

                    b.Property<Guid?>("IdCliente");

                    b.Property<string>("NombreProducto");

                    b.HasKey("IdProducto");

                    b.HasIndex("IdCliente");

                    b.ToTable("Productos");
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("SistemaKPI_API.Entities.NewEntities.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("SistemaKPI_API.Entities.NewEntities.Usuario")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("SistemaKPI_API.Entities.NewEntities.Usuario")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("SistemaKPI_API.Entities.NewEntities.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SistemaKPI_API.Entities.NewEntities.Usuario")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("SistemaKPI_API.Entities.NewEntities.Usuario")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SistemaKPI_API.Entities.PedidoDiario", b =>
                {
                    b.HasOne("SistemaKPI_API.Entities.PedidoSemanal")
                        .WithMany("LstPedidosDiario")
                        .HasForeignKey("IdPedidoDiario")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SistemaKPI_API.Entities.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("IdProducto");
                });

            modelBuilder.Entity("SistemaKPI_API.Entities.Producto", b =>
                {
                    b.HasOne("SistemaKPI_API.Entities.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("IdCliente");
                });
#pragma warning restore 612, 618
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaKPI_API.Migrations
{
    public partial class MigracionNuevasEntidadesPedidoCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductosInventario");

            migrationBuilder.DropTable(
                name: "PedidosCliente");

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    IdCliente = table.Column<Guid>(nullable: false),
                    RazonSocial = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "PedidoSemanal",
                columns: table => new
                {
                    IdPedidoSemanal = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoSemanal", x => x.IdPedidoSemanal);
                });

            migrationBuilder.CreateTable(
                name: "PedidoDiario",
                columns: table => new
                {
                    IdPedidoDiario = table.Column<Guid>(nullable: false),
                    NumBolsas = table.Column<int>(nullable: false),
                    NumDia = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoDiario", x => x.IdPedidoDiario);
                    table.ForeignKey(
                        name: "FK_PedidoDiario_PedidoSemanal_IdPedidoDiario",
                        column: x => x.IdPedidoDiario,
                        principalTable: "PedidoSemanal",
                        principalColumn: "IdPedidoSemanal",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    IdProducto = table.Column<Guid>(nullable: false),
                    IdCliente1 = table.Column<Guid>(nullable: true),
                    CodigoProducto = table.Column<int>(nullable: false),
                    NombreProducto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.IdProducto);
                    table.ForeignKey(
                        name: "FK_Productos_Clientes_IdCliente1",
                        column: x => x.IdCliente1,
                        principalTable: "Clientes",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Productos_PedidoDiario_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "PedidoDiario",
                        principalColumn: "IdPedidoDiario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Productos_IdCliente1",
                table: "Productos",
                column: "IdCliente1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "PedidoDiario");

            migrationBuilder.DropTable(
                name: "PedidoSemanal");

            migrationBuilder.CreateTable(
                name: "PedidosCliente",
                columns: table => new
                {
                    IdPedidoCliente = table.Column<Guid>(nullable: false),
                    FechaEntrega = table.Column<DateTime>(nullable: false),
                    FechaRegistro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidosCliente", x => x.IdPedidoCliente);
                });

            migrationBuilder.CreateTable(
                name: "ProductosInventario",
                columns: table => new
                {
                    IdProductoInventario = table.Column<Guid>(nullable: false),
                    CantidadBolsas = table.Column<string>(nullable: true),
                    CodigoProducto = table.Column<string>(nullable: true),
                    Cumplimiento = table.Column<string>(nullable: true),
                    Devoluciones = table.Column<string>(nullable: true),
                    Discrepancia = table.Column<string>(nullable: true),
                    IdPedidoCliente = table.Column<Guid>(nullable: false),
                    NombreProducto = table.Column<string>(nullable: true),
                    RazonSocial = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductosInventario", x => x.IdProductoInventario);
                    table.ForeignKey(
                        name: "FK_ProductosInventario_PedidosCliente_IdPedidoCliente",
                        column: x => x.IdPedidoCliente,
                        principalTable: "PedidosCliente",
                        principalColumn: "IdPedidoCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductosInventario_IdPedidoCliente",
                table: "ProductosInventario",
                column: "IdPedidoCliente");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaKPI_API.Migrations
{
    public partial class AgregarPedidoCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CodigoProducto",
                table: "Productos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PedidosCliente",
                columns: table => new
                {
                    IdPedidoCliente = table.Column<Guid>(nullable: false),
                    FechaRegistro = table.Column<DateTime>(nullable: false),
                    FechaEntrega = table.Column<DateTime>(nullable: false)
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
                    RazonSocial = table.Column<string>(nullable: true),
                    NombreProducto = table.Column<string>(nullable: true),
                    CodigoProducto = table.Column<string>(nullable: true),
                    IdPedidoCliente = table.Column<Guid>(nullable: false)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductosInventario");

            migrationBuilder.DropTable(
                name: "PedidosCliente");

            migrationBuilder.DropColumn(
                name: "CodigoProducto",
                table: "Productos");
        }
    }
}

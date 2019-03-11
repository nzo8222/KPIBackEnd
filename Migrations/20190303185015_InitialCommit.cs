using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaKPI_API.Migrations
{
    public partial class InitialCommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    IdCliente = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    IdProducto = table.Column<Guid>(nullable: false),
                    Precio = table.Column<decimal>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.IdProducto);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    IdPedido = table.Column<Guid>(nullable: false),
                    IdCliente = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.IdPedido);
                    table.ForeignKey(
                        name: "FK_Pedidos_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductosDetalles",
                columns: table => new
                {
                    IdProductoDetalle = table.Column<Guid>(nullable: false),
                    IdProducto = table.Column<Guid>(nullable: true),
                    Cantidad = table.Column<decimal>(nullable: false),
                    CostoUnitario = table.Column<decimal>(nullable: false),
                    Total = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductosDetalles", x => x.IdProductoDetalle);
                    table.ForeignKey(
                        name: "FK_ProductosDetalles_Pedidos_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "Pedidos",
                        principalColumn: "IdPedido",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductosDetalles_Productos_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "Productos",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_IdCliente",
                table: "Pedidos",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_ProductosDetalles_IdProducto",
                table: "ProductosDetalles",
                column: "IdProducto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductosDetalles");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}

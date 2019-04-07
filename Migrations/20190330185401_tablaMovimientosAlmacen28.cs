using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaKPI_API.Migrations
{
    public partial class tablaMovimientosAlmacen28 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductosDetalles");

            migrationBuilder.DropTable(
                name: "Producto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    IdProducto = table.Column<Guid>(nullable: false),
                    CodigoProducto = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    Precio = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.IdProducto);
                });

            migrationBuilder.CreateTable(
                name: "ProductosDetalles",
                columns: table => new
                {
                    IdProductoDetalle = table.Column<Guid>(nullable: false),
                    Cantidad = table.Column<decimal>(nullable: false),
                    CostoUnitario = table.Column<decimal>(nullable: false),
                    IdProducto = table.Column<Guid>(nullable: true),
                    Total = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductosDetalles", x => x.IdProductoDetalle);
                    table.ForeignKey(
                        name: "FK_ProductosDetalles_Producto_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "Producto",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductosDetalles_IdProducto",
                table: "ProductosDetalles",
                column: "IdProducto");
        }
    }
}

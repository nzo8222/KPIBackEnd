using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaKPI_API.Migrations
{
    public partial class TablaMovimientosAlmacen15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovimientosAlmacen_ProductosInventario_ProductoIdProductoInventario",
                table: "MovimientosAlmacen");

            migrationBuilder.DropIndex(
                name: "IX_MovimientosAlmacen_ProductoIdProductoInventario",
                table: "MovimientosAlmacen");

            migrationBuilder.DropColumn(
                name: "ProductoIdProductoInventario",
                table: "MovimientosAlmacen");

            migrationBuilder.AddColumn<Guid>(
                name: "IdProducto",
                table: "MovimientosAlmacen",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdProducto",
                table: "MovimientosAlmacen");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductoIdProductoInventario",
                table: "MovimientosAlmacen",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MovimientosAlmacen_ProductoIdProductoInventario",
                table: "MovimientosAlmacen",
                column: "ProductoIdProductoInventario");

            migrationBuilder.AddForeignKey(
                name: "FK_MovimientosAlmacen_ProductosInventario_ProductoIdProductoInventario",
                table: "MovimientosAlmacen",
                column: "ProductoIdProductoInventario",
                principalTable: "ProductosInventario",
                principalColumn: "IdProductoInventario",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

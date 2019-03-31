using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaKPI_API.Migrations
{
    public partial class TablaMovimientosAlmacen5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductosInventario_MovimientosAlmacen_IdProductoInventario",
                table: "ProductosInventario");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddForeignKey(
                name: "FK_ProductosInventario_MovimientosAlmacen_IdProductoInventario",
                table: "ProductosInventario",
                column: "IdProductoInventario",
                principalTable: "MovimientosAlmacen",
                principalColumn: "IdMovimientoAlmacen",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

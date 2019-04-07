using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaKPI_API.Migrations
{
    public partial class TablaMovimientosAlmacen4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductosInventario_MovimientosAlmacen_IdPedidoCliente",
                table: "ProductosInventario");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductosInventario_PedidosCliente_PedidoClienteIdPedidoCliente",
                table: "ProductosInventario");

            migrationBuilder.DropIndex(
                name: "IX_ProductosInventario_PedidoClienteIdPedidoCliente",
                table: "ProductosInventario");

            migrationBuilder.DropColumn(
                name: "PedidoClienteIdPedidoCliente",
                table: "ProductosInventario");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductosInventario_PedidosCliente_IdPedidoCliente",
                table: "ProductosInventario",
                column: "IdPedidoCliente",
                principalTable: "PedidosCliente",
                principalColumn: "IdPedidoCliente",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductosInventario_MovimientosAlmacen_IdProductoInventario",
                table: "ProductosInventario",
                column: "IdProductoInventario",
                principalTable: "MovimientosAlmacen",
                principalColumn: "IdMovimientoAlmacen",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductosInventario_PedidosCliente_IdPedidoCliente",
                table: "ProductosInventario");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductosInventario_MovimientosAlmacen_IdProductoInventario",
                table: "ProductosInventario");

            migrationBuilder.AddColumn<Guid>(
                name: "PedidoClienteIdPedidoCliente",
                table: "ProductosInventario",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductosInventario_PedidoClienteIdPedidoCliente",
                table: "ProductosInventario",
                column: "PedidoClienteIdPedidoCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductosInventario_MovimientosAlmacen_IdPedidoCliente",
                table: "ProductosInventario",
                column: "IdPedidoCliente",
                principalTable: "MovimientosAlmacen",
                principalColumn: "IdMovimientoAlmacen",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductosInventario_PedidosCliente_PedidoClienteIdPedidoCliente",
                table: "ProductosInventario",
                column: "PedidoClienteIdPedidoCliente",
                principalTable: "PedidosCliente",
                principalColumn: "IdPedidoCliente",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

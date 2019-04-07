using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaKPI_API.Migrations
{
    public partial class TablaMovimientosAlmacen3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductosInventario_PedidosCliente_IdPedidoCliente",
                table: "ProductosInventario");

            migrationBuilder.AddColumn<Guid>(
                name: "PedidoClienteIdPedidoCliente",
                table: "ProductosInventario",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MovimientosAlmacen",
                columns: table => new
                {
                    IdMovimientoAlmacen = table.Column<Guid>(nullable: false),
                    TipoMovimiento = table.Column<string>(nullable: true),
                    FechaMovimiento = table.Column<DateTime>(nullable: false),
                    NumBolsas = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimientosAlmacen", x => x.IdMovimientoAlmacen);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductosInventario_MovimientosAlmacen_IdPedidoCliente",
                table: "ProductosInventario");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductosInventario_PedidosCliente_PedidoClienteIdPedidoCliente",
                table: "ProductosInventario");

            migrationBuilder.DropTable(
                name: "MovimientosAlmacen");

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
        }
    }
}

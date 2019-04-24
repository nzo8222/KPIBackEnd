using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaKPI_API.Migrations
{
    public partial class MigracionNuevasEntidadesPedidoCliente3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_PedidoDiario_IdProducto",
                table: "Productos");

            migrationBuilder.AddColumn<Guid>(
                name: "IdProducto",
                table: "PedidoDiario",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PedidoDiario_IdProducto",
                table: "PedidoDiario",
                column: "IdProducto");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoDiario_Productos_IdProducto",
                table: "PedidoDiario",
                column: "IdProducto",
                principalTable: "Productos",
                principalColumn: "IdProducto",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoDiario_Productos_IdProducto",
                table: "PedidoDiario");

            migrationBuilder.DropIndex(
                name: "IX_PedidoDiario_IdProducto",
                table: "PedidoDiario");

            migrationBuilder.DropColumn(
                name: "IdProducto",
                table: "PedidoDiario");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_PedidoDiario_IdProducto",
                table: "Productos",
                column: "IdProducto",
                principalTable: "PedidoDiario",
                principalColumn: "IdPedidoDiario",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

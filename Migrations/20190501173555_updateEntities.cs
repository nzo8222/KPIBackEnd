using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaKPI_API.Migrations
{
    public partial class updateEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoDiario_PedidoSemanal_PedidoSemanalIdPedidoSemanal",
                table: "PedidoDiario");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Clientes_IdCliente1",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_PedidoDiario_PedidoSemanalIdPedidoSemanal",
                table: "PedidoDiario");

            migrationBuilder.DropColumn(
                name: "PedidoSemanalIdPedidoSemanal",
                table: "PedidoDiario");

            migrationBuilder.RenameColumn(
                name: "IdCliente1",
                table: "Productos",
                newName: "IdCliente");

            migrationBuilder.RenameIndex(
                name: "IX_Productos_IdCliente1",
                table: "Productos",
                newName: "IX_Productos_IdCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoDiario_PedidoSemanal_IdPedidoDiario",
                table: "PedidoDiario",
                column: "IdPedidoDiario",
                principalTable: "PedidoSemanal",
                principalColumn: "IdPedidoSemanal",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Clientes_IdCliente",
                table: "Productos",
                column: "IdCliente",
                principalTable: "Clientes",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoDiario_PedidoSemanal_IdPedidoDiario",
                table: "PedidoDiario");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Clientes_IdCliente",
                table: "Productos");

            migrationBuilder.RenameColumn(
                name: "IdCliente",
                table: "Productos",
                newName: "IdCliente1");

            migrationBuilder.RenameIndex(
                name: "IX_Productos_IdCliente",
                table: "Productos",
                newName: "IX_Productos_IdCliente1");

            migrationBuilder.AddColumn<Guid>(
                name: "PedidoSemanalIdPedidoSemanal",
                table: "PedidoDiario",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PedidoDiario_PedidoSemanalIdPedidoSemanal",
                table: "PedidoDiario",
                column: "PedidoSemanalIdPedidoSemanal");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoDiario_PedidoSemanal_PedidoSemanalIdPedidoSemanal",
                table: "PedidoDiario",
                column: "PedidoSemanalIdPedidoSemanal",
                principalTable: "PedidoSemanal",
                principalColumn: "IdPedidoSemanal",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Clientes_IdCliente1",
                table: "Productos",
                column: "IdCliente1",
                principalTable: "Clientes",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

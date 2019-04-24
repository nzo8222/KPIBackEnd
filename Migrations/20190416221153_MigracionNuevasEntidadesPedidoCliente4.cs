using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaKPI_API.Migrations
{
    public partial class MigracionNuevasEntidadesPedidoCliente4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoDiario_PedidoSemanal_IdPedidoDiario",
                table: "PedidoDiario");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoDiario_PedidoSemanal_PedidoSemanalIdPedidoSemanal",
                table: "PedidoDiario");

            migrationBuilder.DropIndex(
                name: "IX_PedidoDiario_PedidoSemanalIdPedidoSemanal",
                table: "PedidoDiario");

            migrationBuilder.DropColumn(
                name: "PedidoSemanalIdPedidoSemanal",
                table: "PedidoDiario");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoDiario_PedidoSemanal_IdPedidoDiario",
                table: "PedidoDiario",
                column: "IdPedidoDiario",
                principalTable: "PedidoSemanal",
                principalColumn: "IdPedidoSemanal",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

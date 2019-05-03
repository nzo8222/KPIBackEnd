using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaKPI_API.Migrations
{
    public partial class UpdateEntidades4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoDiario_PedidoSemanal_IdPedidoDiario",
                table: "PedidoDiario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaKPI_API.Migrations
{
    public partial class SeAgregoTablaInventarioFisico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InventarioFisico",
                columns: table => new
                {
                    IdInventarioFisico = table.Column<Guid>(nullable: false),
                    CodigoProducto = table.Column<string>(nullable: true),
                    NombreProducto = table.Column<string>(nullable: true),
                    NumBolsas = table.Column<string>(nullable: true),
                    FechaInventario = table.Column<DateTime>(nullable: false),
                    FolioRemision = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventarioFisico", x => x.IdInventarioFisico);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventarioFisico");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaKPI_API.Migrations
{
    public partial class SeAgregoCampoRemisionTablaMovimientoAlmacen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FolioRemision",
                table: "MovimientosAlmacen",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FolioRemision",
                table: "MovimientosAlmacen");
        }
    }
}

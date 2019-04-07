using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaKPI_API.Migrations
{
    public partial class CambioTablaInventarioProductos3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Discrepancia",
                table: "ProductosInventario",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Devoluciones",
                table: "ProductosInventario",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Cumplimiento",
                table: "ProductosInventario",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "CantidadPiezas",
                table: "ProductosInventario",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Discrepancia",
                table: "ProductosInventario",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Devoluciones",
                table: "ProductosInventario",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Cumplimiento",
                table: "ProductosInventario",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CantidadPiezas",
                table: "ProductosInventario",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}

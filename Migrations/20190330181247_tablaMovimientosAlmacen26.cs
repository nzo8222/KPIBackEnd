using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaKPI_API.Migrations
{
    public partial class tablaMovimientosAlmacen26 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdProducto",
                table: "MovimientosAlmacen");

            migrationBuilder.AddColumn<string>(
                name: "CodigoProducto",
                table: "MovimientosAlmacen",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NombreProducto",
                table: "MovimientosAlmacen",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodigoProducto",
                table: "MovimientosAlmacen");

            migrationBuilder.DropColumn(
                name: "NombreProducto",
                table: "MovimientosAlmacen");

            migrationBuilder.AddColumn<Guid>(
                name: "IdProducto",
                table: "MovimientosAlmacen",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}

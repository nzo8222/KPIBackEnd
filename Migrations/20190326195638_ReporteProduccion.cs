using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaKPI_API.Migrations
{
    public partial class ReporteProduccion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReporteProduccion",
                columns: table => new
                {
                    IdProduccion = table.Column<Guid>(nullable: false),
                    CodigoNuevo = table.Column<string>(nullable: true),
                    Presentacion = table.Column<string>(nullable: true),
                    Dia = table.Column<string>(nullable: true),
                    Mes = table.Column<string>(nullable: true),
                    Anho = table.Column<string>(nullable: true),
                    Semana = table.Column<string>(nullable: true),
                    Familia = table.Column<string>(nullable: true),
                    Capacidad = table.Column<string>(nullable: true),
                    Cliente = table.Column<string>(nullable: true),
                    Maquina = table.Column<string>(nullable: true),
                    TotalDeCavidades = table.Column<string>(nullable: true),
                    CantidadBolsas = table.Column<string>(nullable: true),
                    CantidadPiezas = table.Column<string>(nullable: true),
                    Turno = table.Column<string>(nullable: true),
                    Supervisor = table.Column<string>(nullable: true),
                    HRUsadas = table.Column<string>(nullable: true),
                    MinutosUsados = table.Column<string>(nullable: true),
                    TiempoDecimal = table.Column<string>(nullable: true),
                    ScrapBolsa = table.Column<string>(nullable: true),
                    Poletileno = table.Column<string>(nullable: true),
                    Eficiencia = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReporteProduccion", x => x.IdProduccion);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReporteProduccion");
        }
    }
}

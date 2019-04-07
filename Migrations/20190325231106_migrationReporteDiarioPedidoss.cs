using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaKPI_API.Migrations
{
    public partial class migrationReporteDiarioPedidoss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReporteDiarioPedidosClienteCSV",
                columns: table => new
                {
                    IdPedido = table.Column<Guid>(nullable: false),
                    CodigoNuevo = table.Column<string>(nullable: true),
                    Cliente = table.Column<string>(nullable: true),
                    Capacidad = table.Column<string>(nullable: true),
                    Presentacion = table.Column<string>(nullable: true),
                    NumPzBol = table.Column<string>(nullable: true),
                    NumBolzXTarima = table.Column<string>(nullable: true),
                    NumPzXTarima = table.Column<string>(nullable: true),
                    DiaDelMes = table.Column<string>(nullable: true),
                    DiaDeSemana = table.Column<string>(nullable: true),
                    SemanaAnual = table.Column<string>(nullable: true),
                    NumDeDia = table.Column<string>(nullable: true),
                    SemanaMes = table.Column<string>(nullable: true),
                    NombreMes = table.Column<string>(nullable: true),
                    Anho = table.Column<string>(nullable: true),
                    PedidoPorBolsa = table.Column<string>(nullable: true),
                    SurtidoPorBolsa = table.Column<string>(nullable: true),
                    PedidoPorPieza = table.Column<string>(nullable: true),
                    SurtidoPorPz = table.Column<string>(nullable: true),
                    PorcentajeCumplimiento = table.Column<string>(nullable: true),
                    CodigoChofer = table.Column<string>(nullable: true),
                    NombreDelChofer = table.Column<string>(nullable: true),
                    NumeroDeCaja = table.Column<string>(nullable: true),
                    Flete = table.Column<string>(nullable: true),
                    CodigoCargadores = table.Column<string>(nullable: true),
                    Cargadores = table.Column<string>(nullable: true),
                    TiempoDeCarga = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReporteDiarioPedidosClienteCSV", x => x.IdPedido);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReporteDiarioPedidosClienteCSV");
        }
    }
}

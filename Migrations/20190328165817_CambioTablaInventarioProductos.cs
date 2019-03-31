using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaKPI_API.Migrations
{
    public partial class CambioTablaInventarioProductos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CantidadPiezas",
                table: "ProductosInventario",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Cumplimiento",
                table: "ProductosInventario",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Devoluciones",
                table: "ProductosInventario",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Discrepancia",
                table: "ProductosInventario",
                nullable: false,
                defaultValue: 0);

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
                    ScrapPolietilenoGr = table.Column<string>(nullable: true),
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
                name: "ReporteDiarioPedidosClienteCSV");

            migrationBuilder.DropTable(
                name: "ReporteProduccion");

            migrationBuilder.DropColumn(
                name: "CantidadPiezas",
                table: "ProductosInventario");

            migrationBuilder.DropColumn(
                name: "Cumplimiento",
                table: "ProductosInventario");

            migrationBuilder.DropColumn(
                name: "Devoluciones",
                table: "ProductosInventario");

            migrationBuilder.DropColumn(
                name: "Discrepancia",
                table: "ProductosInventario");
        }
    }
}

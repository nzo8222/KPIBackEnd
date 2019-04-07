using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaKPI_API.Entities
{
    public class ReporteCSVsinID
    {

        public string CodigoNuevo { get; set; }
        // Codigo Nuevo,
        public string Cliente { get; set; }
        // Cliente, 
        public string Capacidad { get; set; }
        //Capacidad, 
        public string Presentacion { get; set; }
        //  Presentacion,
        public string NumPzBol { get; set; }
        //Pza./Bol,
        public string NumBolzXTarima { get; set; }
        //Bolsa/Tarima,
        public string NumPzXTarima { get; set; }
        //  Pza./Tarima
        public string DiaDelMes { get; set; }
        //  ,Dia del mes,
        public string DiaDeSemana { get; set; }
        //  Dia Semana, 
        public string SemanaAnual { get; set; }
        //Semana Anual
        public string NumDeDia { get; set; }
        // ,Numero de Dia
        public string SemanaMes { get; set; }
        //,Semana Mes
        public string NombreMes { get; set; }
        //, Mes,
        public string Anho { get; set; }
        //Año, 
        public string PedidoPorBolsa { get; set; }
        // Pedido por Bolsa
        public string SurtidoPorBolsa { get; set; }
        //  , Surtido por bolsa,
        public string PedidoPorPieza { get; set; }
        //Pedido por Pieza, 
        public string SurtidoPorPz { get; set; }
        // Surtido por Pieza,
        public string PorcentajeCumplimiento { get; set; }
        // % de Cumplimiento,
        public string CodigoChofer { get; set; }
        //Codigo de Chofer, 
        public string NombreDelChofer { get; set; }
        //Nombre del Chofer, 
        public string NumeroDeCaja { get; set; }
        //Numero de Caja, 
        public string Flete { get; set; }
        //Flete,
        public string CodigoCargadores { get; set; }
        //Codigo de Cargadores, 
        public string Cargadores { get; set; }
        //Cargadores, 
        public string TiempoDeCarga { get; set; }
        //Tiempo de Carga
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaKPI_API.Entities
{
    public class ReporteProduccion
    {
        [Key]
        public Guid IdProduccion { get; set; }
        public string CodigoNuevo { get; set; }
        public string Presentacion { get; set; }
        public string Dia { get; set; }
        public string Mes { get; set; }
        public string Anho { get; set; }
        public string Semana { get; set; }
        public string Familia { get; set; }
        public string Capacidad { get; set; }
        public string Cliente { get; set; }
        public string Maquina { get; set; }
        public string TotalDeCavidades { get; set; }
        public string CantidadBolsas { get; set; }
        public string CantidadPiezas { get; set; }
        public string Turno { get; set; }
        public string Supervisor { get; set; }
        public string HRUsadas { get; set; }
        public string MinutosUsados { get; set; }
        public string TiempoDecimal { get; set; }
        public string ScrapBolsa { get; set; }
        public string ScrapPolietilenoGr { get; set; }
        public string Poletileno { get; set; }
        public string Eficiencia { get; set; }


    }
}

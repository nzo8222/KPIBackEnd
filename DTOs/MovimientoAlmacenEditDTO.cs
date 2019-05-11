using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaKPI_API.DTOs
{
    public class MovimientoAlmacenEditDTO
    {
        public Guid IdMovimientoAlmacen { get; set; }
        public Guid IdProducto { get; set; }
        public string TipoMovimiento { get; set; }
        public int NumBolsas { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public string Turno { get; set; }
        public int FolioRemision { get; set; }
    }
}

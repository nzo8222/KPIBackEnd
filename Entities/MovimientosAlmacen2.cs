using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaKPI_API.Entities
{
    public class MovimientosAlmacen2
    {
        [Key]
        public Guid IdMovimientoAlmacen { get; set; }
        public string CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public string TipoMovimiento { get; set; }

        public string NumBolsas { get; set; }
        public DateTime FechaMovimiento { get; set; }
    }
}

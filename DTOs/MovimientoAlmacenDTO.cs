using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaKPI_API.DTOs
{
    public class MovimientoAlmacenDTO
    {
        
        public string CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public string TipoMovimiento { get; set; }

        public string NumBolsas { get; set; }
        
        public string Turno { get; set; }
    }
}

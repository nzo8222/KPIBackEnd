using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaKPI_API.DTOs
{
    public class InventarioFisicoDTO
    {
        public string CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public string NumBolsas { get; set; }
        public DateTime FechaInventario { get; set; }
        public string FolioRemision { get; set; }
    }
}

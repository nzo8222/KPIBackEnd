using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaKPI_API.Entities
{
    public class InventarioFisico
    {
        [Key]
        public Guid IdInventarioFisico { get; set; }
        public string CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public string NumBolsas { get; set; }
        public DateTime FechaInventario { get; set; }
        public string FolioRemision { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaKPI_API.Models
{
    public class GraficaCumplimientoModel
    {
        public string NombreProducto { get; set; }
        public List<decimal> Cumplimientos { get; set; }
    }
}

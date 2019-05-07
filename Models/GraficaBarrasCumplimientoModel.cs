using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaKPI_API.Models
{
    public class GraficaBarrasCumplimientoModel
    {
        public string NombreProducto { get; set; }
        public List<decimal> NumBolsasEntregadas { get; set; }
        public List<int> numBolsasPedidoDiario { get; set; }
    }
}

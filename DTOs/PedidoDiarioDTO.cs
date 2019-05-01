using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaKPI_API.DTOs
{
    public class PedidoDiarioDTO
    {
        public string IdProducto { get; set; }
        public int NumBolsas { get; set; }
        public int NumDia { get; set; }
    }
}

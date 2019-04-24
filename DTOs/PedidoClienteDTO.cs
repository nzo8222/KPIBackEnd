using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaKPI_API.DTOs
{
    public class PedidoClienteDTO
    {
        public List<PedidoDiarioDTO> PedidoDiarioDTO { get; set; }
        public DateTime FechaI { get; set; }
        public DateTime FechaF { get; set; }

    }
}

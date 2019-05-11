using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaKPI_API.DTOs
{
    public class PedidoSemanalEditDTO
    {
        public Guid IdPedidoSemanal { get; set; }
        public Guid IdProducto { get; set; }
        public int NumBolLunes { get; set; }
        public int NumBolMartes { get; set; }
        public int NumBolMiercoles { get; set; }
        public int NumBolJueves { get; set; }
        public int NumBolViernes { get; set; }
        public int NumBolSabado { get; set; }
        public int NumBolDomingo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}

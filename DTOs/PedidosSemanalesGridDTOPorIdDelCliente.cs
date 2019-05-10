using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaKPI_API.DTOs
{
    public class PedidosSemanalesGridDTOPorIdDelCliente
    {
        public Guid IdPedidoSemanal { get; set; }
        public string NombreProducto { get; set; }
        public int CodigoProducto { get; set; }
        public string Cliente { get; set; }
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

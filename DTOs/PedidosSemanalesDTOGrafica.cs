using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaKPI_API.DTOs
{
    public class PedidosSemanalesDTOGrafica
    {
        public Guid IdPedidoSemanal { get; set; }
        public string NombreProducto { get; set; }
        public int NumBolsas { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal promedioCumplimiento { get; set; }
    }
}

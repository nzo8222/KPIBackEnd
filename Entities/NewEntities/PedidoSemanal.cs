using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaKPI_API.Entities
{
    public class PedidoSemanal
    {
        [Key]
        public Guid IdPedidoSemanal { get; set; }
        //[ForeignKey("IdPedidoDiario")]
        public List<PedidoDiario> IdPedidoDiario { get; set; }
        public DateTime FechaInicioSemana { get; set; }
        public DateTime FechaFinSemana { get; set; }
    }
}

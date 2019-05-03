using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaKPI_API.Entities
{
    public class PedidoDiario
    {
        [Key]
        public Guid IdPedidoDiario { get; set; }

        [ForeignKey("IdProducto")]
        public Producto Producto { get; set; }
        [ForeignKey("IdPedidoSemanal")]
        public PedidoSemanal PedidoSemanal { get; set; }
        public int NumBolsas { get; set; }
        public int NumDia { get; set; }
        public decimal Cumplimiento { get; set; }
        public PedidoDiario()
        {

        }
        public PedidoDiario(Guid id, int bolsas, int dia)
        {
            IdPedidoDiario = id;
            NumBolsas = bolsas;
            NumDia = dia;

        }
    }
}

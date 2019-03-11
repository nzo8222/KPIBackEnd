using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaKPI_API.Entities
{
    public class Pedido
    {
        [Key]
        public Guid IdPedido { get; set; }

        [ForeignKey("IdCliente")]
        public Cliente Cliente { get; set; }

        [ForeignKey("IdProducto")]
        public virtual List<ProductoDetalle> Productos { get; set; }


    }
}

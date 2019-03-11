using SistemaKPI_API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaKPI_API.Entities
{
    public class PedidoCliente
    {
        [Key]
        public Guid IdPedidoCliente { get; set; }

        public DateTime FechaRegistro { get; set; }

        public DateTime FechaEntrega { get; set; }

        public virtual List<ProductoInventario> ProductosContpaq { get; set; }

    }
}

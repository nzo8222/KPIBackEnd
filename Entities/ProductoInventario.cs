using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaKPI_API.Entities
{
    public class ProductoInventario
    {
        [Key]
        public Guid IdProductoInventario { get; set; }
        public string RazonSocial { get; set; }
        public string NombreProducto { get; set; }
        public string CodigoProducto { get; set; }
        public int CantidadPiezas { get; set; }

        [ForeignKey("IdPedidoCliente")]
        public Guid IdPedidoCliente { get; set; }
    }
}

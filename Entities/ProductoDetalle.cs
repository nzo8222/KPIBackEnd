using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaKPI_API.Entities
{
    public class ProductoDetalle
    {
        [Key]
        public Guid IdProductoDetalle { get; set; }
        [ForeignKey("IdProducto")]
        public Producto Producto { get; set; }
        public decimal Cantidad { get; set; }
        public decimal CostoUnitario { get; set; }
        public decimal Total { get; set; }
    }
}

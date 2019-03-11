using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaKPI_API.Entities
{
    public class Producto
    {
        [Key]
        public Guid IdProducto { get; set; }
        public int CodigoProducto { get; set; }
        public decimal Precio { get; set; }
        public string Descripcion { get; set; }
    }
}

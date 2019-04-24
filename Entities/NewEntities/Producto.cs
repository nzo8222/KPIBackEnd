using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaKPI_API.Entities
{
    public class Producto
    {
        [Key]
        public Guid IdProducto { get; set; }

        public Cliente IdCliente { get; set; }

        public int CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
    }
}

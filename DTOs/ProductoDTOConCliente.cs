using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaKPI_API.DTOs
{
    public class ProductoDTOConCliente
    {
        public string NombreProducto { get; set; }
        public int CodigoProducto { get; set; }
        public Guid idCliente { get; set; }
    }
}

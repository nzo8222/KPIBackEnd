using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaKPI_API.DTOs
{
    public class ProductoDTOSinCliente
    {
        public Guid IdProducto { get; set; }
        public int CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
    }
}

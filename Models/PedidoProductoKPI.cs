using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaKPI_API.Models
{
    public class PedidoProductoKPI
    {
        public string RazonSocial { get; set; }
        public string NombreProducto { get; set; }
        public string CodigoProducto { get; set; }
        public string CantidadPiezas { get; set; }
        public string Cumplimiento { get; set; }
        public string Devoluciones { get; set; }
        public string Discrepancia { get; set; }


        public string FechaRegistro { get; set; }

        public string FechaEntrega { get; set; }
    }
}

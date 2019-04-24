using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaKPI_API.Models
{
    public class PedidoProductoKPI
    {
        public Guid IdProductoInventario { get; set; }
        public string RazonSocial { get; set; }
        public string NombreProducto { get; set; }
        public string CodigoProducto { get; set; }
        public string CantidadBolsas { get; set; }
        public string Cumplimiento { get; set; }
        public string Devoluciones { get; set; }
        public string Discrepancia { get; set; }


        public DateTime FechaRegistro { get; set; }

        public DateTime FechaEntrega { get; set; }
    }
}

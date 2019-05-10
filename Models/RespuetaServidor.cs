using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaKPI_API.Models
{
    public class RespuestaServidor
    {
        public bool Exitoso { get; set; }
        public string MensajeError { get; set; }

        public object Payload { get; set; }
    }
}

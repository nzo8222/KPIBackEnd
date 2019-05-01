using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaKPI_API.DTOs
{
    public class LogInDTO
    {
        public string Usuario { get; set; }

        public string Password { get; set; }

        public bool Recordar { get; set; }
    }
}

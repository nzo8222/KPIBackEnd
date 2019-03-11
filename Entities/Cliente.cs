using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaKPI_API.Entities
{
    public class Cliente
    {
        [Key]
        public Guid IdCliente { get; set; }
        public string Nombre { get; set; }
    }
}

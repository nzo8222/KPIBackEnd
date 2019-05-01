using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaKPI_API.Entities.NewEntities
{
    public class Usuario : IdentityUser<Guid>
    {
        [Key]
        public Guid IdUsuario { get; set; }
    }
}

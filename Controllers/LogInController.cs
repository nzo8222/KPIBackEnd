using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SistemaKPI_API.DTOs;
using SistemaKPI_API.Entities.NewEntities;
using SistemaKPI_API.Models;

namespace SistemaKPI_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogInController : ControllerBase
    {
        private readonly UserManager<Usuario> _usrMngr;

        public LogInController(UserManager<Usuario> usrMngr)
        {
            _usrMngr = usrMngr;
        }

        [HttpPost]
        [Route("Registro")]
        public async Task<IActionResult> RegistroUsuario([FromBody]RegistroUsuarioDTO usuario)
        {
            var user = new Usuario
            {
                IdUsuario = Guid.NewGuid(),
                Email = usuario.Email,
                UserName = usuario.Usuario,
            };

            var result = await _usrMngr.CreateAsync(user, usuario.Password);

            if (!result.Succeeded) return new OkObjectResult(new RespuestaServidor
            { Exitoso = false, MensajeError = "No se pudo crear el usuario." }
         );

            return new OkObjectResult(new RespuestaServidor
            { Exitoso = true, MensajeError = string.Empty }
           );
            ;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LogInUsuario([FromBody]LogInDTO logInDTO)
        {
            // Comprueba credenciales.
            if (string.IsNullOrEmpty(logInDTO.Usuario) || string.IsNullOrEmpty(logInDTO.Password))
            {
                return new OkObjectResult(new RespuestaServidor
                { Exitoso = true, MensajeError = "Es necesario ingresar información de inicio de sesión." });
            };

            // Se busca al usuario dentro del servicio de Identity.
            var user = await _usrMngr.FindByNameAsync(logInDTO.Usuario);

            if (user == null)
            {
                return new OkObjectResult(new RespuestaServidor
                { Exitoso = false, MensajeError = "No se encontró el usuario." });
            };

            // Valida el password
            var passwordCheck = await _usrMngr.CheckPasswordAsync(user, logInDTO.Password);

            if (!passwordCheck)
            {
                return new OkObjectResult(new RespuestaServidor
                { Exitoso = false, MensajeError = "Password no coincide." });
            }

            return new OkObjectResult(new RespuestaServidor
            { Exitoso = true, MensajeError = string.Empty });
        }

    }
}
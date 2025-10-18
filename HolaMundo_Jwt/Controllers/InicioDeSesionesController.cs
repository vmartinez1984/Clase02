using AutorizacionJwtServicio;
using HolaMundo_AuthBasic.Dtos;
using HolaMundo_AuthBasic.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HolaMundo_Jwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InicioDeSesionesController : ControllerBase
    {
        private readonly TokenServicio _tokenServicio;

        public InicioDeSesionesController(TokenServicio tokenServicio)
        {
            this._tokenServicio = tokenServicio;
        }

        [HttpPost]
        public async Task<IActionResult> IniciarSesion(InicioDeSesionDto inicioDeSesion)
        {
            //Esto deberia esta en la capa de reglas de negocio
            UsuarioEntidad usuario = await ObtenerAsync(inicioDeSesion.Correo);
            string token;

            if (usuario == null)
            {
                token = string.Empty;
            }
            if (EsValido(usuario.Contrasenia, inicioDeSesion.Contrasenia))
            {

                DateTime fechaDeExpiracion = DateTime.Now.AddMinutes(20);
                token = _tokenServicio.ObtenerToken(usuario.Nombre, usuario.Role, "1", usuario.Correo, fechaDeExpiracion);
            }
            else
            {
                token = string.Empty;
            }
            // fin de la capa de negocios

            if (token == null)
            {
                return NotFound(new { Mensaje = "Credenciales no validad" });
            }
            else
            {
                return Ok(new { Token = token });
            }

        }

        /// <summary>
        /// Aqui se deberia comparar los hash 
        /// </summary>
        /// <param name="contrasenia1"></param>
        /// <param name="contrasenia2"></param>
        /// <returns></returns>
        private bool EsValido(string contrasenia1, string contrasenia2)
        {
            if (contrasenia1 == contrasenia2)
                return true;

            return false;
        }



        /// <summary>
        /// Aqui deberia ir a la base de datos, su capa repositprio o persistencia
        /// </summary>
        /// <param name="correo"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private async Task<UsuarioEntidad> ObtenerAsync(string correo)
        {

            return new UsuarioEntidad
            {
                Contrasenia = "123456",
                Correo = "juan@hernandez",
                Nombre = "Juan Hernandez",
                Role = "Cliente"
            };
        }
    }
}

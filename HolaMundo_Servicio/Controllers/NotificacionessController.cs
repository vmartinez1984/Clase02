using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotificacionServicio;

namespace HolaMundo_Servicio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificacionessController : ControllerBase
    {
        private readonly Notificacion _notificacion;

        public NotificacionessController(Notificacion notificacion)
        {
            _notificacion = notificacion;
        }

        [HttpGet]
        public async Task<IActionResult> EnviarPorCorreo()
        {
            await _notificacion.EnviarPorCorreoAsync();

            return Ok();
        }
    }
}

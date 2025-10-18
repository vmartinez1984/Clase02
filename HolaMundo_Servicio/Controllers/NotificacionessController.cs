using Microsoft.AspNetCore.Mvc;
using NotificacionesServicio;

namespace HolaMundo_Servicio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificacionessController : ControllerBase
    {
        private readonly NotificacionServicio _notificacion;

        public NotificacionessController(NotificacionServicio notificacion)
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

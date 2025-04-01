using Microsoft.AspNetCore.Mvc;
using SistemaGestionDeCalidad.BLL.Servicios.Contrato;
using SistemaGestionDeCalidad.DTO;
using SistemaGestionDeCalidad.MODEL;
using SistemaGestionDeCalidad.DAL.Repositorios.Contrato;
using System;
using System.Threading.Tasks;

namespace SistemaGestionDeCalidad.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificacionesController : ControllerBase
    {
        private readonly INotificacionesService _notificacionesService;
        private readonly IGenericRepository<Usuarios> _usuarioRepo;  // Inyectar el repositorio de usuarios
        private readonly IGenericRepository<Notificaciones> _notificacionesRepo; // Inyectar el repositorio de notificaciones

        public NotificacionesController(
            INotificacionesService notificacionesService,
            IGenericRepository<Usuarios> usuarioRepo,
            IGenericRepository<Notificaciones> notificacionesRepo)
        {
            _notificacionesService = notificacionesService;
            _usuarioRepo = usuarioRepo;
            _notificacionesRepo = notificacionesRepo;
        }

        [HttpGet("{idUsuario}")]
        public async Task<IActionResult> ObtenerNotificaciones(int idUsuario)
        {
            var resultado = await _notificacionesService.ObtenerNotificacionesAsync(idUsuario);
            return Ok(resultado);
        }

        [HttpPut("{id}/marcar-como-leida")]
        public async Task<IActionResult> MarcarComoLeida(int id)
        {
            var resultado = await _notificacionesService.MarcarComoLeidaAsync(id);
            if (!resultado)
                return NotFound();
            return NoContent();
        }
    }
}

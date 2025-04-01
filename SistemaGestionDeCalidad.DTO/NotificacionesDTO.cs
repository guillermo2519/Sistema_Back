using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGestionDeCalidad.DTO
{
    public class NotificacionesDTO
    {
        public int? Id { get; set; }              // ID de la notificación
        public string? Mensaje { get; set; }      // Mensaje de la notificación
        public string? Tipo { get; set; }         // Tipo de la notificación (info, alerta, etc.)
        public DateTime? FechaCreacion { get; set; } // Fecha de creación
        public bool? Leido { get; set; }          // Si la notificación ha sido leída (true o false)

        // Si necesitas incluir información del usuario o empresa en el DTO, podrías agregar:
        public int? IdUsuario { get; set; }       // ID del usuario
        public int? IdEmpresa { get; set; }       // ID de la empresa
    }
}

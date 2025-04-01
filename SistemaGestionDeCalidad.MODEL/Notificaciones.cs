using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionDeCalidad.MODEL
{
    public class Notificaciones
    {
        public int? Id { get; set; }               // ID de la notificación
        public int? IdUsuario { get; set; }        // ID del usuario al que va dirigida la notificación
        public int? IdEmpresa { get; set; }        // ID de la empresa asociada a la notificación
        public string? Mensaje { get; set; }       // Mensaje de la notificación
        public string? Tipo { get; set; }          // Tipo de la notificación (info, alerta, etc.)
        public DateTime? FechaCreacion { get; set; }  // Fecha y hora de creación de la notificación
        public bool? Leido { get; set; }           // Si la notificación ha sido leída (true o false)
    }

}

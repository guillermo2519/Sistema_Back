using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaGestionDeCalidad.DTO;

namespace SistemaGestionDeCalidad.BLL.Servicios.Contrato
{
    public interface INotificacionesService
    {
        Task<List<NotificacionesDTO>> ObtenerNotificacionesAsync(int idUsuario);
        Task<NotificacionesDTO> ObtenerNotificacionPorIdAsync(int id);
        Task<int> CrearNotificacionAsync(NotificacionesDTO modelo);
        Task<bool> MarcarComoLeidaAsync(int id);
    }
}
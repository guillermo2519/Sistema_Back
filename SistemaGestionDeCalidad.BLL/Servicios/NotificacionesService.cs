using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SistemaGestionDeCalidad.BLL.Servicios.Contrato;
using SistemaGestionDeCalidad.DAL.Repositorios.Contrato;
using SistemaGestionDeCalidad.DTO;
using SistemaGestionDeCalidad.MODEL;

namespace SistemaGestionDeCalidad.BLL.Servicios
{
    public class NotificacionesService : INotificacionesService
    {
        private readonly IGenericRepository<Notificaciones> _notificacionesRepo;
        private readonly IMapper _mapper;

        public NotificacionesService(IGenericRepository<Notificaciones> notificacionesRepo, IMapper mapper)
        {
            _notificacionesRepo = notificacionesRepo;
            _mapper = mapper;
        }

        public async Task<List<NotificacionesDTO>> ObtenerNotificacionesAsync(int idUsuario)
        {
            var notificaciones = await _notificacionesRepo.Consultar(x => x.IdUsuario == idUsuario);
            return _mapper.Map<List<NotificacionesDTO>>(notificaciones);
        }

        public async Task<NotificacionesDTO> ObtenerNotificacionPorIdAsync(int id)
        {
            var notificacion = await _notificacionesRepo.Obtener(x => x.Id == id);
            return _mapper.Map<NotificacionesDTO>(notificacion);
        }

        public async Task<int> CrearNotificacionAsync(NotificacionesDTO modelo)
        {
            var notificacion = _mapper.Map<Notificaciones>(modelo);
            notificacion.FechaCreacion = DateTime.Now;
            var resultado = await _notificacionesRepo.Crear(notificacion);
            return resultado.Id ?? 0;
        }

        public async Task<bool> MarcarComoLeidaAsync(int id)
        {
            var notificacion = await _notificacionesRepo.Obtener(x => x.Id == id);
            if (notificacion == null)
                return false;

            notificacion.Leido = true;
            return await _notificacionesRepo.Editar(notificacion);
        }
    }

}

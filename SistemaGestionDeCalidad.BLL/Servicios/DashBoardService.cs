using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaGestionDeCalidad.BLL.Servicios.Contrato;
using SistemaGestionDeCalidad.DAL.Repositorios.Contrato;
using SistemaGestionDeCalidad.DTO;
using SistemaGestionDeCalidad.MODEL;

namespace SistemaGestionDeCalidad.BLL.Servicios
{
    public class DashBoardService : IDashBoardService
    {
        private readonly IGenericRepository<Usuarios> _usuariosRepository;
        private readonly IGenericRepository<Auditorias> _auditoriasRepository;
        private readonly IGenericRepository<Indicadores> _indicadoresRepository;
        private readonly IGenericRepository<Roles> _rolesRepository;
        private readonly IMapper _mapper;

        public DashBoardService(IGenericRepository<Usuarios> usuariosRepository, 
            IGenericRepository<Auditorias> auditoriasRepository, IGenericRepository<Indicadores> indicadoresRepository,
            IGenericRepository<Roles> rolesRepository, IMapper mapper)
        {
            _usuariosRepository = usuariosRepository;
            _auditoriasRepository = auditoriasRepository;
            _indicadoresRepository = indicadoresRepository;
            _rolesRepository = rolesRepository;
            _mapper = mapper;
        }

        // Método para obtener auditorías programadas para la fecha actual
        public async Task<IEnumerable<AuditoriasDTO>> GetAuditoriasHoyAsync()
        {
            var hoy = DateTime.Today;

            // Usamos 'await' con 'ToListAsync' para consultas asincrónicas con EF Core
            var auditorias = await _auditoriasRepository
                .Consultar(a => a.FechaProgramada.HasValue && a.FechaProgramada.Value.Date == hoy);

            return _mapper.Map<IEnumerable<AuditoriasDTO>>(auditorias);
        }

        public async Task<DashBoardDTO> Resumen()
        {
            DashBoardDTO vmDashBoard = new DashBoardDTO();

            try
            {
                // Lógica para poblar vmDashBoard con datos relevantes
            }
            catch (Exception ex)
            {
                // Manejo de errores y registro
                throw;
            }

            return vmDashBoard; // Devuelve el objeto al final
        }




    }
}

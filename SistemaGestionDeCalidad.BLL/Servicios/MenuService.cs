using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaGestionDeCalidad.BLL.Servicios.Contrato;
using SistemaGestionDeCalidad.DAL.Repositorios.Contrato;
using SistemaGestionDeCalidad.DTO;
using SistemaGestionDeCalidad.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionDeCalidad.BLL.Servicios
{
    public class MenuService : IMenuService
    {
        private readonly IGenericRepository<Menu> _menuRol;
        private readonly IMapper _mapper;

        public MenuService(IGenericRepository<Menu> menuRol, IMapper mapper)
        {
            _menuRol = menuRol;
            _mapper = mapper;
        }

        public async Task<List<MenuDTO>> Listas()
        {
            try
            {
                var listaMenu = await _menuRol.Consultar(); // Obtener todos los menús
                return _mapper.Map<List<MenuDTO>>(listaMenu.ToList()); // Mapear a MenuDTO
            }
            catch
            {
                throw;
            }
        }

        public async Task<MenuDTO> Resumen(int IdUsuario)
        {
            try
            {
                var menuQuery = await _menuRol.Consultar(m => m.IdMenu == IdUsuario); // Filtrar por IdUsuario
                var menu = await menuQuery.FirstOrDefaultAsync(); // Obtener el primer resultado
                return _mapper.Map<MenuDTO>(menu); // Mapear a MenuDTO
            }
            catch
            {
                throw;
            }
        }




    }



}

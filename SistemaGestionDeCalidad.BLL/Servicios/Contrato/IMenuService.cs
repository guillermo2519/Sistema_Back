using SistemaGestionDeCalidad.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaGestionDeCalidad.DTO;

namespace SistemaGestionDeCalidad.BLL.Servicios.Contrato
{
    public interface IMenuService
    {
        Task<MenuDTO> Resumen(int IdUsuario);
        Task<List<MenuDTO>> Listas();
    }
}

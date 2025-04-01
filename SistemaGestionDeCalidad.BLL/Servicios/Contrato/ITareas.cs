using SistemaGestionDeCalidad.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionDeCalidad.BLL.Servicios.Contrato
{
    public interface ITareas
    {
        Task<List<TareasDTO>> Lista();
        Task<TareasDTO> Crear(TareasDTO modelo);
        Task<bool> Editar(TareasDTO modelo);
        Task<bool> EditarEstado(TareasDTO modelo);
        Task<bool> Eliminar(int id);
    }
}

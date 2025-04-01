using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaGestionDeCalidad.DTO;

namespace SistemaGestionDeCalidad.BLL.Servicios.Contrato
{
    public interface IControl_Documental 
    {
        Task<List<Control_DocumentalDTO>> Lista();
        Task<Control_DocumentalDTO> Crear(Control_DocumentalDTO modelo);
        Task<bool> Editar(Control_DocumentalDTO modelo);
        Task<bool> EditarEstado(Control_DocumentalDTO modelo);
        Task<bool> Eliminar(int id);
    }
}

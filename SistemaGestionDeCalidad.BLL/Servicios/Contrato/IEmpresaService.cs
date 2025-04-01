using SistemaGestionDeCalidad.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionDeCalidad.BLL.Servicios.Contrato
{
    public interface IEmpresaService
    {
        Task<List<EmpresaDTO>> Lista();
        Task<EmpresaDTO> Crear(EmpresaDTO modelo);
        Task<bool> Editar(EmpresaDTO modelo);
        Task<bool> Eliminar(int id);
    }
}

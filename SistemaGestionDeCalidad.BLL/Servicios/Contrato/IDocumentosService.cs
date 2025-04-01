using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaGestionDeCalidad.DTO;

namespace SistemaGestionDeCalidad.BLL.Servicios.Contrato
{
    public interface IDocumentosService
    {
        Task<List<DocumentosDTO>> Lista();
        Task<DocumentosDTO> Crear(DocumentosDTO modelo);
        Task<bool> Editar(DocumentosDTO modelo);
        Task<bool> Eliminar(int id);
    }
}

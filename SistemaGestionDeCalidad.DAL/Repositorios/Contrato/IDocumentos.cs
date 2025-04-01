using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaGestionDeCalidad.MODEL;

namespace SistemaGestionDeCalidad.DAL.Repositorios.Contrato
{
    public interface IDocumentos
    {
        Task<Documentos> Registrar(Documentos modelo);


    }
}

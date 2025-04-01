using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Linq.Expressions;

namespace SistemaGestionDeCalidad.DAL.Repositorios.Contrato
{
    public interface IGenericRepository<TModel> where TModel : class
    {
        Task<TModel> Obtener(Expression<Func<TModel, bool>> filtro); //obtener un modelo, ya sea un menu, usuario, rol, etc
        Task<TModel> Crear(TModel modelo); //crear un nuevo menu, etc
        Task<bool> Editar(TModel modelo); 
        Task<bool> Eliminar(TModel modelo);
        Task<bool> EditarEstado(TModel modelo);
        Task<IQueryable<TModel>> Consultar(Expression<Func<TModel, bool>> filtro = null); //Devuelve una consulta no un modelo

    }
}

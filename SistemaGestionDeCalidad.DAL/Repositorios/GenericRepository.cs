using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaGestionDeCalidad.DAL.Repositorios.Contrato;
using SistemaGestionDeCalidad.DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace SistemaGestionDeCalidad.DAL.Repositorios
{
    public class GenericRepository<TModel> : IGenericRepository<TModel> where TModel : class
    {
        //Variable solo de lectura
        private readonly SgcDbContext _dbcontext;

        public GenericRepository(SgcDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<TModel> Obtener(Expression<Func<TModel, bool>> filtro)
        {
            try
            {
                TModel modelo = await _dbcontext.Set<TModel>().FirstOrDefaultAsync(filtro);
                return modelo;
            }
            catch{
                throw;
            }
        }
        public async Task<TModel> Crear(TModel modelo)
        {
            try
            {
                _dbcontext.Set<TModel>().Add(modelo);
                await _dbcontext.SaveChangesAsync();
                return modelo;
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> Editar(TModel modelo)
        {
            try
            {
                _dbcontext.Set<TModel>().Update(modelo);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> EditarEstado(TModel modelo)
        {
            try
            {
                _dbcontext.Set<TModel>().Update(modelo);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> Eliminar(TModel modelo)
        {
            try
            {
                _dbcontext.Set<TModel>().Remove(modelo);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }
        public async Task<IQueryable<TModel>> Consultar(Expression<Func<TModel, bool>> filtro = null)
        {
            try
            {
                IQueryable<TModel> queryModelo = filtro == null ? _dbcontext.Set<TModel>() : _dbcontext.Set<TModel>().Where(filtro);
                return queryModelo;
            }
            catch
            {
                throw;
            }
        }

    }
}

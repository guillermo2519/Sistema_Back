using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaGestionDeCalidad.DAL.Repositorios.Contrato;
using SistemaGestionDeCalidad.DAL.DBContext;
using SistemaGestionDeCalidad.MODEL;

namespace SistemaGestionDeCalidad.DAL.Repositorios
{
    public class DocumentosRepository : GenericRepository<Documentos>, IDocumentos 
    {
        private readonly SgcDbContext _dbcontext;

        public DocumentosRepository(SgcDbContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Documentos> Registrar(Documentos modelo)
        {
            Documentos DocumentoGenerado = new Documentos();

            using (var CreateDoc = _dbcontext.Database.BeginTransaction())
            {
                try
                {
                    // Agregamos el modelo a la entidad Documentos
                    var documentoGenerado = await _dbcontext.Set<Documentos>().AddAsync(modelo);
                    await _dbcontext.SaveChangesAsync();

                    // Confirmamos la transacción
                    await CreateDoc.CommitAsync();

                    return documentoGenerado.Entity; // Devolvemos el documento registrado
                }
                catch (Exception ex)
                {
                    // Si hay un error, revertimos la transacción
                    await CreateDoc.RollbackAsync();
                    throw new Exception("Error al registrar el documento", ex);
                }
            }

        }

    }
}

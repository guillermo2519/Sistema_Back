using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using SistemaGestionDeCalidad.BLL.Servicios.Contrato;
using SistemaGestionDeCalidad.DAL.Repositorios.Contrato;
using SistemaGestionDeCalidad.DTO;
using SistemaGestionDeCalidad.MODEL;

namespace SistemaGestionDeCalidad.BLL.Servicios
{
    public class DocumentosService : IDocumentosService
    {

        private readonly IGenericRepository<Documentos> _documentoRepositorio;
        private readonly IMapper _mapper;

        public DocumentosService(IGenericRepository<Documentos> documentoRepositorio, IMapper mapper)
        {
            _documentoRepositorio = documentoRepositorio;
            _mapper = mapper;
        }

        public async Task<List<DocumentosDTO>> Lista()
        {
            var documentos = await _documentoRepositorio.Consultar();
            return _mapper.Map<List<DocumentosDTO>>(documentos);
        }

        public async Task<DocumentosDTO> Crear(DocumentosDTO modelo)
        {
            var documentoCreado = await _documentoRepositorio.Crear(_mapper.Map<Documentos>(modelo));
            return _mapper.Map<DocumentosDTO>(documentoCreado);
        }

        public async Task<bool> Editar(DocumentosDTO modelo)
        {
            var documento = _mapper.Map<Documentos>(modelo);
            var documentoEncontrado = await _documentoRepositorio.Obtener(d => d.Id == documento.Id);

            if (documentoEncontrado == null)
                throw new TaskCanceledException("El documento no existe.");

            documentoEncontrado.Titulo = documento.Titulo;
            documentoEncontrado.Descripcion = documento.Descripcion;

            return await _documentoRepositorio.Editar(documentoEncontrado);
        }

        public async Task<bool> Eliminar(int id)
        {
            var documentoEncontrado = await _documentoRepositorio.Obtener(d => d.Id == id);
            if (documentoEncontrado == null)
                throw new TaskCanceledException("El documento no existe.");

            return await _documentoRepositorio.Eliminar(documentoEncontrado);
        }


    }
}

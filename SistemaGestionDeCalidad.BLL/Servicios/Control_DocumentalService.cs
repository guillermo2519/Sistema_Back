using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SistemaGestionDeCalidad.BLL.Servicios.Contrato;
using SistemaGestionDeCalidad.DAL.Repositorios.Contrato;
using SistemaGestionDeCalidad.DTO;
using SistemaGestionDeCalidad.MODEL;


namespace SistemaGestionDeCalidad.BLL.Servicios
{
    public class Control_DocumentalService : IControl_Documental
    {
        private readonly IGenericRepository<ControlDocumental> _documentoRepositorio;
        private readonly IMapper _mapper;

        public Control_DocumentalService(IGenericRepository<ControlDocumental> documentoRepositorio, IMapper mapper)
        {
            _documentoRepositorio = documentoRepositorio;
            _mapper = mapper;
        }

        public async Task<List<Control_DocumentalDTO>> Lista()
        {
            // Espera la consulta primero, luego aplica el Include
            var documentos = await _documentoRepositorio.Consultar(); // Esto devuelve IQueryable<ControlDocumental>

            // Ahora aplica Include
            var documentosConUsuario = documentos.Include(d => d.Usuario);

            // Convierte a lista y mapea
            return _mapper.Map<List<Control_DocumentalDTO>>(await documentosConUsuario.ToListAsync());
        }


        public async Task<Control_DocumentalDTO> Crear(Control_DocumentalDTO modelo)
        {
            var documentoCreado = await _documentoRepositorio.Crear(_mapper.Map<ControlDocumental>(modelo));
            return _mapper.Map<Control_DocumentalDTO>(documentoCreado);
        }

        public async Task<bool> Editar(Control_DocumentalDTO modelo)
        {
            var documento = _mapper.Map<ControlDocumental>(modelo);
            var documentoEncontrado = await _documentoRepositorio.Obtener(d => d.ID == documento.ID);

            if (documentoEncontrado == null)
                throw new TaskCanceledException("El documento no existe.");

            // Aquí se actualizan los valores de la entidad
            documentoEncontrado.MOTIVO_ALTA = documento.MOTIVO_ALTA;
            documentoEncontrado.TIPO_DOCUMENTO = documento.TIPO_DOCUMENTO;
            documentoEncontrado.CODIGO = documento.CODIGO;
            documentoEncontrado.TIEMPO_RETENCION = documento.TIEMPO_RETENCION;
            documentoEncontrado.PROCESO = documento.PROCESO;
            documentoEncontrado.APRUEBA = documento.APRUEBA;
            documentoEncontrado.NOMBRE_DOCUMENTO = documento.NOMBRE_DOCUMENTO;
            documentoEncontrado.ARCHIVO_URL = documento.ARCHIVO_URL;
            //documentoEncontrado.ESTADO = documento.ESTADO;

            return await _documentoRepositorio.Editar(documentoEncontrado);
        }

        public async Task<bool> EditarEstado(Control_DocumentalDTO modelo)
        {
            var documento = _mapper.Map<ControlDocumental>(modelo);
            var documentoEncontrado = await _documentoRepositorio.Obtener(d => d.ID == documento.ID);

            if (documentoEncontrado == null)
                throw new TaskCanceledException("El documento no existe.");

            // Aquí se actualizan los valores de la entidad
            documentoEncontrado.MOTIVO_ALTA = documento.MOTIVO_ALTA;
            documentoEncontrado.TIPO_DOCUMENTO = documento.TIPO_DOCUMENTO;
            documentoEncontrado.CODIGO = documento.CODIGO;
            documentoEncontrado.TIEMPO_RETENCION = documento.TIEMPO_RETENCION;
            documentoEncontrado.PROCESO = documento.PROCESO;
            documentoEncontrado.APRUEBA = documento.APRUEBA;
            documentoEncontrado.NOMBRE_DOCUMENTO = documento.NOMBRE_DOCUMENTO;
            documentoEncontrado.ARCHIVO_URL = documento.ARCHIVO_URL;
            documentoEncontrado.ESTADO = documento.ESTADO;
            documentoEncontrado.COMENTARIOS = documento.COMENTARIOS; // Agregado

            return await _documentoRepositorio.EditarEstado(documentoEncontrado);
        }


        public async Task<bool> Eliminar(int id)
        {
            var documentoEncontrado = await _documentoRepositorio.Obtener(d => d.ID == id);
            if (documentoEncontrado == null)
                throw new TaskCanceledException("El documento no existe.");

            return await _documentoRepositorio.Eliminar(documentoEncontrado);
        }


    }
}

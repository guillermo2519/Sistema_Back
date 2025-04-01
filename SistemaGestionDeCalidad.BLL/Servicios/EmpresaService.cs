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
    public class EmpresaService : IEmpresaService
    {
        private readonly IGenericRepository<Empresa> _empresaRepositorio;
        private readonly IMapper _mapper;
        private readonly ILogger<EmpresaService> _logger;

        public EmpresaService(IGenericRepository<Empresa> empresaRepositorio, IMapper mapper, ILogger<EmpresaService> logger)
        {
            _empresaRepositorio = empresaRepositorio;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<EmpresaDTO>> Lista()
        {
            // Espera el resultado de la consulta
            var empresas = await _empresaRepositorio.Consultar();

            // Llama a ToListAsync sobre el IQueryable resultante
            var listaEmpresas = await empresas.ToListAsync();

            // Mapea la lista a DTOs
            return _mapper.Map<List<EmpresaDTO>>(listaEmpresas);
        }


        public async Task<EmpresaDTO> Crear(EmpresaDTO modelo)
        {
            var documentoCreado = await _empresaRepositorio.Crear(_mapper.Map<Empresa>(modelo));
            return _mapper.Map<EmpresaDTO>(documentoCreado);
        }

        public async Task<bool> Editar(EmpresaDTO modelo)
        {
            var empresaId = _mapper.Map<Empresa>(modelo);
            var empresaEncontrada = await _empresaRepositorio.Obtener(d => d.Id == empresaId.Id);

            if (empresaEncontrada == null)
                throw new TaskCanceledException("La empresa no existe.");

            // Aquí se actualizan los valores de la entidad
            empresaEncontrada.Nombre = empresaId.Nombre;
            empresaEncontrada.Direccion = empresaId.Direccion;
            empresaEncontrada.Telefono = empresaId.Telefono;
            empresaEncontrada.Email = empresaId.Email;
            //documentoEncontrado.ESTADO = documento.ESTADO;

            return await _empresaRepositorio.Editar(empresaEncontrada);
        }

        public async Task<bool> Eliminar(int id)
        {
            var empresaEncontrado = await _empresaRepositorio.Obtener(d => d.Id == id);
            if (empresaEncontrado == null)
                throw new TaskCanceledException("La Empresa no existe.");

            return await _empresaRepositorio.Eliminar(empresaEncontrado);
        }

    }
}

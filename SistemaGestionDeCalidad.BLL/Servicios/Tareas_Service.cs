using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    public class Tareas_Service : ITareas
    {
        private readonly IGenericRepository<Tareas> _tareasRepositorio;
        private readonly IMapper _mapper;

        public Tareas_Service(IGenericRepository<Tareas> tareasRepositorio, IMapper mapper)
        {
            _tareasRepositorio = tareasRepositorio;
            _mapper = mapper;
        }

        public async Task<List<TareasDTO>> Lista()
        {
            // Espera la consulta primero, luego aplica el Include
            var documentos = await _tareasRepositorio.Consultar(); // Esto devuelve IQueryable<ControlDocumental>

            // Ahora aplica Include
            var TareasConUsuario = documentos.Include(d => d.Usuario);

            // Convierte a lista y mapea
            return _mapper.Map<List<TareasDTO>>(await TareasConUsuario.ToListAsync());
        }

        public async Task<TareasDTO> Crear(TareasDTO modelo)
        {
            var tareaCreado = await _tareasRepositorio.Crear(_mapper.Map<Tareas>(modelo));
            return _mapper.Map<TareasDTO>(tareaCreado);
        }

        public async Task<bool> Editar(TareasDTO modelo)
        {
            var tarea = _mapper.Map<Tareas>(modelo);
            var tareaEncontrada = await _tareasRepositorio.Obtener(t => t.ID == tarea.ID);

            if (tareaEncontrada == null)
                throw new TaskCanceledException("La tarea no existe.");

            // Verificar que COMPLETED es un valor booleano válido
            if (!bool.TryParse(modelo.COMPLETED.ToString(), out bool completed))
            {
                throw new ArgumentException("El valor de COMPLETED no es válido.");
            }

            // Actualiza solo los campos relevantes en la entidad Tareas
            tareaEncontrada.TITLE = tarea.TITLE;
            tareaEncontrada.DESCRIPCION = tarea.DESCRIPCION;
            tareaEncontrada.COMPLETED = completed;  // Usamos el valor validado
            tareaEncontrada.PROCESO = tarea.PROCESO;
            tareaEncontrada.APRUEBA = tarea.APRUEBA;
            tareaEncontrada.ID_USUARIO = tarea.ID_USUARIO;
            tareaEncontrada.ID_EMPRESA = tarea.ID_EMPRESA;
            tareaEncontrada.UPDATED_AT = DateTime.UtcNow;

            return await _tareasRepositorio.Editar(tareaEncontrada);
        }


        public async Task<bool> EditarEstado(TareasDTO modelo)
        {
            var tarea = _mapper.Map<Tareas>(modelo);
            var tareaEncontrada = await _tareasRepositorio.Obtener(t => t.ID == tarea.ID);

            if (tareaEncontrada == null)
                throw new TaskCanceledException("La tarea no existe.");

            // Actualiza solo los campos relevantes
            tareaEncontrada.COMPLETED = tarea.COMPLETED;

            return await _tareasRepositorio.EditarEstado(tareaEncontrada);
        }


        public async Task<bool> Eliminar(int id)
        {
            var tareaEncontrado = await _tareasRepositorio.Obtener(d => d.ID == id);
            if (tareaEncontrado == null)
                throw new TaskCanceledException("El documento no existe.");

            return await _tareasRepositorio.Eliminar(tareaEncontrado);
        }


    }
}

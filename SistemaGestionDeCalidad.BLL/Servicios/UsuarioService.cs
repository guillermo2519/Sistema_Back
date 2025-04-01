using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public class UsuarioService : IUsuarioService
    {

        private readonly IGenericRepository<Usuarios> _usuarioRepositorio;
        private readonly IMapper _mapper;
        private readonly ILogger<UsuarioService> _logger;

        public UsuarioService(ILogger<UsuarioService> logger,IGenericRepository<Usuarios> usuarioRepositorio, IMapper mapper)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<UsuariosDTO>> Lista()
        {
           try
            {
                var queryUsuario = await _usuarioRepositorio.Consultar();
                var listaUsuarios = queryUsuario.Include(rol => rol.RolNavigation).ToList();

                return _mapper.Map<List<UsuariosDTO>>(listaUsuarios);
            }
            catch
            {
                throw;
            }
        }


        public async Task<SesionDTO> ValidarCredenciales(string correo, string clave)
        {
            try
            {
                var queryUsuario = await _usuarioRepositorio.Consultar(u =>
                    u.Email == correo &&
                    u.PasswordHash == clave
                );

                if (queryUsuario.FirstOrDefault() == null)
                    throw new TaskCanceledException("El Usuario no existe.");

                Usuarios devolverUsuario = queryUsuario.Include(rol => rol.RolNavigation).First();

                return _mapper.Map<SesionDTO>(devolverUsuario);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Operación cancelada: {ex.Message}");
            }
        }

        public async Task<UsuariosDTO> Crear(UsuariosDTO modelo)
        {
            try
            {
                var usuarioCreado = await _usuarioRepositorio.Crear(_mapper.Map<Usuarios>(modelo));

                // Verificar si el idUsuario es 0 después de la creación
                if (usuarioCreado.idUsuario == 0)
                {
                    throw new Exception("Hubo un error al crear el usuario. El ID es 0.");
                }

                var query = await _usuarioRepositorio.Consultar(u => u.idUsuario == usuarioCreado.idUsuario);
                usuarioCreado = query.Include(rol => rol.RolNavigation).First();

                return _mapper.Map<UsuariosDTO>(usuarioCreado);
            }
            catch (Exception ex)
            {
                // Registrar el error para obtener más detalles
                _logger.LogError(ex, "Error al guardar usuario");
                throw; // Re-lanzar el error
            }
        }

        public async Task<bool> Editar(UsuariosDTO modelo)
        {
           try
            {
                var usuarioModelo = _mapper.Map<Usuarios>(modelo);

                var usuarioEncontrado = await _usuarioRepositorio.Obtener(u => u.idUsuario == usuarioModelo.idUsuario);

                if (usuarioEncontrado == null)
                    throw new TaskCanceledException("El usuario no existe.");

                usuarioEncontrado.Nombre = usuarioModelo.Nombre;
                usuarioEncontrado.Email = usuarioModelo.Email;
                usuarioEncontrado.Rol = usuarioModelo.Rol;
                usuarioEncontrado.PasswordHash = usuarioModelo.PasswordHash;
                usuarioEncontrado.IdEmpresa = usuarioModelo.IdEmpresa;
                usuarioEncontrado.Proceso = usuarioModelo.Proceso;


                bool respuesta = await _usuarioRepositorio.Editar(usuarioEncontrado);

                if (!respuesta)
                    throw new TaskCanceledException("No se puedo editar el usuario");

                return respuesta;

            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Operación cancelada: {ex.Message}");
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                var usuarioEncontrado = await _usuarioRepositorio.Obtener(u => u.idUsuario == id);

                if (usuarioEncontrado == null)
                    throw new TaskCanceledException("El Usuario no existe.");

                bool respuesta = await _usuarioRepositorio.Eliminar(usuarioEncontrado);

                if (!respuesta)
                    throw new TaskCanceledException("No se puedo eliminar el usuario");

                return respuesta;

            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Operación cancelada: {ex.Message}");
            }
        }


    }
}

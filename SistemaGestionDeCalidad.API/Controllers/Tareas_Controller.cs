using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using SistemaGestionDeCalidad.BLL.Servicios.Contrato;
using SistemaGestionDeCalidad.DTO;
using SistemaGestionDeCalidad.API.Utilidad;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using SistemaGestionDeCalidad.MODEL;
using SistemaGestionDeCalidad.DAL.DBContext;
using SistemaGestionDeCalidad.BLL.Servicios;

namespace SistemaGestionDeCalidad.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class Tareas_Controller : Controller
    {
        private readonly ITareas _tareasService;
        private readonly ILogger<Tareas_Controller> _logger;
        private readonly SgcDbContext _context;
        public Tareas_Controller(ILogger<Tareas_Controller> logger, ITareas tareasService, SgcDbContext context)
        {
            _tareasService = tareasService;
            _logger = logger;
            _context = context;
        }


        // GET: api/Control_Documental
        [HttpGet]
        [Route("Lista")]
        public async Task<ActionResult<List<TareasDTO>>> GetLista()
        {
            try
            {
                var documentos = await _tareasService.Lista();
                return Ok(documentos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener la lista: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("Crear")]
        public async Task<ActionResult<Tareas>> Crear([FromBody] TareasDTO modelo)
        {
            try
            {
                if (modelo.ID_EMPRESA == null)
                    return BadRequest("El ID_EMPRESA es obligatorio.");

                // Crear el nuevo documento
                var documento = new Tareas
                {
                    TITLE = modelo.TITLE,
                    DESCRIPCION = modelo.DESCRIPCION,
                    COMPLETED = modelo.COMPLETED,
                    PROCESO = modelo.PROCESO,
                    APRUEBA = modelo.APRUEBA,
                    CREATED_AT = DateTime.Now,
                    UPDATED_AT = DateTime.Now,
                    ID_USUARIO = modelo.ID_USUARIO,
                    ID_EMPRESA = modelo.ID_EMPRESA,
                };

                _context.Tareas.Add(documento);
                await _context.SaveChangesAsync();

                // Obtener el usuario y su rol
                var usuario = await _context.Usuarios.FindAsync(modelo.ID_USUARIO);
                if (usuario == null)
                    return BadRequest("El usuario no existe.");

                // Obtener todos los usuarios con el mismo rol
                var usuariosConMismoRol = await _context.Usuarios
                    .Where(u => u.Rol == usuario.Rol)
                    .ToListAsync();

                var notificacion = new Notificaciones
                {
                    IdUsuario = usuario.idUsuario,
                    Mensaje = $"Se ha creado un nuevo documento: {modelo.TITLE}",
                    Tipo = "info",
                    FechaCreacion = DateTime.Now,
                    Leido = false,
                    IdEmpresa = modelo.ID_EMPRESA // Asegura que se está asignando correctamente
                };

                _context.Notificaciones.Add(notificacion);
                await _context.SaveChangesAsync();


                return Ok(documento);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al guardar documento: {ex.Message}");
            }
        }



        // PUT: api/Control_Documental
        [HttpPut]
        [Route("Editar")]
        public async Task<ActionResult> Editar([FromBody] TareasDTO modelo)
        {
            if (modelo == null)
            {
                return BadRequest("El modelo no puede ser nulo.");
            }

            try
            {
                var resultado = await _tareasService.Editar(modelo);
                if (!resultado)
                {
                    return NotFound($"La tarea con ID {modelo.ID} no fue encontrado.");
                }

                return NoContent(); // Responde con un 204 No Content si la actualización fue exitosa
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al editar el documento: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("EditarEstado")]
        public async Task<ActionResult> EditarEstado([FromBody] TareasDTO modelo)
        {
            if (modelo == null)
            {
                return BadRequest("El modelo no puede ser nulo.");
            }

            try
            {
                var resultado = await _tareasService.EditarEstado(modelo);
                if (!resultado)
                {
                    return NotFound($"La tarea con ID {modelo.ID} no fue encontrado.");
                }

                return NoContent(); // Responde con un 204 No Content si la actualización fue exitosa
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al editar el documento: {ex.Message}");
            }
        }


        [HttpPut]
        [Route("ActualizarArchivo/{id}")]
        public async Task<ActionResult> ActualizarArchivo(int id, IFormFile archivo)
        {
            if (archivo == null || archivo.Length == 0)
            {
                return BadRequest("No se proporcionó un archivo.");
            }

            try
            {
                var tarea = await _context.Tareas.FindAsync(id);
                if (tarea == null)
                {
                    return NotFound($"El documento con ID {id} no fue encontrado.");
                }

                // Convertir archivo a Base64
                using (var memoryStream = new MemoryStream())
                {
                    await archivo.CopyToAsync(memoryStream);
                    string base64String = Convert.ToBase64String(memoryStream.ToArray());

                    // Obtener el tipo MIME del archivo
                    string mimeType = archivo.ContentType;

                    // Agregar el prefijo adecuado dependiendo del tipo de archivo
                    string archivoConPrefijo = $"data:{mimeType};base64,{base64String}";

                    // Actualizar en la base de datos
                    //documento.ARCHIVO_URL = archivoConPrefijo;
                    //documento.FECHA_ACTUALIZACION = DateTime.Now;

                    _context.Tareas.Update(tarea);
                    await _context.SaveChangesAsync();
                }

                return Ok(new { mensaje = "Archivo actualizado correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al actualizar el archivo: {ex.Message}");
            }
        }




        // DELETE: api/Control_Documental/5
        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<ActionResult> Eliminar(int id)
        {
            try
            {
                var resultado = await _tareasService.Eliminar(id);
                if (!resultado)
                {
                    return NotFound($"El documento con ID {id} no fue encontrado.");
                }

                return NoContent(); // Responde con un 204 No Content si la eliminación fue exitosa
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al eliminar el documento: {ex.Message}");
            }
        }


    }
}


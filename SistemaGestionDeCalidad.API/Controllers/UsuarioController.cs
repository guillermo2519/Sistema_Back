using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using SistemaGestionDeCalidad.BLL.Servicios.Contrato;
using SistemaGestionDeCalidad.DTO;
using SistemaGestionDeCalidad.API.Utilidad;
using Microsoft.AspNetCore.Cors;

namespace SistemaGestionDeCalidad.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(ILogger<UsuarioController> logger, IUsuarioService usuarioService)
        {
            _logger = logger;
            _usuarioService = usuarioService;
        }


        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var rsp = new Response<List<UsuariosDTO>>();

            try
            {
                rsp.status = true;
                rsp.value = await _usuarioService.Lista();

            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;
            }
            return Ok(rsp);
        }

        [HttpPost]
        [Route("IniciarSesion")]
        [EnableCors("AllowAngularClient")]
        public async Task<IActionResult> IniciarSesion([FromBody] LoginDTO login)
        {
            var rsp = new Response<SesionDTO>();

            try
            {
                // Validar las credenciales del usuario
                var sesion = await _usuarioService.ValidarCredenciales(login.Correo, login.Clave);

                if (sesion == null)
                {
                    rsp.status = false;
                    rsp.msg = "Credenciales inválidas.";
                    return Unauthorized(rsp);
                }

                // Si la validación es exitosa, guardar el idUsuario en la sesión
                HttpContext.Session.SetString("idUsuario", sesion.idUsuario.ToString());
                HttpContext.Session.SetString("idEmpresa", sesion.IdEmpresa.ToString());

                rsp.status = true;
                rsp.value = sesion;
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;
            }

            return Ok(rsp);
        }


        [HttpPost]
        [Route("GuardarUsuario")]
        public async Task<IActionResult> GuardarUsuario([FromBody] UsuariosDTO usuario)
        {
            var rsp = new Response<UsuariosDTO>();
            try
            {
                rsp.status = true;
                rsp.value = await _usuarioService.Crear(usuario);
            }
            catch (Exception ex)
            {
                // Registrar el error para obtener más detalles
                _logger.LogError(ex, "Error al guardar usuario");

                rsp.status = false;
                rsp.msg = $"Error al guardar usuario: {ex.Message}";
            }
            return Ok(rsp);
        }


        [HttpPut]
        [Route("EditarUsuario")]
        public async Task<IActionResult> EditarUsuario([FromBody] UsuariosDTO usuario)
        {
            var rsp = new Response<bool>();

            try
            {
                rsp.status = true;
                rsp.value = await _usuarioService.Editar(usuario);

            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;
            }
            return Ok(rsp);
        }

        [HttpDelete]
        [Route("EliminarUsuario/{id:int}")]
        public async Task<IActionResult> EliminarUsuario(int id)
        {
            var rsp = new Response<bool>();

            try
            {
                rsp.status = true;
                rsp.value = await _usuarioService.Eliminar(id);

            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;
            }
            return Ok(rsp);
        }


    }
}

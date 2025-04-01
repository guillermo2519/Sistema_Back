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
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaService _empresaService;
        private readonly ILogger<EmpresaController> _logger;


        public EmpresaController(ILogger<EmpresaController> logger, IEmpresaService EmpresasService, SgcDbContext context)
        {
            _empresaService = EmpresasService;
            _logger = logger;
        }

        // GET: api/Control_Documental
        [HttpGet]
        [Route("Lista")]
        public async Task<ActionResult<List<EmpresaDTO>>> GetLista()
        {
            try
            {
                var documentos = await _empresaService.Lista();
                return Ok(documentos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener la lista: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("Crear")]
        public async Task<IActionResult> Crear([FromBody] EmpresaDTO empresa)
        {
            var rsp = new Response<EmpresaDTO>();
            try
            {
                rsp.status = true;
                rsp.value = await _empresaService.Crear(empresa);
            }
            catch (Exception ex)
            {
                // Registrar el error para obtener más detalles
                _logger.LogError(ex, "Error al guardar la empresa");

                rsp.status = false;
                rsp.msg = $"Error al guardar la empresa: {ex.Message}";
            }
            return Ok(rsp);
        }

        [HttpPut]
        [Route("EditarEmpresa")]
        public async Task<IActionResult> EditarEmpresa([FromBody] EmpresaDTO empresa)
        {
            var rsp = new Response<bool>();

            try
            {
                rsp.status = true;
                rsp.value = await _empresaService.Editar(empresa);

            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;
            }
            return Ok(rsp);
        }

        [HttpDelete]
        [Route("EliminarEmpresa/{id:int}")]
        public async Task<IActionResult> EliminarEmpresa(int id)
        {
            var rsp = new Response<bool>();

            try
            {
                rsp.status = true;
                rsp.value = await _empresaService.Eliminar(id);

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

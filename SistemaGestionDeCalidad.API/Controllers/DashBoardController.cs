using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using SistemaGestionDeCalidad.BLL.Servicios.Contrato;
using SistemaGestionDeCalidad.DTO;
using SistemaGestionDeCalidad.API.Utilidad;

namespace SistemaGestionDeCalidad.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashBoardController : ControllerBase
    {
        private readonly IDashBoardService _dashBoardService;

        public DashBoardController(IDashBoardService dashBoardService)
        {
            _dashBoardService = dashBoardService;
        }

        [HttpGet]
        [Route("Resumen")]
        public async Task<IActionResult> Resumen()
        {
            var rsp = new Response<DashBoardDTO>();

            //Ejecutar el servcio 

            try
            {
                rsp.status = true;
                rsp.value = await _dashBoardService.Resumen();

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

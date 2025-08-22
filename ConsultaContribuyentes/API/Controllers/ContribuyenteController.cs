using Aplicacion.Interfaces.IContribuyentes;
using Dominio.Excepciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContribuyenteController : ControllerBase
    {
        private readonly IContribuyenteServicio servicio;
        private readonly ILogger<ContribuyenteController> logger;

        public ContribuyenteController(IContribuyenteServicio servicio, ILogger<ContribuyenteController> logger)
        {
            this.servicio = servicio;
            this.logger = logger;
        }
        [HttpGet("obtener-contribuyentes")]
        public IActionResult Get()
        {
            try
            {
                var contribuyentes = servicio.GetContribuyentes();
                return Ok(contribuyentes);
            }
            catch (NoHayRegistrosExcepcion ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                logger.LogError($"API. Error: {ex}");
                return StatusCode(500, "Hubo un error al ejecutar este petición. Contacte a un administrador");
            }
            
        }

    }
}

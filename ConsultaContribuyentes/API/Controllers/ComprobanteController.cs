using Aplicacion.Interfaces.IComprobantes;
using Dominio.Excepciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprobanteController : ControllerBase
    {
        private readonly IComprobanteServicio servicio;
        private readonly ILogger<ComprobanteController> logger;

        public ComprobanteController(IComprobanteServicio servicio, ILogger<ComprobanteController> logger)
        {
            this.servicio = servicio;
            this.logger = logger;
        }
        [HttpGet("ncf-por-contribuyente/{rncCedula}")]
        public IActionResult Get(string? rncCedula)
        {
            if (string.IsNullOrWhiteSpace(rncCedula))
            { 
                logger.LogWarning("Al controlador llego un RNC / Cedula nulo o vacío");
                return BadRequest("Debe proporcionar un RNC / Cédula válido");
            }   
            try
            {
                var comprobantes = servicio.GetComprobantes(rncCedula);
                return Ok(comprobantes);
            }
            catch (ContribuyenteSinComprobanteExcepcion ex)
            { 
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500,"Hubo un error al ejecutar esta petición. Contacte a un administrador");
            }
        }
    }
}

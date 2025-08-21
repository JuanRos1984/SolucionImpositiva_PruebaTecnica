using Aplicacion.Interfaces.IComprobantes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprobanteController : ControllerBase
    {
        private readonly IComprobanteServicio servicio;
        public ComprobanteController(IComprobanteServicio servicio)
        {
            this.servicio = servicio;
        }
        [HttpGet("ncf-por-contribuyente/{rncCedula}")]
        public IActionResult Get(string rncCedula)
        {
            return Ok(servicio.GetComprobantes(rncCedula));
        }
    }
}

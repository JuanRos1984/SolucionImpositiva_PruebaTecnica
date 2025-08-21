using Aplicacion.Interfaces.IContribuyentes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContribuyenteController : ControllerBase
    {
        private readonly IContribuyenteServicio servicio;

        public ContribuyenteController(IContribuyenteServicio servicio)
        {
            this.servicio = servicio;
        }
        [HttpGet("obtener-contribuyentes")]
        public IActionResult Get()
        {
            return Ok(servicio.GetContribuyentes());
        }

    }
}

using API.Controllers;
using Aplicacion.DTOs;
using Aplicacion.Interfaces.IContribuyentes;
using Dominio.Excepciones;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasUnitarias.Controladores
{
    public class ContribuyenteControllerTest
    {
        private readonly Mock<IContribuyenteServicio> mockServicio;
        private readonly Mock<ILogger<ContribuyenteController>> mocklLogger;
        private readonly ContribuyenteController controller;
        public ContribuyenteControllerTest()
        {
            mockServicio = new Mock<IContribuyenteServicio>();
            mocklLogger = new Mock<ILogger<ContribuyenteController>>();
            controller = new ContribuyenteController(mockServicio.Object, mocklLogger.Object);
        }

        [Fact]
        public void Get_RetornaDatos()
        {
            var dto = new List<ContribuyenteDTO>
            {
                new ContribuyenteDTO
                {
                    RNCCedula = "001",
                    Nombre = "Primer contribuyente",
                    Tipo = "Persona Física",
                    Estatus = "Activo"
                },
                new ContribuyenteDTO
                {
                    RNCCedula = "225",
                    Nombre = "Segundo contribuyente",
                    Tipo = "Persona Jurídica",
                    Estatus = "Activo"
                }
            };

            mockServicio.Setup(a=>a.GetContribuyentes()).Returns(dto);

            var resultado = controller.Get();

            var okResult = Assert.IsType<OkObjectResult>(resultado);
            var dtoResultado = Assert.IsAssignableFrom<IEnumerable<ContribuyenteDTO>>(okResult.Value);
            Assert.Equal(2, dtoResultado.Count());
            Assert.Equal("001", dtoResultado.First().RNCCedula);
            Assert.Equal("Activo", dtoResultado.Last().Estatus);
        }

        [Fact]
        public void Get_ServicioLanzaNoHayRegistrosExcepcion_RetornaNotFound()
        {
            mockServicio.Setup(a => a.GetContribuyentes()).Throws(new NoHayRegistrosExcepcion());

            var resultado = controller.Get();

            var notFound = Assert.IsType<NotFoundObjectResult>(resultado);

            Assert.Equal("No se encontraron registros",notFound.Value);
        }

        [Fact]
        public void Get_ServicioLanzaExcepcionGenerica_RetornaStatusCode500()
        {
            mockServicio.Setup(a=>a.GetContribuyentes()).Throws(new Exception());

            var resultado = controller.Get();

            var error = Assert.IsType<ObjectResult>(resultado);

            Assert.Equal(500,error.StatusCode);
            Assert.Equal("Hubo un error al ejecutar este petición. Contacte a un administrador",error.Value);
        }
    }
}

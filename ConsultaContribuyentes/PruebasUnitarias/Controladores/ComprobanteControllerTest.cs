using API.Controllers;
using Aplicacion.DTOs;
using Aplicacion.Interfaces.IComprobantes;
using Castle.Core.Logging;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;

namespace PruebasUnitarias.Controladores
{
    public class ComprobanteControllerTest
    {
        private readonly Mock<IComprobanteServicio> mockServicio;
        private readonly Mock<ILogger<ComprobanteController>> mocklLogger;
        private readonly ComprobanteController controller;

        public ComprobanteControllerTest()
        {
            mockServicio = new Mock<IComprobanteServicio>();
            mocklLogger = new Mock<ILogger<ComprobanteController>>();
            controller = new ComprobanteController(mockServicio.Object, mocklLogger.Object);
        }

        [Fact]
        public void Get_RNCCedulaEsNulo_RetornaBadRequest()
        {
            var resultado = controller.Get(null);
            var badRequest = Assert.IsType<BadRequestObjectResult>(resultado);

            Assert.Equal("Debe proporcionar un RNC / Cédula válido",badRequest.Value);
        }

        [Fact]
        public void Get_RNCCedulaValido_RetornaOkConDatos()
        {
            var rncCedula = "00100050509";

            var dto = new ComprobanteDTO
            {
                Comprobantes = new List<Comprobante> 
                {
                    new Comprobante
                    {
                        RncCedula = rncCedula,
                        Contribuyente = "Comercio Antillano",
                        EstatusContribuyente = "Activo",
                        TipoContribuyente = "Persona Juridica",
                        NCF = "A03100000010",
                        Monto = 1000,
                        ITBIS18 = 180
                    },
                    new Comprobante
                    {
                        RncCedula = rncCedula,
                        Contribuyente = "Comercio Antillano",
                        EstatusContribuyente = "Activo",
                        TipoContribuyente = "Persona Juridica",
                        NCF = "A03100000011",
                        Monto = 2000,
                        ITBIS18 = 360
                    }
                },
                SumaITBIS = 540
            };

            mockServicio.Setup(a => a.GetComprobantes(rncCedula)).Returns(dto);

            var resultado = controller.Get(rncCedula);

            var okResult = Assert.IsType<OkObjectResult>(resultado);
            var dtoResultado = Assert.IsType<ComprobanteDTO>(okResult.Value);
            Assert.Equal(dto.Comprobantes.FirstOrDefault().RncCedula,dtoResultado.Comprobantes.FirstOrDefault().RncCedula);
            Assert.Equal(2,dtoResultado.Comprobantes.Count);
            Assert.Equal(540,dtoResultado.SumaITBIS);
        }
    }
}

using Aplicacion.Interfaces.IComprobantes;
using Aplicacion.Servicios;
using Dominio.Entidades;
using Dominio.Excepciones;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasUnitarias.Servicios
{
    public class ComprobanteServicioTest
    {
        private readonly Mock<IComprobanteRepositorio> mockRepo;
        private readonly Mock<ILogger<ComprobanteServicio>> mockLogger;
        private readonly ComprobanteServicio servicio;
        public ComprobanteServicioTest()
        {
            mockRepo = new Mock<IComprobanteRepositorio>();
            mockLogger = new Mock<ILogger<ComprobanteServicio>>();
            servicio = new ComprobanteServicio(mockRepo.Object,mockLogger.Object);
        }

        [Fact]
        public void GetComprobantes_RNCValidoConComprobantes_RetornaInformacion()
        {
            var rncCedula = "10123456789";
            var comprobantes = new List<Comprobante>
            {
                new Comprobante
                {
                    RncCedula = "10123456789",
                    Contribuyente = "JUAN PEREZ",
                    TipoContribuyente = "PERSONA FISICA",
                    EstatusContribuyente = "ACTIVO",
                    NCF = "E310000000001",
                    Monto = 500,
                    ITBIS18 = 90
                },
                new Comprobante
                {
                    RncCedula = "10123456789",
                    Contribuyente = "JUAN PEREZ",
                    TipoContribuyente = "PERSONA FISICA",
                    EstatusContribuyente = "ACTIVO",
                    NCF = "E310000000011",
                    Monto = 1000,
                    ITBIS18 = 180
                }
            };
            mockRepo.Setup(a => a.GetComprobantes(rncCedula)).Returns(comprobantes);

            var resultado = servicio.GetComprobantes(rncCedula);

            Assert.NotNull(resultado);
            Assert.Equal(2, resultado.Comprobantes.Count);
            Assert.Equal("E310000000001", resultado.Comprobantes[0].NCF);
            Assert.Equal(1000, resultado.Comprobantes[1].Monto);
        }

        [Fact]
        public void GetComprobantes_RncVacio_LanzaArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => servicio.GetComprobantes(""));
        }

        [Fact]
        public void GetComprobantes_RncValidoSinComprobantes_LanzaContribuyenteSinComprobanteExcepcion()
        {
            var rncCedula = "223";
            mockRepo.Setup(a => a.GetComprobantes(rncCedula)).Returns(new List<Comprobante>());

            Assert.Throws<ContribuyenteSinComprobanteExcepcion>(() => servicio.GetComprobantes(rncCedula));
        }

        [Fact]
        public void GetComprobantes_SumaITBISCorrectamente()
        {
            var rncCedula = "00100040205";

            var comprobantes = new List<Comprobante>
            {
                new Comprobante { ITBIS18 = 1800 },
                new Comprobante { ITBIS18 = 900 }
            };
            mockRepo.Setup(a => a.GetComprobantes(rncCedula)).Returns(comprobantes);


            var resultado = servicio.GetComprobantes(rncCedula);

            Assert.Equal(2700,resultado.SumaITBIS);
        }
    }
}

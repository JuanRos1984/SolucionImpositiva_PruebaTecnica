using Aplicacion.Interfaces.IContribuyentes;
using Aplicacion.Servicios;
using Castle.Core.Logging;
using Dominio.Entidades;
using Dominio.Excepciones;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PruebasUnitarias.Servicios
{
    public class ContribuyenteServicioTest
    {
        public readonly Mock<IContribuyenteRepositorio> mockRepo;
        public readonly Mock<ILogger<ContribuyenteServicio>> mockLogger;
        public readonly ContribuyenteServicio servicio;
        public ContribuyenteServicioTest()
        {
            mockRepo = new Mock<IContribuyenteRepositorio>();
            mockLogger = new Mock<ILogger<ContribuyenteServicio>>();
            servicio = new ContribuyenteServicio(mockRepo.Object,mockLogger.Object);
        }
        [Fact]
        public void GetContribuyente_RetornaInformacion()
        {
            var contribuyentes = new List<Contribuyente> 
            {
                new Contribuyente
                { 
                    RNCCedula = "223",
                    Nombre = "Contribuyente 1",
                    Tipo = "Persona Fisica",
                    Estatus = "Activo"
                },
                new Contribuyente
                {
                    RNCCedula = "402",
                    Nombre = "Contribuyente 2",
                    Tipo = "Persona Juridica",
                    Estatus = "Inactivo"
                }
            };
            mockRepo.Setup(a=>a.GetContribuyentes()).Returns(contribuyentes);

            var resultado = servicio.GetContribuyentes();

            Assert.NotNull(resultado);
            Assert.Equal(2, resultado.Count());
            Assert.Equal("Activo", resultado.FirstOrDefault().Estatus);
            Assert.Equal("402", resultado.LastOrDefault().RNCCedula);
        }

        [Fact]
        public void GetContribuyentes_NoRetornaData_LanzaNoHayRegistrosExepcion()
        {
            mockRepo.Setup(a=>a.GetContribuyentes()).Returns(new List<Contribuyente>());

            Assert.Throws<NoHayRegistrosExcepcion>(()=>servicio.GetContribuyentes());
        }

        [Fact]
        public void GetContribuyentes_RepositorioFalla_LanzaExcepcion()
        {
            mockRepo.Setup(a=>a.GetContribuyentes()).Throws(new Exception("Error"));

            Assert.Throws<Exception>(()=>servicio.GetContribuyentes());
        }
        
    }
}

using Aplicacion.DTOs;
using Aplicacion.Interfaces.IComprobantes;
using Dominio.Entidades;
using Dominio.Excepciones;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Aplicacion.Servicios
{
    public class ComprobanteServicio : IComprobanteServicio
    {
        private readonly IComprobanteRepositorio repo;
        private readonly ILogger<ComprobanteServicio> logger;
        public ComprobanteServicio(IComprobanteRepositorio repo, ILogger<ComprobanteServicio> logger)
        {
            this.repo = repo;
            this.logger = logger;
        }
        public ComprobanteDTO GetComprobantes(string rncCedula)
        {
            if (string.IsNullOrWhiteSpace(rncCedula))
            {
                logger.LogWarning("Se intento obtener comprobantes sin enviar un RNC o Cedula valido");
                throw new ArgumentNullException("El RNC o Cedula no deben estar vacios");
            }
            try
            {
                var comprobantes = repo.GetComprobantes(rncCedula);
                if (!comprobantes.Any())
                {
                    throw new ContribuyenteSinComprobanteExcepcion(rncCedula);
                }

                var sumaITBIS = comprobantes.Sum(a => a.ITBIS18);

                return new ComprobanteDTO
                {
                    Comprobantes = comprobantes.ToList(),
                    SumaITBIS = sumaITBIS
                };
            }
            catch (ContribuyenteSinComprobanteExcepcion ex)
            {
                logger.LogInformation(ex, $"Capa de Aplicacion: {ex.Message}");
                throw; 
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Capa de Aplición. Error: {ex.Message}");
                throw;
            }

        }
    }
}

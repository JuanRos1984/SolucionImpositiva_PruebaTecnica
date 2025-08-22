using Aplicacion.DTOs;
using Aplicacion.Interfaces.IContribuyentes;
using Dominio.Excepciones;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Servicios
{
    public class ContribuyenteServicio : IContribuyenteServicio
    {
        private readonly IContribuyenteRepositorio repo;
        private readonly ILogger<ContribuyenteServicio> logger;
        public ContribuyenteServicio(IContribuyenteRepositorio repositorio, ILogger<ContribuyenteServicio> logger)
        {
            repo = repositorio; 
            this.logger = logger;
        }
        public IEnumerable<ContribuyenteDTO> GetContribuyentes()
        {
            var result = new List<ContribuyenteDTO>();

            try
            {
                var contribuyentes = repo.GetContribuyentes();
                if (contribuyentes == null || !contribuyentes.Any())
                   throw new NoHayRegistrosExcepcion();
                
                result = contribuyentes.Select(contri => new ContribuyenteDTO
                {
                    RNCCedula = contri.RNCCedula,
                    Nombre = contri.Nombre,
                    Tipo = contri.Tipo,
                    Estatus = contri.Estatus

                }).ToList();
            }
            catch (NoHayRegistrosExcepcion ex)
            {
                logger.LogWarning("No hay contribuyentes para mostrar");
                throw;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Capa Aplicacion: Error al intentar obtener a los contribuyentes");
                throw;
            }
            return result;
        }
    }
}

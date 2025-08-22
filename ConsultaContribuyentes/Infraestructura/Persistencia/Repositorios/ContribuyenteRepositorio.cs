using Aplicacion.Interfaces.IContribuyentes;
using Dominio.Entidades;
using Infraestructura.Persistencia.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Persistencia.Repositorios
{
    public class ContribuyenteRepositorio : IContribuyenteRepositorio
    {
        private readonly SolucionFiscalContext contexto;
        private readonly ILogger<ContribuyenteRepositorio> logger;
        public ContribuyenteRepositorio(SolucionFiscalContext contexto, ILogger<ContribuyenteRepositorio> logger)
        {
            this.contexto = contexto;   
            this.logger = logger;
        }
        public IEnumerable<Contribuyente> GetContribuyentes()
        {
            try
            {
                return contexto.Contribuyentes.FromSqlInterpolated($"EXEC DBO.GetContribuyentes").ToList();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Capa Infraestructura: Ocurrio un error al ejecutar el procedure");
                throw;
            }
        }
    }
}

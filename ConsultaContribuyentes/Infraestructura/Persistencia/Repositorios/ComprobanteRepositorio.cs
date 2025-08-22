using Aplicacion.Interfaces.IComprobantes;
using Dominio.Entidades;
using Infraestructura.Persistencia.Contexto;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Persistencia.Repositorios
{
    public class ComprobanteRepositorio : IComprobanteRepositorio
    {
        private readonly SolucionFiscalContext context;
        private readonly ILogger<ComprobanteRepositorio> logger;
        public ComprobanteRepositorio(SolucionFiscalContext context, ILogger<ComprobanteRepositorio> logger)
        {
            this.context = context;
            this.logger = logger;
        }
        public IEnumerable<Comprobante> GetComprobantes(string rncCedula)
        {
            try
            {
                return context.Comprobantes.FromSqlInterpolated($"EXEC dbo.GetComprobantes {rncCedula}").ToList();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Capa Infraestructura: Ocurrió un error al ejecutar el procedure.");
                throw;
            }
        }
    }
}

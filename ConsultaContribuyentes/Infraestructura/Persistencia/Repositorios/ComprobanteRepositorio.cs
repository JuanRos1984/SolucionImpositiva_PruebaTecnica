using Aplicacion.Interfaces.IComprobantes;
using Dominio.Entidades;
using Infraestructura.Persistencia.Contexto;
using Microsoft.EntityFrameworkCore;
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
        public ComprobanteRepositorio(SolucionFiscalContext context)
        {
            this.context = context;
        }
        public IEnumerable<Comprobante> GetComprobantes()
        {
            throw new NotImplementedException();
        }
    }
}

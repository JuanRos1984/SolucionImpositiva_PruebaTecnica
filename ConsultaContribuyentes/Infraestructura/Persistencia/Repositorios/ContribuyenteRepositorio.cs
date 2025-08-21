using Aplicacion.Interfaces.IContribuyentes;
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
    public class ContribuyenteRepositorio : IContribuyenteRepositorio
    {
        private readonly SolucionFiscalContext contexto;
        public ContribuyenteRepositorio(SolucionFiscalContext contexto)
        {
            this.contexto = contexto;   
        }
        public IEnumerable<Contribuyente> GetContribuyentes()
        {
            return contexto.Contribuyentes.FromSqlRaw("DBO.GetContribuyentes").ToList();
        }
    }
}

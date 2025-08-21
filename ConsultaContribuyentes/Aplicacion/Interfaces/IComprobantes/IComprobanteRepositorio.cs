using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces.IComprobantes
{
    public interface IComprobanteRepositorio
    {
        IEnumerable<Comprobante> GetComprobantes(string rncCedula);
    }
}

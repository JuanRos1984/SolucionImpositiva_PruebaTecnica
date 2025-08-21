using Aplicacion.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces.IComprobantes
{
    public interface IComprobanteServicio
    {
        ComprobanteDTO GetComprobantes(string rncCedula);
    }
}

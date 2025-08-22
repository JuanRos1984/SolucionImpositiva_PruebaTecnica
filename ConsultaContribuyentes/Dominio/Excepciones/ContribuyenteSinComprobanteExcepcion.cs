using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Excepciones
{
    public class ContribuyenteSinComprobanteExcepcion : Exception
    {
        public ContribuyenteSinComprobanteExcepcion(string rncCedula) : 
            base($"No se encontraron comprobantes fiscales para el RNC / Cedula: {rncCedula}"){}
    }
}

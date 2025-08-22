using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Excepciones
{
    public class NoHayRegistrosExcepcion : Exception
    {
        public NoHayRegistrosExcepcion() : base("No se encontraron registros") { }
        
    }
}

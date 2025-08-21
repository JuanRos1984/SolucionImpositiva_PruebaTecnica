using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Comprobante
    {
        public string RncCedula { get; set; }
        public string Contribuyente { get; set; }
        public string TipoContribuyente { get; set; }
        public string EstatusContribuyente { get; set; }
        public string NCF { get; set; }
        public decimal Monto { get; set; }
        public decimal ITBIS18 { get; set; }

    }
}

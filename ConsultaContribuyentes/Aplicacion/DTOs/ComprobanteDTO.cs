using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.DTOs
{
    public class ComprobanteDTO
    {
        public List<Comprobante> Comprobantes { get; set; }
        public decimal SumaITBIS { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Contribuyente
    {
        [Key]
        public string RNCCedula { get; set; }

        public string Nombre { get; set; }

        public string Tipo { get; set; }

        public string Estatus { get; set; }
        
    }
}

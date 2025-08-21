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
        [StringLength(15)]
        public string RNCCedula { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(20)]
        public string Tipo { get; set; }

        public string Estatus { get; set; }
        
    }
}

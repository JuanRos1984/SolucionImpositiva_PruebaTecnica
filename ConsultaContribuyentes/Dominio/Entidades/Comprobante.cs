using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Comprobante
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(15)]
        public string RNCCedula { get; set; }

        [Required]
        [StringLength(20)]
        public string NCF { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Monto { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal ITBIS18 { get; set; }

        
    }
}

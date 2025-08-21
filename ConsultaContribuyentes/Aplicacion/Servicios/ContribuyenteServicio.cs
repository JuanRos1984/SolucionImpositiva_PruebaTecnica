using Aplicacion.DTOs;
using Aplicacion.Interfaces.IContribuyentes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Servicios
{
    public class ContribuyenteServicio : IContribuyenteServicio
    {
        private readonly IContribuyenteRepositorio repo;
        public ContribuyenteServicio(IContribuyenteRepositorio repositorio)
        {
            repo = repositorio; 
        }
        public IEnumerable<ContribuyenteDTO> GetContribuyentes()
        {
           var result = new List<ContribuyenteDTO>(); 
           var contribuyentes = repo.GetContribuyentes();
           result = contribuyentes.Select(contri => new ContribuyenteDTO 
           {
               RNCCedula = contri.RNCCedula, 
               Nombre = contri.Nombre,
               Tipo = contri.Tipo,
               Estatus = contri.Estatus
               
           }).ToList();

            return result;
        }
    }
}

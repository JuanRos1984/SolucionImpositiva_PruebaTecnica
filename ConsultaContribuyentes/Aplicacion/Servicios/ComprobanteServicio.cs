using Aplicacion.DTOs;
using Aplicacion.Interfaces.IComprobantes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Servicios
{
    public class ComprobanteServicio : IComprobanteServicio
    {
        private readonly IComprobanteRepositorio repo;
        public ComprobanteServicio(IComprobanteRepositorio repo)
        {
            this.repo = repo;
        }
        public ComprobanteDTO GetComprobantes(string rncCedula)
        {
            var comprobantes = repo.GetComprobantes(rncCedula);
            var sumaITBIS = comprobantes.Sum(a=>a.ITBIS18);

            return new ComprobanteDTO
            {
                Comprobantes = comprobantes.ToList(),
                SumaITBIS = sumaITBIS
            };
        }
    }
}

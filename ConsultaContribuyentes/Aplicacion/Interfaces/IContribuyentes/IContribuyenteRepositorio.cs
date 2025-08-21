using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces.IContribuyentes
{
    public interface IContribuyenteRepositorio
    {
        IEnumerable<Contribuyente> GetContribuyentes();
    }
}

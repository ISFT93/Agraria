using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Domain.Interfaces
{
    public interface ITipoEntorno
    {
         int IdTipoEntorno { get; set; }
         string Nombre { get; set; }
    }
}

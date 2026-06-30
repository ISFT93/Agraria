using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Domain.Interfaces
{
    public interface IIndustria
    {
         int idRegistroIndustria { get; set; }
         int idIndustria { get; set; }
         int idProducto { get; set; }
        int cantidadProduccion { get; set; }
        DateTime FechaProduccion { get; set; }
        int idInsumos { get; set; }
        int CantidadInsumos { get; set; }
    }
}

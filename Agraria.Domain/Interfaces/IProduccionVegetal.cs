using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Domain.Interfaces
{
    public interface IProduccionVegetal
    {
        int IdProduccion { get; set; }
        int CantidadPlantines { get; set; }
        DateTime FechaCultivo { get; set; }
        DateTime FechaCosecha { get; set; }
        int CantidadAtados { get; set; }
        bool Estado { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Domain.Interfaces
{
    public interface IProduccionVegetal
    {
        public int IdProduccion { get; set; }
        public int CantidadPlantines { get; set; }
        public DateTime FechaCultivo { get; set; }
        public DateTime FechaCosecha { get; set; }
        public int CantidadAtados { get; set; }
        public bool Estado { get; set; }
    }
}

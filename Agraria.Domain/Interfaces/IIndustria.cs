using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Domain.Interfaces
{
    public interface IIndustria
    {
        public int idRegistroIndustria { get; set; }
        public int idIndustria { get; set; }
        public int idProducto { get; set; }
        public int cantidadProduccion { get; set; }
        public DateTime FechaProduccion { get; set; }
        public int idInsumos { get; set; }
        public int CantidadInsumos { get; set; }
    }
}

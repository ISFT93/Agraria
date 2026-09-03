using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Domain.Interfaces
{
    public interface IArticulosPañol
    {
        int IdArtPañol { get; set; }
        string NombreProducto { get; set; }
        int Cantidad { get; set; }
        int IdUnidad { get; set; }
        DateTime FechaIngreso { get; set; }
        int IdEntorno { get; set; }
        string Responsable { get; set; }
        bool Estado { get; set; }
    }
}

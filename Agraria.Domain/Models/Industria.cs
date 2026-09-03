using Agraria.Domain.Interfaces;

namespace Agraria.Domain.Models
{
    public class Industria : IIndustria
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

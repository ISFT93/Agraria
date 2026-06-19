using Agraria.Domain.Interfaces;

namespace Agraria.Domain.Models
{
    //Alumna: Ceballos Pardo, Manuela
    public class ProduccionVegetal : IProduccionVegetal
    {
        public int IdProduccion { get; set; }
        public int CantidadPlantines { get; set; }
        public DateTime FechaCultivo { get; set; }
        public DateTime FechaCosecha { get; set; }
        public int CantidadAtados { get; set; }
        public bool Estado { get; set; }
    }
}

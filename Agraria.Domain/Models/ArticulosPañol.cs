using Agraria.Domain.Interfaces;

namespace Agraria.Domain.Models
{
    public class ArticulosPañol : IArticulosPañol
    {
        public int IdArtPañol { get; set; }
        public string NombreProducto { get; set; }
        public int Cantidad { get; set; }
        public int IdUnidad { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int IdEntorno { get; set; }
        public string Responsable { get; set; }
        public bool Estado { get; set; }
    }
}

using Agraria.Domain.Interfaces;

namespace Agraria.Domain.Models
{
    public class TipoAnimal : ITipoAnimal
    {
        public int IdTipo { get; set; }
        public string Nombre { get; set; }
    }
}

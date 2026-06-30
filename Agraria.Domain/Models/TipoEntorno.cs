using Agraria.Domain.Interfaces;

namespace Agraria.Domain.Models
{
    public class TipoEntorno : ITipoEntorno
    {
        public int IdTipoEntorno { get; set; }
        public string Nombre { get; set; }
    }
}

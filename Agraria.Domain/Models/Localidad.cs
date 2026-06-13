using Agraria.Domain.Interfaces;

namespace Agraria.Domain.Models
{
    public class Localidad:ILocalidad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }  

    }
}

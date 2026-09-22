using System;

namespace Agraria.Datos.DTO
{
    public class AnimalDTO
    {
        public long IdAnimal { get; set; }
        public string NombreComun { get; set; }
        public string NombreCientifico { get; set; }

        public int IdTipo { get; set; }
        public int IdRubro { get; set; }
        public int IdSubrubro { get; set; }

        // Propiedades descriptivas para la grilla y filtros
        public string TipoAnimal { get; set; }
        public string Rubro { get; set; }
        public string Subrubro { get; set; }

        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; }
    }
}
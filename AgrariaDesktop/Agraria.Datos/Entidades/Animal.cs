using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Datos.Entidades
{
    public class Animal
    {
        public long IdAnimal { get; set; }
        public string NombreComun { get; set; }
        public string NombreCientifico { get; set; }
        public int IdTipo { get; set; }
        public int IdRubro { get; set; }
        public int IdSubrubro { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; }
    }
}
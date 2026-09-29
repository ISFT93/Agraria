using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Datos.DTO
{
    public class EntornoFormativoHoyDTO
    {

        [DisplayName("Nombre")]
        public string Nombre { get; set; } // Nombre del tipo
        [DisplayName("Profesor Responsable")]
        public string Responsable { get; set; }
        public string Observaciones { get; set; }


       public EntornoFormativoHoyDTO () { }

    }

  
}

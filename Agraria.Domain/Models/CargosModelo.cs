using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Domain.Models
{
    public class CargosModelo
    {
        public int CargoId { get; set; }
        public string Descripcion { get; set; }
        public int TipoAsignacionId { get; set; }
        public int TipoAplicacionId { get; set; }
        public bool Activo { get; set; }
    }
}

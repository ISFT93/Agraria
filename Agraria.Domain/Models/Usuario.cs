using Agraria.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Domain.Models
{
    public class Usuario:Persona,IUsuario
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool activo { get; set; }
    }
}

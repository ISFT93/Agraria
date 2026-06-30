using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Domain.Interfaces
{
    public interface IProductos
    {
         int idProducto { get; set; }
         string Nombre { get; set; }
         string Descripcion { get; set; }
    }
}

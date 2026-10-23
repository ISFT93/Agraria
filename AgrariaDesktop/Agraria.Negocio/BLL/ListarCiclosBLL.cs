using Agraria.Datos.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Negocio.BLL
{
    public class ListarCiclosBLL
    {
        private listarCiclosDAL dal = new listarCiclosDAL();

        public DataTable ObtenerCiclos(string filtro = "")
        {
            return dal.ObtenerCiclos(filtro);
        }
    }
}

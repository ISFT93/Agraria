using Agraria.Datos.DAL;
using Agraria.Datos.DTO;
using Agraria.Datos.Entidades;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Agraria.Negocio.BLL
{
    public class VegetalBLL
    {
        private VegetalDAL dal = new VegetalDAL();

        public DataTable ObtenerVegetales(string filtro = "")
        {
            return dal.ObtenerVegetales(filtro);
        }
    }
}
using Agraria.Datos.DAL;
using System.Data;

namespace Agraria.Negocio.BLL
{
    public class AbmActividadesElementosBLL
    {
        private AbmActividadesElementosDAL dal = new AbmActividadesElementosDAL();

        public DataTable ObtenerElementosPorTipo(string tipo)
        {
            return dal.ObtenerElementosPorTipo(tipo);
        }
    }
}
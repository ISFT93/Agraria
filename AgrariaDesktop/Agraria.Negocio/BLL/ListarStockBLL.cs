using Agraria.Datos.DAL;
using System.Data;

namespace Agraria.Negocio.BLL
{
    public class ListarStockBLL
    {
        private ListarStockDAL dal = new ListarStockDAL();

        public DataTable Listar(string tipoElemento = "", string nombre = "")
        {
            if (tipoElemento == "Todos") tipoElemento = "";
            return dal.ObtenerStock(tipoElemento, nombre);
        }
    }
}
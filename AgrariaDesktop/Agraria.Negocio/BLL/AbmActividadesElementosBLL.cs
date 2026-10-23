using Agraria.Datos.DAL;
using System.Data;

namespace Agraria.Negocio.BLL
{
    public class AbmActividadesElementosBLL
    {
        private AbmActividadesElementosDAL dal = new AbmActividadesElementosDAL();

        public void Guardar(long idActividadElemento, long idActividadModelo, long idElemento, int tipoElemento, int tipoMovimiento, decimal cantidadPrevista, int idUnidad, bool obligatorio, bool? vendibleDestino, bool? permiteSustitucion, string observaciones, bool esModificacion)
        {
            if (esModificacion)
            {
                dal.Actualizar(idActividadElemento, idActividadModelo, idElemento, tipoElemento, tipoMovimiento, cantidadPrevista, idUnidad, obligatorio, vendibleDestino, permiteSustitucion, observaciones);
            }
            else
            {
                dal.Insertar(idActividadModelo, idElemento, tipoElemento, tipoMovimiento, cantidadPrevista, idUnidad, obligatorio, vendibleDestino, permiteSustitucion, observaciones);
            }
        }

        public DataTable BuscarPorId(long idActividadElemento)
        {
            return dal.ObtenerPorId(idActividadElemento);
        }

        public DataTable ObtenerElementosPorTipo(string tipo)
        {
            return dal.ObtenerElementosPorTipo(tipo);
        }
    }
}
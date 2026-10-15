using System.Data;
using System.Data.SqlClient;

namespace Agraria.Datos.DAL
{
    public class ListarStockDAL
    {
        public DataTable ObtenerStock(string tipoElemento, string nombre)
        {
            DataTable dt = new DataTable();
            ConexionBD.ConectarBD();
            using (SqlConnection cn = ConexionBD.ConexionSQL)
            {
                using (SqlCommand cmd = new SqlCommand("sp_select_stock", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tipo_elemento", string.IsNullOrEmpty(tipoElemento) ? "" : tipoElemento);
                    cmd.Parameters.AddWithValue("@Nombre", string.IsNullOrEmpty(nombre) ? "" : nombre);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }
    }
}
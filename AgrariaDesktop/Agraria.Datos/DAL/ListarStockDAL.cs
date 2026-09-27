using System.Data;
using System.Data.SqlClient;

namespace Agraria.Datos.DAL
{
    public class ListarStockDAL
    {
        public DataTable ObtenerStock(string tipoElemento, string nroAnimal)
        {
            DataTable dt = new DataTable();
            ConexionBD.ConectarBD();
            using (SqlConnection cn = ConexionBD.ConexionSQL)
            {
                using (SqlCommand cmd = new SqlCommand("sp_select_stock", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tipo_elemento", tipoElemento);
                    cmd.Parameters.AddWithValue("@nro_animal", nroAnimal);

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
using System;
using System.Data;
using System.Data.SqlClient;

namespace Agraria.Datos.DAL
{
    public class listarCiclosDAL
    {
        public DataTable ObtenerCiclos(string filtro = "")
        {
            DataTable dt = new DataTable();

            try
            {
                ConexionBD.ConectarBD();

                using (SqlCommand cmd = new SqlCommand("sp_select_ciclo_modelo", ConexionBD.ConexionSQL))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@filtro", (filtro ?? "").Trim());

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            finally
            {
                ConexionBD.CierraBD(); // antes el finally estaba vacío y la conexión quedaba abierta
            }

            return dt;
        }
    }
}

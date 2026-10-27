using System;
using System.Data;
using System.Data.SqlClient;

namespace Agraria.Datos.DAL
{
    public class AbmActividadesElementosDAL
    {

        public DataTable ObtenerElementosPorTipo(string tipo)
        {
            DataTable dt = new DataTable();
            try
            {
                ConexionBD.ConectarBD();
                SqlCommand cmd = new SqlCommand("sp_select_elementos_por_tipo", ConexionBD.ConexionSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tipo", tipo);

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            finally
            {
                ConexionBD.CierraBD();
            }
            return dt;
        }
    }
}
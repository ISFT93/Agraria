using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agraria.Datos.DTO;
using Agraria.Datos.Entidades;

namespace Agraria.Datos.DAL
{
    public class VegetalDAL
    {
        public DataTable ObtenerVegetales(string filtro = "")
        {
            DataTable dt = new DataTable();

            try
            {
                ConexionBD.ConectarBD();

                SqlCommand cmd = new SqlCommand("sp_select_vegetal", ConexionBD.ConexionSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@filtro", filtro.Trim());

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
using Agraria.Datos.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Agraria.Datos.Entidades;

namespace Agraria.Datos.DAL
{
    public class AbmAnimalDAL
    {
        public void Insertar(long idAnimal, string nombreComun, string nombreCientifico, int idTipo, int idRubro, int idSubrubro, float minimoStock)
        {
            ConexionBD.ConectarBD();
            using (SqlConnection cn = ConexionBD.ConexionSQL)
            {
                using (SqlCommand cmd = new SqlCommand("sp_insertanimales", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_animal", idAnimal);
                    cmd.Parameters.AddWithValue("@Nombre_comun", nombreComun);
                    cmd.Parameters.AddWithValue("@Nombre_cientifico", string.IsNullOrEmpty(nombreCientifico) ? (object)DBNull.Value : nombreCientifico);
                    cmd.Parameters.AddWithValue("@Id_tipo", idTipo);
                    cmd.Parameters.AddWithValue("@Id_rubro", idRubro);
                    cmd.Parameters.AddWithValue("@Id_subrubro", idSubrubro);
                    cmd.Parameters.AddWithValue("@Stock_minimo", minimoStock);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Actualizar(long idAnimal, string nombreComun, string nombreCientifico, int idTipo, int idRubro, int idSubrubro, float minimoStock)
        {
            ConexionBD.ConectarBD();
            using (SqlConnection cn = ConexionBD.ConexionSQL)
            {
                using (SqlCommand cmd = new SqlCommand("sp_updateanimales", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_animal", idAnimal);
                    cmd.Parameters.AddWithValue("@Nombre_comun", nombreComun);
                    cmd.Parameters.AddWithValue("@Nombre_cientifico", string.IsNullOrEmpty(nombreCientifico) ? (object)DBNull.Value : nombreCientifico);
                    cmd.Parameters.AddWithValue("@Id_tipo", idTipo);
                    cmd.Parameters.AddWithValue("@Id_rubro", idRubro);
                    cmd.Parameters.AddWithValue("@Id_subrubro", idSubrubro);
                    cmd.Parameters.AddWithValue("@Stock_minimo", minimoStock);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable ObtenerAnimales()
        {
            DataTable dt = new DataTable();
            ConexionBD.ConectarBD();
            using (SqlConnection cn = ConexionBD.ConexionSQL)
            {
                using (SqlCommand cmd = new SqlCommand("sp_selectanimales", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public DataTable ObtenerCombo(string tabla)
        {
            DataTable dt = new DataTable();
            ConexionBD.ConectarBD();
            using (SqlConnection cn = ConexionBD.ConexionSQL)
            {
                using (SqlCommand cmd = new SqlCommand("sp_select_combo", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tabla", tabla);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }
        public static DataTable ObtenerTipoAnimal()
        {
            ConexionBD.ConectarBD();
            using (SqlCommand cmd = new SqlCommand("SELECT Id_catalogo_item,Nombre from catalogo_tipo_items where id_catalog=1", ConexionBD.ConexionSQL))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public long ObtenerUltimoIdPorUsuario(long baseUsuario)
        {
            long ultimoId = 0;
            try
            {
                ConexionBD.ConectarBD();
                using (SqlCommand cmd = new SqlCommand("sp_select_ultimo_id_animal", ConexionBD.ConexionSQL))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Rango de bloque para Animales (Módulo 3): X30000 a X39999
                    long minId = Convert.ToInt64(baseUsuario.ToString() + "30000");
                    long maxId = Convert.ToInt64(baseUsuario.ToString() + "39999");

                    cmd.Parameters.AddWithValue("@min", minId);
                    cmd.Parameters.AddWithValue("@max", maxId);

                    object resultado = cmd.ExecuteScalar();
                    if (resultado != null && resultado != DBNull.Value)
                    {
                        ultimoId = Convert.ToInt64(resultado);
                    }
                }
            }
            finally
            {
                ConexionBD.CierraBD();
            }
            return ultimoId;
        }
    }
}
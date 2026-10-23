using Agraria.Datos.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agraria.Datos.DAL
{
    public class AbmVegetalesDAL
    {
        public void Insertar(long idVegetal, string nombreComun, string nombreCientifico, string variedadHibrido, int? idTipoCultivo, int? idCicloVida, string periodoSiembra, int? idMetodoSiembra, int? idEstadoFenologico, string requerimientoHidrico)
        {
            ConexionBD.ConectarBD();
            using (SqlConnection cn = ConexionBD.ConexionSQL)
            {
                using (SqlCommand cmd = new SqlCommand("sp_insert_vegetales", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_vegetal", idVegetal);
                    cmd.Parameters.AddWithValue("@Nombre_comun", nombreComun);
                    cmd.Parameters.AddWithValue("@Nombre_cientifico", string.IsNullOrEmpty(nombreCientifico) ? (object)DBNull.Value : nombreCientifico);
                    cmd.Parameters.AddWithValue("@Variedad_hibrido", string.IsNullOrEmpty(variedadHibrido) ? (object)DBNull.Value : variedadHibrido);
                    cmd.Parameters.AddWithValue("@Id_tipo_cultivo", idTipoCultivo.HasValue ? (object)idTipoCultivo.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@Id_ciclo_vida", idCicloVida.HasValue ? (object)idCicloVida.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@Periodo_siembra", string.IsNullOrEmpty(periodoSiembra) ? (object)DBNull.Value : periodoSiembra);
                    cmd.Parameters.AddWithValue("@Id_metodo_siembra", idMetodoSiembra.HasValue ? (object)idMetodoSiembra.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@Id_estado_fenologico", idEstadoFenologico.HasValue ? (object)idEstadoFenologico.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@Requerimiento_hidrico", string.IsNullOrEmpty(requerimientoHidrico) ? (object)DBNull.Value : requerimientoHidrico);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Actualizar(long idVegetal, string nombreComun, string nombreCientifico, string variedadHibrido, int? idTipoCultivo, int? idCicloVida, string periodoSiembra, int? idMetodoSiembra, int? idEstadoFenologico, string requerimientoHidrico)
        {
            ConexionBD.ConectarBD();
            using (SqlConnection cn = ConexionBD.ConexionSQL)
            {
                using (SqlCommand cmd = new SqlCommand("sp_update_vegetales", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_vegetal", idVegetal);
                    cmd.Parameters.AddWithValue("@Nombre_comun", nombreComun);
                    cmd.Parameters.AddWithValue("@Nombre_cientifico", string.IsNullOrEmpty(nombreCientifico) ? (object)DBNull.Value : nombreCientifico);
                    cmd.Parameters.AddWithValue("@Variedad_hibrido", string.IsNullOrEmpty(variedadHibrido) ? (object)DBNull.Value : variedadHibrido);
                    cmd.Parameters.AddWithValue("@Id_tipo_cultivo", idTipoCultivo.HasValue ? (object)idTipoCultivo.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@Id_ciclo_vida", idCicloVida.HasValue ? (object)idCicloVida.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@Periodo_siembra", string.IsNullOrEmpty(periodoSiembra) ? (object)DBNull.Value : periodoSiembra);
                    cmd.Parameters.AddWithValue("@Id_metodo_siembra", idMetodoSiembra.HasValue ? (object)idMetodoSiembra.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@Id_estado_fenologico", idEstadoFenologico.HasValue ? (object)idEstadoFenologico.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@Requerimiento_hidrico", string.IsNullOrEmpty(requerimientoHidrico) ? (object)DBNull.Value : requerimientoHidrico);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable ObtenerPorId(long idVegetal)
        {
            DataTable dt = new DataTable();
            ConexionBD.ConectarBD();
            using (SqlConnection cn = ConexionBD.ConexionSQL)
            {
                using (SqlCommand cmd = new SqlCommand("sp_select_vegetales_por_id", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_vegetal", idVegetal);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public static DataTable ObtenerTipoCultivo()
        {
            ConexionBD.ConectarBD();
            using (SqlCommand cmd = new SqlCommand("SELECT Id_catalogo_item,Nombre from catalogo_tipo_items where id_catalog=2", ConexionBD.ConexionSQL))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
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

        public DataTable ObtenerRequerimientoHidrico()
        {
            DataTable dt = new DataTable();
            ConexionBD.ConectarBD();
            using (SqlConnection cn = ConexionBD.ConexionSQL)
            {
                using (SqlCommand cmd = new SqlCommand("sp_select_requerimiento_hidrico", cn))
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
        public long ObtenerUltimoIdPorUsuario(long baseUsuario)
        {
            long ultimoId = 0;
            try
            {
                ConexionBD.ConectarBD();
                using (SqlCommand cmd = new SqlCommand("sp_select_ultimo_id_vegetal", ConexionBD.ConexionSQL))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    long minId = Convert.ToInt64(baseUsuario.ToString() + "10000");
                    long maxId = Convert.ToInt64(baseUsuario.ToString() + "20000");
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
                 ;
            }
            return ultimoId;
        }
    }
}

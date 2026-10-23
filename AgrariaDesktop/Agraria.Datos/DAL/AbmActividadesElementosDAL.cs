using System;
using System.Data;
using System.Data.SqlClient;

namespace Agraria.Datos.DAL
{
    public class AbmActividadesElementosDAL
    {
        public void Insertar(long idActividadModelo, long idElemento, int tipoElemento, int tipoMovimiento, decimal cantidadPrevista, int idUnidad, bool obligatorio, bool? vendibleDestino, bool? permiteSustitucion, string observaciones)
        {
            ConexionBD.ConectarBD();
            using (SqlConnection cn = ConexionBD.ConexionSQL)
            {
                using (SqlCommand cmd = new SqlCommand("sp_insert_actividad_elemento", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_actividad_modelo", idActividadModelo);
                    cmd.Parameters.AddWithValue("@id_elemento", idElemento);
                    cmd.Parameters.AddWithValue("@tipo_elemento", tipoElemento);
                    cmd.Parameters.AddWithValue("@tipo_movimiento", tipoMovimiento);
                    cmd.Parameters.AddWithValue("@cantidad_prevista", cantidadPrevista);
                    cmd.Parameters.AddWithValue("@id_unidad", idUnidad);
                    cmd.Parameters.AddWithValue("@obligatorio", obligatorio);
                    cmd.Parameters.AddWithValue("@vendible_destino", vendibleDestino.HasValue ? (object)vendibleDestino.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@permite_sustitucion", permiteSustitucion.HasValue ? (object)permiteSustitucion.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@observaciones", string.IsNullOrEmpty(observaciones) ? (object)DBNull.Value : observaciones);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Actualizar(long idActividadElemento, long idActividadModelo, long idElemento, int tipoElemento, int tipoMovimiento, decimal cantidadPrevista, int idUnidad, bool obligatorio, bool? vendibleDestino, bool? permiteSustitucion, string observaciones)
        {
            ConexionBD.ConectarBD();
            using (SqlConnection cn = ConexionBD.ConexionSQL)
            {
                using (SqlCommand cmd = new SqlCommand("sp_update_actividad_elemento", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_actividad_elemento", idActividadElemento);
                    cmd.Parameters.AddWithValue("@id_actividad_modelo", idActividadModelo);
                    cmd.Parameters.AddWithValue("@id_elemento", idElemento);
                    cmd.Parameters.AddWithValue("@tipo_elemento", tipoElemento);
                    cmd.Parameters.AddWithValue("@tipo_movimiento", tipoMovimiento);
                    cmd.Parameters.AddWithValue("@cantidad_prevista", cantidadPrevista);
                    cmd.Parameters.AddWithValue("@id_unidad", idUnidad);
                    cmd.Parameters.AddWithValue("@obligatorio", obligatorio);
                    cmd.Parameters.AddWithValue("@vendible_destino", vendibleDestino.HasValue ? (object)vendibleDestino.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@permite_sustitucion", permiteSustitucion.HasValue ? (object)permiteSustitucion.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@observaciones", string.IsNullOrEmpty(observaciones) ? (object)DBNull.Value : observaciones);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable ObtenerPorId(long idActividadElemento)
        {
            DataTable dt = new DataTable();
            ConexionBD.ConectarBD();
            using (SqlConnection cn = ConexionBD.ConexionSQL)
            {
                using (SqlCommand cmd = new SqlCommand("sp_select_actividad_elemento_por_id", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_actividad_elemento", idActividadElemento);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

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
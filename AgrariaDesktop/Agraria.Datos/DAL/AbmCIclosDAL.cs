using System;
using System.Data;
using System.Data.SqlClient;

namespace Agraria.Datos.DAL
{
    public class AbmCiclosDAL
    {
        public DataTable ObtenerItemsCatalogo(int idCatalogo)
        {
            DataTable dt = new DataTable();
            try
            {
                ConexionBD.ConectarBD();

                SqlCommand cmd = new SqlCommand("sp_select_items_catalogo", ConexionBD.ConexionSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_catalogo", idCatalogo);

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

        // Método maestro transaccional
        public void GuardarCicloCompleto(
            long? idCicloEditar, string nombreCiclo, string descCiclo, decimal duracionCiclo, int modoInicio, bool activoCiclo, DateTime fechaCreacion, int idCreador,
            string nombreActividad, string descActividad, int orden, int tipoActividad, decimal duracionAct, bool demora, bool aprobacion, bool ejecucionParcial, string condicionAvance, bool activaAct,
            long idElementoCat, int tipoElemento, int tipoMovimiento, decimal cantPrevista, int idUnidad, bool obligatorio, bool vendible, bool sustitucion, string observaciones,
            bool esModificacion)
        {
            ConexionBD.ConectarBD();

            // Iniciamos la transacción para asegurar que se guardan las 3 tablas juntas o no se guarda ninguna
            using (SqlTransaction transaction = ConexionBD.ConexionSQL.BeginTransaction())
            {
                try
                {
                    long idCicloFinal = 0;
                    long idActividadFinal = 0;

                    // ==============================================
                    // 1. GUARDAR CICLO MODELO (Tabla Cabecera)
                    // ==============================================
                    SqlCommand cmdCiclo = new SqlCommand();
                    cmdCiclo.Connection = ConexionBD.ConexionSQL;
                    cmdCiclo.Transaction = transaction;
                    cmdCiclo.CommandType = CommandType.StoredProcedure;

                    if (!esModificacion)
                    {
                        cmdCiclo.CommandText = "sp_insert_ciclo_modelo";
                        cmdCiclo.Parameters.AddWithValue("@nombre", nombreCiclo);
                        cmdCiclo.Parameters.AddWithValue("@descripcion", descCiclo);
                        cmdCiclo.Parameters.AddWithValue("@duracion_estimada", duracionCiclo);
                        cmdCiclo.Parameters.AddWithValue("@modo_inicio", modoInicio);
                        cmdCiclo.Parameters.AddWithValue("@activo", activoCiclo);
                        cmdCiclo.Parameters.AddWithValue("@fecha_creacion", fechaCreacion);
                        cmdCiclo.Parameters.AddWithValue("@creado_por", idCreador);

                        // Capturamos el ID autonumérico que nos devuelve el SP
                        SqlParameter pOutCiclo = new SqlParameter("@id_ciclo_generado", SqlDbType.BigInt);
                        pOutCiclo.Direction = ParameterDirection.Output;
                        cmdCiclo.Parameters.Add(pOutCiclo);

                        cmdCiclo.ExecuteNonQuery();
                        idCicloFinal = Convert.ToInt64(pOutCiclo.Value);
                    }
                    else
                    {
                        cmdCiclo.CommandText = "sp_update_ciclo_modelo";
                        cmdCiclo.Parameters.AddWithValue("@id_ciclo", idCicloEditar.Value);
                        cmdCiclo.Parameters.AddWithValue("@nombre", nombreCiclo);
                        cmdCiclo.Parameters.AddWithValue("@descripcion", descCiclo);
                        cmdCiclo.Parameters.AddWithValue("@duracion_estimada", duracionCiclo);
                        cmdCiclo.Parameters.AddWithValue("@modo_inicio", modoInicio);
                        cmdCiclo.Parameters.AddWithValue("@activo", activoCiclo);
                        cmdCiclo.ExecuteNonQuery();
                        idCicloFinal = idCicloEditar.Value;
                    }

                    // ==============================================
                    // 2. GUARDAR ACTIVIDAD DEL CICLO
                    // ==============================================
                    SqlCommand cmdAct = new SqlCommand();
                    cmdAct.Connection = ConexionBD.ConexionSQL;
                    cmdAct.Transaction = transaction;
                    cmdAct.CommandType = CommandType.StoredProcedure;

                    cmdAct.CommandText = "sp_insert_actividad_ciclo";
                    cmdAct.Parameters.AddWithValue("@id_ciclo", idCicloFinal); // <-- Usamos el ID del paso anterior
                    cmdAct.Parameters.AddWithValue("@nombre", nombreActividad);
                    cmdAct.Parameters.AddWithValue("@descripcion", descActividad);
                    cmdAct.Parameters.AddWithValue("@orden", orden);
                    cmdAct.Parameters.AddWithValue("@tipo_actividad", tipoActividad);
                    cmdAct.Parameters.AddWithValue("@duracion_estimada", duracionAct);
                    cmdAct.Parameters.AddWithValue("@demora", demora);
                    cmdAct.Parameters.AddWithValue("@requiere_aprobacion", aprobacion);
                    cmdAct.Parameters.AddWithValue("@permite_ejecucion_parcial", ejecucionParcial);
                    cmdAct.Parameters.AddWithValue("@condicion_avance", condicionAvance);
                    cmdAct.Parameters.AddWithValue("@activa", activaAct);

                    SqlParameter pOutAct = new SqlParameter("@id_actividad_generada", SqlDbType.BigInt);
                    pOutAct.Direction = ParameterDirection.Output;
                    cmdAct.Parameters.Add(pOutAct);

                    cmdAct.ExecuteNonQuery();
                    idActividadFinal = Convert.ToInt64(pOutAct.Value);

                    // ==============================================
                    // 3. GUARDAR ELEMENTO DE LA ACTIVIDAD
                    // ==============================================
                    SqlCommand cmdElem = new SqlCommand("sp_insert_actividad_elemento", ConexionBD.ConexionSQL, transaction);
                    cmdElem.CommandType = CommandType.StoredProcedure;
                    cmdElem.Parameters.AddWithValue("@id_actividad_modelo", idActividadFinal); // <-- Usamos el ID de la actividad
                    cmdElem.Parameters.AddWithValue("@id_elemento", idElementoCat);
                    cmdElem.Parameters.AddWithValue("@tipo_elemento", tipoElemento);
                    cmdElem.Parameters.AddWithValue("@tipo_movimiento", tipoMovimiento);
                    cmdElem.Parameters.AddWithValue("@cantidad_prevista", cantPrevista);
                    cmdElem.Parameters.AddWithValue("@id_unidad", idUnidad);
                    cmdElem.Parameters.AddWithValue("@obligatorio", obligatorio);
                    cmdElem.Parameters.AddWithValue("@vendible_destino", vendible);
                    cmdElem.Parameters.AddWithValue("@permite_sustitucion", sustitucion);
                    cmdElem.Parameters.AddWithValue("@observaciones", observaciones);

                    cmdElem.ExecuteNonQuery();

                    // Si todo salió perfecto, confirmamos y grabamos todo junto en SQL
                    transaction.Commit();
                }
                catch (Exception)
                {
                    // Si alguna de las inserciones falla, cancelamos todo para no dejar registros huérfanos
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
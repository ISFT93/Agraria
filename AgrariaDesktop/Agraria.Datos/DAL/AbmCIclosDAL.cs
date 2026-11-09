using Agraria.Datos.DTO;
using System;
using System.Collections.Generic;
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

        // Convierte null en DBNull para que SQL no tire "parámetro no suministrado"
        private static object ValorODbNull(object valor)
        {
            if (valor == null) return DBNull.Value;
            if (valor is string s && s.Length == 0) return DBNull.Value;
            return valor;
        }

        // =====================================================================
        // MÉTODO MAESTRO TRANSACCIONAL
        // Guarda la cabecera + TODAS las actividades + TODOS sus elementos.
        // En modificación: actualiza la cabecera, borra las actividades/elementos
        // anteriores del ciclo y los vuelve a insertar con lo que hay en pantalla.
        // =====================================================================
        public long GuardarCicloCompleto(
            long? idCicloEditar, string nombreCiclo, string descCiclo, decimal duracionCiclo, int modoInicio,
            bool activoCiclo, DateTime fechaCreacion, int idCreador,
            IList<ActividadModeloDTO> actividades)
        {
            bool esModificacion = idCicloEditar.HasValue;

            ConexionBD.ConectarBD();
            // Guardamos la referencia local: ConectarBD() reemplaza la conexión estática en cada llamada
            SqlConnection cn = ConexionBD.ConexionSQL;

            try
            {
                using (SqlTransaction transaction = cn.BeginTransaction())
                {
                    try
                    {
                        long idCicloFinal;

                        // ==============================================
                        // 1. CICLO MODELO (Cabecera)
                        // ==============================================
                        using (SqlCommand cmdCiclo = new SqlCommand())
                        {
                            cmdCiclo.Connection = cn;
                            cmdCiclo.Transaction = transaction;
                            cmdCiclo.CommandType = CommandType.StoredProcedure;

                            if (!esModificacion)
                            {
                                cmdCiclo.CommandText = "sp_insert_ciclo_modelo";
                                cmdCiclo.Parameters.AddWithValue("@nombre", nombreCiclo);
                                cmdCiclo.Parameters.AddWithValue("@descripcion", ValorODbNull(descCiclo));
                                cmdCiclo.Parameters.AddWithValue("@duracion_estimada", duracionCiclo);
                                cmdCiclo.Parameters.AddWithValue("@modo_inicio", modoInicio);
                                cmdCiclo.Parameters.AddWithValue("@activo", activoCiclo);
                                cmdCiclo.Parameters.AddWithValue("@fecha_creacion", fechaCreacion);
                                cmdCiclo.Parameters.AddWithValue("@creado_por", idCreador);

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
                                cmdCiclo.Parameters.AddWithValue("@descripcion", ValorODbNull(descCiclo));
                                cmdCiclo.Parameters.AddWithValue("@duracion_estimada", duracionCiclo);
                                cmdCiclo.Parameters.AddWithValue("@modo_inicio", modoInicio);
                                cmdCiclo.Parameters.AddWithValue("@activo", activoCiclo);
                                cmdCiclo.ExecuteNonQuery();
                                idCicloFinal = idCicloEditar.Value;
                            }
                        }

                        // ==============================================
                        // 2. EN MODIFICACIÓN: limpiar actividades/elementos viejos
                        // ==============================================
                        if (esModificacion)
                        {
                            using (SqlCommand cmdDel = new SqlCommand("sp_delete_actividades_por_ciclo", cn, transaction))
                            {
                                cmdDel.CommandType = CommandType.StoredProcedure;
                                cmdDel.Parameters.AddWithValue("@id_ciclo", idCicloFinal);
                                cmdDel.ExecuteNonQuery();
                            }
                        }

                        // ==============================================
                        // 3. ACTIVIDADES + ELEMENTOS (todas, no solo la primera)
                        // ==============================================
                        foreach (ActividadModeloDTO act in actividades)
                        {
                            long idActividadFinal;

                            using (SqlCommand cmdAct = new SqlCommand("sp_insert_actividad_ciclo", cn, transaction))
                            {
                                cmdAct.CommandType = CommandType.StoredProcedure;
                                cmdAct.Parameters.AddWithValue("@id_ciclo", idCicloFinal);
                                cmdAct.Parameters.AddWithValue("@nombre", act.Nombre);
                                cmdAct.Parameters.AddWithValue("@descripcion", ValorODbNull(act.Descripcion));
                                cmdAct.Parameters.AddWithValue("@orden", act.Orden);
                                cmdAct.Parameters.AddWithValue("@tipo_actividad", act.IdTipoActividad);
                                cmdAct.Parameters.AddWithValue("@duracion_estimada", act.Duracion);
                                cmdAct.Parameters.AddWithValue("@demora", act.Demora);
                                cmdAct.Parameters.AddWithValue("@requiere_aprobacion", act.Aprobacion);
                                cmdAct.Parameters.AddWithValue("@permite_ejecucion_parcial", act.EjecucionParcial);
                                cmdAct.Parameters.AddWithValue("@condicion_avance", ValorODbNull(act.CondicionAvance));
                                cmdAct.Parameters.AddWithValue("@activa", act.Activa);

                                SqlParameter pOutAct = new SqlParameter("@id_actividad_generada", SqlDbType.BigInt);
                                pOutAct.Direction = ParameterDirection.Output;
                                cmdAct.Parameters.Add(pOutAct);

                                cmdAct.ExecuteNonQuery();
                                idActividadFinal = Convert.ToInt64(pOutAct.Value);
                            }

                            foreach (ActividadElementoModeloDTO elem in act.ListaElementos)
                            {
                                using (SqlCommand cmdElem = new SqlCommand("sp_insert_actividad_elemento", cn, transaction))
                                {
                                    cmdElem.CommandType = CommandType.StoredProcedure;
                                    cmdElem.Parameters.AddWithValue("@id_actividad_modelo", idActividadFinal);
                                    cmdElem.Parameters.AddWithValue("@id_elemento", elem.IdElemento);
                                    cmdElem.Parameters.AddWithValue("@tipo_elemento", elem.IdTipoElemento);
                                    cmdElem.Parameters.AddWithValue("@tipo_movimiento", elem.IdTipoMovimiento);
                                    cmdElem.Parameters.AddWithValue("@cantidad_prevista", elem.CantidadPrevista);
                                    cmdElem.Parameters.AddWithValue("@id_unidad", elem.IdUnidad);
                                    cmdElem.Parameters.AddWithValue("@obligatorio", elem.Obligatorio);
                                    cmdElem.Parameters.AddWithValue("@vendible_destino", elem.Vendible);
                                    cmdElem.Parameters.AddWithValue("@permite_sustitucion", elem.PermiteSustitucion);
                                    cmdElem.Parameters.AddWithValue("@observaciones", ValorODbNull(elem.Observaciones));
                                    cmdElem.Parameters.AddWithValue("@orden", elem.Orden);
                                    cmdElem.ExecuteNonQuery();
                                }
                            }
                        }

                        transaction.Commit();
                        return idCicloFinal;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            finally
            {
                if (cn.State == ConnectionState.Open) cn.Close();
            }
        }

        public DataTable ObtenerCicloPorId(long idCiclo)
        {
            return EjecutarConsulta("sp_get_ciclo_por_id", "@id_ciclo", idCiclo);
        }

        public DataTable ObtenerActividadesPorCiclo(long idCiclo)
        {
            return EjecutarConsulta("sp_get_actividades_por_ciclo", "@id_ciclo", idCiclo);
        }

        public DataTable ObtenerElementosPorActividad(long idActividadModelo)
        {
            return EjecutarConsulta("sp_get_elementos_por_actividad", "@id_actividad_modelo", idActividadModelo);
        }

        private DataTable EjecutarConsulta(string sp, string nombreParam, long valor)
        {
            DataTable dt = new DataTable();
            try
            {
                ConexionBD.ConectarBD();
                using (SqlCommand cmd = new SqlCommand(sp, ConexionBD.ConexionSQL))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(nombreParam, valor);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            finally { ConexionBD.CierraBD(); }
            return dt;
        }
    }
}

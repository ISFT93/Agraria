using System;
using System.Data;
using System.Data.SqlClient;

namespace Agraria.Datos.DAL
{
    public class AbmStockDAL
    {
        public long ObtenerUltimoIdElemento(string tipoElemento, long minId, long maxId)
        {
            long ultimoId = 0;
            try
            {
                ConexionBD.ConectarBD();
                using (SqlCommand cmd = new SqlCommand("sp_obtener_ultimo_id_elemento", ConexionBD.ConexionSQL))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tipo_elemento", tipoElemento);
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

        public long ObtenerUltimoIdStock(long minId, long maxId)
        {
            long ultimoId = 0;
            try
            {
                ConexionBD.ConectarBD();
                using (SqlCommand cmd = new SqlCommand("SELECT ISNULL(MAX(id_stock), 0) FROM stock WHERE id_stock >= @min AND id_stock < @max", ConexionBD.ConexionSQL))
                {
                    cmd.Parameters.AddWithValue("@min", minId);
                    cmd.Parameters.AddWithValue("@max", maxId);

                    object resultado = cmd.ExecuteScalar();
                    if (resultado != null && resultado != DBNull.Value)
                        ultimoId = Convert.ToInt64(resultado);
                }
            }
            finally
            {
                ConexionBD.CierraBD();
            }
            return ultimoId;
        }

        public void Insertar(long idElemento, string tipoElemento, string nombre, string ciclo, DateTime fechaAlta, DateTime? fechaBaja, decimal cantidad, string nroAnimal, string estadoSalud, bool esProductor, decimal? precio, long? idProveedor, bool activo, bool vendible, string motivoMovimiento)
        {
            ConexionBD.ConectarBD();
            using (SqlConnection cn = ConexionBD.ConexionSQL)
            {
                using (SqlCommand cmd = new SqlCommand("sp_insert_stock", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_elemento", idElemento);
                    cmd.Parameters.AddWithValue("@tipo_elemento", tipoElemento);
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@ciclo", string.IsNullOrEmpty(ciclo) ? (object)DBNull.Value : ciclo);
                    cmd.Parameters.AddWithValue("@fecha_alta", fechaAlta);
                    cmd.Parameters.AddWithValue("@fecha_baja", fechaBaja.HasValue ? (object)fechaBaja.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@cantidad", cantidad);
                    cmd.Parameters.AddWithValue("@nro_animal", string.IsNullOrEmpty(nroAnimal) ? (object)DBNull.Value : nroAnimal);
                    cmd.Parameters.AddWithValue("@estado_salud", string.IsNullOrEmpty(estadoSalud) ? (object)DBNull.Value : estadoSalud);
                    cmd.Parameters.AddWithValue("@es_productor", esProductor);
                    cmd.Parameters.AddWithValue("@precio", precio.HasValue ? (object)precio.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@id_proveedor", idProveedor.HasValue ? (object)idProveedor.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@activo", activo);
                    cmd.Parameters.AddWithValue("@vendible", vendible);
                    cmd.Parameters.AddWithValue("@motivo_movimiento", string.IsNullOrEmpty(motivoMovimiento) ? (object)DBNull.Value : motivoMovimiento);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Actualizar(long idStock, long idElemento, string tipoElemento, string nombre, string ciclo, DateTime fechaAlta, DateTime? fechaBaja, decimal cantidad, string nroAnimal, string estadoSalud, bool esProductor, decimal? precio, long? idProveedor, bool activo, bool vendible, string motivoMovimiento)
        {
            ConexionBD.ConectarBD();
            using (SqlConnection cn = ConexionBD.ConexionSQL)
            {
                using (SqlCommand cmd = new SqlCommand("sp_update_stock", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_stock", idStock);
                    cmd.Parameters.AddWithValue("@id_elemento", idElemento);
                    cmd.Parameters.AddWithValue("@tipo_elemento", tipoElemento);
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@ciclo", string.IsNullOrEmpty(ciclo) ? (object)DBNull.Value : ciclo);
                    cmd.Parameters.AddWithValue("@fecha_alta", fechaAlta);
                    cmd.Parameters.AddWithValue("@fecha_baja", fechaBaja.HasValue ? (object)fechaBaja.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@cantidad", cantidad);
                    cmd.Parameters.AddWithValue("@nro_animal", string.IsNullOrEmpty(nroAnimal) ? (object)DBNull.Value : nroAnimal);
                    cmd.Parameters.AddWithValue("@estado_salud", string.IsNullOrEmpty(estadoSalud) ? (object)DBNull.Value : estadoSalud);
                    cmd.Parameters.AddWithValue("@es_productor", esProductor);
                    cmd.Parameters.AddWithValue("@precio", precio.HasValue ? (object)precio.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@id_proveedor", idProveedor.HasValue ? (object)idProveedor.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@activo", activo);
                    cmd.Parameters.AddWithValue("@vendible", vendible);
                    cmd.Parameters.AddWithValue("@motivo_movimiento", string.IsNullOrEmpty(motivoMovimiento) ? (object)DBNull.Value : motivoMovimiento);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public DataTable ObtenerPorId(long idStock)
        {
            DataTable dt = new DataTable();
            ConexionBD.ConectarBD();
            using (SqlConnection cn = ConexionBD.ConexionSQL)
            {
                using (SqlCommand cmd = new SqlCommand("sp_select_stock_por_id", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", idStock);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public DataTable ObtenerProveedores()
        {
            DataTable dt = new DataTable();
            ConexionBD.ConectarBD();
            using (SqlConnection cn = ConexionBD.ConexionSQL)
            {
                using (SqlCommand cmd = new SqlCommand("sp_select_proveedores", cn))
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
    }
}
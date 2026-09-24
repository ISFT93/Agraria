using System;
using System.Data;
using System.Data.SqlClient;

namespace Agraria.Datos
{
    public class ArticulosDAL
    {
        // Ajustá esta cadena de conexión si es necesario
        private static string cadenaConexion = "Server=NOELIA_FLEITAS\\SQLEXPRESS;Database=Agraria;Trusted_Connection=True;";

        // 1. Listar Artículos con Filtros (Categoría y Nombre)
        public static DataTable ObtenerArticulosFiltrados(int? idCategoria, string nombre)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string query = "SELECT a.id_articulo, a.nombre, m.nombre AS marca, a.fecha_alta, c.nombre AS categoria " +
                               "FROM articulos a " +
                               "LEFT JOIN marca m ON a.id_marca = m.id_marca " +
                               "LEFT JOIN categoria c ON a.id_categoria = c.id_categoria " +
                               "WHERE (@id_categoria IS NULL OR a.id_categoria = @id_categoria) " +
                               "AND (@nombre IS NULL OR a.nombre LIKE '%' + @nombre + '%')";

                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@id_categoria", (object)idCategoria ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@nombre", string.IsNullOrEmpty(nombre) ? (object)DBNull.Value : nombre);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        // 2. Obtener el último ID por usuario para el Código por Bloques (Módulo Artículos - Base 20000)
        public static long ObtenerUltimoIdPorUsuario(long idUsuario)
        {
            long ultimoId = 0;
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                // Rango ajustado para la base 20000 del módulo de Artículos por usuario
                string query = "SELECT ISNULL(MAX(id_articulo), 0) FROM articulos WHERE id_articulo >= @min AND id_articulo < @max";
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@min", (idUsuario * 100000) + 20000);
                    cmd.Parameters.AddWithValue("@max", (idUsuario * 100000) + 30000);

                    object resultado = cmd.ExecuteScalar();
                    if (resultado != null && resultado != DBNull.Value)
                    {
                        ultimoId = Convert.ToInt64(resultado);
                    }
                }
            }
            return ultimoId;
        }

        // 3. Insertar Artículo
        public static void Insertar(long id, string nombre, int idMarca, DateTime fechaAlta, int idCategoria)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand cmd = new SqlCommand("sp_insert_articulo", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_articulo", id);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@id_marca", idMarca);
                    cmd.Parameters.AddWithValue("@fecha_alta", fechaAlta);
                    cmd.Parameters.AddWithValue("@id_categoria", idCategoria);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // 4. Modificar Artículo
        public static void Modificar(long id, string nombre, int idMarca, DateTime fechaAlta, int idCategoria)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand cmd = new SqlCommand("sp_update_articulo", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_articulo", id);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@id_marca", idMarca);
                    cmd.Parameters.AddWithValue("@fecha_alta", fechaAlta);
                    cmd.Parameters.AddWithValue("@id_categoria", idCategoria);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // 5. Obtener Marcas para ComboBox
        public static DataTable ObtenerMarcas()
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT id_marca, nombre FROM marca", conexion))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        // 6. Obtener Categorías para ComboBox
        public static DataTable ObtenerCategorias()
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT id_categoria, nombre FROM categoria", conexion))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }
    }
}
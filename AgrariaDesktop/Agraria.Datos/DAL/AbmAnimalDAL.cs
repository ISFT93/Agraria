using System;
using System.Data;
using System.Data.SqlClient;
using Agraria.Datos.Entidades;

namespace Agraria.Datos.DAL
{
    public class AbmAnimalDAL
    {

        public bool GuardarAnimal(Animal animal)
        {
            try
            {
                ConexionBD.ConectarBD();
                using (SqlCommand cmd = new SqlCommand("sp_InsertAnimal", ConexionBD.ConexionSQL))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id_animal", animal.IdAnimal);
                    cmd.Parameters.AddWithValue("@nombre_comun", animal.NombreComun);
                    cmd.Parameters.AddWithValue("@nombre_cientifico", string.IsNullOrEmpty(animal.NombreCientifico) ? (object)DBNull.Value : animal.NombreCientifico);
                    cmd.Parameters.AddWithValue("@id_tipo", animal.IdTipo);
                    cmd.Parameters.AddWithValue("@id_rubro", animal.IdRubro);
                    cmd.Parameters.AddWithValue("@id_subrubro", animal.IdSubrubro);
                    cmd.Parameters.AddWithValue("@fecha_nacimiento", animal.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@sexo", animal.Sexo);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            finally
            {
                 ;
            }
        }

   
        public bool ModificarAnimal(Animal animal)
        {
            try
            {
                ConexionBD.ConectarBD();
                using (SqlCommand cmd = new SqlCommand("sp_UpdateAnimal", ConexionBD.ConexionSQL))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id_animal", animal.IdAnimal);
                    cmd.Parameters.AddWithValue("@nombre_comun", animal.NombreComun);
                    cmd.Parameters.AddWithValue("@nombre_cientifico", string.IsNullOrEmpty(animal.NombreCientifico) ? (object)DBNull.Value : animal.NombreCientifico);
                    cmd.Parameters.AddWithValue("@id_tipo", animal.IdTipo);
                    cmd.Parameters.AddWithValue("@id_rubro", animal.IdRubro);
                    cmd.Parameters.AddWithValue("@id_subrubro", animal.IdSubrubro);
                    cmd.Parameters.AddWithValue("@fecha_nacimiento", animal.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@sexo", animal.Sexo);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            finally
            {
                 ;
            }
        }

       

        public DataTable ObtenerAnimales()
        {
            DataTable dt = new DataTable();
            try
            {
                ConexionBD.ConectarBD();
                using (SqlCommand cmd = new SqlCommand("sp_SelectAnimal", ConexionBD.ConexionSQL))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            finally
            {
                 ;
            }
            return dt;
        }

        // obtiene del último Id según rango de bloque de usuario
        public long ObtenerUltimoIdPorUsuario(long baseUsuario)
        {
            long ultimoId = 0;
            try
            {
                ConexionBD.ConectarBD();
                using (SqlCommand cmd = new SqlCommand("sp_select_ultimo_id_animal", ConexionBD.ConexionSQL))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    long minId = Convert.ToInt64(baseUsuario.ToString() + "130000");
                    long maxId = Convert.ToInt64(baseUsuario.ToString() + "2000000");

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

        // consulta genérica para poblar desplegables
        public DataTable ObtenerTabla(string nombreTabla)
        {
            DataTable dt = new DataTable();
            try
            {
                ConexionBD.ConectarBD();
                string query = $"SELECT * FROM {nombreTabla}";
                using (SqlCommand cmd = new SqlCommand(query, ConexionBD.ConexionSQL))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            finally
            {
                 ;
            }
            return dt;
        }
    }
}
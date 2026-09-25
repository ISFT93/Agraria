using Agraria.Datos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Datos.DAL
{
    public static class ConexionBD
    {
        public static string connectionstring;
        public static SqlConnection ConexionSQL = null; // Mantener la misma conexión
        //public static string datasource = DetectarInstanciaSimple();
        //public static string basededatos = "Agraria";
        public static SqlCommand Orden;
        public static SqlDataReader Lector;


        public static void ConectarBD()
        {
            // Prioridad 1: Variable de entorno (según README.md)
            string strConexion = System.Environment.GetEnvironmentVariable("AGRARIADB_CONNECTION_STRING");

            // Prioridad 2: App.config (fallback)
            if (string.IsNullOrWhiteSpace(strConexion))
            {
                var connSetting = ConfigurationManager.ConnectionStrings["agrariaDB"];
                if (connSetting != null)
                {
                    strConexion = connSetting.ConnectionString;
                }
            }

            if (string.IsNullOrWhiteSpace(strConexion))
            {
                throw new System.InvalidOperationException(
                    "No se pudo establecer la conexión. Defina la variable de entorno 'AGRARIADB_CONNECTION_STRING' " +
                    "o configure 'InstiDB' en el App.config.");
            }

            ConexionSQL = new SqlConnection(strConexion);
            if (ConexionSQL.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    ConexionSQL.Open();
                }
                catch
                {
                    // Manejo de errores, opcional
                    // MessageBox.Show("Error al intentar abrir base de datos", "AVISO IMPORTANTE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //public static void ConectarBD()
        //{
        //    // Verificar si la conexión ya existe y está abierta
        //    if (ConexionSQL == null)
        //    {
        //        connectionstring = @"Data Source=" + datasource + ";Initial Catalog=" + basededatos + ";Trusted_Connection=True;";
        //        ConexionSQL = new SqlConnection(connectionstring);
        //    }

        //    // Solo abrir la conexión si está cerrada
        //    if (ConexionSQL.State == System.Data.ConnectionState.Closed)
        //    {
        //        try
        //        {
        //            ConexionSQL.Open();
        //        }
        //        catch
        //        {
        //            // Manejo de errores, opcional
        //            // MessageBox.Show("Error al intentar abrir base de datos", "AVISO IMPORTANTE", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //}

        public static void CierraBD()
        {
            // Verificar si la conexión está abierta antes de cerrarla
            if (ConexionSQL != null && ConexionSQL.State == System.Data.ConnectionState.Open)
            {
                ConexionSQL.Close();
            }
        }

        public static SqlDataReader LecturaBD(string consulta)
        {
            Orden = new SqlCommand(consulta, ConexionSQL);
            Lector = Orden.ExecuteReader();
            return Lector;
        }

        public static void EjecutaQuery(string dame_query)
        {
            SqlCommand ejecuta = new SqlCommand(dame_query, ConexionSQL);
            ejecuta.ExecuteNonQuery();
        }

    //    public static string DetectarInstanciaSimple()
    //    {
    //        string pc = Environment.MachineName;

    //        string[] posibles =
    //        {
    //    pc + "\\SQLEXPRESS",
    //    pc + "\\MSSQLSERVER",
    //    pc + "\\SQL2019",
    //    pc + "\\SQL2022",
    //    "(localdb)\\MSSQLLocalDB",
    //    ".\\SQLEXPRESS",
    //    ".\\MSSQLSERVER"
    //};

    //        foreach (string instancia in posibles)
    //        {
    //            try
    //            {
    //                using (var cn = new SqlConnection(@"Data Source=" + instancia + ";Integrated Security=True;"))
    //                {
    //                    cn.Open();
    //                    return instancia;
    //                }
    //            }
    //            catch { }
    //        }

    //        return "(localdb)\\MSSQLLocalDB"; // fallback seguro
    //    }


    }
}



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Agraria.Datos.Entidades;

namespace Agraria.Datos.DAL
{
    public static class ProveedorDAL
    {
        public static List<Proveedor> Listar()
        {
            var lista = new List<Proveedor>();

            try
            {
                ConexionBD.ConectarBD();
                string sql = "SELECT id_proveedor, nombre, Telefono, mail, Direccion FROM Proveedores ORDER BY nombre";
                using (SqlCommand cmd = new SqlCommand(sql, ConexionBD.ConexionSQL))
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Proveedor
                        {
                            IdProveedor = Convert.ToInt32(dr["id_proveedor"]),
                            RazonSocial = dr["nombre"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Email = dr["mail"].ToString(),
                            Direccion = dr["Direccion"].ToString()
                        });
                    }
                }
            }
            finally
            {
                 ;
            }

            return lista;
        }
    }
}

using System;
using System.Data;
using Agraria.Datos.DAL;
using Agraria.Datos.Entidades;

namespace Agraria.Negocio.BLL
{
    public class AbmAnimalBLL
    {
        private readonly AbmAnimalDAL dal = new AbmAnimalDAL();

        public bool Guardar(Animal animal, bool esModificacion, int idUsuarioLogueado)
        {
            if (esModificacion)
            {
                return dal.ModificarAnimal(animal);
            }
            else
            {
                if (animal.IdAnimal <= 0)
                {
                    animal.IdAnimal = GenerarIdBloque(idUsuarioLogueado);
                }

                return dal.GuardarAnimal(animal);
            }
        }

        public long GenerarIdBloque(int idUsuario)
        {
            // 1. Buscamos el último ID registrado por este usuario en la base de datos
            long ultimoIdEntero = dal.ObtenerUltimoIdPorUsuario(idUsuario);

            long siguienteIncremental = 1;

            if (ultimoIdEntero > 0)
            {
                // Si ya tiene registros, extraemos la parte final (el incremental de 6 dígitos)
                string ultimoIdStr = ultimoIdEntero.ToString();
                string prefijoBase = $"{idUsuario}2"; // Ej para usuario 3: "31"

                if (ultimoIdStr.StartsWith(prefijoBase))
                {
                    string parteIncrementalStr = ultimoIdStr.Substring(prefijoBase.Length);
                    if (long.TryParse(parteIncrementalStr, out long incrementalActual))
                    {
                        siguienteIncremental = incrementalActual + 1;
                    }
                }
            }

            // 2. CONCATENACIÓN EXACTA: [IdUsuario] + [1] + [Incremental de 6 dígitos con ceros a la izquierda]
            // Ejemplo: Usuario 3, primer registro -> "3" + "1" + "000001" = "32000001"
            string idConcatenado = $"{idUsuario}2{siguienteIncremental:D6}";

            // 3. Convertimos a long (BIGINT) para la Primary Key de SQL Server
            return Convert.ToInt64(idConcatenado);
        }

        public DataTable CargarTablaAuxiliar(string nombreTabla)
        {
            return dal.ObtenerTabla(nombreTabla);
        }

        public  DataTable MostrarAnimales()
        {
            return dal.ObtenerAnimales();
        }
    }
}
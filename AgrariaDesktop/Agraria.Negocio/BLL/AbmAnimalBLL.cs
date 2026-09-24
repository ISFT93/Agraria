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
            long ultimoIdEntero = dal.ObtenerUltimoIdPorUsuario(idUsuario);
            long siguienteIncremental = 30000;

            string prefijoBase = $"{idUsuario}1";

            if (ultimoIdEntero > 0)
            {
                string ultimoIdStr = ultimoIdEntero.ToString();

                if (ultimoIdStr.StartsWith(prefijoBase))
                {
                    string parteIncrementalStr = ultimoIdStr.Substring(prefijoBase.Length);
                    if (long.TryParse(parteIncrementalStr, out long incrementalActual))
                    {
                        siguienteIncremental = Math.Max(30000, incrementalActual + 1);
                    }
                }
            }

            string idConcatenado = $"{prefijoBase}{siguienteIncremental}";

            return Convert.ToInt64(idConcatenado);
        }

        public DataTable CargarTablaAuxiliar(string nombreTabla)
        {
            return dal.ObtenerTabla(nombreTabla);
        }
    }
}
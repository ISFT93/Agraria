using System;
using System.Data;
using Agraria.Datos.DAL;
using Agraria.Datos.Entidades;

namespace Agraria.Negocio.BLL
{
    public class AbmAnimalBLL
    {
        private readonly AbmAnimalDAL dal = new AbmAnimalDAL();

        public void Guardar(Animal animal, bool esModificacion, int idUsuarioLogueado)
        {
            if (esModificacion)
            {
                dal.Actualizar(
                    animal.IdAnimal,
                    animal.NombreComun,
                    animal.NombreCientifico,
                    animal.IdTipo,
                    animal.IdRubro,
                    animal.IdSubrubro,
                    animal.MinimoStock
                );
            }
            else
            {
                if (animal.IdAnimal <= 0)
                {
                    animal.IdAnimal = GenerarIdBloque(idUsuarioLogueado);
                }

                dal.Insertar(
                    animal.IdAnimal,
                    animal.NombreComun,
                    animal.NombreCientifico,
                    animal.IdTipo,
                    animal.IdRubro,
                    animal.IdSubrubro,
                    animal.MinimoStock
                );
            }
        }

        public long GenerarIdBloque(int idUsuario)
        {
            long ultimoIdEntero = dal.ObtenerUltimoIdPorUsuario(idUsuario);
            long siguienteIncremental = 1;

            if (ultimoIdEntero > 0)
            {
                string ultimoIdStr = ultimoIdEntero.ToString();
                string prefijoBase = $"{idUsuario}3";

                if (ultimoIdStr.StartsWith(prefijoBase))
                {
                    string parteIncrementalStr = ultimoIdStr.Substring(prefijoBase.Length);
                    if (long.TryParse(parteIncrementalStr, out long incrementalActual))
                    {
                        siguienteIncremental = incrementalActual + 1;
                    }
                }
            }

            string idConcatenado = $"{idUsuario}3{siguienteIncremental:D4}";
            return Convert.ToInt64(idConcatenado);
        }

        public DataTable CargarCombo(string nombreTabla)
        {
            return dal.ObtenerCombo(nombreTabla);
        }

        public DataTable MostrarAnimales()
        {
            return dal.ObtenerAnimales();
        }
    }
}
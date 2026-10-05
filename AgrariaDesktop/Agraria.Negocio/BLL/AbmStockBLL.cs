using Agraria.Datos.DAL;
using System;
using System.Data;

namespace Agraria.Negocio.BLL
{
    public class AbmStockBLL
    {
        private AbmStockDAL dal = new AbmStockDAL();

        // Genera el código para Vegetal (Base 1), Animal (Base 2) o Articulo (Base 3) validando existencia
        public long GenerarIdElementoSeguro(string tipoElemento, int idUsuario)
        {
            string baseTipo = "0";
            if (tipoElemento == "Vegetal") baseTipo = "1";
            else if (tipoElemento == "Animal") baseTipo = "3";
            else if (tipoElemento == "Articulo") baseTipo = "2";

            long minId = Convert.ToInt64($"{idUsuario}{baseTipo}0000");
            long maxId = Convert.ToInt64($"{idUsuario}{baseTipo}9999");

            long ultimoIdEntero = dal.ObtenerUltimoIdElemento(tipoElemento, minId, maxId);
            long siguienteIncremental = 1;

            if (ultimoIdEntero > 0)
            {
                string ultimoIdStr = ultimoIdEntero.ToString();
                string prefijoBase = $"{idUsuario}{baseTipo}";

                if (ultimoIdStr.StartsWith(prefijoBase))
                {
                    string parteIncrementalStr = ultimoIdStr.Substring(prefijoBase.Length);
                    if (long.TryParse(parteIncrementalStr, out long incrementalActual))
                    {
                        siguienteIncremental = incrementalActual + 1;
                    }
                }
            }

            string idConcatenado = $"{idUsuario}{baseTipo}{siguienteIncremental:D4}";
            return Convert.ToInt64(idConcatenado);
        }

        // Genera el código propio para la tabla Stock (Base 4)
        public long GenerarIdStock(int idUsuario)
        {
            long minId = Convert.ToInt64($"{idUsuario}4000000");
            long maxId = Convert.ToInt64($"{idUsuario}4999999");

            long ultimoIdEntero = dal.ObtenerUltimoIdStock(minId, maxId);
            long siguienteIncremental = 1;

            if (ultimoIdEntero > 0)
            {
                string ultimoIdStr = ultimoIdEntero.ToString();
                string prefijoBase = $"{idUsuario}4";

                if (ultimoIdStr.StartsWith(prefijoBase))
                {
                    string parteIncrementalStr = ultimoIdStr.Substring(prefijoBase.Length);
                    if (long.TryParse(parteIncrementalStr, out long incrementalActual))
                    {
                        siguienteIncremental = incrementalActual + 1;
                    }
                }
            }

            return Convert.ToInt64($"{idUsuario}4{siguienteIncremental:D6}");
        }

        public void Guardar(long idStock, long idElemento, string tipoElemento, string nombre, string ciclo, DateTime fechaAlta, DateTime? fechaBaja, decimal cantidad, string nroAnimal, string estadoSalud, bool esProductor, decimal? precio, long? idProveedor, bool activo, bool vendible, bool esModificacion)
        {
            if (esModificacion)
            {
                dal.Actualizar(
                    idStock, idElemento, tipoElemento, nombre, ciclo, fechaAlta, fechaBaja, cantidad, nroAnimal, estadoSalud, esProductor, precio, idProveedor, activo, vendible);
            }
            else
            {
                dal.Insertar(
                    idElemento, tipoElemento, nombre, ciclo, fechaAlta, fechaBaja, cantidad, nroAnimal, estadoSalud, esProductor, precio, idProveedor, activo, vendible);
            }
        }

        public DataTable BuscarPorId(long idStock)
        {
            return dal.ObtenerPorId(idStock);
        }

        public DataTable CargarProveedores()
        {
            return dal.ObtenerProveedores();
        }
        // Método para guardar el stock general y los animales detallados en bucle
        // Método para guardar el stock general y los animales detallados en bucle
        public void GuardarConDetalleAnimales(
            long idStock, long idElemento, string tipoElemento, string nombre, string ciclo,
            DateTime fechaAlta, DateTime? fechaBaja, decimal cantidad, decimal? precio,
            long? idProveedor, bool activo, bool vendible, bool esModificacion,
            System.Collections.IEnumerable listaAnimales)
        {
            // 1. Guardamos el stock general primero
            if (esModificacion)
            {
                dal.Actualizar(idStock, idElemento, tipoElemento, nombre, ciclo, fechaAlta, fechaBaja, cantidad, null, null, false, precio, idProveedor, activo, vendible);
            }
            else
            {
                dal.Insertar(idElemento, tipoElemento, nombre, ciclo, fechaAlta, fechaBaja, cantidad, null, null, false, precio, idProveedor, activo, vendible);
            }

            // 2. Si es de tipo Animal y la lista tiene elementos, los guardamos uno a uno
            if (tipoElemento == "Animal" && listaAnimales != null)
            {
                foreach (dynamic animal in listaAnimales)
                {
                    dal.InsertarDetalleAnimal(idElemento, animal.NroAnimal, animal.Sexo, animal.EsProductor);
                }
            }
        }
    }
    }

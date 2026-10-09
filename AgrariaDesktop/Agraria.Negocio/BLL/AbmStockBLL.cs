using Agraria.Datos.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Agraria.Negocio.BLL
{
    public class AbmStockBLL
    {
        private AbmStockDAL dal = new AbmStockDAL();

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

        public DataTable BuscarPorId(long idStock)
        {
            return dal.ObtenerPorId(idStock);
        }

        public DataTable CargarProveedores()
        {
            return dal.ObtenerProveedores();
        }

        public void GuardarConDetalleAnimales(
              long idStock, long idElemento, string tipoElemento, string nombre, string ciclo,
              DateTime fechaAlta, DateTime? fechaBaja, decimal cantidad, decimal? precio,
              long? idProveedor, bool activo, bool vendible, bool esModificacion,
              List<AnimalItemDto> listaAnimales)
        {
            if (esModificacion)
            {
                dal.Actualizar(idStock, idElemento, tipoElemento, nombre, ciclo, fechaAlta, fechaBaja, cantidad, precio, idProveedor, activo, vendible);
            }
            else
            {
                dal.Insertar(idStock, idElemento, tipoElemento, nombre, ciclo, fechaAlta, fechaBaja, cantidad, precio, idProveedor, activo, vendible, null);
            }

            if (tipoElemento == "Animal" && listaAnimales != null)
            {
                foreach (AnimalItemDto animal in listaAnimales)
                {
                    dal.InsertarDetalleAnimal(idStock, animal.NroAnimal, animal.Sexo, animal.EsProductor);
                }
            }
        }
    }

    public class AnimalItemDto
    {
        public string NroAnimal { get; set; }
        public string Sexo { get; set; }
        public bool EsProductor { get; set; }
    }
}
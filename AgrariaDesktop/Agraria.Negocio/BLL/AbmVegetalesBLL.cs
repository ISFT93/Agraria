using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Agraria.Datos.DAL;

namespace Agraria.Negocio.BLL
{
    public class AbmVegetalesBLL
    {
        private AbmVegetalesDAL dal = new AbmVegetalesDAL();

        public void Guardar(long idVegetal, string nombreComun, string nombreCientifico, string variedadHibrido, int? idTipoCultivo, int? idCicloVida, string periodoSiembra, int? idMetodoSiembra, int? idEstadoFenologico, string requerimientoHidrico, bool esModificacion)
        {
            if (esModificacion)
            {
                dal.Actualizar(idVegetal, nombreComun, nombreCientifico, variedadHibrido, idTipoCultivo, idCicloVida, periodoSiembra, idMetodoSiembra, idEstadoFenologico, requerimientoHidrico);
            }
            else
            {
                dal.Insertar(idVegetal, nombreComun, nombreCientifico, variedadHibrido, idTipoCultivo, idCicloVida, periodoSiembra, idMetodoSiembra, idEstadoFenologico, requerimientoHidrico);
            }
        }

        public DataTable BuscarPorId(long idVegetal)
        {
            return dal.ObtenerPorId(idVegetal);
        }

        public DataTable CargarCombo(string nombreTabla)
        {
            return dal.ObtenerCombo(nombreTabla);
        }

        public DataTable CargarRequerimientoHidrico()
        {
            return dal.ObtenerRequerimientoHidrico();
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
                string prefijoBase = $"{idUsuario}1"; // Ej para usuario 3: "31"

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
            // Ejemplo: Usuario 3, primer registro -> "3" + "1" + "000001" = "3100001"
            string idConcatenado = $"{idUsuario}1{siguienteIncremental:D6}";

            // 3. Convertimos a long (BIGINT) para la Primary Key de SQL Server
            return Convert.ToInt64(idConcatenado);
        }

    }



    }
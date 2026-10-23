using Agraria.Datos.DAL;
using System;
using System.Data;

namespace Agraria.Negocio.BLL
{
    public class AbmCiclosBLL
    {
        private AbmCiclosDAL dal = new AbmCiclosDAL();

        public DataTable ObtenerItemsCatalogo(int idCatalogo)
        {
            return dal.ObtenerItemsCatalogo(idCatalogo);
        }

        public void GuardarCicloCompleto(
            long? idCicloEditar, string nombreCiclo, string descCiclo, decimal duracionCiclo, int modoInicio, bool activoCiclo, DateTime fechaCreacion, int idCreador,
            string nombreActividad, string descActividad, int orden, int tipoActividad, decimal duracionAct, bool demora, bool aprobacion, bool ejecucionParcial, string condicionAvance, bool activaAct,
            long idElementoCat, int tipoElemento, int tipoMovimiento, decimal cantPrevista, int idUnidad, bool obligatorio, bool vendible, bool sustitucion, string observaciones,
            bool esModificacion)
        {
            // Validaciones de negocio previas a enviar a la base de datos
            if (string.IsNullOrWhiteSpace(nombreCiclo))
                throw new ArgumentException("El nombre del ciclo es obligatorio.");

            if (orden <= 0)
                throw new ArgumentException("El número de orden de la actividad debe ser mayor a 0.");

            if (cantPrevista <= 0)
                throw new ArgumentException("La cantidad prevista del elemento debe ser mayor a cero.");

            // Si pasa los controles, la BLL despacha los datos a la DAL
            dal.GuardarCicloCompleto(
                idCicloEditar, nombreCiclo, descCiclo, duracionCiclo, modoInicio, activoCiclo, fechaCreacion, idCreador,
                nombreActividad, descActividad, orden, tipoActividad, duracionAct, demora, aprobacion, ejecucionParcial, condicionAvance, activaAct,
                idElementoCat, tipoElemento, tipoMovimiento, cantPrevista, idUnidad, obligatorio, vendible, sustitucion, observaciones,
                esModificacion);
        }
    }
}
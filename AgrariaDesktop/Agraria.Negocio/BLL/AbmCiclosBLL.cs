using Agraria.Datos.DAL;
using Agraria.Datos.DTO;
using System;
using System.Collections.Generic;
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

        public long GuardarCicloCompleto(
            long? idCicloEditar, string nombreCiclo, string descCiclo, decimal duracionCiclo, int modoInicio,
            bool activoCiclo, DateTime fechaCreacion, int idCreador,
            IList<ActividadModeloDTO> actividades)
        {
            // ---------- Cabecera ----------
            if (string.IsNullOrWhiteSpace(nombreCiclo))
                throw new ArgumentException("El nombre del ciclo es obligatorio.");

            if (modoInicio <= 0)
                throw new ArgumentException("Debe seleccionar el modo de inicio.");

            // ---------- Actividades ----------
            if (actividades == null || actividades.Count == 0)
                throw new ArgumentException("Debe agregar al menos una actividad al ciclo.");

            foreach (var act in actividades)
            {
                if (string.IsNullOrWhiteSpace(act.Nombre))
                    throw new ArgumentException("Hay una actividad sin nombre.");

                if (act.Orden <= 0)
                    throw new ArgumentException($"La actividad '{act.Nombre}' tiene un orden inválido.");

                if (act.IdTipoActividad <= 0)
                    throw new ArgumentException($"La actividad '{act.Nombre}' no tiene tipo de actividad.");

                if (act.ListaElementos == null || act.ListaElementos.Count == 0)
                    throw new ArgumentException($"La actividad '{act.Nombre}' debe tener al menos un elemento.");

                // ---------- Elementos ----------
                foreach (var elem in act.ListaElementos)
                {
                    if (elem.IdElemento <= 0 || elem.IdTipoElemento <= 0)
                        throw new ArgumentException($"Hay un elemento sin seleccionar en la actividad '{act.Nombre}'.");

                    if (elem.IdTipoMovimiento <= 0)
                        throw new ArgumentException($"El elemento '{elem.NombreElemento}' no tiene tipo de movimiento.");

                    if (elem.IdUnidad <= 0)
                        throw new ArgumentException($"El elemento '{elem.NombreElemento}' no tiene unidad.");

                    if (elem.CantidadPrevista <= 0)
                        throw new ArgumentException($"La cantidad prevista de '{elem.NombreElemento}' debe ser mayor a cero.");
                }
            }

            return dal.GuardarCicloCompleto(
                idCicloEditar, nombreCiclo, descCiclo, duracionCiclo, modoInicio, activoCiclo, fechaCreacion, idCreador,
                actividades);
        }

        public DataTable ObtenerCicloPorId(long idCiclo)
        {
            return dal.ObtenerCicloPorId(idCiclo);
        }

        public DataTable ObtenerActividadesPorCiclo(long idCiclo)
        {
            return dal.ObtenerActividadesPorCiclo(idCiclo);
        }

        public DataTable ObtenerElementosPorActividad(long idActividadModelo)
        {
            return dal.ObtenerElementosPorActividad(idActividadModelo);
        }
    }
}

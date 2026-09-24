using System;
using System.Data;
using Agraria.Datos;

namespace Agraria.BLL
{
    public class ArticulosBLL
    {
        // 1. Obtener artículos con filtros (Categoría y Nombre)
        public DataTable ObtenerArticulos(int? idCategoria, string nombre)
        {
            return ArticulosDAL.ObtenerArticulosFiltrados(idCategoria, nombre);
        }

        // Sobrecarga por si se llama sin parámetros
        public DataTable ObtenerArticulos()
        {
            return ArticulosDAL.ObtenerArticulosFiltrados(null, string.Empty);
        }

        // 2. Cargar combos para la interfaz
        public DataTable CargarComboCategorias()
        {
            return ArticulosDAL.ObtenerCategorias();
        }

        public DataTable CargarComboMarcas()
        {
            return ArticulosDAL.ObtenerMarcas();
        }

        // 3. Generación del Código por Bloques ([IdUsuario] + Base 20000 + Correlativo)
        public long ObtenerSiguienteId(int idUsuario)
        {
            long ultimoId = ArticulosDAL.ObtenerUltimoIdPorUsuario(idUsuario);

            // Si el usuario no tiene registros todavía, arranca en la base 20001 con su prefijo
            if (ultimoId == 0)
            {
                string primerIdStr = $"{idUsuario}20001";
                return Convert.ToInt64(primerIdStr);
            }

            // Si ya tiene registros, incrementa en 1 manteniendo intacto el bloque
            return ultimoId + 1;
        }

        // 4. Insertar
        public void Insertar(long id, string nombre, int idMarca, DateTime fechaAlta, int idCategoria)
        {
            ArticulosDAL.Insertar(id, nombre, idMarca, fechaAlta, idCategoria);
        }

        // 5. Modificar
        public void Modificar(long id, string nombre, int idMarca, DateTime fechaAlta, int idCategoria)
        {
            ArticulosDAL.Modificar(id, nombre, idMarca, fechaAlta, idCategoria);
        }
    }
}
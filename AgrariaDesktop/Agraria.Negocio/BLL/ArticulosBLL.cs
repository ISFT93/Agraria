using System;
using System.Data;
using Agraria.Datos;

namespace Agraria.BLL
{
    public class ArticulosBLL
    {
        public DataTable ObtenerArticulos(int? idCategoria, string nombre)
        {
            return ArticulosDAL.ObtenerArticulosFiltrados(idCategoria, nombre);
        }

        public DataTable ObtenerArticulos()
        {
            return ArticulosDAL.ObtenerArticulosFiltrados(null, string.Empty);
        }

        public DataTable CargarComboCategorias()
        {
            return ArticulosDAL.ObtenerCategorias();
        }

        public DataTable CargarComboMarcas()
        {
            return ArticulosDAL.ObtenerMarcas();
        }

        public long ObtenerSiguienteId(int idUsuario)
        {
            return ArticulosDAL.ObtenerUltimoIdPorUsuario(idUsuario);
        }

        public void Insertar(long id, string nombre, int idMarca, float stockMinimo, int idCategoria)
        {
            ArticulosDAL.Insertar(id, nombre, idMarca, stockMinimo, idCategoria);
        }

        public void Modificar(long id, string nombre, int idMarca, float stockMinimo, int idCategoria)
        {
            ArticulosDAL.Modificar(id, nombre, idMarca, stockMinimo, idCategoria);
        }
    }
}
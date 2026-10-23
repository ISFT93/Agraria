using System.ComponentModel;

namespace Agraria.Datos.DTO
{
    public class ActividadElementoModeloDTO
    {
        public int Orden { get; set; }
        public int IdTipoElemento { get; set; }
        public string TipoElemento { get; set; }

        // 🔹 Propiedades faltantes agregadas para solucionar el error CS0117
        public long IdElemento { get; set; }
        public string NombreElemento { get; set; }
        public string TipoMovimiento { get; set; }
        public int IdUnidad { get; set; }
        public decimal CantidadPrevista { get; set; }
        public bool Obligatorio { get; set; }
        public bool PermiteSustitucion { get; set; }
        public bool Vendible { get; set; }
    }

    public class CicloActividadModeloDTO
    {
        public int Orden { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int IdTipoActividad { get; set; }
        public string TipoActividad { get; set; }
        public decimal Duracion { get; set; }
        public bool Demora { get; set; }
        public bool Aprobacion { get; set; }
        public bool EjecucionParcial { get; set; }
        public string CondicionAvance { get; set; }
        public bool Activa { get; set; }

        public BindingList<ActividadElementoModeloDTO> ListaElementos { get; set; } = new BindingList<ActividadElementoModeloDTO>();
    }
}
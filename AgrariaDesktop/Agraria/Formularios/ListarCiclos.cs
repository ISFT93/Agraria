using Agraria.Datos.DAL;
using Agraria.Datos.DTO;
using Agraria.Datos.Entidades;
using Agraria.Negocio.BLL;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agraria.Formularios
{
    public partial class ListarCiclos : MaterialForm
    {


        private readonly UsuarioLoginDTO _usuarioLogeado;
        private readonly bool _esInvitado;
        private ListarCiclosBLL CiclosModeloBLL = new ListarCiclosBLL();
        public ListarCiclos(UsuarioLoginDTO usuarioLogeado, bool esInvitado)
        {
            InitializeComponent();
            _usuarioLogeado = usuarioLogeado;
            _esInvitado = esInvitado;


            // Configurar el MaterialSkinManager
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT; // O DARK

            // Configurar esquemas de color (Ejemplo:  Green , LightGreen  y Teal )
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Green800,
                Primary.Green900,
                Primary.Green500,
                Accent.Green200,
          TextShade.WHITE
            );
        }



        private void ListarCiclos_Load(object sender, EventArgs e)
        {
            CargarCiclosModelo();

        }
        private void CargarCiclosModelo(string filtro = "")
        {
            try
            {
                DataTable dt = CiclosModeloBLL.ObtenerCiclos(filtro);
                dtgvListarCiclos.DataSource = dt;

                ConfigurarColumna("id_ciclo", "Código", visible: true, displayIndex: 0);
                ConfigurarColumna("nombre", "Nombre del Ciclo");
                ConfigurarColumna("descripcion", "Descripción");
                ConfigurarColumna("duracion_estimada", "Duración (Días)");

                // Mostrar la duración como número entero (48 en vez de 48,00)
                if (dtgvListarCiclos.Columns["duracion_estimada"] != null)
                {
                    dtgvListarCiclos.Columns["duracion_estimada"].DefaultCellStyle.Format = "0";
                    dtgvListarCiclos.Columns["duracion_estimada"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                ConfigurarColumna("activo", "Activo");
                ConfigurarColumna("fecha_creacion", "Fecha de Creación");

                // El SP ahora devuelve también los NOMBRES; los IDs se ocultan
                bool hayNombreModo = dt.Columns.Contains("modo_inicio_nombre");
                ConfigurarColumna("modo_inicio", "Modo de Inicio", visible: !hayNombreModo);
                ConfigurarColumna("modo_inicio_nombre", "Modo de Inicio");

                bool hayNombreCreador = dt.Columns.Contains("creado_por_nombre");
                ConfigurarColumna("creado_por", "Creado Por", visible: !hayNombreCreador);
                ConfigurarColumna("creado_por_nombre", "Creado Por");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los ciclos modelo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarColumna(string nombre, string encabezado, bool visible = true, int displayIndex = -1)
        {
            var col = dtgvListarCiclos.Columns[nombre];
            if (col == null) return;
            col.HeaderText = encabezado;
            col.Visible = visible;
            if (displayIndex >= 0) col.DisplayIndex = displayIndex;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarCiclosModelo(txtBuscar.Text.Trim());
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            AbmCiclos frm = new AbmCiclos(_usuarioLogeado);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CargarCiclosModelo(txtBuscar.Text.Trim());
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            // CurrentRow cubre el caso en que se hizo clic en una celda sin seleccionar la fila completa
            DataGridViewRow fila = dtgvListarCiclos.SelectedRows.Count > 0
                ? dtgvListarCiclos.SelectedRows[0]
                : dtgvListarCiclos.CurrentRow;

            if (fila == null || fila.Cells["id_ciclo"].Value == null || fila.Cells["id_ciclo"].Value == DBNull.Value)
            {
                MessageBox.Show("Seleccione un ciclo de la lista para modificar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            long idCiclo = Convert.ToInt64(fila.Cells["id_ciclo"].Value);

            AbmCiclos frm = new AbmCiclos(idCiclo, _usuarioLogeado);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                CargarCiclosModelo(txtBuscar.Text.Trim());
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void cmbFiltrarPor_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarCiclosModelo(txtBuscar.Text.Trim());
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dtgvListarVegetales_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }
    }
}
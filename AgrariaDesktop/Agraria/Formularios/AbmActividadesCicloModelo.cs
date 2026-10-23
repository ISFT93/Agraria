using Agraria.Datos.DTO;
using Agraria.Negocio.BLL;
using System;
using System.Data;
using System.Windows.Forms;

namespace Agraria.Formularios
{
    public partial class AbmActividadesCicloModelo : Form
    {
        private AbmCiclosBLL bll = new AbmCiclosBLL();

        // Propiedad pública donde guardaremos la actividad para que AbmCiclos la lea
        public CicloActividadModeloDTO NuevaActividad { get; private set; }

        // Pedimos el número de orden por parámetro al abrir el formulario
        public AbmActividadesCicloModelo(int ordenAsignado)
        {
            InitializeComponent();
            txtOrden.Text = ordenAsignado.ToString();
            txtOrden.Enabled = false; // Bloqueado para que mantenga el correlativo
        }

        private void AbmActividadesCicloModelo_Load(object sender, EventArgs e)
        {
            CargarCombos();
        }

        private void CargarCombos()
        {
            // Cargar combo desde BD (Catálogo 15 = Tipo de Actividad)
            DataTable dtTipos = bll.ObtenerItemsCatalogo(15);
            cmbTipoActividad.DataSource = dtTipos;
            cmbTipoActividad.DisplayMember = "Nombre";
            cmbTipoActividad.ValueMember = "Id_catalogo_item";
            cmbTipoActividad.SelectedIndex = -1;

            // Cargar los combos de opciones fijas (Sí/No)
            CargarComboBooleano(cmbDemora);
            CargarComboBooleano(cmbAprobacion1);
            CargarComboBooleano(cmbEjecucion);
            CargarComboBooleano(cmbActiva);
        }

        private void CargarComboBooleano(ComboBox combo)
        {
            combo.Items.Clear();
            combo.Items.Add(new { Text = "Sí", Value = true });
            combo.Items.Add(new { Text = "No", Value = false });
            combo.DisplayMember = "Text";
            combo.ValueMember = "Value";
            combo.SelectedIndex = -1; // Deja el combo en blanco por defecto
        }

        private void btnAceptarActividad_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || cmbTipoActividad.SelectedIndex == -1)
            {
                MessageBox.Show("Complete los campos obligatorios: Nombre y Tipo de Actividad.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Llenamos la propiedad pública con los datos ingresados
            NuevaActividad = new CicloActividadModeloDTO
            {
                Orden = Convert.ToInt32(txtOrden.Text),
                Nombre = txtNombre.Text.Trim(),
                Descripcion = txtDescripcionActividad.Text.Trim(),
                IdTipoActividad = Convert.ToInt32(cmbTipoActividad.SelectedValue),
                TipoActividad = cmbTipoActividad.Text,
                Duracion = numDuracion.Value,
                Demora = cmbDemora.SelectedIndex != -1 && (bool)((dynamic)cmbDemora.SelectedItem).Value,
                Aprobacion = cmbAprobacion1.SelectedIndex != -1 && (bool)((dynamic)cmbAprobacion1.SelectedItem).Value,
                EjecucionParcial = cmbEjecucion.SelectedIndex != -1 && (bool)((dynamic)cmbEjecucion.SelectedItem).Value,
                CondicionAvance = txtCondicionAvance.Text.Trim(),
                Activa = cmbActiva.SelectedIndex == -1 || (bool)((dynamic)cmbActiva.SelectedItem).Value
            };

            this.DialogResult = DialogResult.OK; // Le avisamos al form principal que todo salió bien
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
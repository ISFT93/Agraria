using Agraria.Datos.DTO;
using Agraria.Negocio.BLL;
using System;
using System.Data;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace Agraria.Formularios
{
    public partial class AbmActividadesCicloModelo : MaterialForm
    {
        private AbmCiclosBLL bll = new AbmCiclosBLL();

        // Propiedad pública donde guardaremos la actividad para que AbmCiclos la lea
        public ActividadModeloDTO NuevaActividad { get; private set; }

        // ========================================================
        // 1. CONSTRUCTOR PARA NUEVO
        // ========================================================
        public AbmActividadesCicloModelo(int ordenAsignado)
        {
            InitializeComponent();
            ConfigurarSkin();

            txtOrden.Text = ordenAsignado.ToString();
            txtOrden.Enabled = false; // Bloqueado para que mantenga el correlativo
        }

        // ========================================================
        // 2. CONSTRUCTOR PARA MODIFICAR (El que llama la grilla)
        // ========================================================
        public AbmActividadesCicloModelo(ActividadModeloDTO actividadExistente)
        {
            InitializeComponent();
            ConfigurarSkin();

            // Guardamos la actividad seleccionada en la variable global
            NuevaActividad = actividadExistente;
            txtOrden.Enabled = false;
        }

        // Centralizamos el diseño para no repetir código en los dos constructores
        private void ConfigurarSkin()
        {
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

        private void AbmActividadesCicloModelo_Load(object sender, EventArgs e)
        {
            CargarCombos();

            // Si "NuevaActividad" tiene datos (Modo Edición), los volcamos a los TextBox y Combos
            if (NuevaActividad != null)
            {
                txtOrden.Text = NuevaActividad.Orden.ToString();
                txtNombre.Text = NuevaActividad.Nombre;
                txtDescripcionActividad.Text = NuevaActividad.Descripcion;
                txtCondicionAvance.Text = NuevaActividad.CondicionAvance;
                numDuracion.Value = NuevaActividad.Duracion;

                cmbTipoActividad.SelectedValue = NuevaActividad.IdTipoActividad;

                // Llamamos a un método de apoyo para seleccionar el booleano correcto
                SetearComboBooleano(cmbDemora, NuevaActividad.Demora);
                SetearComboBooleano(cmbAprobacion1, NuevaActividad.Aprobacion);
                SetearComboBooleano(cmbEjecucion, NuevaActividad.EjecucionParcial);
                SetearComboBooleano(cmbActiva, NuevaActividad.Activa);
            }
        }

        // Método de apoyo para leer el "Value" de tus objetos anónimos en los combos Sí/No
        private void SetearComboBooleano(ComboBox combo, bool valorBuscado)
        {
            for (int i = 0; i < combo.Items.Count; i++)
            {
                if (((dynamic)combo.Items[i]).Value == valorBuscado)
                {
                    combo.SelectedIndex = i;
                    break;
                }
            }
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

            // Si es Nuevo, lo creamos. Si es Modificar, usamos el que ya trajimos para actualizar sus propiedades.
            if (NuevaActividad == null)
            {
                NuevaActividad = new ActividadModeloDTO();
            }

            NuevaActividad.Orden = Convert.ToInt32(txtOrden.Text);
            NuevaActividad.Nombre = txtNombre.Text.Trim();
            NuevaActividad.Descripcion = txtDescripcionActividad.Text.Trim();
            NuevaActividad.IdTipoActividad = Convert.ToInt32(cmbTipoActividad.SelectedValue);
            NuevaActividad.TipoActividad = cmbTipoActividad.Text;
            NuevaActividad.Duracion = numDuracion.Value;
            NuevaActividad.Demora = cmbDemora.SelectedIndex != -1 && (bool)((dynamic)cmbDemora.SelectedItem).Value;
            NuevaActividad.Aprobacion = cmbAprobacion1.SelectedIndex != -1 && (bool)((dynamic)cmbAprobacion1.SelectedItem).Value;
            NuevaActividad.EjecucionParcial = cmbEjecucion.SelectedIndex != -1 && (bool)((dynamic)cmbEjecucion.SelectedItem).Value;
            NuevaActividad.CondicionAvance = txtCondicionAvance.Text.Trim();
            NuevaActividad.Activa = cmbActiva.SelectedIndex == -1 || (bool)((dynamic)cmbActiva.SelectedItem).Value;

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
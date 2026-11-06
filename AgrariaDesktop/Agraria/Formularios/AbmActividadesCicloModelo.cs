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

            if (NuevaActividad != null)
            {
                txtOrden.Text = NuevaActividad.Orden.ToString();
                txtNombre.Text = NuevaActividad.Nombre;
                txtDescripcionActividad.Text = NuevaActividad.Descripcion;
                txtCondicionAvance.Text = NuevaActividad.CondicionAvance;

                // Cargamos la duración en el MaskedTextBox
                mskDuracionEstimada.Text = NuevaActividad.Duracion.ToString();

                cmbTipoActividad.SelectedValue = NuevaActividad.IdTipoActividad;

                chkDemora.Checked = NuevaActividad.Demora;
                chkRequiereAprobacion.Checked = NuevaActividad.Aprobacion;
                chkPermiteEjecucionParcial.Checked = NuevaActividad.EjecucionParcial;
                chkActivo.Checked = NuevaActividad.Activa;
            }
            else
            {
                chkDemora.Checked = false;
                chkRequiereAprobacion.Checked = false;
                chkPermiteEjecucionParcial.Checked = false;
                chkActivo.Checked = true;
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

            if (NuevaActividad == null)
            {
                NuevaActividad = new ActividadModeloDTO();
            }

            NuevaActividad.Orden = Convert.ToInt32(txtOrden.Text);
            NuevaActividad.Nombre = txtNombre.Text.Trim();
            NuevaActividad.Descripcion = txtDescripcionActividad.Text.Trim();
            NuevaActividad.IdTipoActividad = Convert.ToInt32(cmbTipoActividad.SelectedValue);
            NuevaActividad.TipoActividad = cmbTipoActividad.Text;

            // Leemos la duración desde el MaskedTextBox de forma segura
            decimal duracionActividad = 0;
            string textoDuracion = mskDuracionEstimada.Text.Replace(":", "").Trim();
            if (!string.IsNullOrEmpty(textoDuracion))
            {
                decimal.TryParse(textoDuracion, out duracionActividad);
            }
            NuevaActividad.Duracion = duracionActividad;

            NuevaActividad.Demora = chkDemora.Checked;
            NuevaActividad.Aprobacion = chkRequiereAprobacion.Checked;
            NuevaActividad.EjecucionParcial = chkPermiteEjecucionParcial.Checked;
            NuevaActividad.Activa = chkActivo.Checked;

            NuevaActividad.CondicionAvance = txtCondicionAvance.Text.Trim();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
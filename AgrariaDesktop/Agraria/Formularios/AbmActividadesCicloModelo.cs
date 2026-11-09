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

        // AbmCiclos lee esta propiedad al cerrar con OK.
        // En modificación apunta al MISMO objeto de la lista, así que se edita en memoria.
        public ActividadModeloDTO NuevaActividad { get; private set; }

        // ========================================================
        // CONSTRUCTOR PARA NUEVO
        // ========================================================
        public AbmActividadesCicloModelo(int ordenAsignado)
        {
            InitializeComponent();
            ConfigurarSkin();

            txtOrden.Text = ordenAsignado.ToString();
            txtOrden.Enabled = false;
        }

        // ========================================================
        // CONSTRUCTOR PARA MODIFICAR
        // ========================================================
        public AbmActividadesCicloModelo(ActividadModeloDTO actividadExistente)
        {
            InitializeComponent();
            ConfigurarSkin();

            NuevaActividad = actividadExistente;
            txtOrden.Enabled = false;
        }

        private void ConfigurarSkin()
        {
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
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
            try
            {
                CargarCombos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los tipos de actividad: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (NuevaActividad != null)
            {
                // ---- MODIFICAR: volcar el DTO en los controles ----
                txtOrden.Text = NuevaActividad.Orden.ToString();
                txtNombre.Text = NuevaActividad.Nombre;
                txtDescripcionActividad.Text = NuevaActividad.Descripcion;
                txtCondicionAvance.Text = NuevaActividad.CondicionAvance;

                // Sin decimales: la máscara es "00000" (antes "30.00" quedaba como "3000")
                AbmCiclos.EscribirDuracion(mskDuracionEstimada, NuevaActividad.Duracion);

                if (NuevaActividad.IdTipoActividad > 0)
                    cmbTipoActividad.SelectedValue = NuevaActividad.IdTipoActividad;
                else
                    cmbTipoActividad.SelectedIndex = -1;

                chkDemora.Checked = NuevaActividad.Demora;
                chkRequiereAprobacion.Checked = NuevaActividad.Aprobacion;
                chkPermiteEjecucionParcial.Checked = NuevaActividad.EjecucionParcial;
                chkActivo.Checked = NuevaActividad.Activa;
            }
            else
            {
                // ---- NUEVO: valores por defecto ----
                chkDemora.Checked = false;
                chkRequiereAprobacion.Checked = false;
                chkPermiteEjecucionParcial.Checked = false;
                chkActivo.Checked = true;
            }
        }

        private void CargarCombos()
        {
            // Catálogo 15 = Tipo de Actividad
            DataTable dtTipos = bll.ObtenerItemsCatalogo(15);
            cmbTipoActividad.DataSource = dtTipos;
            cmbTipoActividad.DisplayMember = "Nombre";
            cmbTipoActividad.ValueMember = "Id_catalogo_item";
            cmbTipoActividad.SelectedIndex = -1;
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

            int.TryParse(txtOrden.Text, out int orden);
            NuevaActividad.Orden = orden;
            NuevaActividad.Nombre = txtNombre.Text.Trim();
            NuevaActividad.Descripcion = txtDescripcionActividad.Text.Trim();
            NuevaActividad.IdTipoActividad = Convert.ToInt32(cmbTipoActividad.SelectedValue);
            NuevaActividad.TipoActividad = cmbTipoActividad.Text;
            NuevaActividad.Duracion = AbmCiclos.LeerDuracion(mskDuracionEstimada);

            NuevaActividad.Demora = chkDemora.Checked;
            NuevaActividad.Aprobacion = chkRequiereAprobacion.Checked;
            NuevaActividad.EjecucionParcial = chkPermiteEjecucionParcial.Checked;
            NuevaActividad.Activa = chkActivo.Checked;
            NuevaActividad.CondicionAvance = txtCondicionAvance.Text.Trim();

            // ListaElementos NO se toca: en modificación conserva los elementos ya cargados

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

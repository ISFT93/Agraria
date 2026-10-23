using Agraria.Datos.DTO;
using Agraria.Negocio.BLL;
using System;
using System.Data;
using System.Windows.Forms;

namespace Agraria.Formularios
{
    public partial class AbmActividadesElementos : Form
    {
        // 1. Instanciamos AMBAS capas de negocio
        private AbmCiclosBLL ciclosBll = new AbmCiclosBLL();
        private AbmActividadesElementosBLL elementosBll = new AbmActividadesElementosBLL();

        // Propiedad donde el form principal leerá el resultado
        public ActividadElementoModeloDTO NuevoElemento { get; private set; }

        public AbmActividadesElementos(int ordenAsignado)
        {
            InitializeComponent();
            txtOrdenElemento.Text = ordenAsignado.ToString();
            txtOrdenElemento.Enabled = false;
        }

        private void AbmActividadesElementos_Load(object sender, EventArgs e)
        {
            CargarCombos();
        }

        // Método que soluciona el error CS0103
        private void LlenarCombo(ComboBox combo, int idCatalogo)
        {
            if (combo == null) return;
            DataTable dt = ciclosBll.ObtenerItemsCatalogo(idCatalogo);
            combo.DataSource = dt;
            combo.DisplayMember = "Nombre";
            combo.ValueMember = "Id_catalogo_item";
            combo.SelectedIndex = -1;
        }

        // Método seguro para Sí/No
        private void CargarComboBooleano(ComboBox combo)
        {
            combo.Items.Clear();
            combo.Items.Add(new { Text = "Sí", Value = true });
            combo.Items.Add(new { Text = "No", Value = false });
            combo.DisplayMember = "Text";
            combo.ValueMember = "Value";
            combo.SelectedIndex = -1;
        }

        private void CargarCombos()
        {
            // Combos de Base de Datos
            LlenarCombo(cmbTipoElemento, 11);
            LlenarCombo(cmbTipoMovimiento, 16);
            LlenarCombo(cmbTipoUnidad, 17);

            // Combos booleanos fijos
            CargarComboBooleano(cmbPermiteSustitucion);
            CargarComboBooleano(cmbVendible);
            CargarComboBooleano(cmbObligatorio);

            // Valores por defecto
            cmbPermiteSustitucion.SelectedIndex = 1; // No
            cmbVendible.SelectedIndex = 1;           // No
            cmbObligatorio.SelectedIndex = 0;        // Sí
        }

        private void cmbTipoElemento_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Extraemos el texto casteando la fila para evitar el error de "System.Data.DataRowView"
            if (cmbTipoElemento.SelectedIndex != -1 && cmbTipoElemento.SelectedItem is DataRowView)
            {
                DataRowView filaSeleccionada = (DataRowView)cmbTipoElemento.SelectedItem;
                string tipoSeleccionado = filaSeleccionada["Nombre"].ToString();

                // Solución al error CS1061: usar elementosBll en lugar de bll
                DataTable dtElementos = elementosBll.ObtenerElementosPorTipo(tipoSeleccionado);

                cmbElemento.DataSource = dtElementos;
                cmbElemento.DisplayMember = "nombre";
                cmbElemento.ValueMember = "id_elemento";
                cmbElemento.SelectedIndex = -1;
            }
            else
            {
                cmbElemento.DataSource = null;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (cmbTipoElemento.SelectedIndex == -1 || cmbElemento.SelectedIndex == -1 || cmbTipoMovimiento.SelectedIndex == -1 || cmbTipoUnidad.SelectedIndex == -1)
            {
                MessageBox.Show("Complete los campos obligatorios.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Construimos el DTO leyendo el .Value de los combos booleanos
            NuevoElemento = new ActividadElementoModeloDTO
            {
                Orden = Convert.ToInt32(txtOrdenElemento.Text),
                IdTipoElemento = Convert.ToInt32(cmbTipoElemento.SelectedValue),
                TipoElemento = cmbTipoElemento.Text,
                IdElemento = Convert.ToInt64(cmbElemento.SelectedValue),
                NombreElemento = cmbElemento.Text,
                TipoMovimiento = cmbTipoMovimiento.Text,
                IdUnidad = Convert.ToInt32(cmbTipoUnidad.SelectedValue),
                CantidadPrevista = numCantPrevista.Value,
                Obligatorio = (bool)((dynamic)cmbObligatorio.SelectedItem).Value,
                PermiteSustitucion = (bool)((dynamic)cmbPermiteSustitucion.SelectedItem).Value,
                Vendible = (bool)((dynamic)cmbVendible.SelectedItem).Value
            };

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
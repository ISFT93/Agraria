using Agraria.Datos.DTO;
using Agraria.Negocio.BLL;
using MaterialSkin;
using System;
using System.Data;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;


namespace Agraria.Formularios
{
    public partial class AbmActividadesElementos : MaterialForm
    {
        // 🔹 SOLUCIÓN CS1061: Instanciamos AMBAS capas de negocio
        private AbmCiclosBLL ciclosBll = new AbmCiclosBLL();
        private AbmActividadesElementosBLL elementosBll = new AbmActividadesElementosBLL();

        // Propiedad donde el form principal leerá el resultado
        public ActividadElementoModeloDTO NuevoElemento { get; private set; }

        public AbmActividadesElementos(int ordenAsignado)
        {
            InitializeComponent();
            txtOrdenElemento.Text = ordenAsignado.ToString();
            txtOrdenElemento.Enabled = false;

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

        private void AbmActividadesElementos_Load(object sender, EventArgs e)
        {
            CargarCombos();
        }

        // =========================================================
        // 🔹 SOLUCIÓN CS0103: Agregamos el método LlenarCombo que faltaba
        // =========================================================
        private void LlenarCombo(ComboBox combo, int idCatalogo)
        {
            if (combo == null) return;
            DataTable dt = ciclosBll.ObtenerItemsCatalogo(idCatalogo);
            combo.DataSource = dt;
            combo.DisplayMember = "Nombre";
            combo.ValueMember = "Id_catalogo_item";
            combo.SelectedIndex = -1;
        }

        private void CargarCombos()
        {
            // 1. Cargar Combos de Catálogos desde la Base de Datos
            LlenarCombo(cmbTipoElemento, 11);
            LlenarCombo(cmbTipoMovimiento, 16);
            LlenarCombo(cmbTipoUnidad, 17);

            // 2. Cargar Combos Booleanos mediante el método seguro
            CargarComboBooleano(cmbPermiteSustitucion);
            CargarComboBooleano(cmbVendible);
            CargarComboBooleano(cmbObligatorio);

            // Valores por defecto
            cmbPermiteSustitucion.SelectedIndex = 1; // No
            cmbVendible.SelectedIndex = 1;           // No
            cmbObligatorio.SelectedIndex = 0;        // Sí
        }

        private void CargarComboBooleano(ComboBox combo)
        {
            combo.DataSource = new[] {
        new { Text = "Sí", Value = true },
        new { Text = "No", Value = false }
    };
            combo.DisplayMember = "Text";
            combo.ValueMember = "Value";
            combo.SelectedIndex = -1;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (cmbTipoElemento.SelectedIndex == -1)
            {
                MessageBox.Show("Complete los campos obligatorios.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Construimos el DTO con los datos del form (asegurate de leer el .Value en los booleanos)
            NuevoElemento = new ActividadElementoModeloDTO
            {
                IdTipoMovimiento = Convert.ToInt32(cmbTipoMovimiento.SelectedValue),
                IdUnidad = Convert.ToInt32(cmbTipoUnidad.SelectedValue),
                IdElemento = Convert.ToInt64(cmbElemento.SelectedValue),
                Orden = Convert.ToInt32(txtOrdenElemento.Text),
                IdTipoElemento = Convert.ToInt32(cmbTipoElemento.SelectedValue),
                TipoElemento = cmbTipoElemento.Text,
                CantidadPrevista = numCantPrevista.Value,
                Obligatorio = cmbObligatorio.SelectedIndex != -1 && (bool)((dynamic)cmbObligatorio.SelectedItem).Value
                // (Si tu DTO tiene IdElemento, TipoMovimiento, etc., agregalos acá)
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cmbTipoElemento_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verificamos que el item seleccionado sea realmente una fila de datos válida
            if (cmbTipoElemento.SelectedIndex != -1 && cmbTipoElemento.SelectedItem is DataRowView drv)
            {
                string tipoSeleccionado = drv["Nombre"].ToString();

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
    }
}
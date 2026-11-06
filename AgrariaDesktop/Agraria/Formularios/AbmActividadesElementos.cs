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

        public AbmActividadesElementos(ActividadElementoModeloDTO elementoExistente)
        {
            InitializeComponent();

            // Guardamos la referencia para editar sobre el mismo objeto
            NuevoElemento = elementoExistente;
            txtOrdenElemento.Enabled = false;
        }
        private void AbmActividadesElementos_Load(object sender, EventArgs e)
        {
            CargarCombos();

            // Si NuevoElemento no es nulo, significa que venimos desde el botón Modificar
            if (NuevoElemento != null)
            {
                txtOrdenElemento.Text = NuevoElemento.Orden.ToString();
                numCantPrevista.Value = NuevoElemento.CantidadPrevista;

                // Seleccionamos los combos de catálogos
                cmbTipoElemento.SelectedValue = NuevoElemento.IdTipoElemento;
                cmbElemento.SelectedValue = NuevoElemento.IdElemento;
                cmbTipoMovimiento.Text = NuevoElemento.TipoMovimiento;
                cmbTipoUnidad.SelectedValue = NuevoElemento.IdUnidad;

                // Asignamos el estado guardado a los CheckBox
                chkObligatorio.Checked = NuevoElemento.Obligatorio;
                chkVendible.Checked = NuevoElemento.Vendible;
                chkPermiteSustitucion.Checked = NuevoElemento.PermiteSustitucion;
            }
            else
            {
                // Valores por defecto para un nuevo elemento
                chkObligatorio.Checked = true;    // Por defecto Sí
                chkVendible.Checked = false;      // Por defecto No
                chkPermiteSustitucion.Checked = false; // Por defecto No
            }
        }

        // Método de apoyo para seleccionar el ítem correcto en los combos de Sí/No
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
            if (cmbTipoElemento.SelectedIndex == -1 || cmbElemento.SelectedIndex == -1 || cmbTipoMovimiento.SelectedIndex == -1)
            {
                MessageBox.Show("Complete los campos obligatorios, incluyendo el Tipo de Movimiento.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Si es nuevo, lo creamos. Si es edición, actualizamos sus propiedades.
            if (NuevoElemento == null)
            {
                NuevoElemento = new ActividadElementoModeloDTO();
            }

            NuevoElemento.Orden = Convert.ToInt32(txtOrdenElemento.Text);
            NuevoElemento.IdTipoElemento = Convert.ToInt32(cmbTipoElemento.SelectedValue);
            NuevoElemento.TipoElemento = cmbTipoElemento.Text;

            NuevoElemento.IdElemento = Convert.ToInt64(cmbElemento.SelectedValue);
            NuevoElemento.NombreElemento = cmbElemento.Text;

            NuevoElemento.IdTipoMovimiento = Convert.ToInt32(cmbTipoMovimiento.SelectedValue);
            NuevoElemento.IdUnidad = Convert.ToInt32(cmbTipoUnidad.SelectedValue);
            NuevoElemento.CantidadPrevista = numCantPrevista.Value;

            // Leemos directamente el estado de los CheckBox
            NuevoElemento.Obligatorio = chkObligatorio.Checked;
            NuevoElemento.Vendible = chkVendible.Checked;
            NuevoElemento.PermiteSustitucion = chkPermiteSustitucion.Checked;

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
                cmbElemento.DataSource = null;            }
        }
    }
}
using Agraria.Datos.DTO;
using Agraria.Negocio.BLL;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Data;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace Agraria.Formularios
{
    public partial class AbmActividadesElementos : MaterialForm
    {
        private AbmCiclosBLL ciclosBll = new AbmCiclosBLL();
        private AbmActividadesElementosBLL elementosBll = new AbmActividadesElementosBLL();

        // AbmCiclos lee esta propiedad al cerrar con OK.
        // En modificación apunta al MISMO objeto de la lista.
        public ActividadElementoModeloDTO NuevoElemento { get; private set; }

        // Tipo de movimiento elegido antes de abrir el form (Entrada / Salida).
        // Reemplaza al combo cmbTipoMovimiento, que ya no se usa.
        private int _idTipoMovimiento;
        private string _tipoMovimiento;

        private bool EsSalida =>
            string.Equals((_tipoMovimiento ?? "").Trim(), "Salida", StringComparison.OrdinalIgnoreCase);

        // ========================================================
        // CONSTRUCTOR PARA NUEVO (recibe el movimiento elegido)
        // ========================================================
        public AbmActividadesElementos(int ordenAsignado, int idTipoMovimiento, string tipoMovimiento)
        {
            InitializeComponent();
            ConfigurarSkin();

            _idTipoMovimiento = idTipoMovimiento;
            _tipoMovimiento = tipoMovimiento;

            txtOrdenElemento.Text = ordenAsignado.ToString();
            txtOrdenElemento.Enabled = false;

            ConfigurarControles();
        }

        // ========================================================
        // CONSTRUCTOR PARA MODIFICAR (el movimiento sale del propio elemento)
        // ========================================================
        public AbmActividadesElementos(ActividadElementoModeloDTO elementoExistente)
        {
            InitializeComponent();
            ConfigurarSkin();

            NuevoElemento = elementoExistente;
            _idTipoMovimiento = elementoExistente.IdTipoMovimiento;
            _tipoMovimiento = elementoExistente.TipoMovimiento;

            txtOrdenElemento.Enabled = false;

            ConfigurarControles();
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

        private void ConfigurarControles()
        {
            // Cantidad prevista como número entero
            numCantPrevista.DecimalPlaces = 0;
            numCantPrevista.Increment = 1;

            // El tipo de movimiento ya viene elegido: se ocultan el combo y su etiqueta
           // cmbTipoMovimiento.Visible = false;
           // label27.Visible = false;          // "Tipo de Movimiento"

            AplicarVisibilidadVendible();
        }

        // Entrada -> Vendible oculto | Salida -> Vendible visible
        private void AplicarVisibilidadVendible()
        {
            bool salida = EsSalida;
            chkVendible.Visible = salida;
            //label26.Visible = salida;         // etiqueta "Vendible"
            if (!salida) chkVendible.Checked = false;

            if (!string.IsNullOrWhiteSpace(_tipoMovimiento))
                this.Text = "Elemento de " + _tipoMovimiento;
        }

        private void AbmActividadesElementos_Load(object sender, EventArgs e)
        {
            try
            {
                CargarCombos();
                ResolverNombreMovimientoSiFalta();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los catálogos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (NuevoElemento != null)
            {
                // ---- MODIFICAR ----
                txtOrdenElemento.Text = NuevoElemento.Orden.ToString();

                decimal cantidad = Math.Round(NuevoElemento.CantidadPrevista, 0);
                numCantPrevista.Value = Math.Min(numCantPrevista.Maximum, Math.Max(numCantPrevista.Minimum, cantidad));

                // 1ro el tipo (carga cmbElemento), 2do el elemento
                SeleccionarValor(cmbTipoElemento, NuevoElemento.IdTipoElemento);
                SeleccionarValor(cmbElemento, NuevoElemento.IdElemento);
                SeleccionarValor(cmbTipoUnidad, NuevoElemento.IdUnidad);

                chkObligatorio.Checked = NuevoElemento.Obligatorio;
                chkVendible.Checked = EsSalida && NuevoElemento.Vendible;
                chkPermiteSustitucion.Checked = NuevoElemento.PermiteSustitucion;
                txtObservacion.Text = NuevoElemento.Observaciones ?? "";
            }
            else
            {
                // ---- NUEVO ----
                chkObligatorio.Checked = true;
                chkVendible.Checked = false;
                chkPermiteSustitucion.Checked = false;
            }
        }

        // Si se modifica un elemento viejo y el SP no trajo el nombre del movimiento,
        // se busca en el catálogo 16 por su ID para saber si es Entrada o Salida.
        private void ResolverNombreMovimientoSiFalta()
        {
            if (!string.IsNullOrWhiteSpace(_tipoMovimiento) || _idTipoMovimiento <= 0) return;

            DataTable dt = ciclosBll.ObtenerItemsCatalogo(16);
            foreach (DataRow fila in dt.Rows)
            {
                if (Convert.ToInt32(fila["Id_catalogo_item"]) == _idTipoMovimiento)
                {
                    _tipoMovimiento = fila["Nombre"].ToString();
                    break;
                }
            }
            AplicarVisibilidadVendible();
        }

        // Selecciona por valor comparando como texto (evita problemas int/long)
        private static void SeleccionarValor(ComboBox combo, object valor)
        {
            combo.SelectedIndex = -1;
            if (valor == null || combo.DataSource == null || string.IsNullOrEmpty(combo.ValueMember)) return;

            string buscado = Convert.ToString(valor);
            for (int i = 0; i < combo.Items.Count; i++)
            {
                if (combo.Items[i] is DataRowView drv &&
                    Convert.ToString(drv[combo.ValueMember]) == buscado)
                {
                    combo.SelectedIndex = i;
                    return;
                }
            }
        }

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
            LlenarCombo(cmbTipoElemento, 11);   // Articulo / Vegetal / Animal
            LlenarCombo(cmbTipoUnidad, 17);     // Unidades
            // cmbTipoMovimiento ya no se carga: el movimiento se elige antes de abrir el form
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (cmbTipoElemento.SelectedIndex == -1 || cmbElemento.SelectedIndex == -1 || cmbTipoUnidad.SelectedIndex == -1)
            {
                MessageBox.Show("Complete los campos obligatorios: Tipo, Elemento y Unidad.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_idTipoMovimiento <= 0)
            {
                MessageBox.Show("No se definió el tipo de movimiento (Entrada / Salida).", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numCantPrevista.Value <= 0)
            {
                MessageBox.Show("La cantidad prevista debe ser mayor a cero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (NuevoElemento == null)
            {
                NuevoElemento = new ActividadElementoModeloDTO();
            }

            int.TryParse(txtOrdenElemento.Text, out int orden);
            NuevoElemento.Orden = orden;

            NuevoElemento.IdTipoElemento = Convert.ToInt32(cmbTipoElemento.SelectedValue);
            NuevoElemento.TipoElemento = cmbTipoElemento.Text;

            NuevoElemento.IdElemento = Convert.ToInt64(cmbElemento.SelectedValue);
            NuevoElemento.NombreElemento = cmbElemento.Text;

            // Movimiento: viene de la opción elegida (Entrada / Salida)
            NuevoElemento.IdTipoMovimiento = _idTipoMovimiento;
            NuevoElemento.TipoMovimiento = _tipoMovimiento;

            NuevoElemento.IdUnidad = Convert.ToInt32(cmbTipoUnidad.SelectedValue);
            NuevoElemento.Unidad = cmbTipoUnidad.Text;

            NuevoElemento.CantidadPrevista = numCantPrevista.Value;

            NuevoElemento.Obligatorio = chkObligatorio.Checked;
            NuevoElemento.Vendible = EsSalida && chkVendible.Checked;   // en Entrada siempre false
            NuevoElemento.PermiteSustitucion = chkPermiteSustitucion.Checked;
            NuevoElemento.Observaciones = txtObservacion.Text.Trim();

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

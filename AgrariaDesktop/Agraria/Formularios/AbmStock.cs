using Agraria.BLL;
using Agraria.Datos.DTO;
using Agraria.Negocio.BLL;
using System;
using System.Data;
using System.Windows.Forms;

namespace Agraria.Formularios
{
    public partial class AbmStock : Form
    {
        private AbmStockBLL bll = new AbmStockBLL();
        private AbmAnimalBLL animalBLL = new AbmAnimalBLL();
        private AbmVegetalesBLL vegetalBLL = new AbmVegetalesBLL();
        private ArticulosBLL articuloBLL = new ArticulosBLL();
        private long? idStockEditar = null;
        private UsuarioLoginDTO _usuarioActual;

        public AbmStock(UsuarioLoginDTO usuarioLogeado)
        {
            InitializeComponent();
            _usuarioActual = usuarioLogeado;
            ConfigurarFormulario();
        }

        public AbmStock(long idStock, UsuarioLoginDTO usuarioLogeado) : this(usuarioLogeado)
        {
            idStockEditar = idStock;
            CargarDatos(idStockEditar.Value);
        }

        private void ConfigurarFormulario()
        {
            cmbTipoElemento.Items.AddRange(new object[] { "Articulo", "Vegetal", "Animal" });
            cmbEsProductor.Items.AddRange(new object[] { "Sí", "No" });
            cmbActivo.Items.AddRange(new object[] { "Sí", "No" });
            cmbVendible.Items.AddRange(new object[] { "Sí", "No" });

            cmbActivo.SelectedIndex = 0;
            cmbVendible.SelectedIndex = 1;
            cmbEsProductor.SelectedIndex = 1;

            txtCodigoStock.Enabled = false;
            txtCodigoBloque.Enabled = false;

            CargarCombosEstaticos();
        }

        private void cmbTipoElemento_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool esAnimal = (cmbTipoElemento.Text == "Animal");

            txtNroAnimal.Enabled = esAnimal;
            txtEstadoSalud.Enabled = esAnimal;
            cmbEsProductor.Enabled = esAnimal;

            if (!esAnimal)
            {
                txtNroAnimal.Clear();
                txtEstadoSalud.Clear();
                cmbEsProductor.SelectedIndex = 1; // "No"
            }
            if (idStockEditar == null && cmbTipoElemento.SelectedIndex != -1)
            {
                txtCodigoBloque.Text = bll.GenerarIdElementoSeguro(cmbTipoElemento.Text, _usuarioActual.Id).ToString();

            }

            CargarDatos();

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cmbTipoElemento.Text) || string.IsNullOrWhiteSpace(txtCodigoBloque.Text))
                {
                    MessageBox.Show("Faltan datos obligatorios del elemento.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string nombre = txtNombre.Text.Trim();
                if (string.IsNullOrWhiteSpace(nombre))
                {
                    MessageBox.Show("El Nombre es obligatorio.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool esModificacion = (idStockEditar != null);

                long idStockFinal = esModificacion ? Convert.ToInt64(txtCodigoStock.Text) : 0;
                long idElemento = Convert.ToInt64(txtCodigoBloque.Text);

                string tipoElemento = cmbTipoElemento.Text;

                // Sumatoria del ciclo para guardar
                int sumaCiclo = 0;
                if (chkVerano.Checked) sumaCiclo += 2;     //[cite: 3]
                if (chkOtoño.Checked) sumaCiclo += 4;      //[cite: 3]
                if (chkInvierno.Checked) sumaCiclo += 8;   //[cite: 3]
                if (chkPrimavera.Checked) sumaCiclo += 16; //[cite: 3]

                // Solo guardamos número si tildaron algo, si no, se guarda nulo
                string ciclo = sumaCiclo > 0 ? sumaCiclo.ToString() : null;

                DateTime fechaAlta = dtpFechaAlta.Value;
                DateTime? fechaBaja = (dtpFechaBaja.Format == DateTimePickerFormat.Custom && dtpFechaBaja.CustomFormat == " ")
                       ? null
                       : (DateTime?)dtpFechaBaja.Value;

                decimal cantidad = decimal.TryParse(txtCantidad.Text, out decimal c) ? c : 0m;
                decimal? precio = numPrecio.Value > 0 ? (decimal?)numPrecio.Value : null;

                string nroAnimal = txtNroAnimal.Text.Trim();
                string estadoSalud = txtEstadoSalud.Text.Trim();
                string motivoMovimiento = txtMotivoMovimiento.Text.Trim();

                bool esProductor = (cmbEsProductor.Text == "Sí");
                bool activo = (cmbActivo.Text == "Sí");
                bool vendible = (cmbVendible.Text == "Sí");
                // 1. Capturamos el ID del proveedor (si seleccionó uno)
                long? idProveedor = cmbProveedor.SelectedValue != null ? (long?)Convert.ToInt64(cmbProveedor.SelectedValue) : null;

                // 2. Modificamos la llamada a Guardar reemplazando el 'null' por 'idProveedor'
                bll.Guardar(idStockFinal, idElemento, tipoElemento, nombre, ciclo, fechaAlta, fechaBaja, cantidad, nroAnimal, estadoSalud, esProductor, precio, idProveedor, activo, vendible, motivoMovimiento, esModificacion);
                MessageBox.Show("Stock guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatos(long id)
        {
            DataTable dt = bll.BuscarPorId(id);
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                txtCodigoStock.Text = dr["id_stock"].ToString();
                txtCodigoBloque.Text = dr["id_elemento"].ToString();
                txtNombre.Text = dr["Nombre"]?.ToString(); // Cargar Nombre

                cmbTipoElemento.SelectedIndexChanged -= cmbTipoElemento_SelectedIndexChanged;
                cmbTipoElemento.Text = dr["tipo_elemento"].ToString();
                cmbTipoElemento.SelectedIndexChanged += cmbTipoElemento_SelectedIndexChanged;

                // Decodificar el ciclo
                if (dr["ciclo"] != DBNull.Value && int.TryParse(dr["ciclo"].ToString(), out int cicloGuardado))
                {
                    chkVerano.Checked = (cicloGuardado & 2) == 2;
                    chkOtoño.Checked = (cicloGuardado & 4) == 4;
                    chkInvierno.Checked = (cicloGuardado & 8) == 8;
                    chkPrimavera.Checked = (cicloGuardado & 16) == 16;
                }
                else
                {
                    chkVerano.Checked = false;
                    chkOtoño.Checked = false;
                    chkInvierno.Checked = false;
                    chkPrimavera.Checked = false;
                }

                if (dr["fecha_alta"] != DBNull.Value) dtpFechaAlta.Value = Convert.ToDateTime(dr["fecha_alta"]);
                if (dr["fecha_baja"] != DBNull.Value)
                {
                    dtpFechaBaja.Format = DateTimePickerFormat.Short; // Mostramos el formato normal
                    dtpFechaBaja.Value = Convert.ToDateTime(dr["fecha_baja"]);
                }
                else
                {
                    dtpFechaBaja.Format = DateTimePickerFormat.Custom;
                    dtpFechaBaja.CustomFormat = " "; // Lo dejamos en blanco si viene Null
                }

                txtCantidad.Text = dr["cantidad"].ToString();
                txtNroAnimal.Text = dr["nro_animal"]?.ToString();
                txtEstadoSalud.Text = dr["estado_salud"]?.ToString();
                if (dr["precio"] != DBNull.Value && decimal.TryParse(dr["precio"].ToString(), out decimal precioGuardado))
                {
                    numPrecio.Value = precioGuardado;
                }
                else
                {
                    numPrecio.Value = 0;
                }
                txtMotivoMovimiento.Text = dr["motivo_movimiento"]?.ToString();
                if (dr["id_proveedor"] != DBNull.Value)
                {
                    cmbProveedor.SelectedValue =
                        Convert.ToInt64(dr["id_proveedor"]);
                }
                else
                {
                    cmbProveedor.SelectedIndex = -1;
                }

                cmbEsProductor.Text = Convert.ToBoolean(dr["es_productor"]) ? "Sí" : "No";
                cmbActivo.Text = Convert.ToBoolean(dr["activo"]) ? "Sí" : "No";
                cmbVendible.Text = Convert.ToBoolean(dr["vendible"]) ? "Sí" : "No";
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void CargarCombosEstaticos()
        {
            DataTable dtProveedores = bll.CargarProveedores();
            cmbProveedor.DataSource = dtProveedores;
            cmbProveedor.DisplayMember = "nombre";
            cmbProveedor.ValueMember = "id_proveedor";
            cmbProveedor.SelectedIndex = -1;
        }

        private void CargarDatos()
        {
            cmbDatos.Items.Clear();
            if (cmbTipoElemento.Text == "Animal")
            {
                DataTable dtAnimales = animalBLL.MostrarAnimales();
                cmbDatos.DataSource = dtAnimales;
                cmbDatos.DisplayMember = "nombrecomun";
                cmbDatos.ValueMember = "idanimal";
                cmbDatos.SelectedIndex = -1;
            }
            else if (cmbTipoElemento.Text == "Vegetal")
            {
                DataTable dtAnimales = vegetalBLL.CargarCombo("vegetal");
                cmbDatos.DataSource = dtAnimales;
                cmbDatos.DisplayMember = "nombre_comun";
                cmbDatos.ValueMember = "id_vegetal";
                cmbDatos.SelectedIndex = -1;
            }
            else if (cmbTipoElemento.Text == "Articulo")
            {
                DataTable dtAnimales = articuloBLL.ObtenerArticulos();
                cmbDatos.DataSource = dtAnimales;
                cmbDatos.DisplayMember = "nombre";
                cmbDatos.ValueMember = "id_articulo";
                cmbDatos.SelectedIndex = -1;

            }
        }

        private void AbmStock_Load(object sender, EventArgs e)
        {
            dtpFechaBaja.Format = DateTimePickerFormat.Custom;
            dtpFechaBaja.CustomFormat = " ";
        }

        private void dtpFechaBaja_ValueChanged(object sender, EventArgs e)
        {
            dtpFechaBaja.Format = DateTimePickerFormat.Short; //
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {


        }

        private void cmbDatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Solo copiar el id al txtCodigoStock si estamos creando (no en modo edición)
            if (idStockEditar != null) return;

            try
            {
                // Si no hay selección o DataSource, limpiamos
                if (cmbDatos.SelectedIndex == -1 || cmbDatos.SelectedValue == null)
                {
                    txtCodigoStock.Clear();
                    return;
                }

                // Cuando el combo está ligado a un DataTable, SelectedValue suele ser el valor del ValueMember.
                // En algunos casos SelectedValue puede ser un DataRowView; lo manejamos.
                if (cmbDatos.SelectedValue is DataRowView drv)
                {
                    var valueMember = cmbDatos.ValueMember;
                    if (!string.IsNullOrEmpty(valueMember) && drv.Row.Table.Columns.Contains(valueMember))
                    {
                        txtCodigoStock.Text = drv.Row[valueMember]?.ToString();
                    }
                    else
                    {
                        txtCodigoStock.Clear();
                    }
                }
                else
                {
                    txtCodigoStock.Text = cmbDatos.SelectedValue.ToString();
                }
            }
            catch
            {
                // Si ocurre cualquier error, no romper la UI; opcionalmente loggear aquí.
                txtCodigoStock.Clear();
            }
        }
    }
    
}
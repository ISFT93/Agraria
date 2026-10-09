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
            cmbActivo.Items.AddRange(new object[] { "Sí", "No" });
            cmbVendible.Items.AddRange(new object[] { "Sí", "No" });

            cmbActivo.SelectedIndex = 0;
            cmbVendible.SelectedIndex = 1;

            txtCodigoStock.Enabled = false;
            txtCodigoBloque.Enabled = false;

            CargarCombosEstaticos();
        }

        private void cmbTipoElemento_SelectedIndexChanged(object sender, EventArgs e)
        {
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

                DetallesAnimal formDetalles = null;
                int cantidadAnimales = 0;

                if (cmbTipoElemento.Text == "Animal")
                {
                    if (!int.TryParse(txtCantidad.Text, out cantidadAnimales) || cantidadAnimales <= 0)
                    {
                        MessageBox.Show("Por favor, ingrese una cantidad válida de animales para detallar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    formDetalles = new DetallesAnimal(cantidadAnimales);
                    if (formDetalles.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }
                }

                bool esModificacion = (idStockEditar != null);

                long idStockFinal = esModificacion ? Convert.ToInt64(txtCodigoStock.Text) : bll.GenerarIdStock(_usuarioActual.Id);
                long idElemento = Convert.ToInt64(txtCodigoBloque.Text);
                string tipoElemento = cmbTipoElemento.Text;

                int sumaCiclo = 0;
                if (chkVerano.Checked) sumaCiclo += 2;
                if (chkOtoño.Checked) sumaCiclo += 4;
                if (chkInvierno.Checked) sumaCiclo += 8;
                if (chkPrimavera.Checked) sumaCiclo += 16;

                string ciclo = sumaCiclo > 0 ? sumaCiclo.ToString() : null;

                DateTime fechaAlta = dtpFechaAlta.Value;
                DateTime? fechaBaja = (dtpFechaBaja.Format == DateTimePickerFormat.Custom && dtpFechaBaja.CustomFormat == " ")
                       ? null
                       : (DateTime?)dtpFechaBaja.Value;

                decimal? precio = numPrecio.Value > 0 ? (decimal?)numPrecio.Value : null;

                bool activo = (cmbActivo.Text == "Sí");
                bool vendible = (cmbVendible.Text == "Sí");
                long? idProveedor = cmbProveedor.SelectedValue != null ? (long?)Convert.ToInt64(cmbProveedor.SelectedValue) : null;

                if (tipoElemento == "Animal" && formDetalles != null && formDetalles.ListaAnimales != null && formDetalles.ListaAnimales.Count > 0)
                {
                    bll.GuardarConDetalleAnimales(
                        idStockFinal,
                        idElemento,
                        tipoElemento,
                        nombre,
                        ciclo,
                        fechaAlta,
                        fechaBaja,
                        formDetalles.ListaAnimales.Count,
                        precio,
                        idProveedor,
                        activo,
                        vendible,
                        esModificacion,
                        formDetalles.ListaAnimales
                    );
                }
                else
                {
                    decimal cantidadGeneral = decimal.TryParse(txtCantidad.Text, out decimal c) ? c : 0m;

                    if (esModificacion)
                    {
                        new Agraria.Datos.DAL.AbmStockDAL().Actualizar(
                            idStockFinal, idElemento, tipoElemento, nombre, ciclo, fechaAlta, fechaBaja, cantidadGeneral, precio, idProveedor, activo, vendible
                        );
                    }
                    else
                    {
                        new Agraria.Datos.DAL.AbmStockDAL().Insertar(
                            idStockFinal, idElemento, tipoElemento, nombre, ciclo, fechaAlta, fechaBaja, cantidadGeneral, precio, idProveedor, activo, vendible, null
                        );
                    }
                }

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
                txtNombre.Text = dr["Nombre"]?.ToString();

                cmbTipoElemento.SelectedIndexChanged -= cmbTipoElemento_SelectedIndexChanged;
                cmbTipoElemento.Text = dr["tipo_elemento"].ToString();
                cmbTipoElemento.SelectedIndexChanged += cmbTipoElemento_SelectedIndexChanged;

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
                    dtpFechaBaja.Format = DateTimePickerFormat.Short;
                    dtpFechaBaja.Value = Convert.ToDateTime(dr["fecha_baja"]);
                }
                else
                {
                    dtpFechaBaja.Format = DateTimePickerFormat.Custom;
                    dtpFechaBaja.CustomFormat = " ";
                }

                txtCantidad.Text = dr["cantidad"].ToString();

                if (dr["precio"] != DBNull.Value && decimal.TryParse(dr["precio"].ToString(), out decimal precioGuardado))
                {
                    numPrecio.Value = precioGuardado;
                }
                else
                {
                    numPrecio.Value = 0;
                }

                if (dr["id_proveedor"] != DBNull.Value)
                {
                    cmbProveedor.SelectedValue = Convert.ToInt64(dr["id_proveedor"]);
                }
                else
                {
                    cmbProveedor.SelectedIndex = -1;
                }

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
            cmbDatos.DataSource = null;
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
                DataTable dtVegetales = vegetalBLL.CargarCombo("vegetal");
                cmbDatos.DataSource = dtVegetales;
                cmbDatos.DisplayMember = "nombre_comun";
                cmbDatos.ValueMember = "id_vegetal";
                cmbDatos.SelectedIndex = -1;
            }
            else if (cmbTipoElemento.Text == "Articulo")
            {
                DataTable dtArticulos = articuloBLL.ObtenerArticulos();
                cmbDatos.DataSource = dtArticulos;
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
            dtpFechaBaja.Format = DateTimePickerFormat.Short;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbTipoElemento.Text == "Animal")
                {
                    // Usamos decimal.TryParse para que soporte el formato "5,00" o "5"
                    if (decimal.TryParse(txtCantidad.Text, out decimal cantidadDecimal) && cantidadDecimal > 0)
                    {
                        // Convertimos el decimal a entero para pasarlo al formulario de detalles
                        int cantidadAnimales = Convert.ToInt32(cantidadDecimal);

                        DetallesAnimal formDetalles = new DetallesAnimal(cantidadAnimales);

                        if (formDetalles.ShowDialog() == DialogResult.OK)
                        {
                            if (formDetalles.ListaAnimales != null)
                            {
                                txtCantidad.Text = formDetalles.ListaAnimales.Count.ToString();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No hay una cantidad válida de animales registrada para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("El botón de búsqueda de detalles solo está disponible para elementos de tipo Animal.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al abrir los detalles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmbDatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (idStockEditar != null) return;

            try
            {
                if (cmbDatos.SelectedIndex == -1 || cmbDatos.SelectedValue == null)
                {
                    txtCodigoStock.Clear();
                    return;
                }

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
                txtCodigoStock.Clear();
            }
        }
    }
}
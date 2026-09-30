using System;
using System.Data;
using System.Reflection;
using System.Windows.Forms;

namespace Agraria.Formularios
{
    public partial class AbmArticulos : Form
    {
        private Agraria.BLL.ArticulosBLL articulosBLL = new Agraria.BLL.ArticulosBLL();
        private object _usuarioActual;
        public long? idArticuloActual = null;

        // Constructor para ALTA NUEVA
        public AbmArticulos(object usuarioLogeado)
        {
            InitializeComponent();
            _usuarioActual = usuarioLogeado;
            idArticuloActual = null;
        }

        // Constructor para MODIFICACIÓN
        public AbmArticulos(object usuarioLogeado, long idArticulo, string nombre, string nombreMarca, float stockMinimo, string nombreCategoria)
        {
            InitializeComponent();
            _usuarioActual = usuarioLogeado;
            idArticuloActual = idArticulo;

            txtcodigoArticulo.Text = idArticulo.ToString();
            txtNombre.Text = nombre;
            numStockMinimo.Value = (decimal)stockMinimo;

            this.Tag = new { nombreMarca, nombreCategoria };
        }

        private void rjBAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombre.Text.Trim();

                if (string.IsNullOrEmpty(nombre))
                {
                    MessageBox.Show("El nombre del artículo es obligatorio.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cbmMarca.SelectedIndex == -1 || cbmMarca.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar una marca.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbcategoria.SelectedIndex == -1 || cmbcategoria.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar una categoría.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idMarca = Convert.ToInt32(cbmMarca.SelectedValue);
                float stockMinimo = (float)numStockMinimo.Value;
                int idCategoria = Convert.ToInt32(cmbcategoria.SelectedValue);

                if (idArticuloActual == null)
                {
                    long.TryParse(txtcodigoArticulo.Text, out long nuevoId);
                    articulosBLL.Insertar(nuevoId, nombre, idMarca, stockMinimo, idCategoria);
                    MessageBox.Show("¡Artículo guardado con éxito con el ID: " + nuevoId + "!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    articulosBLL.Modificar(idArticuloActual.Value, nombre, idMarca, stockMinimo, idCategoria);
                    MessageBox.Show("¡Artículo modificado con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rjBCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FormArticulosDetalle_Load_1(object sender, EventArgs e)
        {
            try
            {
                cbmMarca.DataSource = Agraria.Datos.ArticulosDAL.ObtenerMarcas();
                cbmMarca.DisplayMember = "nombre";
                cbmMarca.ValueMember = "id_marca";
                cbmMarca.SelectedIndex = -1;

                cmbcategoria.DataSource = Agraria.Datos.ArticulosDAL.ObtenerCategorias();
                cmbcategoria.DisplayMember = "nombre";
                cmbcategoria.ValueMember = "id_categoria";
                cmbcategoria.SelectedIndex = -1;

                if (idArticuloActual == null)
                {
                    int idUsuarioActual = 1;

                    if (_usuarioActual != null)
                    {
                        var prop = _usuarioActual.GetType().GetProperty("Id", BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                        if (prop != null)
                        {
                            var valorProp = prop.GetValue(_usuarioActual, null);
                            if (valorProp != null)
                            {
                                idUsuarioActual = Convert.ToInt32(valorProp);
                            }
                        }
                    }

                    long idSiguiente = articulosBLL.ObtenerSiguienteId(idUsuarioActual);

                    txtcodigoArticulo.Text = idSiguiente.ToString();
                    txtcodigoArticulo.ReadOnly = true;
                    txtcodigoArticulo.BackColor = System.Drawing.Color.LightGray;
                    numStockMinimo.Value = 0;
                }
                else
                {
                    txtcodigoArticulo.Text = idArticuloActual.Value.ToString();
                    txtcodigoArticulo.ReadOnly = true;
                    txtcodigoArticulo.BackColor = System.Drawing.Color.LightGray;

                    if (this.Tag != null)
                    {
                        var valores = (dynamic)this.Tag;

                        string marcaBuscada = valores.nombreMarca;
                        if (!string.IsNullOrEmpty(marcaBuscada))
                        {
                            int indexMarca = cbmMarca.FindStringExact(marcaBuscada);
                            if (indexMarca != -1) cbmMarca.SelectedIndex = indexMarca;
                        }

                        string categoriaBuscada = valores.nombreCategoria;
                        if (!string.IsNullOrEmpty(categoriaBuscada))
                        {
                            int indexCat = cmbcategoria.FindStringExact(categoriaBuscada);
                            if (indexCat != -1) cmbcategoria.SelectedIndex = indexCat;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos iniciales: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            txtNombre.Focus();
        }

        private void txtcodigoArticulo_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
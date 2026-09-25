using System;
using System.Data;
using System.Reflection;
using System.Windows.Forms;

namespace Agraria.Formularios
{
    public partial class AbmArticulos : Form
    {
        private Agraria.BLL.ArticulosBLL articulosBLL = new Agraria.BLL.ArticulosBLL();
        private object _usuarioActual; // Objeto de sesión del usuario logueado
        public long? idArticuloActual = null; // Si es null es alta nueva, si tiene valor es modificación

        // Constructor que recibe el usuario logueado para respetar la lógica de bloques
        public AbmArticulos(object usuarioLogeado)
        {
            InitializeComponent();
            _usuarioActual = usuarioLogeado;

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
                DateTime fechaAlta = dypFechaAlta.Value.Date;
                int idCategoria = Convert.ToInt32(cmbcategoria.SelectedValue);

                if (idArticuloActual == null)
                {
                    long.TryParse(txtcodigoArticulo.Text, out long nuevoId);

                    articulosBLL.Insertar(nuevoId, nombre, idMarca, fechaAlta, idCategoria);
                    MessageBox.Show("¡Artículo guardado con éxito con el ID: " + nuevoId + "!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    articulosBLL.Modificar(idArticuloActual.Value, nombre, idMarca, fechaAlta, idCategoria);
                    MessageBox.Show("¡Artículo modificado con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Notifica al formulario lista para refrescar la grilla
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
                if (idArticuloActual == null)
                {
                    // Extracción segura del ID del usuario (evita NullReferenceException si es null o no encuentra la propiedad)
                    int idUsuarioActual = 1; // Valor por defecto de respaldo

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
                    txtcodigoArticulo.BackColor = System.Drawing.Color.LightGray; // Bloqueado visualmente
                }
                else
                {
                    txtcodigoArticulo.Text = idArticuloActual.Value.ToString();
                    txtcodigoArticulo.ReadOnly = true;
                    txtcodigoArticulo.BackColor = System.Drawing.Color.LightGray;
                }

                // Cargar los ComboBox de Marcas y Categorías usando la BLL/DAL
                cbmMarca.DataSource = Agraria.Datos.ArticulosDAL.ObtenerMarcas();
                cbmMarca.DisplayMember = "nombre";
                cbmMarca.ValueMember = "id_marca";
                cbmMarca.SelectedIndex = -1;

                cmbcategoria.DataSource = Agraria.Datos.ArticulosDAL.ObtenerCategorias();
                cmbcategoria.DisplayMember = "nombre";
                cmbcategoria.ValueMember = "id_categoria";
                cmbcategoria.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos iniciales: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtNombre.Focus();

        }
    }
}
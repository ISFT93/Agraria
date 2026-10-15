using Agraria.Datos.DTO;
using Agraria.Datos.Entidades;
using Agraria.Negocio;
using Agraria.Negocio.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agraria.Formularios
{
    public partial class AbmUsuario : Form
    {
        public AbmUsuarioBLL AbmUsuarioBLL = new AbmUsuarioBLL();
        private bool esInvitado = false;
        private int? idUsuarioEditar = null;
        private UsuarioLoginDTO _usuarioActual; // Recibimos la sesión real

        // Constructor para NUEVO
        public AbmUsuario(UsuarioLoginDTO usuarioLogeado, bool invitado = false)
        {
            InitializeComponent();
            _usuarioActual = usuarioLogeado;
            esInvitado = invitado;

            CargarComboBoxes();

            if (esInvitado)
                DeshabilitarControles();
        }

        // Constructor para MODIFICAR
        public AbmUsuario(int idUsuario, UsuarioLoginDTO usuarioLogeado) : this(usuarioLogeado)
        {
            idUsuarioEditar = idUsuario;
            CargarDatos(idUsuarioEditar.Value);
        }

        private void CargarDatos(int id)
        {
            // Buscamos los datos del usuario en la lista utilizando su ID
            List<AbmUsuarioDTO> usuarios = AbmUsuarioBLL.CargarTodoslosUsuarios();
            var usuario = usuarios.FirstOrDefault(u => u.Id == id);

            if (usuario != null)
            {
                txtNombre.Text = usuario.Nombre;
                txtApellido.Text = usuario.Apellido;
                txtDocumento.Text = usuario.Documento.ToString();
                txtDireccion.Text = usuario.Direccion;
                txtTelefono.Text = usuario.Telefono;
                cmbPartido.Text = usuario.Partido;
                cmbLocalidad.Text = usuario.Localidad;
                txtCodigoPostal.Text = usuario.CodigoPostal.ToString();
                txtEmail.Text = usuario.Email;
                txtNombreUsuario.Text = usuario.NombreUsuario;
                txtContraseña.Text = usuario.Contraseña;
                cmbPreguntaSeguridad.Text = usuario.PreguntaSeguridad;
                txtRespuestaSeguridad.Text = usuario.RespuestaSeguridad;

                // Cargar los permisos
                var permisos = AbmUsuarioBLL.ObtenerPermisosPorUsuario(id);
                chkEntornoFormativo.Checked = permisos.PuedeEntornoFormativo;
                chkAltaUsuario.Checked = permisos.PuedeAltaUsuario;
                chkVenta.Checked = permisos.PuedeVenta;
                chkInventario.Checked = permisos.PuedeInventario;
                chkIndustria.Checked = permisos.PuedeIndustria;
                chkProduccionAnimal.Checked = permisos.PuedeProduccionAnimal;
                chkProduccionVegetal.Checked = permisos.PuedeProduccionVegetal;
                chkAdministracion.Checked = permisos.PuedeAdministracion;
                chkPañol.Checked = permisos.PuedePañol;
            }
        }

        private void DeshabilitarControles()
        {
            DeshabilitarControlesRecursivo(this);
        }

        private void DeshabilitarControlesRecursivo(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is TextBox txt)
                    txt.ReadOnly = true;
                else if (c is ComboBox combo)
                    combo.Enabled = false;
                else if (c is Button btn && btn.Name != "btnCancelar") // Dejamos libre Cancelar
                    btn.Enabled = false;
                else if (c is CheckBox chk)
                    chk.Enabled = false;

                // 🔁 Recorre los hijos
                if (c.HasChildren)
                    DeshabilitarControlesRecursivo(c);
            }
        }

        private void CargarComboBoxes()
        {
            cmbPartido.DataSource = AbmUsuarioBLL.CargarPartidos();
            cmbPartido.DisplayMember = "NombrePartido";
            cmbPartido.ValueMember = "IdPartido";
            cmbPartido.SelectedIndex = -1;

            cmbLocalidad.DataSource = AbmUsuarioBLL.CargarLocalidades();
            cmbLocalidad.DisplayMember = "NombreLocalidad";
            cmbLocalidad.ValueMember = "IdLocalidad";
            cmbLocalidad.SelectedIndex = -1;

            cmbPreguntaSeguridad.DataSource = AbmUsuarioBLL.CargarPreguntasSeguridad();
            cmbPreguntaSeguridad.DisplayMember = "TextoPregunta";
            cmbPreguntaSeguridad.ValueMember = "IdPregunta";
            cmbPreguntaSeguridad.SelectedIndex = -1;
        }

        private void cmbPartido_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPartido.SelectedValue != null && cmbPartido.SelectedValue is int idPartido)
            {
                cmbLocalidad.DataSource = AbmUsuarioBLL.CargarLocalidadesPorPartido(idPartido);
                cmbLocalidad.DisplayMember = "NombreLocalidad";
                cmbLocalidad.ValueMember = "IdLocalidad";
                cmbLocalidad.SelectedIndex = -1;
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtDocumento.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                cmbLocalidad.SelectedIndex == -1 ||
                cmbPartido.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtNombreUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtContraseña.Text) ||
                cmbPreguntaSeguridad.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtRespuestaSeguridad.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            try
            {
                bool esModificacion = (idUsuarioEditar != null);

                // Armamos la entidad del Usuario
                var usuario = new Agraria.Datos.Entidades.AbmUsuario
                {
                    Id = esModificacion ? idUsuarioEditar.Value : 0,
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Documento = int.Parse(txtDocumento.Text),
                    Telefono = txtTelefono.Text,
                    Direccion = txtDireccion.Text,
                    IdLocalidad = new LocalidadDTO { NombreLocalidad = cmbLocalidad.Text },
                    IdPartido = new PartidoDTO { NombrePartido = cmbPartido.Text },
                    IdPreguntaSeguridad = new PreguntaSeguridadDTO { TextoPregunta = cmbPreguntaSeguridad.Text },
                    Email = txtEmail.Text,
                    NombreUsuario = txtNombreUsuario.Text,
                    Contraseña = txtContraseña.Text,
                    RespuestaSeguridad = txtRespuestaSeguridad.Text,
                    Estado = true
                };

                if (!esModificacion)
                {
                    // NUEVO USUARIO
                    int nuevoId = AbmUsuarioBLL.InsertarUsuarioYObtenerId(usuario);

                    AbmUsuarioBLL.GuardarPermisos(
                        nuevoId,
                        chkEntornoFormativo.Checked,
                        chkAltaUsuario.Checked,
                        chkVenta.Checked,
                        chkInventario.Checked,
                        chkIndustria.Checked,
                        chkProduccionAnimal.Checked,
                        chkProduccionVegetal.Checked,
                        chkAdministracion.Checked,
                        chkPañol.Checked
                    );

                    MessageBox.Show("Usuario creado correctamente con sus permisos.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // MODIFICAR USUARIO EXISTENTE
                    AbmUsuarioBLL.ModificarUsuario(usuario);

                    AbmUsuarioBLL.ActualizarPermisos(
                        usuario.Id,
                        chkEntornoFormativo.Checked,
                        chkAltaUsuario.Checked,
                        chkVenta.Checked,
                        chkInventario.Checked,
                        chkIndustria.Checked,
                        chkProduccionAnimal.Checked,
                        chkProduccionVegetal.Checked,
                        chkAdministracion.Checked,
                        chkPañol.Checked
                    );

                    MessageBox.Show("Usuario modificado y permisos actualizados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Cierra y avisa a ListarUsuario que todo salió bien
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // --- VALIDACIONES DE CAMPOS (Mantenemos tus configuraciones de teclado) ---
        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloNumeros(e);
        }

        private void Solotexto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloTexto(e);
        }

        private void TextoyNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.TextoYNumero(e);
        }

        private void CopiaryPegar_KeyDown(object sender, KeyEventArgs e)
        {
            Validaciones.DeshabilitarCopiarPegar(e);
        }

        private void SoloTextoNumeroEspacio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloTextoNumeroEspacio(e);
        }
    }
}
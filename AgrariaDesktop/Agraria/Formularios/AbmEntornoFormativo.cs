using Agraria.Datos.DTO;
using Agraria.Datos.Entidades;
using Agraria.Negocio;
using Agraria.Negocio.BLL;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Agraria.Formularios
{
    public partial class AbmEntornoFormativo : Form
    {
        private EntornoFormativoBLL entornoBLL = new EntornoFormativoBLL();
        private bool esInvitado = false;
        private int? idEntornoEditar = null;
        private UsuarioLoginDTO _usuarioActual; // Sesión real

        // Constructor para NUEVO
        public AbmEntornoFormativo(UsuarioLoginDTO usuarioLogeado, bool invitado = false)
        {
            InitializeComponent();
            _usuarioActual = usuarioLogeado;
            esInvitado = invitado;

            CargarTipoEntorno();

            if (esInvitado)
                DeshabilitarControles();
        }

        // Constructor para MODIFICAR
        public AbmEntornoFormativo(int idEntorno, UsuarioLoginDTO usuarioLogeado, bool invitado = false) : this(usuarioLogeado, invitado)
        {
            idEntornoEditar = idEntorno;
            CargarDatos(idEntornoEditar.Value);
        }

        private void CargarTipoEntorno()
        {
            cmbTipoEntorno.DataSource = EntornoFormativoBLL.ObtenerTipoEntornos();
            cmbTipoEntorno.DisplayMember = "Nombre";
            cmbTipoEntorno.ValueMember = "IdTipoEntorno";
            cmbTipoEntorno.SelectedIndex = -1;
        }

        private void CargarDatos(int id)
        {
            // Buscamos los datos del entorno en la lista utilizando su ID
            var lista = entornoBLL.ObtenerEntornos();
            var entorno = lista.FirstOrDefault(e => e.IdEntorno == id);

            if (entorno != null)
            {
                txtNombreEntorno.Text = entorno.Nombre;
                cmbTipoEntorno.Text = entorno.IdTipoEntorno; // O el campo que represente el texto en tu DTO
                txtProfesorResponsable.Text = entorno.Responsable;
                txtAño.Text = entorno.Año;
                txtDivision.Text = entorno.Division;
                txtGrupo.Text = entorno.Grupo;
                dtpFecha.Value = entorno.Fecha;
                txtObservacion.Text = entorno.Observaciones;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombreEntorno.Text) || cmbTipoEntorno.SelectedIndex == -1)
                {
                    MessageBox.Show("El nombre y el tipo de entorno son obligatorios.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool esModificacion = (idEntornoEditar != null);

                EntornoFormativo entorno = new EntornoFormativo
                {
                    IdEntorno = esModificacion ? idEntornoEditar.Value : 0,
                    Nombre = txtNombreEntorno.Text,
                    IdTipoEntorno = (int)cmbTipoEntorno.SelectedValue,
                    Responsable = txtProfesorResponsable.Text,
                    Año = txtAño.Text,
                    Division = txtDivision.Text,
                    Grupo = txtGrupo.Text,
                    Fecha = dtpFecha.Value,
                    Observaciones = txtObservacion.Text
                };

                if (esModificacion)
                {
                    EntornoFormativoBLL.ModificarEntorno(entorno);
                }
                else
                {
                    entornoBLL.Guardar(entorno);
                }

                // Lógica de Urgencia
                /*
                if (chkUrgencia.Checked)
                {
                    string mensaje = $"🚨 URGENCIA - El entorno de {entorno.Nombre} (Del Grupo {entorno.Grupo} Division {entorno.Division}) - Observaciones: {entorno.Observaciones}";
                    UrgenciaBLL urgenciaBLL = new UrgenciaBLL();
                    urgenciaBLL.Agregar(mensaje);
                    MessageBox.Show("Se registró una urgencia.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                */

                MessageBox.Show("Datos guardados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar entorno: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void DeshabilitarControles()
        {
            DeshabilitarControlesRecursivo(this);
        }

        private void DeshabilitarControlesRecursivo(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is TextBox txt) txt.ReadOnly = true;
                else if (c is ComboBox combo) combo.Enabled = false;
                else if (c is Button btn && btn.Name != "btnCancelar") btn.Enabled = false; // Dejar salir
                if (c.HasChildren) DeshabilitarControlesRecursivo(c);
            }
        }

        // --- VALIDACIONES DE CAMPOS ---
        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e) => Validaciones.SoloNumeros(e);
        private void Solotexto_KeyPress(object sender, KeyPressEventArgs e) => Validaciones.SoloTexto(e);
        private void TextoyNumero_KeyPress(object sender, KeyPressEventArgs e) => Validaciones.TextoYNumero(e);
        private void CopiaryPegar_KeyDown(object sender, KeyEventArgs e) => Validaciones.DeshabilitarCopiarPegar(e);
        private void SoloTextoNumeroEspacio_KeyPress(object sender, KeyPressEventArgs e) => Validaciones.SoloTextoNumeroEspacio(e);
    }
}
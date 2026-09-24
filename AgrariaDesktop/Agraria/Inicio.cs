using Agraria.Datos.DAL;
using Agraria.Datos.DTO;
using Agraria.Formularios;
using Agraria.Negocio.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Agraria
{
    public partial class Inicio : Form
    {
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;
        private List<Form> formulariosAbiertos = new List<Form>();
        private System.Windows.Forms.Timer timer;
        private UsuarioLoginDTO usuarioLogeado;
        UrgenciaBLL urgenciaBLL = new UrgenciaBLL();
        private bool esInvitado = false;

        //habilitar movimiento del formulario
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        /// <summary>
        ///  hasta aqui
        /// </summary>
        /// <param name="usuario"></param>
        public Inicio(UsuarioLoginDTO usuario)
        {
            InitializeComponent();
            random = new Random();
            usuarioLogeado = usuario;
            esInvitado = false;

        }
        public Inicio(bool modoInvitado)
        {
            InitializeComponent();
            esInvitado = modoInvitado;
            usuarioLogeado = null;
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            Formularios.Login login = new Formularios.Login();
            login.ShowDialog();
        }

        private void btnUsuarioAlta_Click(object sender, EventArgs e)
        {
            CerrarTodosLosFormularios();

            // ✅ Pasamos el parámetro esInvitado al mismo formulario MDI
            var cargaForm = new Formularios.AbmUsuario(esInvitado);

            cargaForm.MdiParent = this;
            cargaForm.Dock = DockStyle.Fill;
            cargaForm.Show();

            formulariosAbiertos.Add(cargaForm);
            activeForm = cargaForm;
        }

        private void CerrarTodosLosFormularios()
        {
            foreach (var formulario in formulariosAbiertos)
            {
                if (formulario != null && !formulario.IsDisposed)
                {
                    formulario.Close();
                }
            }

            formulariosAbiertos.Clear();
        }

        private void pbCerrarAgraria_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEntornoFormativo_Click(object sender, EventArgs e)
        {
            CerrarTodosLosFormularios();

            // ✅ Pasamos el parámetro esInvitado al mismo formulario MDI
            var cargaForm = new Formularios.AbmEntornoFormativo(esInvitado);

            cargaForm.MdiParent = this;
            cargaForm.Dock = DockStyle.Fill;
            cargaForm.Show();

            formulariosAbiertos.Add(cargaForm);
            activeForm = cargaForm;
        }

        private void btnVenta_Click(object sender, EventArgs e)
        {
            CerrarTodosLosFormularios();

            // ✅ Pasamos el parámetro esInvitado al mismo formulario MDI
            var cargaForm = new Formularios.RegistroVenta(esInvitado);

            cargaForm.MdiParent = this;
            cargaForm.Dock = DockStyle.Fill;
            cargaForm.Show();

            formulariosAbiertos.Add(cargaForm);
            activeForm = cargaForm;
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void btnProduccionAnimal_Click(object sender, EventArgs e)
        {
            CerrarTodosLosFormularios();

            // Pasamos el parámetro esInvitado al mismo formulario MDI
            var cargaForm = new Formularios.ProduccionAnimal(usuarioLogeado, esInvitado);

            cargaForm.MdiParent = this;
            cargaForm.Dock = DockStyle.Fill;
            cargaForm.Show();

            formulariosAbiertos.Add(cargaForm);
            activeForm = cargaForm;
        }

        private void btnProduccionVegetal_Click(object sender, EventArgs e)
        {
            CerrarTodosLosFormularios();

            // ✅ Pasamos el parámetro esInvitado al mismo formulario MDI
            var cargaForm = new Formularios.ListarVegetales(usuarioLogeado, esInvitado);

            cargaForm.MdiParent = this;
            cargaForm.Dock = DockStyle.Fill;
            cargaForm.Show();

            formulariosAbiertos.Add(cargaForm);
            activeForm = cargaForm;
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            if (usuarioLogeado != null)
            {
                AplicarPermisos();
            }
            else
            {
                ActivarModoInvitado();
            }
        }

        private void btnIndustria_Click(object sender, EventArgs e)
        {
            CerrarTodosLosFormularios();

            // ✅ Pasamos el parámetro esInvitado al mismo formulario MDI
            var cargaForm = new Formularios.Industria(esInvitado);

            cargaForm.MdiParent = this;
            cargaForm.Dock = DockStyle.Fill;
            cargaForm.Show();

            formulariosAbiertos.Add(cargaForm);
            activeForm = cargaForm;
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            CerrarTodosLosFormularios();

            // ✅ Pasamos el parámetro esInvitado al mismo formulario MDI
            var cargaForm = new Formularios.Inventario(esInvitado);

            cargaForm.MdiParent = this;
            cargaForm.Dock = DockStyle.Fill;
            cargaForm.Show();

            formulariosAbiertos.Add(cargaForm);
            activeForm = cargaForm;
        }

        private void btnAdministracion_Click(object sender, EventArgs e)
        {
            CerrarTodosLosFormularios();

            // ✅ Pasamos el parámetro esInvitado al mismo formulario MDI
            var cargaForm = new Formularios.AbmAdministracion(esInvitado);

            cargaForm.MdiParent = this;
            cargaForm.Dock = DockStyle.Fill;
            cargaForm.Show();

            formulariosAbiertos.Add(cargaForm);
            activeForm = cargaForm;
        }

        private void pbUrgencias_Click(object sender, EventArgs e)
        {
            UrgenciaBLL urgenciaBLL = new UrgenciaBLL();
            var mensajes = urgenciaBLL.ObtenerMensajesDelDia();

            if (mensajes.Count == 0)
            {
                MessageBox.Show("No hay mensajes de urgencia pendientes para hoy.",
                    "Urgencias", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string texto = string.Join("\n\n", mensajes);
            MessageBox.Show(texto, "🚨 Urgencias del día 🚨", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void AplicarPermisos()
        {
            entornosFormativosToolStripMenuItem.Enabled = usuarioLogeado.PuedeEntornoFormativo;
            altaDeUsuarioToolStripMenuItem.Enabled = usuarioLogeado.PuedeAltaUsuario;
            ventasToolStripMenuItem.Enabled = usuarioLogeado.PuedeVenta;
            inventarioToolStripMenuItem.Enabled = usuarioLogeado.PuedeInventario;
            industriaToolStripMenuItem.Enabled = usuarioLogeado.PuedeIndustria;
            produccionAnimalToolStripMenuItem.Enabled = usuarioLogeado.PuedeProduccionAnimal;
            produccionVegetalToolStripMenuItem.Enabled = usuarioLogeado.PuedeProduccionVegetal;
            administracionToolStripMenuItem.Enabled = usuarioLogeado.PuedeAdministracion;
        }

        private void ActivarModoInvitado()
        {
            entornosFormativosToolStripMenuItem.Enabled = true;
            altaDeUsuarioToolStripMenuItem.Enabled = true;
            ventasToolStripMenuItem.Enabled = true;
            inventarioToolStripMenuItem.Enabled = true;
            industriaToolStripMenuItem.Enabled = true;
            produccionAnimalToolStripMenuItem.Enabled = true;
            produccionVegetalToolStripMenuItem.Enabled = true;
            administracionToolStripMenuItem.Enabled = true;
        }

        private void panelSuperior_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void btnPañol_Click(object sender, EventArgs e)
        {
            CerrarTodosLosFormularios();

            // Pasamos el usuario actual
            var cargaForm = new Formularios.FormArticulosLista(usuarioLogeado);

            // Quitamos MdiParent y Dock.Fill para que respete sus 900x550
            cargaForm.StartPosition = FormStartPosition.CenterScreen;
            cargaForm.Show();

            formulariosAbiertos.Add(cargaForm);
            activeForm = cargaForm;
        }

        private void lblUsuario_Click(object sender, EventArgs e)
        {
        }

        private void entornoAnimalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarTodosLosFormularios();

            // Instancia el formulario pasando el estado de invitado/permisos
            var cargaForm = new Formularios.FormAnimal(esInvitado);

            // Centrar en pantalla respetando sus dimensiones propias
            cargaForm.StartPosition = FormStartPosition.CenterScreen;
            cargaForm.Show();

            // Registro de formularios activos
            formulariosAbiertos.Add(cargaForm);
            activeForm = cargaForm;
        }
    }
}
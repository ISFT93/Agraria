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
        // UrgenciaBLL urgenciaBLL = new UrgenciaBLL();
        private bool esInvitado = false;

        // Evita mostrar el login más de una vez
        private bool loginPresentado = false;

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


        /// Se ejecuta cuando el form ya está mostrado; aquí abrimos el Login centrado sobre Inicio

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (!loginPresentado && usuarioLogeado == null)
            {
                loginPresentado = true;
                MostrarLoginModal();
            }
        }

        private void MostrarLoginModal()
        {
            using (var login = new Formularios.Login())
            {
                login.StartPosition = FormStartPosition.CenterParent;
                var result = login.ShowDialog(this);

                if (result == DialogResult.OK)
                {
                    if (login.EsInvitado)
                    {
                        esInvitado = true;
                        usuarioLogeado = null;
                        ActivarModoInvitado();

                        MessageBox.Show("Entraste en modo invitado.\nPodés navegar pero no modificar datos.",
                            "Modo Invitado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (login.UsuarioAutenticado != null)
                    {
                        usuarioLogeado = login.UsuarioAutenticado;
                        esInvitado = false;
                        AplicarPermisos();
                    }
                }
                else
                {
                    // Si cierra sin autenticarse, salir (puedes cambiar este comportamiento)
                    Application.Exit();
                }
            }
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            Formularios.Login login = new Formularios.Login();
            login.ShowDialog();
        }

        private void btnUsuarioAlta_Click(object sender, EventArgs e)
        {
            CerrarTodosLosFormularios();

            var cargaForm = new Formularios.ListarUsuario(usuarioLogeado, esInvitado);
            cargaForm.MdiParent = this;
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



        private void btnEntornoFormativo_Click(object sender, EventArgs e)
        {
            CerrarTodosLosFormularios();

            var cargaForm = new Formularios.ListarEntornoFormativo(usuarioLogeado, esInvitado);
            cargaForm.MdiParent = this;
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



        private void btnEntornoVegetal_Click(object sender, EventArgs e)
        {
            CerrarTodosLosFormularios();

            var cargaForm = new Formularios.ListarVegetales(usuarioLogeado, esInvitado);
            cargaForm.MdiParent = this;
            //cargaForm.Dock = DockStyle.Fill;
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
            var cargaForm = new Formularios.Dashboard();
            cargaForm.MdiParent = this;
            cargaForm.MaximizeBox = true;
            cargaForm.Dock = DockStyle.Fill;
            cargaForm.Show();
        }



        private void btnAdministracion_Click(object sender, EventArgs e)
        {
            CerrarTodosLosFormularios();

            var cargaForm = new Formularios.AbmAdministracion(esInvitado);
            cargaForm.MdiParent = this;
            cargaForm.Show();

            formulariosAbiertos.Add(cargaForm);
            activeForm = cargaForm;
        }


        private void AplicarPermisos()
        {
            entornosFormativosToolStripMenuItem.Enabled = usuarioLogeado.PuedeEntornoFormativo;
            altaDeUsuarioToolStripMenuItem.Enabled = usuarioLogeado.PuedeAltaUsuario;
            EntornoVegetalToolStripMenuItem.Enabled = usuarioLogeado.PuedeProduccionVegetal;
            administracionToolStripMenuItem.Enabled = usuarioLogeado.PuedeAdministracion;
        }

        private void ActivarModoInvitado()
        {
            entornosFormativosToolStripMenuItem.Enabled = true;
            altaDeUsuarioToolStripMenuItem.Enabled = true;
            EntornoVegetalToolStripMenuItem.Enabled = true;
            administracionToolStripMenuItem.Enabled = true;
        }



        private void btnArticulos_Click(object sender, EventArgs e)
        {
            CerrarTodosLosFormularios();

            var cargaForm = new Formularios.ListaArticulos(usuarioLogeado);
            cargaForm.MdiParent = this;
            cargaForm.Show();

            formulariosAbiertos.Add(cargaForm);
            activeForm = cargaForm;
        }


        private void btnEntornoAnimal_Click(object sender, EventArgs e)
        {
            CerrarTodosLosFormularios();

            // 🟢 Corregido: se usa 'usuarioLogeado' (con una sola 'o') y se pasa 'esInvitado'
            var cargaForm = new Formularios.ListaAnimales(usuarioLogeado, esInvitado);
            cargaForm.MdiParent = this;
            cargaForm.Show();

            formulariosAbiertos.Add(cargaForm);
            activeForm = cargaForm;
        }


        private void ciclosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarTodosLosFormularios();

            var cargaForm = new Formularios.ListarCiclos(usuarioLogeado, esInvitado);
            cargaForm.MdiParent = this;
            //cargaForm.Dock = DockStyle.Fill;
            cargaForm.Show();

            formulariosAbiertos.Add(cargaForm);
            activeForm = cargaForm;

        }

        private void StocktoolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarTodosLosFormularios();

            var cargaForm = new Formularios.ListarStock(usuarioLogeado, esInvitado);
            cargaForm.MdiParent = this;
            //cargaForm.Dock = DockStyle.Fill;
            cargaForm.Show();

            formulariosAbiertos.Add(cargaForm);
            activeForm = cargaForm;
        }
    }
}
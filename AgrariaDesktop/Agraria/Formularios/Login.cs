using Agraria.Datos.DAL;
using Agraria.Datos.DTO;
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
//using static System.Windows.Forms.VisualStyleElement.Window;
using System.Runtime.InteropServices;


namespace Agraria.Formularios
{
    public partial class Login : Form
    {
        private readonly UsuarioLoginBLL usuarioLoginBLL;

        /// <summary>
        /// //// habilitar movimiento del formulario
        /// </summary>

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        /// <summary>
        /// // hasta aqui
        /// </summary>

        // Propiedades públicas para que el form propietario (Inicio) reciba el resultado
        public UsuarioLoginDTO UsuarioAutenticado { get; private set; }
        public bool EsInvitado { get; private set; } = false;

        public Login()
        {
            InitializeComponent();
            usuarioLoginBLL = new UsuarioLoginBLL();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            /*
            try
            {
                var usuarioBLL = new AbmUsuarioBLL();

                // ✅ Si no hay usuarios, crear el admin por única vez
                if (!usuarioBLL.HayUsuariosRegistrados())
                {
                    usuarioBLL.CrearUsuarioAdminInicial();

                    MessageBox.Show(
                        "Se ha creado un usuario administrador inicial.\n\n" +
                        "Usuario: admin\nContraseña: 123\n\n" +
                        "Por favor, inicie sesión con estas credenciales y cambie la contraseña desde su perfil.",
                        "Usuario Administrador Creado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar usuario administrador inicial: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            */
        }

        private void pbCerrar_Click(object sender, EventArgs e)
        {
            // Si cierra sin autenticar, cerrará el diálogo retornando Cancel al propietario
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Event handler actualizado: ahora asíncrono y muestra reloj de arena hasta que finaliza el proceso
        private async void btnAceptarLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string pass = txtContraseña.Text.Trim();

            // Deshabilitar controles para evitar múltiples envíos
            var controlesAffectados = new Control[] { txtUsuario, txtContraseña, btnIngresar };
            foreach (var c in controlesAffectados) c.Enabled = false;

            // Mostrar cursor de espera a nivel de formulario/ aplicación
            this.UseWaitCursor = true;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                // Ejecutar autenticación en hilo de fondo para no bloquear la UI
                var user = await Task.Run(() => usuarioLoginBLL.Autenticar(usuario, pass));

                if (user != null)
                {
                    // Devolvemos el usuario al formulario propietario en lugar de crear otro Inicio
                    UsuarioAutenticado = user;
                    EsInvitado = false;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Manejo mínimo de errores; opcionalmente loguear
                MessageBox.Show("Error durante la autenticación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Restaurar cursor y re-habilitar controles
                this.UseWaitCursor = false;
                Cursor.Current = Cursors.Default;
                foreach (var c in controlesAffectados) c.Enabled = true;
            }
        }


        private void lblOlvidarContraseña_Click(object sender, EventArgs e)
        {
            Formularios.CambiarContraseña cambiar = new CambiarContraseña();
            cambiar.ShowDialog();
        }

        private void lblInvitado_Click(object sender, EventArgs e)
        {
            // Marca modo invitado y cierra el diálogo con OK para que el propietario lo procese
            UsuarioAutenticado = null;
            EsInvitado = true;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private void CopiaryPegar_KeyDown(object sender, KeyEventArgs e)
        {
            Validaciones.DeshabilitarCopiarPegar(e);
        }


        private void SoloTextoNumeroEspacio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloTextoNumeroEspacio(e);
        }

        private void panelSuperior_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }



    }
}
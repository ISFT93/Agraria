namespace Agraria.Formularios
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            txtUsuario = new TextBox();
            txtContraseña = new TextBox();
            lblUsuario = new Label();
            lblContraseña = new Label();
            pictureBox1 = new PictureBox();
            lblOlvidarContraseña = new Label();
            lblInvitado = new Label();
            errorProvider1 = new ErrorProvider(components);
            btnIngresar = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // txtUsuario
            // 
            txtUsuario.BorderStyle = BorderStyle.FixedSingle;
            txtUsuario.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtUsuario.Location = new Point(321, 84);
            txtUsuario.Margin = new Padding(2, 2, 2, 2);
            txtUsuario.MaxLength = 50;
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(114, 29);
            txtUsuario.TabIndex = 1;
            txtUsuario.KeyDown += CopiaryPegar_KeyDown;
            txtUsuario.KeyPress += SoloTextoNumeroEspacio_KeyPress;
            // 
            // txtContraseña
            // 
            txtContraseña.BorderStyle = BorderStyle.FixedSingle;
            txtContraseña.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtContraseña.Location = new Point(321, 137);
            txtContraseña.Margin = new Padding(2, 2, 2, 2);
            txtContraseña.MaxLength = 6;
            txtContraseña.Name = "txtContraseña";
            txtContraseña.PasswordChar = '*';
            txtContraseña.Size = new Size(114, 29);
            txtContraseña.TabIndex = 2;
            txtContraseña.KeyDown += CopiaryPegar_KeyDown;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.BackColor = Color.Transparent;
            lblUsuario.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblUsuario.ForeColor = Color.Black;
            lblUsuario.Location = new Point(223, 83);
            lblUsuario.Margin = new Padding(2, 0, 2, 0);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(87, 24);
            lblUsuario.TabIndex = 6;
            lblUsuario.Text = "Usuario:";
            // 
            // lblContraseña
            // 
            lblContraseña.AutoSize = true;
            lblContraseña.BackColor = Color.Transparent;
            lblContraseña.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblContraseña.ForeColor = Color.Black;
            lblContraseña.Location = new Point(185, 134);
            lblContraseña.Margin = new Padding(2, 0, 2, 0);
            lblContraseña.Name = "lblContraseña";
            lblContraseña.Size = new Size(122, 24);
            lblContraseña.TabIndex = 7;
            lblContraseña.Text = "Contraseña:";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImage = Properties.Resources.agr;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(30, 71);
            pictureBox1.Margin = new Padding(0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(142, 128);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // lblOlvidarContraseña
            // 
            lblOlvidarContraseña.AutoSize = true;
            lblOlvidarContraseña.BackColor = Color.Transparent;
            lblOlvidarContraseña.Cursor = Cursors.Hand;
            lblOlvidarContraseña.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            lblOlvidarContraseña.ForeColor = Color.Black;
            lblOlvidarContraseña.Location = new Point(279, 208);
            lblOlvidarContraseña.Name = "lblOlvidarContraseña";
            lblOlvidarContraseña.Size = new Size(184, 16);
            lblOlvidarContraseña.TabIndex = 5;
            lblOlvidarContraseña.Text = "Olvidaste tu Contraseña ?";
            lblOlvidarContraseña.Click += lblOlvidarContraseña_Click;
            // 
            // lblInvitado
            // 
            lblInvitado.AutoSize = true;
            lblInvitado.BackColor = Color.Transparent;
            lblInvitado.Cursor = Cursors.Hand;
            lblInvitado.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            lblInvitado.ForeColor = Color.Black;
            lblInvitado.Location = new Point(20, 209);
            lblInvitado.Name = "lblInvitado";
            lblInvitado.Size = new Size(196, 16);
            lblInvitado.TabIndex = 4;
            lblInvitado.Text = "INGRESAR CON INVITADO";
            lblInvitado.Click += lblInvitado_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // btnIngresar
            // 
            btnIngresar.BackgroundImageLayout = ImageLayout.Stretch;
            btnIngresar.Location = new Point(333, 170);
            btnIngresar.Margin = new Padding(3, 2, 3, 2);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(91, 29);
            btnIngresar.TabIndex = 3;
            btnIngresar.Text = "&Login";
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.Click += btnAceptarLogin_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(56, 124, 31);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(530, 253);
            Controls.Add(btnIngresar);
            Controls.Add(lblInvitado);
            Controls.Add(lblOlvidarContraseña);
            Controls.Add(pictureBox1);
            Controls.Add(lblContraseña);
            Controls.Add(lblUsuario);
            Controls.Add(txtContraseña);
            Controls.Add(txtUsuario);
            Margin = new Padding(2, 2, 2, 2);
            Name = "Login";
            Padding = new Padding(3, 48, 3, 2);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += Login_Load;
            MouseDown += panelSuperior_MouseDown;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblContraseña;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Label lblOlvidarContraseña;
        private Label lblInvitado;
        private ErrorProvider errorProvider1;
        private Button btnIngresar;
    }
}
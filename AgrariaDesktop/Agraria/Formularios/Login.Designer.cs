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
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            txtUsuario = new TextBox();
            txtContraseña = new TextBox();
            lblUsuario = new Label();
            lblContraseña = new Label();
            pictureBox1 = new PictureBox();
            pbCerrar = new PictureBox();
            btnIngresar = new Tienda.RJButton();
            lblOlvidarContraseña = new Label();
            lblInvitado = new Label();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbCerrar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(2, 3, 2, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(545, 15);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 257);
            panel2.Margin = new Padding(2, 3, 2, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(545, 15);
            panel2.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(0, 15);
            panel3.Margin = new Padding(2, 3, 2, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(14, 242);
            panel3.TabIndex = 2;
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.Dock = DockStyle.Right;
            panel4.Location = new Point(531, 15);
            panel4.Margin = new Padding(2, 3, 2, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(14, 242);
            panel4.TabIndex = 3;
            // 
            // txtUsuario
            // 
            txtUsuario.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtUsuario.Location = new Point(363, 63);
            txtUsuario.Margin = new Padding(2, 3, 2, 3);
            txtUsuario.MaxLength = 50;
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(130, 34);
            txtUsuario.TabIndex = 4;
            txtUsuario.KeyDown += CopiaryPegar_KeyDown;
            txtUsuario.KeyPress += SoloTextoNumeroEspacio_KeyPress;
            // 
            // txtContraseña
            // 
            txtContraseña.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtContraseña.Location = new Point(363, 133);
            txtContraseña.Margin = new Padding(2, 3, 2, 3);
            txtContraseña.MaxLength = 6;
            txtContraseña.Name = "txtContraseña";
            txtContraseña.PasswordChar = '*';
            txtContraseña.Size = new Size(130, 34);
            txtContraseña.TabIndex = 5;
            txtContraseña.KeyDown += CopiaryPegar_KeyDown;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.BackColor = Color.Transparent;
            lblUsuario.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblUsuario.ForeColor = Color.Black;
            lblUsuario.Location = new Point(251, 61);
            lblUsuario.Margin = new Padding(2, 0, 2, 0);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(110, 29);
            lblUsuario.TabIndex = 6;
            lblUsuario.Text = "Usuario:";
            // 
            // lblContraseña
            // 
            lblContraseña.AutoSize = true;
            lblContraseña.BackColor = Color.Transparent;
            lblContraseña.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblContraseña.ForeColor = Color.Black;
            lblContraseña.Location = new Point(216, 129);
            lblContraseña.Margin = new Padding(2, 0, 2, 0);
            lblContraseña.Name = "lblContraseña";
            lblContraseña.Size = new Size(153, 29);
            lblContraseña.TabIndex = 7;
            lblContraseña.Text = "Contraseña:";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImage = Properties.Resources.agr;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(31, 45);
            pictureBox1.Margin = new Padding(0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(162, 171);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // pbCerrar
            // 
            pbCerrar.BackgroundImage = Properties.Resources.x;
            pbCerrar.BackgroundImageLayout = ImageLayout.Stretch;
            pbCerrar.Location = new Point(499, 21);
            pbCerrar.Margin = new Padding(2, 3, 2, 3);
            pbCerrar.Name = "pbCerrar";
            pbCerrar.Size = new Size(26, 28);
            pbCerrar.SizeMode = PictureBoxSizeMode.StretchImage;
            pbCerrar.TabIndex = 9;
            pbCerrar.TabStop = false;
            pbCerrar.Click += pbCerrar_Click;
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.White;
            btnIngresar.FlatAppearance.BorderSize = 0;
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnIngresar.ForeColor = Color.FromArgb(56, 124, 31);
            btnIngresar.Location = new Point(414, 181);
            btnIngresar.Margin = new Padding(3, 4, 3, 4);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(112, 43);
            btnIngresar.TabIndex = 10;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnAceptarLogin_Click;
            // 
            // lblOlvidarContraseña
            // 
            lblOlvidarContraseña.AutoSize = true;
            lblOlvidarContraseña.BackColor = Color.Transparent;
            lblOlvidarContraseña.Cursor = Cursors.Hand;
            lblOlvidarContraseña.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            lblOlvidarContraseña.ForeColor = Color.Black;
            lblOlvidarContraseña.Location = new Point(315, 228);
            lblOlvidarContraseña.Name = "lblOlvidarContraseña";
            lblOlvidarContraseña.Size = new Size(228, 20);
            lblOlvidarContraseña.TabIndex = 11;
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
            lblInvitado.Location = new Point(19, 229);
            lblInvitado.Name = "lblInvitado";
            lblInvitado.Size = new Size(241, 20);
            lblInvitado.TabIndex = 12;
            lblInvitado.Text = "INGRESAR CON INVITADO";
            lblInvitado.Click += lblInvitado_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(56, 124, 31);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(545, 272);
            Controls.Add(lblInvitado);
            Controls.Add(lblOlvidarContraseña);
            Controls.Add(btnIngresar);
            Controls.Add(pbCerrar);
            Controls.Add(pictureBox1);
            Controls.Add(lblContraseña);
            Controls.Add(lblUsuario);
            Controls.Add(txtContraseña);
            Controls.Add(txtUsuario);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2, 3, 2, 3);
            MaximumSize = new Size(545, 272);
            MinimumSize = new Size(545, 272);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += Login_Load;
            MouseDown += panelSuperior_MouseDown;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbCerrar).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblContraseña;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pbCerrar;
        private Tienda.RJButton btnIngresar;
        private Label lblOlvidarContraseña;
        private Label lblInvitado;
        private ErrorProvider errorProvider1;
    }
}
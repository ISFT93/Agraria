namespace Agraria.Formularios
{
    partial class CambiarContraseña
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CambiarContraseña));
            txtRespuestaSeguridad = new TextBox();
            label14 = new Label();
            label13 = new Label();
            cmbPreguntaSeguridad = new ComboBox();
            label9 = new Label();
            txtNombreUsuario = new TextBox();
            label11 = new Label();
            label1 = new Label();
            txtConfirmarNuevaContraseña = new TextBox();
            txtNuevaContraseña = new TextBox();
            pictureBox1 = new PictureBox();
            errorProvider1 = new ErrorProvider(components);
            rjBCancelar = new Button();
            rjBAceptar = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // txtRespuestaSeguridad
            // 
            txtRespuestaSeguridad.BorderStyle = BorderStyle.FixedSingle;
            txtRespuestaSeguridad.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtRespuestaSeguridad.Location = new Point(541, 174);
            txtRespuestaSeguridad.MaxLength = 15;
            txtRespuestaSeguridad.Name = "txtRespuestaSeguridad";
            txtRespuestaSeguridad.Size = new Size(326, 29);
            txtRespuestaSeguridad.TabIndex = 3;
            txtRespuestaSeguridad.KeyDown += CopiaryPegar_KeyDown;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = Color.Transparent;
            label14.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label14.ForeColor = Color.Black;
            label14.Location = new Point(251, 174);
            label14.Name = "label14";
            label14.Size = new Size(243, 24);
            label14.TabIndex = 42;
            label14.Text = "Respuesta de seguridad:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.Transparent;
            label13.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label13.ForeColor = Color.Black;
            label13.Location = new Point(261, 135);
            label13.Name = "label13";
            label13.Size = new Size(232, 24);
            label13.TabIndex = 40;
            label13.Text = "Pregunta de Seguridad:";
            // 
            // cmbPreguntaSeguridad
            // 
            cmbPreguntaSeguridad.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPreguntaSeguridad.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            cmbPreguntaSeguridad.FormattingEnabled = true;
            cmbPreguntaSeguridad.ItemHeight = 24;
            cmbPreguntaSeguridad.Location = new Point(541, 135);
            cmbPreguntaSeguridad.Name = "cmbPreguntaSeguridad";
            cmbPreguntaSeguridad.Size = new Size(326, 32);
            cmbPreguntaSeguridad.TabIndex = 39;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label9.ForeColor = Color.Black;
            label9.Location = new Point(306, 213);
            label9.Name = "label9";
            label9.Size = new Size(188, 24);
            label9.TabIndex = 37;
            label9.Text = "Nueva Contraseña:";
            // 
            // txtNombreUsuario
            // 
            txtNombreUsuario.BorderStyle = BorderStyle.FixedSingle;
            txtNombreUsuario.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtNombreUsuario.ForeColor = Color.Black;
            txtNombreUsuario.Location = new Point(541, 96);
            txtNombreUsuario.MaxLength = 15;
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.Size = new Size(146, 29);
            txtNombreUsuario.TabIndex = 1;
            txtNombreUsuario.KeyDown += CopiaryPegar_KeyDown;
            txtNombreUsuario.KeyPress += SoloTextoNumeroEspacio_KeyPress;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label11.ForeColor = Color.Black;
            label11.Location = new Point(298, 97);
            label11.Name = "label11";
            label11.Size = new Size(196, 24);
            label11.TabIndex = 35;
            label11.Text = "Nombre de usuario:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(210, 253);
            label1.Name = "label1";
            label1.Size = new Size(284, 24);
            label1.TabIndex = 43;
            label1.Text = "Confirmar Nueva Contraseña:";
            // 
            // txtConfirmarNuevaContraseña
            // 
            txtConfirmarNuevaContraseña.BorderStyle = BorderStyle.FixedSingle;
            txtConfirmarNuevaContraseña.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtConfirmarNuevaContraseña.Location = new Point(541, 252);
            txtConfirmarNuevaContraseña.MaxLength = 15;
            txtConfirmarNuevaContraseña.Name = "txtConfirmarNuevaContraseña";
            txtConfirmarNuevaContraseña.Size = new Size(146, 29);
            txtConfirmarNuevaContraseña.TabIndex = 5;
            txtConfirmarNuevaContraseña.Visible = false;
            txtConfirmarNuevaContraseña.KeyDown += CopiaryPegar_KeyDown;
            // 
            // txtNuevaContraseña
            // 
            txtNuevaContraseña.BorderStyle = BorderStyle.FixedSingle;
            txtNuevaContraseña.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtNuevaContraseña.Location = new Point(541, 213);
            txtNuevaContraseña.MaxLength = 15;
            txtNuevaContraseña.Name = "txtNuevaContraseña";
            txtNuevaContraseña.Size = new Size(146, 29);
            txtNuevaContraseña.TabIndex = 4;
            txtNuevaContraseña.Visible = false;
            txtNuevaContraseña.KeyDown += CopiaryPegar_KeyDown;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = Properties.Resources.agr;
            pictureBox1.Location = new Point(6, 97);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(193, 166);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 48;
            pictureBox1.TabStop = false;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // rjBCancelar
            // 
            rjBCancelar.Location = new Point(785, 256);
            rjBCancelar.Margin = new Padding(3, 2, 3, 2);
            rjBCancelar.Name = "rjBCancelar";
            rjBCancelar.Size = new Size(82, 22);
            rjBCancelar.TabIndex = 7;
            rjBCancelar.Text = "&Guardar";
            rjBCancelar.UseVisualStyleBackColor = true;
            rjBCancelar.Click += btnGuardar_Click;
            // 
            // rjBAceptar
            // 
            rjBAceptar.Location = new Point(785, 220);
            rjBAceptar.Margin = new Padding(3, 2, 3, 2);
            rjBAceptar.Name = "rjBAceptar";
            rjBAceptar.Size = new Size(82, 22);
            rjBAceptar.TabIndex = 6;
            rjBAceptar.Text = "&Confirmar";
            rjBAceptar.UseVisualStyleBackColor = true;
            rjBAceptar.Click += btnConfirmar_Click;
            // 
            // CambiarContraseña
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(56, 124, 31);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(904, 338);
            Controls.Add(rjBCancelar);
            Controls.Add(rjBAceptar);
            Controls.Add(pictureBox1);
            Controls.Add(txtNuevaContraseña);
            Controls.Add(txtConfirmarNuevaContraseña);
            Controls.Add(label1);
            Controls.Add(txtRespuestaSeguridad);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(cmbPreguntaSeguridad);
            Controls.Add(label9);
            Controls.Add(txtNombreUsuario);
            Controls.Add(label11);
            Name = "CambiarContraseña";
            StartPosition = FormStartPosition.CenterParent;
            Text = "CambiarContraseña";
            Load += CambiarContraseña_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtRespuestaSeguridad;
        private Label label14;
        private Label label13;
        private ComboBox cmbPreguntaSeguridad;
        private Label label9;
        private TextBox txtNombreUsuario;
        private Label label11;
        private Label label1;
        private TextBox txtConfirmarNuevaContraseña;
        private TextBox txtNuevaContraseña;
        private PictureBox pictureBox1;
        private ErrorProvider errorProvider1;
        private Button rjBCancelar;
        private Button rjBAceptar;
    }
}
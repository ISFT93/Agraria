namespace Agraria.Formularios
{
    partial class AbmUsuario
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
            panel2 = new Panel();
            txtRespuestaSeguridad = new TextBox();
            btnCancelar = new Button();
            label14 = new Label();
            btnAceptar = new Button();
            chkPañol = new CheckBox();
            txtNombre = new TextBox();
            chkVenta = new CheckBox();
            txtDocumento = new TextBox();
            chkInventario = new CheckBox();
            txtApellido = new TextBox();
            chkIndustria = new CheckBox();
            txtDireccion = new TextBox();
            cmbPreguntaSeguridad = new ComboBox();
            txtCodigoPostal = new TextBox();
            label13 = new Label();
            lblApellido = new Label();
            chkProduccionAnimal = new CheckBox();
            txtTelefono = new TextBox();
            chkProduccionVegetal = new CheckBox();
            label2 = new Label();
            txtID = new TextBox();
            label6 = new Label();
            lblID = new Label();
            label3 = new Label();
            chkAdministracion = new CheckBox();
            label11 = new Label();
            chkEntornoFormativo = new CheckBox();
            txtNombreUsuario = new TextBox();
            chkAltaUsuario = new CheckBox();
            label4 = new Label();
            txtEmail = new TextBox();
            label10 = new Label();
            label12 = new Label();
            label7 = new Label();
            cmbLocalidad = new ComboBox();
            txtContraseña = new TextBox();
            cmbPartido = new ComboBox();
            label5 = new Label();
            label8 = new Label();
            errorProvider1 = new ErrorProvider(components);
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(txtRespuestaSeguridad);
            panel2.Controls.Add(btnCancelar);
            panel2.Controls.Add(label14);
            panel2.Controls.Add(btnAceptar);
            panel2.Controls.Add(chkPañol);
            panel2.Controls.Add(txtNombre);
            panel2.Controls.Add(chkVenta);
            panel2.Controls.Add(txtDocumento);
            panel2.Controls.Add(chkInventario);
            panel2.Controls.Add(txtApellido);
            panel2.Controls.Add(chkIndustria);
            panel2.Controls.Add(txtDireccion);
            panel2.Controls.Add(cmbPreguntaSeguridad);
            panel2.Controls.Add(txtCodigoPostal);
            panel2.Controls.Add(label13);
            panel2.Controls.Add(lblApellido);
            panel2.Controls.Add(chkProduccionAnimal);
            panel2.Controls.Add(txtTelefono);
            panel2.Controls.Add(chkProduccionVegetal);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(txtID);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(lblID);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(chkAdministracion);
            panel2.Controls.Add(label11);
            panel2.Controls.Add(chkEntornoFormativo);
            panel2.Controls.Add(txtNombreUsuario);
            panel2.Controls.Add(chkAltaUsuario);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(txtEmail);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(label12);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(cmbLocalidad);
            panel2.Controls.Add(txtContraseña);
            panel2.Controls.Add(cmbPartido);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label8);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(833, 513);
            panel2.TabIndex = 25;
            // 
            // txtRespuestaSeguridad
            // 
            txtRespuestaSeguridad.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtRespuestaSeguridad.Location = new Point(259, 477);
            txtRespuestaSeguridad.Name = "txtRespuestaSeguridad";
            txtRespuestaSeguridad.Size = new Size(113, 29);
            txtRespuestaSeguridad.TabIndex = 31;
            txtRespuestaSeguridad.KeyDown += CopiaryPegar_KeyDown;
            txtRespuestaSeguridad.KeyPress += TextoyNumero_KeyPress;
            // 
            // btnCancelar
            // 
            btnCancelar.ForeColor = Color.Black;
            btnCancelar.Location = new Point(744, 477);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 46;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label14.ForeColor = Color.White;
            label14.Location = new Point(10, 482);
            label14.Name = "label14";
            label14.Size = new Size(237, 24);
            label14.TabIndex = 32;
            label14.Text = "Respuesta de seguridad";
            // 
            // btnAceptar
            // 
            btnAceptar.ForeColor = Color.Black;
            btnAceptar.Location = new Point(744, 448);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 23);
            btnAceptar.TabIndex = 45;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // chkPañol
            // 
            chkPañol.AutoSize = true;
            chkPañol.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            chkPañol.ForeColor = Color.White;
            chkPañol.Location = new Point(525, 377);
            chkPañol.Name = "chkPañol";
            chkPañol.Size = new Size(82, 28);
            chkPañol.TabIndex = 44;
            chkPañol.Text = "Pañol";
            chkPañol.UseVisualStyleBackColor = true;
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtNombre.Location = new Point(166, 21);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(225, 29);
            txtNombre.TabIndex = 15;
            txtNombre.KeyDown += CopiaryPegar_KeyDown;
            txtNombre.KeyPress += Solotexto_KeyPress;
            // 
            // chkVenta
            // 
            chkVenta.AutoSize = true;
            chkVenta.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            chkVenta.ForeColor = Color.White;
            chkVenta.Location = new Point(526, 333);
            chkVenta.Name = "chkVenta";
            chkVenta.Size = new Size(83, 28);
            chkVenta.TabIndex = 43;
            chkVenta.Text = "Venta";
            chkVenta.UseVisualStyleBackColor = true;
            // 
            // txtDocumento
            // 
            txtDocumento.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtDocumento.Location = new Point(166, 202);
            txtDocumento.Name = "txtDocumento";
            txtDocumento.Size = new Size(114, 29);
            txtDocumento.TabIndex = 5;
            txtDocumento.KeyDown += CopiaryPegar_KeyDown;
            txtDocumento.KeyPress += SoloNumeros_KeyPress;
            // 
            // chkInventario
            // 
            chkInventario.AutoSize = true;
            chkInventario.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            chkInventario.ForeColor = Color.White;
            chkInventario.Location = new Point(526, 113);
            chkInventario.Name = "chkInventario";
            chkInventario.Size = new Size(120, 28);
            chkInventario.TabIndex = 42;
            chkInventario.Text = "Inventario";
            chkInventario.UseVisualStyleBackColor = true;
            // 
            // txtApellido
            // 
            txtApellido.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtApellido.Location = new Point(166, 56);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(225, 29);
            txtApellido.TabIndex = 4;
            txtApellido.KeyDown += CopiaryPegar_KeyDown;
            txtApellido.KeyPress += Solotexto_KeyPress;
            // 
            // chkIndustria
            // 
            chkIndustria.AutoSize = true;
            chkIndustria.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            chkIndustria.ForeColor = Color.White;
            chkIndustria.Location = new Point(526, 69);
            chkIndustria.Name = "chkIndustria";
            chkIndustria.Size = new Size(108, 28);
            chkIndustria.TabIndex = 41;
            chkIndustria.Text = "Industria";
            chkIndustria.UseVisualStyleBackColor = true;
            // 
            // txtDireccion
            // 
            txtDireccion.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtDireccion.Location = new Point(166, 237);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(225, 29);
            txtDireccion.TabIndex = 9;
            txtDireccion.KeyDown += CopiaryPegar_KeyDown;
            txtDireccion.KeyPress += TextoyNumero_KeyPress;
            // 
            // cmbPreguntaSeguridad
            // 
            cmbPreguntaSeguridad.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPreguntaSeguridad.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            cmbPreguntaSeguridad.FormattingEnabled = true;
            cmbPreguntaSeguridad.Location = new Point(258, 439);
            cmbPreguntaSeguridad.Name = "cmbPreguntaSeguridad";
            cmbPreguntaSeguridad.Size = new Size(447, 32);
            cmbPreguntaSeguridad.TabIndex = 29;
            // 
            // txtCodigoPostal
            // 
            txtCodigoPostal.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtCodigoPostal.Location = new Point(166, 272);
            txtCodigoPostal.Name = "txtCodigoPostal";
            txtCodigoPostal.Size = new Size(89, 29);
            txtCodigoPostal.TabIndex = 7;
            txtCodigoPostal.KeyDown += CopiaryPegar_KeyDown;
            txtCodigoPostal.KeyPress += SoloNumeros_KeyPress;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label13.ForeColor = Color.White;
            label13.Location = new Point(21, 447);
            label13.Name = "label13";
            label13.Size = new Size(226, 24);
            label13.TabIndex = 30;
            label13.Text = "Pregunta de Seguridad";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblApellido.ForeColor = Color.White;
            lblApellido.Location = new Point(53, 137);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(100, 24);
            lblApellido.TabIndex = 14;
            lblApellido.Text = "Localidad";
            // 
            // chkProduccionAnimal
            // 
            chkProduccionAnimal.AutoSize = true;
            chkProduccionAnimal.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            chkProduccionAnimal.ForeColor = Color.White;
            chkProduccionAnimal.Location = new Point(526, 157);
            chkProduccionAnimal.Name = "chkProduccionAnimal";
            chkProduccionAnimal.Size = new Size(200, 28);
            chkProduccionAnimal.TabIndex = 40;
            chkProduccionAnimal.Text = "ProduccionAnimal";
            chkProduccionAnimal.UseVisualStyleBackColor = true;
            // 
            // txtTelefono
            // 
            txtTelefono.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtTelefono.Location = new Point(166, 167);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(162, 29);
            txtTelefono.TabIndex = 6;
            txtTelefono.KeyDown += CopiaryPegar_KeyDown;
            txtTelefono.KeyPress += SoloNumeros_KeyPress;
            // 
            // chkProduccionVegetal
            // 
            chkProduccionVegetal.AutoSize = true;
            chkProduccionVegetal.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            chkProduccionVegetal.ForeColor = Color.White;
            chkProduccionVegetal.Location = new Point(526, 201);
            chkProduccionVegetal.Name = "chkProduccionVegetal";
            chkProduccionVegetal.Size = new Size(207, 28);
            chkProduccionVegetal.TabIndex = 39;
            chkProduccionVegetal.Text = "ProduccionVegetal";
            chkProduccionVegetal.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(78, 99);
            label2.Name = "label2";
            label2.Size = new Size(75, 24);
            label2.TabIndex = 15;
            label2.Text = "Partido";
            // 
            // txtID
            // 
            txtID.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtID.Location = new Point(166, 412);
            txtID.Name = "txtID";
            txtID.Size = new Size(55, 29);
            txtID.TabIndex = 33;
            txtID.Visible = false;
            txtID.KeyDown += CopiaryPegar_KeyDown;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label6.ForeColor = Color.White;
            label6.Location = new Point(66, 61);
            label6.Name = "label6";
            label6.Size = new Size(87, 24);
            label6.TabIndex = 19;
            label6.Text = "Apellido";
            // 
            // lblID
            // 
            lblID.AutoSize = true;
            lblID.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblID.ForeColor = Color.White;
            lblID.Location = new Point(122, 417);
            lblID.Name = "lblID";
            lblID.Size = new Size(29, 24);
            lblID.TabIndex = 34;
            lblID.Text = "ID";
            lblID.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(52, 244);
            label3.Name = "label3";
            label3.Size = new Size(99, 24);
            label3.TabIndex = 16;
            label3.Text = "Dirección";
            // 
            // chkAdministracion
            // 
            chkAdministracion.AutoSize = true;
            chkAdministracion.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            chkAdministracion.ForeColor = Color.White;
            chkAdministracion.Location = new Point(526, 245);
            chkAdministracion.Name = "chkAdministracion";
            chkAdministracion.Size = new Size(167, 28);
            chkAdministracion.TabIndex = 38;
            chkAdministracion.Text = "Administracion";
            chkAdministracion.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label11.ForeColor = Color.White;
            label11.Location = new Point(70, 347);
            label11.Name = "label11";
            label11.Size = new Size(81, 24);
            label11.TabIndex = 25;
            label11.Text = "Usuario";
            // 
            // chkEntornoFormativo
            // 
            chkEntornoFormativo.AutoSize = true;
            chkEntornoFormativo.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            chkEntornoFormativo.ForeColor = Color.White;
            chkEntornoFormativo.Location = new Point(526, 25);
            chkEntornoFormativo.Name = "chkEntornoFormativo";
            chkEntornoFormativo.Size = new Size(221, 28);
            chkEntornoFormativo.TabIndex = 37;
            chkEntornoFormativo.Text = "Entornos Formativos";
            chkEntornoFormativo.UseVisualStyleBackColor = true;
            // 
            // txtNombreUsuario
            // 
            txtNombreUsuario.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtNombreUsuario.Location = new Point(166, 342);
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.Size = new Size(174, 29);
            txtNombreUsuario.TabIndex = 2;
            txtNombreUsuario.KeyDown += CopiaryPegar_KeyDown;
            txtNombreUsuario.KeyPress += Solotexto_KeyPress;
            // 
            // chkAltaUsuario
            // 
            chkAltaUsuario.AutoSize = true;
            chkAltaUsuario.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            chkAltaUsuario.ForeColor = Color.White;
            chkAltaUsuario.Location = new Point(525, 289);
            chkAltaUsuario.Name = "chkAltaUsuario";
            chkAltaUsuario.Size = new Size(141, 28);
            chkAltaUsuario.TabIndex = 36;
            chkAltaUsuario.Text = "Alta Usuario";
            chkAltaUsuario.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(14, 277);
            label4.Name = "label4";
            label4.Size = new Size(139, 24);
            label4.TabIndex = 17;
            label4.Text = "Código Postal";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtEmail.Location = new Point(166, 307);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(304, 29);
            txtEmail.TabIndex = 0;
            txtEmail.KeyDown += CopiaryPegar_KeyDown;
            txtEmail.KeyPress += TextoyNumero_KeyPress;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label10.ForeColor = Color.White;
            label10.Location = new Point(35, 382);
            label10.Name = "label10";
            label10.Size = new Size(116, 24);
            label10.TabIndex = 26;
            label10.Text = "Contraseña";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label12.ForeColor = Color.White;
            label12.Location = new Point(89, 312);
            label12.Name = "label12";
            label12.Size = new Size(62, 24);
            label12.TabIndex = 24;
            label12.Text = "Email";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label7.ForeColor = Color.White;
            label7.Location = new Point(36, 207);
            label7.Name = "label7";
            label7.Size = new Size(117, 24);
            label7.TabIndex = 20;
            label7.Text = "Documento";
            // 
            // cmbLocalidad
            // 
            cmbLocalidad.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLocalidad.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            cmbLocalidad.FormattingEnabled = true;
            cmbLocalidad.Location = new Point(166, 129);
            cmbLocalidad.Name = "cmbLocalidad";
            cmbLocalidad.Size = new Size(191, 32);
            cmbLocalidad.TabIndex = 23;
            // 
            // txtContraseña
            // 
            txtContraseña.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtContraseña.Location = new Point(166, 377);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.Size = new Size(174, 29);
            txtContraseña.TabIndex = 10;
            txtContraseña.KeyDown += CopiaryPegar_KeyDown;
            txtContraseña.KeyPress += TextoyNumero_KeyPress;
            // 
            // cmbPartido
            // 
            cmbPartido.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPartido.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            cmbPartido.FormattingEnabled = true;
            cmbPartido.Location = new Point(166, 91);
            cmbPartido.Name = "cmbPartido";
            cmbPartido.Size = new Size(191, 32);
            cmbPartido.TabIndex = 22;
            cmbPartido.SelectedIndexChanged += cmbPartido_SelectedIndexChanged;
            cmbPartido.Click += cmbPartido_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(60, 172);
            label5.Name = "label5";
            label5.Size = new Size(93, 24);
            label5.TabIndex = 18;
            label5.Text = "Telefono";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label8.ForeColor = Color.White;
            label8.Location = new Point(66, 26);
            label8.Name = "label8";
            label8.Size = new Size(85, 24);
            label8.TabIndex = 21;
            label8.Text = "Nombre";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // AbmUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(141, 181, 146);
            ClientSize = new Size(833, 513);
            Controls.Add(panel2);
            Name = "AbmUsuario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AbmUsuario";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label lblApellido;
        private TextBox txtContraseña;
        private TextBox txtDireccion;
        private TextBox txtCodigoPostal;
        private TextBox txtTelefono;
        private TextBox txtDocumento;
        private TextBox txtApellido;
        private TextBox txtNombreUsuario;
        private TextBox txtEmail;
        private Label label8;
        private TextBox txtNombre;
        private Label label10;
        private Label label11;
        private Label label12;
        private ComboBox cmbLocalidad;
        private ComboBox cmbPartido;
        private Label label13;
        private ComboBox cmbPreguntaSeguridad;
        private TextBox txtRespuestaSeguridad;
        private Label label14;
        private Label lblID;
        private TextBox txtID;
        private ErrorProvider errorProvider1;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
        private CheckBox checkBox8;
        private CheckBox checkBox7;
        private CheckBox checkBox6;
        private CheckBox checkBox5;
        private CheckBox checkBox4;
        private CheckBox checkBox3;
        private CheckBox chkEntornoFormativo;
        private CheckBox chkAltaUsuario;
        private CheckBox chkVenta;
        private CheckBox chkInventario;
        private CheckBox chkIndustria;
        private CheckBox chkProduccionAnimal;
        private CheckBox chkProduccionVegetal;
        private CheckBox chkAdministracion;
        private CheckBox chkPañol;
        private Panel panel2;
        private Button btnCancelar;
        private Button btnAceptar;
    }
}
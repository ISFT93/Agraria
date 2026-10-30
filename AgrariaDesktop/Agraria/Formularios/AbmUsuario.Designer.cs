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
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(952, 684);
            panel2.TabIndex = 25;
            // 
            // txtRespuestaSeguridad
            // 
            txtRespuestaSeguridad.BorderStyle = BorderStyle.FixedSingle;
            txtRespuestaSeguridad.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtRespuestaSeguridad.Location = new Point(311, 635);
            txtRespuestaSeguridad.Margin = new Padding(3, 4, 3, 4);
            txtRespuestaSeguridad.Name = "txtRespuestaSeguridad";
            txtRespuestaSeguridad.Size = new Size(129, 34);
            txtRespuestaSeguridad.TabIndex = 31;
            txtRespuestaSeguridad.KeyDown += CopiaryPegar_KeyDown;
            txtRespuestaSeguridad.KeyPress += TextoyNumero_KeyPress;
            // 
            // btnCancelar
            // 
            btnCancelar.ForeColor = Color.Black;
            btnCancelar.Location = new Point(850, 636);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(86, 31);
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
            label14.Location = new Point(11, 643);
            label14.Name = "label14";
            label14.Size = new Size(298, 29);
            label14.TabIndex = 32;
            label14.Text = "Respuesta de seguridad";
            // 
            // btnAceptar
            // 
            btnAceptar.ForeColor = Color.Black;
            btnAceptar.Location = new Point(850, 597);
            btnAceptar.Margin = new Padding(3, 4, 3, 4);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(86, 31);
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
            chkPañol.Location = new Point(600, 503);
            chkPañol.Margin = new Padding(3, 4, 3, 4);
            chkPañol.Name = "chkPañol";
            chkPañol.Size = new Size(102, 33);
            chkPañol.TabIndex = 44;
            chkPañol.Text = "Pañol";
            chkPañol.UseVisualStyleBackColor = true;
            // 
            // txtNombre
            // 
            txtNombre.BorderStyle = BorderStyle.FixedSingle;
            txtNombre.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtNombre.Location = new Point(205, 27);
            txtNombre.Margin = new Padding(3, 4, 3, 4);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(257, 34);
            txtNombre.TabIndex = 15;
            txtNombre.KeyDown += CopiaryPegar_KeyDown;
            txtNombre.KeyPress += Solotexto_KeyPress;
            // 
            // chkVenta
            // 
            chkVenta.AutoSize = true;
            chkVenta.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            chkVenta.ForeColor = Color.White;
            chkVenta.Location = new Point(601, 444);
            chkVenta.Margin = new Padding(3, 4, 3, 4);
            chkVenta.Name = "chkVenta";
            chkVenta.Size = new Size(101, 33);
            chkVenta.TabIndex = 43;
            chkVenta.Text = "Venta";
            chkVenta.UseVisualStyleBackColor = true;
            // 
            // txtDocumento
            // 
            txtDocumento.BorderStyle = BorderStyle.FixedSingle;
            txtDocumento.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtDocumento.Location = new Point(205, 268);
            txtDocumento.Margin = new Padding(3, 4, 3, 4);
            txtDocumento.Name = "txtDocumento";
            txtDocumento.Size = new Size(130, 34);
            txtDocumento.TabIndex = 5;
            txtDocumento.KeyDown += CopiaryPegar_KeyDown;
            txtDocumento.KeyPress += SoloNumeros_KeyPress;
            // 
            // chkInventario
            // 
            chkInventario.AutoSize = true;
            chkInventario.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            chkInventario.ForeColor = Color.White;
            chkInventario.Location = new Point(601, 151);
            chkInventario.Margin = new Padding(3, 4, 3, 4);
            chkInventario.Name = "chkInventario";
            chkInventario.Size = new Size(149, 33);
            chkInventario.TabIndex = 42;
            chkInventario.Text = "Inventario";
            chkInventario.UseVisualStyleBackColor = true;
            // 
            // txtApellido
            // 
            txtApellido.BorderStyle = BorderStyle.FixedSingle;
            txtApellido.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtApellido.Location = new Point(205, 74);
            txtApellido.Margin = new Padding(3, 4, 3, 4);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(257, 34);
            txtApellido.TabIndex = 4;
            txtApellido.KeyDown += CopiaryPegar_KeyDown;
            txtApellido.KeyPress += Solotexto_KeyPress;
            // 
            // chkIndustria
            // 
            chkIndustria.AutoSize = true;
            chkIndustria.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            chkIndustria.ForeColor = Color.White;
            chkIndustria.Location = new Point(601, 92);
            chkIndustria.Margin = new Padding(3, 4, 3, 4);
            chkIndustria.Name = "chkIndustria";
            chkIndustria.Size = new Size(135, 33);
            chkIndustria.TabIndex = 41;
            chkIndustria.Text = "Industria";
            chkIndustria.UseVisualStyleBackColor = true;
            // 
            // txtDireccion
            // 
            txtDireccion.BorderStyle = BorderStyle.FixedSingle;
            txtDireccion.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtDireccion.Location = new Point(205, 315);
            txtDireccion.Margin = new Padding(3, 4, 3, 4);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(257, 34);
            txtDireccion.TabIndex = 9;
            txtDireccion.KeyDown += CopiaryPegar_KeyDown;
            txtDireccion.KeyPress += TextoyNumero_KeyPress;
            // 
            // cmbPreguntaSeguridad
            // 
            cmbPreguntaSeguridad.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPreguntaSeguridad.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            cmbPreguntaSeguridad.FormattingEnabled = true;
            cmbPreguntaSeguridad.Location = new Point(310, 584);
            cmbPreguntaSeguridad.Margin = new Padding(3, 4, 3, 4);
            cmbPreguntaSeguridad.Name = "cmbPreguntaSeguridad";
            cmbPreguntaSeguridad.Size = new Size(510, 37);
            cmbPreguntaSeguridad.TabIndex = 29;
            // 
            // txtCodigoPostal
            // 
            txtCodigoPostal.BorderStyle = BorderStyle.FixedSingle;
            txtCodigoPostal.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtCodigoPostal.Location = new Point(205, 362);
            txtCodigoPostal.Margin = new Padding(3, 4, 3, 4);
            txtCodigoPostal.Name = "txtCodigoPostal";
            txtCodigoPostal.Size = new Size(101, 34);
            txtCodigoPostal.TabIndex = 7;
            txtCodigoPostal.KeyDown += CopiaryPegar_KeyDown;
            txtCodigoPostal.KeyPress += SoloNumeros_KeyPress;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label13.ForeColor = Color.White;
            label13.Location = new Point(24, 596);
            label13.Name = "label13";
            label13.Size = new Size(283, 29);
            label13.TabIndex = 30;
            label13.Text = "Pregunta de Seguridad";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblApellido.ForeColor = Color.White;
            lblApellido.Location = new Point(61, 183);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(127, 29);
            lblApellido.TabIndex = 14;
            lblApellido.Text = "Localidad";
            // 
            // chkProduccionAnimal
            // 
            chkProduccionAnimal.AutoSize = true;
            chkProduccionAnimal.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            chkProduccionAnimal.ForeColor = Color.White;
            chkProduccionAnimal.Location = new Point(601, 209);
            chkProduccionAnimal.Margin = new Padding(3, 4, 3, 4);
            chkProduccionAnimal.Name = "chkProduccionAnimal";
            chkProduccionAnimal.Size = new Size(246, 33);
            chkProduccionAnimal.TabIndex = 40;
            chkProduccionAnimal.Text = "ProduccionAnimal";
            chkProduccionAnimal.UseVisualStyleBackColor = true;
            // 
            // txtTelefono
            // 
            txtTelefono.BorderStyle = BorderStyle.FixedSingle;
            txtTelefono.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtTelefono.Location = new Point(205, 222);
            txtTelefono.Margin = new Padding(3, 4, 3, 4);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(185, 34);
            txtTelefono.TabIndex = 6;
            txtTelefono.KeyDown += CopiaryPegar_KeyDown;
            txtTelefono.KeyPress += SoloNumeros_KeyPress;
            // 
            // chkProduccionVegetal
            // 
            chkProduccionVegetal.AutoSize = true;
            chkProduccionVegetal.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            chkProduccionVegetal.ForeColor = Color.White;
            chkProduccionVegetal.Location = new Point(601, 268);
            chkProduccionVegetal.Margin = new Padding(3, 4, 3, 4);
            chkProduccionVegetal.Name = "chkProduccionVegetal";
            chkProduccionVegetal.Size = new Size(256, 33);
            chkProduccionVegetal.TabIndex = 39;
            chkProduccionVegetal.Text = "ProduccionVegetal";
            chkProduccionVegetal.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(89, 132);
            label2.Name = "label2";
            label2.Size = new Size(97, 29);
            label2.TabIndex = 15;
            label2.Text = "Partido";
            // 
            // txtID
            // 
            txtID.BorderStyle = BorderStyle.FixedSingle;
            txtID.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtID.Location = new Point(205, 548);
            txtID.Margin = new Padding(3, 4, 3, 4);
            txtID.Name = "txtID";
            txtID.Size = new Size(62, 34);
            txtID.TabIndex = 33;
            txtID.Visible = false;
            txtID.KeyDown += CopiaryPegar_KeyDown;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label6.ForeColor = Color.White;
            label6.Location = new Point(75, 81);
            label6.Name = "label6";
            label6.Size = new Size(110, 29);
            label6.TabIndex = 19;
            label6.Text = "Apellido";
            // 
            // lblID
            // 
            lblID.AutoSize = true;
            lblID.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblID.ForeColor = Color.White;
            lblID.Location = new Point(139, 556);
            lblID.Name = "lblID";
            lblID.Size = new Size(38, 29);
            lblID.TabIndex = 34;
            lblID.Text = "ID";
            lblID.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(59, 325);
            label3.Name = "label3";
            label3.Size = new Size(124, 29);
            label3.TabIndex = 16;
            label3.Text = "Dirección";
            // 
            // chkAdministracion
            // 
            chkAdministracion.AutoSize = true;
            chkAdministracion.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            chkAdministracion.ForeColor = Color.White;
            chkAdministracion.Location = new Point(601, 327);
            chkAdministracion.Margin = new Padding(3, 4, 3, 4);
            chkAdministracion.Name = "chkAdministracion";
            chkAdministracion.Size = new Size(207, 33);
            chkAdministracion.TabIndex = 38;
            chkAdministracion.Text = "Administracion";
            chkAdministracion.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label11.ForeColor = Color.White;
            label11.Location = new Point(80, 463);
            label11.Name = "label11";
            label11.Size = new Size(103, 29);
            label11.TabIndex = 25;
            label11.Text = "Usuario";
            // 
            // chkEntornoFormativo
            // 
            chkEntornoFormativo.AutoSize = true;
            chkEntornoFormativo.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            chkEntornoFormativo.ForeColor = Color.White;
            chkEntornoFormativo.Location = new Point(601, 33);
            chkEntornoFormativo.Margin = new Padding(3, 4, 3, 4);
            chkEntornoFormativo.Name = "chkEntornoFormativo";
            chkEntornoFormativo.Size = new Size(275, 33);
            chkEntornoFormativo.TabIndex = 37;
            chkEntornoFormativo.Text = "Entornos Formativos";
            chkEntornoFormativo.UseVisualStyleBackColor = true;
            // 
            // txtNombreUsuario
            // 
            txtNombreUsuario.BorderStyle = BorderStyle.FixedSingle;
            txtNombreUsuario.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtNombreUsuario.Location = new Point(205, 455);
            txtNombreUsuario.Margin = new Padding(3, 4, 3, 4);
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.Size = new Size(198, 34);
            txtNombreUsuario.TabIndex = 2;
            txtNombreUsuario.KeyDown += CopiaryPegar_KeyDown;
            txtNombreUsuario.KeyPress += Solotexto_KeyPress;
            // 
            // chkAltaUsuario
            // 
            chkAltaUsuario.AutoSize = true;
            chkAltaUsuario.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            chkAltaUsuario.ForeColor = Color.White;
            chkAltaUsuario.Location = new Point(600, 385);
            chkAltaUsuario.Margin = new Padding(3, 4, 3, 4);
            chkAltaUsuario.Name = "chkAltaUsuario";
            chkAltaUsuario.Size = new Size(176, 33);
            chkAltaUsuario.TabIndex = 36;
            chkAltaUsuario.Text = "Alta Usuario";
            chkAltaUsuario.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(16, 369);
            label4.Name = "label4";
            label4.Size = new Size(178, 29);
            label4.TabIndex = 17;
            label4.Text = "Código Postal";
            // 
            // txtEmail
            // 
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtEmail.Location = new Point(205, 408);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(347, 34);
            txtEmail.TabIndex = 0;
            txtEmail.KeyDown += CopiaryPegar_KeyDown;
            txtEmail.KeyPress += TextoyNumero_KeyPress;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label10.ForeColor = Color.White;
            label10.Location = new Point(40, 509);
            label10.Name = "label10";
            label10.Size = new Size(146, 29);
            label10.TabIndex = 26;
            label10.Text = "Contraseña";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label12.ForeColor = Color.White;
            label12.Location = new Point(102, 416);
            label12.Name = "label12";
            label12.Size = new Size(79, 29);
            label12.TabIndex = 24;
            label12.Text = "Email";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label7.ForeColor = Color.White;
            label7.Location = new Point(41, 276);
            label7.Name = "label7";
            label7.Size = new Size(145, 29);
            label7.TabIndex = 20;
            label7.Text = "Documento";
            // 
            // cmbLocalidad
            // 
            cmbLocalidad.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLocalidad.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            cmbLocalidad.FormattingEnabled = true;
            cmbLocalidad.Location = new Point(205, 171);
            cmbLocalidad.Margin = new Padding(3, 4, 3, 4);
            cmbLocalidad.Name = "cmbLocalidad";
            cmbLocalidad.Size = new Size(218, 37);
            cmbLocalidad.TabIndex = 23;
            // 
            // txtContraseña
            // 
            txtContraseña.BorderStyle = BorderStyle.FixedSingle;
            txtContraseña.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtContraseña.Location = new Point(205, 502);
            txtContraseña.Margin = new Padding(3, 4, 3, 4);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.Size = new Size(198, 34);
            txtContraseña.TabIndex = 10;
            txtContraseña.KeyDown += CopiaryPegar_KeyDown;
            txtContraseña.KeyPress += TextoyNumero_KeyPress;
            // 
            // cmbPartido
            // 
            cmbPartido.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPartido.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            cmbPartido.FormattingEnabled = true;
            cmbPartido.Location = new Point(205, 120);
            cmbPartido.Margin = new Padding(3, 4, 3, 4);
            cmbPartido.Name = "cmbPartido";
            cmbPartido.Size = new Size(218, 37);
            cmbPartido.TabIndex = 22;
            cmbPartido.SelectedIndexChanged += cmbPartido_SelectedIndexChanged;
            cmbPartido.Click += cmbPartido_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(69, 229);
            label5.Name = "label5";
            label5.Size = new Size(118, 29);
            label5.TabIndex = 18;
            label5.Text = "Telefono";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label8.ForeColor = Color.White;
            label8.Location = new Point(75, 35);
            label8.Name = "label8";
            label8.Size = new Size(107, 29);
            label8.TabIndex = 21;
            label8.Text = "Nombre";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // AbmUsuario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(141, 181, 146);
            ClientSize = new Size(952, 684);
            Controls.Add(panel2);
            Margin = new Padding(3, 4, 3, 4);
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
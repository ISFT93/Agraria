namespace Agraria.Formularios
{
    partial class AbmAdministracion
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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            groupBox1 = new GroupBox();
            label12 = new Label();
            txtCodigoPostal = new TextBox();
            btnLimpiarLocalidadPartido = new Tienda.RJButton();
            txtLocalidad = new TextBox();
            txtPartido = new TextBox();
            btnGuardarUsuario = new Tienda.RJButton();
            btnModificarUsuario = new Tienda.RJButton();
            cmbLocalidad = new ComboBox();
            lblApellido = new Label();
            cmbPartido = new ComboBox();
            label2 = new Label();
            tabPage2 = new TabPage();
            groupBox3 = new GroupBox();
            btnLimpiarEntornos = new Tienda.RJButton();
            txtTipoEntorno = new TextBox();
            cmbTipoEntorno = new ComboBox();
            lblTipoEntorno = new Label();
            btnGuardarEntorno = new Tienda.RJButton();
            btnModificarEntorno = new Tienda.RJButton();
            tabPage3 = new TabPage();
            groupBox4 = new GroupBox();
            btnLimpiarIndustria = new Tienda.RJButton();
            label5 = new Label();
            label4 = new Label();
            txtPrecioProducto = new TextBox();
            label3 = new Label();
            txtReceta = new TextBox();
            txtProducto = new TextBox();
            label1 = new Label();
            cmbProducto = new ComboBox();
            btnGuardarProducto = new Tienda.RJButton();
            btnModificarProducto = new Tienda.RJButton();
            tabPage4 = new TabPage();
            btnImprimirProveedores = new Tienda.RJButton();
            groupBox5 = new GroupBox();
            btnLimpiarProveedores = new Tienda.RJButton();
            dtgProveedores = new DataGridView();
            label11 = new Label();
            txtDireccion = new TextBox();
            label10 = new Label();
            txtEmail = new TextBox();
            groupBox6 = new GroupBox();
            label8 = new Label();
            txtTelefono = new TextBox();
            label7 = new Label();
            txtRazonSocial = new TextBox();
            btnGuardarProveedor = new Tienda.RJButton();
            btnModificarProveedor = new Tienda.RJButton();
            btnLimpiarAlimentos = new Tienda.RJButton();
            label6 = new Label();
            txtKgUnidad = new TextBox();
            cmbKgUnidad = new ComboBox();
            btnGuardarUnidad = new Tienda.RJButton();
            btnModificarUnidad = new Tienda.RJButton();
            errorProvider1 = new ErrorProvider(components);
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            groupBox1.SuspendLayout();
            tabPage2.SuspendLayout();
            groupBox3.SuspendLayout();
            tabPage3.SuspendLayout();
            groupBox4.SuspendLayout();
            tabPage4.SuspendLayout();
            groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgProveedores).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1125, 881);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.FromArgb(141, 181, 146);
            tabPage1.Controls.Add(groupBox1);
            tabPage1.Location = new Point(4, 38);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3, 3, 3, 3);
            tabPage1.Size = new Size(1117, 839);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Alta de Usuario";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(txtCodigoPostal);
            groupBox1.Controls.Add(btnLimpiarLocalidadPartido);
            groupBox1.Controls.Add(txtLocalidad);
            groupBox1.Controls.Add(txtPartido);
            groupBox1.Controls.Add(btnGuardarUsuario);
            groupBox1.Controls.Add(btnModificarUsuario);
            groupBox1.Controls.Add(cmbLocalidad);
            groupBox1.Controls.Add(lblApellido);
            groupBox1.Controls.Add(cmbPartido);
            groupBox1.Controls.Add(label2);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(6, 5);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(930, 200);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Localidad y Partido:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(506, 51);
            label12.Name = "label12";
            label12.Size = new Size(185, 29);
            label12.TabIndex = 0;
            label12.Text = "Codigo Postal:";
            // 
            // txtCodigoPostal
            // 
            txtCodigoPostal.BorderStyle = BorderStyle.FixedSingle;
            txtCodigoPostal.Location = new Point(697, 51);
            txtCodigoPostal.MaxLength = 10;
            txtCodigoPostal.Name = "txtCodigoPostal";
            txtCodigoPostal.Size = new Size(162, 34);
            txtCodigoPostal.TabIndex = 1;
            // 
            // btnLimpiarLocalidadPartido
            // 
            btnLimpiarLocalidadPartido.BackColor = Color.White;
            btnLimpiarLocalidadPartido.FlatStyle = FlatStyle.Flat;
            btnLimpiarLocalidadPartido.ForeColor = Color.Green;
            btnLimpiarLocalidadPartido.Location = new Point(435, 143);
            btnLimpiarLocalidadPartido.Name = "btnLimpiarLocalidadPartido";
            btnLimpiarLocalidadPartido.Size = new Size(192, 39);
            btnLimpiarLocalidadPartido.TabIndex = 2;
            btnLimpiarLocalidadPartido.Text = "Limpiar";
            btnLimpiarLocalidadPartido.UseVisualStyleBackColor = false;
            // 
            // txtLocalidad
            // 
            txtLocalidad.BorderStyle = BorderStyle.FixedSingle;
            txtLocalidad.Location = new Point(304, 44);
            txtLocalidad.MaxLength = 40;
            txtLocalidad.Name = "txtLocalidad";
            txtLocalidad.Size = new Size(162, 34);
            txtLocalidad.TabIndex = 3;
            // 
            // txtPartido
            // 
            txtPartido.BorderStyle = BorderStyle.FixedSingle;
            txtPartido.Location = new Point(304, 101);
            txtPartido.MaxLength = 40;
            txtPartido.Name = "txtPartido";
            txtPartido.Size = new Size(162, 34);
            txtPartido.TabIndex = 4;
            // 
            // btnGuardarUsuario
            // 
            btnGuardarUsuario.BackColor = Color.White;
            btnGuardarUsuario.FlatStyle = FlatStyle.Flat;
            btnGuardarUsuario.ForeColor = Color.FromArgb(56, 124, 31);
            btnGuardarUsuario.Location = new Point(790, 143);
            btnGuardarUsuario.Name = "btnGuardarUsuario";
            btnGuardarUsuario.Size = new Size(126, 41);
            btnGuardarUsuario.TabIndex = 5;
            btnGuardarUsuario.Text = "Guardar";
            btnGuardarUsuario.UseVisualStyleBackColor = false;
            // 
            // btnModificarUsuario
            // 
            btnModificarUsuario.BackColor = Color.White;
            btnModificarUsuario.FlatStyle = FlatStyle.Flat;
            btnModificarUsuario.ForeColor = Color.FromArgb(56, 124, 31);
            btnModificarUsuario.Location = new Point(634, 143);
            btnModificarUsuario.Name = "btnModificarUsuario";
            btnModificarUsuario.Size = new Size(150, 40);
            btnModificarUsuario.TabIndex = 6;
            btnModificarUsuario.Text = "Modificar";
            btnModificarUsuario.UseVisualStyleBackColor = false;
            // 
            // cmbLocalidad
            // 
            cmbLocalidad.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLocalidad.FormattingEnabled = true;
            cmbLocalidad.Location = new Point(126, 41);
            cmbLocalidad.Name = "cmbLocalidad";
            cmbLocalidad.Size = new Size(162, 37);
            cmbLocalidad.TabIndex = 7;
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(10, 44);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(134, 29);
            lblApellido.TabIndex = 8;
            lblApellido.Text = "Localidad:";
            // 
            // cmbPartido
            // 
            cmbPartido.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPartido.FormattingEnabled = true;
            cmbPartido.Location = new Point(126, 97);
            cmbPartido.Name = "cmbPartido";
            cmbPartido.Size = new Size(162, 37);
            cmbPartido.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(35, 101);
            label2.Name = "label2";
            label2.Size = new Size(104, 29);
            label2.TabIndex = 10;
            label2.Text = "Partido:";
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.FromArgb(141, 181, 146);
            tabPage2.Controls.Add(groupBox3);
            tabPage2.Location = new Point(4, 38);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 3, 3, 3);
            tabPage2.Size = new Size(1117, 839);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Entorno Formativo";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btnLimpiarEntornos);
            groupBox3.Controls.Add(txtTipoEntorno);
            groupBox3.Controls.Add(cmbTipoEntorno);
            groupBox3.Controls.Add(lblTipoEntorno);
            groupBox3.Controls.Add(btnGuardarEntorno);
            groupBox3.Controls.Add(btnModificarEntorno);
            groupBox3.ForeColor = Color.White;
            groupBox3.Location = new Point(6, 5);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(930, 160);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Entornos:";
            // 
            // btnLimpiarEntornos
            // 
            btnLimpiarEntornos.BackColor = Color.White;
            btnLimpiarEntornos.FlatStyle = FlatStyle.Flat;
            btnLimpiarEntornos.ForeColor = Color.Green;
            btnLimpiarEntornos.Location = new Point(459, 113);
            btnLimpiarEntornos.Name = "btnLimpiarEntornos";
            btnLimpiarEntornos.Size = new Size(192, 39);
            btnLimpiarEntornos.TabIndex = 0;
            btnLimpiarEntornos.Text = "Limpiar";
            btnLimpiarEntornos.UseVisualStyleBackColor = false;
            // 
            // txtTipoEntorno
            // 
            txtTipoEntorno.BorderStyle = BorderStyle.FixedSingle;
            txtTipoEntorno.Location = new Point(398, 49);
            txtTipoEntorno.MaxLength = 30;
            txtTipoEntorno.Name = "txtTipoEntorno";
            txtTipoEntorno.Size = new Size(162, 34);
            txtTipoEntorno.TabIndex = 1;
            // 
            // cmbTipoEntorno
            // 
            cmbTipoEntorno.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoEntorno.FormattingEnabled = true;
            cmbTipoEntorno.Location = new Point(221, 47);
            cmbTipoEntorno.Name = "cmbTipoEntorno";
            cmbTipoEntorno.Size = new Size(162, 37);
            cmbTipoEntorno.TabIndex = 2;
            // 
            // lblTipoEntorno
            // 
            lblTipoEntorno.AutoSize = true;
            lblTipoEntorno.Location = new Point(21, 53);
            lblTipoEntorno.Name = "lblTipoEntorno";
            lblTipoEntorno.Size = new Size(209, 29);
            lblTipoEntorno.TabIndex = 3;
            lblTipoEntorno.Text = "Tipo de Entorno:";
            // 
            // btnGuardarEntorno
            // 
            btnGuardarEntorno.BackColor = Color.White;
            btnGuardarEntorno.FlatStyle = FlatStyle.Flat;
            btnGuardarEntorno.ForeColor = Color.FromArgb(56, 124, 31);
            btnGuardarEntorno.Location = new Point(800, 113);
            btnGuardarEntorno.Name = "btnGuardarEntorno";
            btnGuardarEntorno.Size = new Size(126, 41);
            btnGuardarEntorno.TabIndex = 4;
            btnGuardarEntorno.Text = "Guardar";
            btnGuardarEntorno.UseVisualStyleBackColor = false;
            // 
            // btnModificarEntorno
            // 
            btnModificarEntorno.BackColor = Color.White;
            btnModificarEntorno.FlatStyle = FlatStyle.Flat;
            btnModificarEntorno.ForeColor = Color.FromArgb(56, 124, 31);
            btnModificarEntorno.Location = new Point(645, 113);
            btnModificarEntorno.Name = "btnModificarEntorno";
            btnModificarEntorno.Size = new Size(150, 40);
            btnModificarEntorno.TabIndex = 5;
            btnModificarEntorno.Text = "Modificar";
            btnModificarEntorno.UseVisualStyleBackColor = false;
            // 
            // tabPage3
            // 
            tabPage3.BackColor = Color.FromArgb(141, 181, 146);
            tabPage3.Controls.Add(groupBox4);
            tabPage3.Location = new Point(4, 38);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3, 3, 3, 3);
            tabPage3.Size = new Size(1117, 839);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Industria";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(btnLimpiarIndustria);
            groupBox4.Controls.Add(label5);
            groupBox4.Controls.Add(label4);
            groupBox4.Controls.Add(txtPrecioProducto);
            groupBox4.Controls.Add(label3);
            groupBox4.Controls.Add(txtReceta);
            groupBox4.Controls.Add(txtProducto);
            groupBox4.Controls.Add(label1);
            groupBox4.Controls.Add(cmbProducto);
            groupBox4.Controls.Add(btnGuardarProducto);
            groupBox4.Controls.Add(btnModificarProducto);
            groupBox4.ForeColor = Color.White;
            groupBox4.Location = new Point(6, 5);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(1078, 487);
            groupBox4.TabIndex = 1;
            groupBox4.TabStop = false;
            groupBox4.Text = "Industria:";
            // 
            // btnLimpiarIndustria
            // 
            btnLimpiarIndustria.BackColor = Color.White;
            btnLimpiarIndustria.FlatStyle = FlatStyle.Flat;
            btnLimpiarIndustria.ForeColor = Color.Green;
            btnLimpiarIndustria.Location = new Point(617, 424);
            btnLimpiarIndustria.Name = "btnLimpiarIndustria";
            btnLimpiarIndustria.Size = new Size(150, 39);
            btnLimpiarIndustria.TabIndex = 0;
            btnLimpiarIndustria.Text = "Limpiar";
            btnLimpiarIndustria.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label5.Location = new Point(7, 100);
            label5.Name = "label5";
            label5.Size = new Size(270, 29);
            label5.TabIndex = 1;
            label5.Text = "Nombre del Producto:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label4.Location = new Point(22, 161);
            label4.Name = "label4";
            label4.Size = new Size(252, 29);
            label4.TabIndex = 2;
            label4.Text = "Precio del Producto:";
            // 
            // txtPrecioProducto
            // 
            txtPrecioProducto.BorderStyle = BorderStyle.FixedSingle;
            txtPrecioProducto.Location = new Point(283, 161);
            txtPrecioProducto.MaxLength = 10;
            txtPrecioProducto.Name = "txtPrecioProducto";
            txtPrecioProducto.Size = new Size(162, 34);
            txtPrecioProducto.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(485, 39);
            label3.Name = "label3";
            label3.Size = new Size(102, 29);
            label3.TabIndex = 4;
            label3.Text = "Receta:";
            // 
            // txtReceta
            // 
            txtReceta.BorderStyle = BorderStyle.FixedSingle;
            txtReceta.Location = new Point(584, 35);
            txtReceta.Multiline = true;
            txtReceta.Name = "txtReceta";
            txtReceta.Size = new Size(470, 300);
            txtReceta.TabIndex = 5;
            // 
            // txtProducto
            // 
            txtProducto.BorderStyle = BorderStyle.FixedSingle;
            txtProducto.Location = new Point(283, 100);
            txtProducto.MaxLength = 30;
            txtProducto.Name = "txtProducto";
            txtProducto.Size = new Size(162, 34);
            txtProducto.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 39);
            label1.Name = "label1";
            label1.Size = new Size(250, 29);
            label1.TabIndex = 7;
            label1.Text = "Producto a producir:";
            // 
            // cmbProducto
            // 
            cmbProducto.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProducto.Location = new Point(283, 39);
            cmbProducto.Name = "cmbProducto";
            cmbProducto.Size = new Size(162, 37);
            cmbProducto.TabIndex = 8;
            // 
            // btnGuardarProducto
            // 
            btnGuardarProducto.BackColor = Color.White;
            btnGuardarProducto.FlatStyle = FlatStyle.Flat;
            btnGuardarProducto.ForeColor = Color.FromArgb(56, 124, 31);
            btnGuardarProducto.Location = new Point(929, 424);
            btnGuardarProducto.Name = "btnGuardarProducto";
            btnGuardarProducto.Size = new Size(126, 41);
            btnGuardarProducto.TabIndex = 9;
            btnGuardarProducto.Text = "Guardar";
            btnGuardarProducto.UseVisualStyleBackColor = false;
            // 
            // btnModificarProducto
            // 
            btnModificarProducto.BackColor = Color.White;
            btnModificarProducto.FlatStyle = FlatStyle.Flat;
            btnModificarProducto.ForeColor = Color.FromArgb(56, 124, 31);
            btnModificarProducto.Location = new Point(774, 424);
            btnModificarProducto.Name = "btnModificarProducto";
            btnModificarProducto.Size = new Size(150, 40);
            btnModificarProducto.TabIndex = 10;
            btnModificarProducto.Text = "Modificar";
            btnModificarProducto.UseVisualStyleBackColor = false;
            // 
            // tabPage4
            // 
            tabPage4.BackColor = Color.FromArgb(141, 181, 146);
            tabPage4.Controls.Add(btnImprimirProveedores);
            tabPage4.Controls.Add(groupBox5);
            tabPage4.Controls.Add(groupBox6);
            tabPage4.Location = new Point(4, 38);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3, 3, 3, 3);
            tabPage4.Size = new Size(1117, 839);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Inventario";
            // 
            // btnImprimirProveedores
            // 
            btnImprimirProveedores.BackColor = Color.AliceBlue;
            btnImprimirProveedores.FlatStyle = FlatStyle.Flat;
            btnImprimirProveedores.ForeColor = Color.FromArgb(56, 124, 31);
            btnImprimirProveedores.Location = new Point(934, 760);
            btnImprimirProveedores.Name = "btnImprimirProveedores";
            btnImprimirProveedores.Size = new Size(150, 40);
            btnImprimirProveedores.TabIndex = 0;
            btnImprimirProveedores.Text = "Imprimir";
            btnImprimirProveedores.UseVisualStyleBackColor = false;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(btnLimpiarProveedores);
            groupBox5.Controls.Add(dtgProveedores);
            groupBox5.Controls.Add(label11);
            groupBox5.Controls.Add(txtDireccion);
            groupBox5.Controls.Add(label10);
            groupBox5.Controls.Add(txtEmail);
            groupBox5.ForeColor = Color.White;
            groupBox5.Location = new Point(3, 5);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(1080, 749);
            groupBox5.TabIndex = 3;
            groupBox5.TabStop = false;
            groupBox5.Text = "Proveedores:";
            // 
            // btnLimpiarProveedores
            // 
            btnLimpiarProveedores.BackColor = Color.White;
            btnLimpiarProveedores.FlatStyle = FlatStyle.Flat;
            btnLimpiarProveedores.ForeColor = Color.Green;
            btnLimpiarProveedores.Location = new Point(465, 149);
            btnLimpiarProveedores.Name = "btnLimpiarProveedores";
            btnLimpiarProveedores.Size = new Size(193, 39);
            btnLimpiarProveedores.TabIndex = 0;
            btnLimpiarProveedores.Text = "Limpiar";
            btnLimpiarProveedores.UseVisualStyleBackColor = false;
            // 
            // dtgProveedores
            // 
            dtgProveedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgProveedores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgProveedores.Dock = DockStyle.Bottom;
            dtgProveedores.Location = new Point(3, 301);
            dtgProveedores.Name = "dtgProveedores";
            dtgProveedores.RowHeadersWidth = 51;
            dtgProveedores.Size = new Size(1074, 445);
            dtgProveedores.TabIndex = 65;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(70, 91);
            label11.Name = "label11";
            label11.Size = new Size(131, 29);
            label11.TabIndex = 66;
            label11.Text = "Direccion:";
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(203, 85);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(278, 34);
            txtDireccion.TabIndex = 67;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(107, 45);
            label10.Name = "label10";
            label10.Size = new Size(86, 29);
            label10.TabIndex = 68;
            label10.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(203, 41);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(278, 34);
            txtEmail.TabIndex = 69;
            // 
            // groupBox6
            // 
            groupBox6.Location = new Point(0, 0);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(200, 100);
            groupBox6.TabIndex = 4;
            groupBox6.TabStop = false;
            // 
            // label8
            // 
            label8.Location = new Point(0, 0);
            label8.Name = "label8";
            label8.Size = new Size(100, 23);
            label8.TabIndex = 0;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(0, 0);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(100, 27);
            txtTelefono.TabIndex = 0;
            // 
            // label7
            // 
            label7.Location = new Point(0, 0);
            label7.Name = "label7";
            label7.Size = new Size(100, 23);
            label7.TabIndex = 0;
            // 
            // txtRazonSocial
            // 
            txtRazonSocial.Location = new Point(0, 0);
            txtRazonSocial.Name = "txtRazonSocial";
            txtRazonSocial.Size = new Size(100, 27);
            txtRazonSocial.TabIndex = 0;
            // 
            // btnGuardarProveedor
            // 
            btnGuardarProveedor.BackColor = Color.DarkBlue;
            btnGuardarProveedor.FlatStyle = FlatStyle.Flat;
            btnGuardarProveedor.ForeColor = Color.White;
            btnGuardarProveedor.Location = new Point(0, 0);
            btnGuardarProveedor.Name = "btnGuardarProveedor";
            btnGuardarProveedor.Size = new Size(150, 40);
            btnGuardarProveedor.TabIndex = 0;
            btnGuardarProveedor.UseVisualStyleBackColor = false;
            // 
            // btnModificarProveedor
            // 
            btnModificarProveedor.BackColor = Color.DarkBlue;
            btnModificarProveedor.FlatStyle = FlatStyle.Flat;
            btnModificarProveedor.ForeColor = Color.White;
            btnModificarProveedor.Location = new Point(0, 0);
            btnModificarProveedor.Name = "btnModificarProveedor";
            btnModificarProveedor.Size = new Size(150, 40);
            btnModificarProveedor.TabIndex = 0;
            btnModificarProveedor.UseVisualStyleBackColor = false;
            // 
            // btnLimpiarAlimentos
            // 
            btnLimpiarAlimentos.BackColor = Color.DarkBlue;
            btnLimpiarAlimentos.FlatStyle = FlatStyle.Flat;
            btnLimpiarAlimentos.ForeColor = Color.White;
            btnLimpiarAlimentos.Location = new Point(0, 0);
            btnLimpiarAlimentos.Name = "btnLimpiarAlimentos";
            btnLimpiarAlimentos.Size = new Size(150, 40);
            btnLimpiarAlimentos.TabIndex = 0;
            btnLimpiarAlimentos.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            label6.Location = new Point(0, 0);
            label6.Name = "label6";
            label6.Size = new Size(100, 23);
            label6.TabIndex = 0;
            // 
            // txtKgUnidad
            // 
            txtKgUnidad.Location = new Point(0, 0);
            txtKgUnidad.Name = "txtKgUnidad";
            txtKgUnidad.Size = new Size(100, 27);
            txtKgUnidad.TabIndex = 0;
            // 
            // cmbKgUnidad
            // 
            cmbKgUnidad.Location = new Point(0, 0);
            cmbKgUnidad.Name = "cmbKgUnidad";
            cmbKgUnidad.Size = new Size(121, 28);
            cmbKgUnidad.TabIndex = 0;
            // 
            // btnGuardarUnidad
            // 
            btnGuardarUnidad.BackColor = Color.DarkBlue;
            btnGuardarUnidad.FlatStyle = FlatStyle.Flat;
            btnGuardarUnidad.ForeColor = Color.White;
            btnGuardarUnidad.Location = new Point(0, 0);
            btnGuardarUnidad.Name = "btnGuardarUnidad";
            btnGuardarUnidad.Size = new Size(150, 40);
            btnGuardarUnidad.TabIndex = 0;
            btnGuardarUnidad.UseVisualStyleBackColor = false;
            // 
            // btnModificarUnidad
            // 
            btnModificarUnidad.BackColor = Color.DarkBlue;
            btnModificarUnidad.FlatStyle = FlatStyle.Flat;
            btnModificarUnidad.ForeColor = Color.White;
            btnModificarUnidad.Location = new Point(0, 0);
            btnModificarUnidad.Name = "btnModificarUnidad";
            btnModificarUnidad.Size = new Size(150, 40);
            btnModificarUnidad.TabIndex = 0;
            btnModificarUnidad.UseVisualStyleBackColor = false;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // AbmAdministracion
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(141, 181, 146);
            ClientSize = new Size(1125, 881);
            Controls.Add(tabControl1);
            Name = "AbmAdministracion";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Módulo de Administración";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tabPage2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            tabPage3.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            tabPage4.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgProveedores).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private GroupBox groupBox1;
        private Label label12;
        private TextBox txtCodigoPostal;
        private Tienda.RJButton btnLimpiarLocalidadPartido;
        private TextBox txtLocalidad;
        private TextBox txtPartido;
        private Tienda.RJButton btnGuardarUsuario;
        private Tienda.RJButton btnModificarUsuario;
        private ComboBox cmbLocalidad;
        private Label lblApellido;
        private ComboBox cmbPartido;
        private Label label2;
        private TabPage tabPage2;
        private GroupBox groupBox3;
        private Tienda.RJButton btnLimpiarEntornos;
        private TextBox txtTipoEntorno;
        private ComboBox cmbTipoEntorno;
        private Label lblTipoEntorno;
        private Tienda.RJButton btnGuardarEntorno;
        private Tienda.RJButton btnModificarEntorno;
        private TabPage tabPage3;
        private GroupBox groupBox4;
        private Tienda.RJButton btnLimpiarIndustria;
        private Label label5;
        private Label label4;
        private TextBox txtPrecioProducto;
        private Label label3;
        private TextBox txtReceta;
        private TextBox txtProducto;
        private Label label1;
        private ComboBox cmbProducto;
        private Tienda.RJButton btnGuardarProducto;
        private Tienda.RJButton btnModificarProducto;
        private TabPage tabPage4;
        private Tienda.RJButton btnImprimirProveedores;
        private GroupBox groupBox5;
        private Tienda.RJButton btnLimpiarProveedores;
        private DataGridView dtgProveedores;
        private Label label11;
        private TextBox txtDireccion;
        private Label label10;
        private TextBox txtEmail;
        private Label label8;
        private TextBox txtTelefono;
        private Label label7;
        private TextBox txtRazonSocial;
        private Tienda.RJButton btnGuardarProveedor;
        private Tienda.RJButton btnModificarProveedor;
        private GroupBox groupBox6;
        private Tienda.RJButton btnLimpiarAlimentos;
        private Label label6;
        private TextBox txtKgUnidad;
        private ComboBox cmbKgUnidad;
        private Tienda.RJButton btnGuardarUnidad;
        private Tienda.RJButton btnModificarUnidad;
        private ErrorProvider errorProvider1;
    }
}
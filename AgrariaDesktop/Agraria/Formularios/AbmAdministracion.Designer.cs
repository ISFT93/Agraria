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
            tabControl1.Margin = new Padding(3, 2, 3, 2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(984, 661);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.FromArgb(141, 181, 146);
            tabPage1.Controls.Add(groupBox1);
            tabPage1.Location = new Point(4, 33);
            tabPage1.Margin = new Padding(3, 2, 3, 2);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3, 2, 3, 2);
            tabPage1.Size = new Size(976, 624);
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
            groupBox1.Location = new Point(5, 4);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(814, 150);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Localidad y Partido:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(443, 38);
            label12.Name = "label12";
            label12.Size = new Size(145, 24);
            label12.TabIndex = 0;
            label12.Text = "Codigo Postal:";
            // 
            // txtCodigoPostal
            // 
            txtCodigoPostal.Location = new Point(594, 38);
            txtCodigoPostal.Margin = new Padding(3, 2, 3, 2);
            txtCodigoPostal.MaxLength = 10;
            txtCodigoPostal.Name = "txtCodigoPostal";
            txtCodigoPostal.Size = new Size(142, 29);
            txtCodigoPostal.TabIndex = 1;
            // 
            // btnLimpiarLocalidadPartido
            // 
            btnLimpiarLocalidadPartido.BackColor = Color.White;
            btnLimpiarLocalidadPartido.FlatStyle = FlatStyle.Flat;
            btnLimpiarLocalidadPartido.ForeColor = Color.Green;
            btnLimpiarLocalidadPartido.Location = new Point(381, 107);
            btnLimpiarLocalidadPartido.Margin = new Padding(3, 2, 3, 2);
            btnLimpiarLocalidadPartido.Name = "btnLimpiarLocalidadPartido";
            btnLimpiarLocalidadPartido.Size = new Size(168, 29);
            btnLimpiarLocalidadPartido.TabIndex = 2;
            btnLimpiarLocalidadPartido.Text = "Limpiar";
            btnLimpiarLocalidadPartido.UseVisualStyleBackColor = false;
            // 
            // txtLocalidad
            // 
            txtLocalidad.Location = new Point(266, 33);
            txtLocalidad.Margin = new Padding(3, 2, 3, 2);
            txtLocalidad.MaxLength = 40;
            txtLocalidad.Name = "txtLocalidad";
            txtLocalidad.Size = new Size(142, 29);
            txtLocalidad.TabIndex = 3;
            // 
            // txtPartido
            // 
            txtPartido.Location = new Point(266, 76);
            txtPartido.Margin = new Padding(3, 2, 3, 2);
            txtPartido.MaxLength = 40;
            txtPartido.Name = "txtPartido";
            txtPartido.Size = new Size(142, 29);
            txtPartido.TabIndex = 4;
            // 
            // btnGuardarUsuario
            // 
            btnGuardarUsuario.BackColor = Color.White;
            btnGuardarUsuario.FlatStyle = FlatStyle.Flat;
            btnGuardarUsuario.ForeColor = Color.FromArgb(56, 124, 31);
            btnGuardarUsuario.Location = new Point(691, 107);
            btnGuardarUsuario.Margin = new Padding(3, 2, 3, 2);
            btnGuardarUsuario.Name = "btnGuardarUsuario";
            btnGuardarUsuario.Size = new Size(110, 31);
            btnGuardarUsuario.TabIndex = 5;
            btnGuardarUsuario.Text = "Guardar";
            btnGuardarUsuario.UseVisualStyleBackColor = false;
            // 
            // btnModificarUsuario
            // 
            btnModificarUsuario.BackColor = Color.White;
            btnModificarUsuario.FlatStyle = FlatStyle.Flat;
            btnModificarUsuario.ForeColor = Color.FromArgb(56, 124, 31);
            btnModificarUsuario.Location = new Point(555, 107);
            btnModificarUsuario.Margin = new Padding(3, 2, 3, 2);
            btnModificarUsuario.Name = "btnModificarUsuario";
            btnModificarUsuario.Size = new Size(131, 30);
            btnModificarUsuario.TabIndex = 6;
            btnModificarUsuario.Text = "Modificar";
            btnModificarUsuario.UseVisualStyleBackColor = false;
            // 
            // cmbLocalidad
            // 
            cmbLocalidad.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLocalidad.FormattingEnabled = true;
            cmbLocalidad.Location = new Point(110, 31);
            cmbLocalidad.Margin = new Padding(3, 2, 3, 2);
            cmbLocalidad.Name = "cmbLocalidad";
            cmbLocalidad.Size = new Size(142, 32);
            cmbLocalidad.TabIndex = 7;
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(9, 33);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(106, 24);
            lblApellido.TabIndex = 8;
            lblApellido.Text = "Localidad:";
            // 
            // cmbPartido
            // 
            cmbPartido.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPartido.FormattingEnabled = true;
            cmbPartido.Location = new Point(110, 73);
            cmbPartido.Margin = new Padding(3, 2, 3, 2);
            cmbPartido.Name = "cmbPartido";
            cmbPartido.Size = new Size(142, 32);
            cmbPartido.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(31, 76);
            label2.Name = "label2";
            label2.Size = new Size(81, 24);
            label2.TabIndex = 10;
            label2.Text = "Partido:";
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.FromArgb(141, 181, 146);
            tabPage2.Controls.Add(groupBox3);
            tabPage2.Location = new Point(4, 33);
            tabPage2.Margin = new Padding(3, 2, 3, 2);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 2, 3, 2);
            tabPage2.Size = new Size(976, 624);
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
            groupBox3.Location = new Point(5, 4);
            groupBox3.Margin = new Padding(3, 2, 3, 2);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 2, 3, 2);
            groupBox3.Size = new Size(814, 120);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Entornos:";
            // 
            // btnLimpiarEntornos
            // 
            btnLimpiarEntornos.BackColor = Color.White;
            btnLimpiarEntornos.FlatStyle = FlatStyle.Flat;
            btnLimpiarEntornos.ForeColor = Color.Green;
            btnLimpiarEntornos.Location = new Point(402, 85);
            btnLimpiarEntornos.Margin = new Padding(3, 2, 3, 2);
            btnLimpiarEntornos.Name = "btnLimpiarEntornos";
            btnLimpiarEntornos.Size = new Size(168, 29);
            btnLimpiarEntornos.TabIndex = 0;
            btnLimpiarEntornos.Text = "Limpiar";
            btnLimpiarEntornos.UseVisualStyleBackColor = false;
            // 
            // txtTipoEntorno
            // 
            txtTipoEntorno.Location = new Point(348, 37);
            txtTipoEntorno.Margin = new Padding(3, 2, 3, 2);
            txtTipoEntorno.MaxLength = 30;
            txtTipoEntorno.Name = "txtTipoEntorno";
            txtTipoEntorno.Size = new Size(142, 29);
            txtTipoEntorno.TabIndex = 1;
            // 
            // cmbTipoEntorno
            // 
            cmbTipoEntorno.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoEntorno.FormattingEnabled = true;
            cmbTipoEntorno.Location = new Point(193, 35);
            cmbTipoEntorno.Margin = new Padding(3, 2, 3, 2);
            cmbTipoEntorno.Name = "cmbTipoEntorno";
            cmbTipoEntorno.Size = new Size(142, 32);
            cmbTipoEntorno.TabIndex = 2;
            // 
            // lblTipoEntorno
            // 
            lblTipoEntorno.AutoSize = true;
            lblTipoEntorno.Location = new Point(18, 40);
            lblTipoEntorno.Name = "lblTipoEntorno";
            lblTipoEntorno.Size = new Size(168, 24);
            lblTipoEntorno.TabIndex = 3;
            lblTipoEntorno.Text = "Tipo de Entorno:";
            // 
            // btnGuardarEntorno
            // 
            btnGuardarEntorno.BackColor = Color.White;
            btnGuardarEntorno.FlatStyle = FlatStyle.Flat;
            btnGuardarEntorno.ForeColor = Color.FromArgb(56, 124, 31);
            btnGuardarEntorno.Location = new Point(700, 85);
            btnGuardarEntorno.Margin = new Padding(3, 2, 3, 2);
            btnGuardarEntorno.Name = "btnGuardarEntorno";
            btnGuardarEntorno.Size = new Size(110, 31);
            btnGuardarEntorno.TabIndex = 4;
            btnGuardarEntorno.Text = "Guardar";
            btnGuardarEntorno.UseVisualStyleBackColor = false;
            // 
            // btnModificarEntorno
            // 
            btnModificarEntorno.BackColor = Color.White;
            btnModificarEntorno.FlatStyle = FlatStyle.Flat;
            btnModificarEntorno.ForeColor = Color.FromArgb(56, 124, 31);
            btnModificarEntorno.Location = new Point(564, 85);
            btnModificarEntorno.Margin = new Padding(3, 2, 3, 2);
            btnModificarEntorno.Name = "btnModificarEntorno";
            btnModificarEntorno.Size = new Size(131, 30);
            btnModificarEntorno.TabIndex = 5;
            btnModificarEntorno.Text = "Modificar";
            btnModificarEntorno.UseVisualStyleBackColor = false;
            // 
            // tabPage3
            // 
            tabPage3.BackColor = Color.FromArgb(141, 181, 146);
            tabPage3.Controls.Add(groupBox4);
            tabPage3.Location = new Point(4, 33);
            tabPage3.Margin = new Padding(3, 2, 3, 2);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3, 2, 3, 2);
            tabPage3.Size = new Size(976, 624);
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
            groupBox4.Location = new Point(5, 4);
            groupBox4.Margin = new Padding(3, 2, 3, 2);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(3, 2, 3, 2);
            groupBox4.Size = new Size(943, 365);
            groupBox4.TabIndex = 1;
            groupBox4.TabStop = false;
            groupBox4.Text = "Industria:";
            // 
            // btnLimpiarIndustria
            // 
            btnLimpiarIndustria.BackColor = Color.White;
            btnLimpiarIndustria.FlatStyle = FlatStyle.Flat;
            btnLimpiarIndustria.ForeColor = Color.Green;
            btnLimpiarIndustria.Location = new Point(540, 318);
            btnLimpiarIndustria.Margin = new Padding(3, 2, 3, 2);
            btnLimpiarIndustria.Name = "btnLimpiarIndustria";
            btnLimpiarIndustria.Size = new Size(131, 29);
            btnLimpiarIndustria.TabIndex = 0;
            btnLimpiarIndustria.Text = "Limpiar";
            btnLimpiarIndustria.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label5.Location = new Point(6, 75);
            label5.Name = "label5";
            label5.Size = new Size(216, 24);
            label5.TabIndex = 1;
            label5.Text = "Nombre del Producto:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label4.Location = new Point(19, 121);
            label4.Name = "label4";
            label4.Size = new Size(201, 24);
            label4.TabIndex = 2;
            label4.Text = "Precio del Producto:";
            // 
            // txtPrecioProducto
            // 
            txtPrecioProducto.Location = new Point(226, 121);
            txtPrecioProducto.Margin = new Padding(3, 2, 3, 2);
            txtPrecioProducto.MaxLength = 10;
            txtPrecioProducto.Name = "txtPrecioProducto";
            txtPrecioProducto.Size = new Size(142, 29);
            txtPrecioProducto.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(424, 29);
            label3.Name = "label3";
            label3.Size = new Size(81, 24);
            label3.TabIndex = 4;
            label3.Text = "Receta:";
            // 
            // txtReceta
            // 
            txtReceta.Location = new Point(511, 26);
            txtReceta.Margin = new Padding(3, 2, 3, 2);
            txtReceta.Multiline = true;
            txtReceta.Name = "txtReceta";
            txtReceta.Size = new Size(412, 226);
            txtReceta.TabIndex = 5;
            // 
            // txtProducto
            // 
            txtProducto.Location = new Point(226, 75);
            txtProducto.Margin = new Padding(3, 2, 3, 2);
            txtProducto.MaxLength = 30;
            txtProducto.Name = "txtProducto";
            txtProducto.Size = new Size(142, 29);
            txtProducto.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 29);
            label1.Name = "label1";
            label1.Size = new Size(201, 24);
            label1.TabIndex = 7;
            label1.Text = "Producto a producir:";
            // 
            // cmbProducto
            // 
            cmbProducto.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProducto.Location = new Point(228, 26);
            cmbProducto.Margin = new Padding(3, 2, 3, 2);
            cmbProducto.Name = "cmbProducto";
            cmbProducto.Size = new Size(142, 32);
            cmbProducto.TabIndex = 8;
            // 
            // btnGuardarProducto
            // 
            btnGuardarProducto.BackColor = Color.White;
            btnGuardarProducto.FlatStyle = FlatStyle.Flat;
            btnGuardarProducto.ForeColor = Color.FromArgb(56, 124, 31);
            btnGuardarProducto.Location = new Point(813, 318);
            btnGuardarProducto.Margin = new Padding(3, 2, 3, 2);
            btnGuardarProducto.Name = "btnGuardarProducto";
            btnGuardarProducto.Size = new Size(110, 31);
            btnGuardarProducto.TabIndex = 9;
            btnGuardarProducto.Text = "Guardar";
            btnGuardarProducto.UseVisualStyleBackColor = false;
            // 
            // btnModificarProducto
            // 
            btnModificarProducto.BackColor = Color.White;
            btnModificarProducto.FlatStyle = FlatStyle.Flat;
            btnModificarProducto.ForeColor = Color.FromArgb(56, 124, 31);
            btnModificarProducto.Location = new Point(677, 318);
            btnModificarProducto.Margin = new Padding(3, 2, 3, 2);
            btnModificarProducto.Name = "btnModificarProducto";
            btnModificarProducto.Size = new Size(131, 30);
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
            tabPage4.Location = new Point(4, 33);
            tabPage4.Margin = new Padding(3, 2, 3, 2);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3, 2, 3, 2);
            tabPage4.Size = new Size(976, 624);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Inventario";
            // 
            // btnImprimirProveedores
            // 
            btnImprimirProveedores.BackColor = Color.AliceBlue;
            btnImprimirProveedores.FlatStyle = FlatStyle.Flat;
            btnImprimirProveedores.ForeColor = Color.FromArgb(56, 124, 31);
            btnImprimirProveedores.Location = new Point(817, 570);
            btnImprimirProveedores.Margin = new Padding(3, 2, 3, 2);
            btnImprimirProveedores.Name = "btnImprimirProveedores";
            btnImprimirProveedores.Size = new Size(131, 30);
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
            groupBox5.Location = new Point(3, 4);
            groupBox5.Margin = new Padding(3, 2, 3, 2);
            groupBox5.Name = "groupBox5";
            groupBox5.Padding = new Padding(3, 2, 3, 2);
            groupBox5.Size = new Size(945, 562);
            groupBox5.TabIndex = 3;
            groupBox5.TabStop = false;
            groupBox5.Text = "Proveedores:";
            // 
            // btnLimpiarProveedores
            // 
            btnLimpiarProveedores.BackColor = Color.White;
            btnLimpiarProveedores.FlatStyle = FlatStyle.Flat;
            btnLimpiarProveedores.ForeColor = Color.Green;
            btnLimpiarProveedores.Location = new Point(407, 112);
            btnLimpiarProveedores.Margin = new Padding(3, 2, 3, 2);
            btnLimpiarProveedores.Name = "btnLimpiarProveedores";
            btnLimpiarProveedores.Size = new Size(169, 29);
            btnLimpiarProveedores.TabIndex = 0;
            btnLimpiarProveedores.Text = "Limpiar";
            btnLimpiarProveedores.UseVisualStyleBackColor = false;
            // 
            // dtgProveedores
            // 
            dtgProveedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgProveedores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgProveedores.Dock = DockStyle.Bottom;
            dtgProveedores.Location = new Point(3, 226);
            dtgProveedores.Margin = new Padding(3, 2, 3, 2);
            dtgProveedores.Name = "dtgProveedores";
            dtgProveedores.Size = new Size(939, 334);
            dtgProveedores.TabIndex = 65;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(61, 68);
            label11.Name = "label11";
            label11.Size = new Size(105, 24);
            label11.TabIndex = 66;
            label11.Text = "Direccion:";
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(178, 64);
            txtDireccion.Margin = new Padding(3, 2, 3, 2);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(244, 29);
            txtDireccion.TabIndex = 67;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(94, 34);
            label10.Name = "label10";
            label10.Size = new Size(68, 24);
            label10.TabIndex = 68;
            label10.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(178, 31);
            txtEmail.Margin = new Padding(3, 2, 3, 2);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(244, 29);
            txtEmail.TabIndex = 69;
            // 
            // groupBox6
            // 
            groupBox6.Location = new Point(0, 0);
            groupBox6.Margin = new Padding(3, 2, 3, 2);
            groupBox6.Name = "groupBox6";
            groupBox6.Padding = new Padding(3, 2, 3, 2);
            groupBox6.Size = new Size(175, 75);
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
            txtTelefono.Size = new Size(100, 23);
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
            txtRazonSocial.Size = new Size(100, 23);
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
            txtKgUnidad.Size = new Size(100, 23);
            txtKgUnidad.TabIndex = 0;
            // 
            // cmbKgUnidad
            // 
            cmbKgUnidad.Location = new Point(0, 0);
            cmbKgUnidad.Name = "cmbKgUnidad";
            cmbKgUnidad.Size = new Size(121, 23);
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
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(141, 181, 146);
            ClientSize = new Size(984, 661);
            Controls.Add(tabControl1);
            Margin = new Padding(3, 2, 3, 2);
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
namespace Agraria.Formularios
{
    partial class Inventario
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
            groupBox2 = new GroupBox();
            panel1 = new Panel();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            panel5 = new Panel();
            dtgArticulos = new DataGridView();
            panel3 = new Panel();
            btnImprimir = new Tienda.RJButton();
            txtFiltrarNombre = new TextBox();
            label3 = new Label();
            tabPage2 = new TabPage();
            panel6 = new Panel();
            dtgAlimentos = new DataGridView();
            panel4 = new Panel();
            btnImprimirAlimentos = new Tienda.RJButton();
            panel2 = new Panel();
            panel8 = new Panel();
            panel7 = new Panel();
            gbEnviarPolloIndustria = new GroupBox();
            btnModificarArticulo = new Tienda.RJButton();
            btnLimpiar = new Tienda.RJButton();
            btnAgregar = new Tienda.RJButton();
            label6 = new Label();
            cmbKgUnidad = new ComboBox();
            txtPrecio = new TextBox();
            txtCantidad = new TextBox();
            cmbEntornoFormativo = new ComboBox();
            label2 = new Label();
            dtpFechaIngreso = new DateTimePicker();
            label7 = new Label();
            txtNombreProducto = new TextBox();
            lblEntorno = new Label();
            label4 = new Label();
            lblID = new Label();
            txtResponsableCargo = new TextBox();
            label1 = new Label();
            groupBox5 = new GroupBox();
            btnModificarAlimentos = new Tienda.RJButton();
            cmbProveedores = new ComboBox();
            btnLimpiarAlimentos = new Tienda.RJButton();
            btnAgregarAlimentos = new Tienda.RJButton();
            label5 = new Label();
            cmbMedidaProveedor = new ComboBox();
            txtPrecioProveedor = new TextBox();
            txtCantidadProveedor = new TextBox();
            cmbTipoEntorno2 = new ComboBox();
            label8 = new Label();
            dtpFechaIngresoAlimento = new DateTimePicker();
            label9 = new Label();
            txtNombreAlimentoProveedor = new TextBox();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            errorProvider1 = new ErrorProvider(components);
            groupBox2.SuspendLayout();
            panel1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgArticulos).BeginInit();
            panel3.SuspendLayout();
            tabPage2.SuspendLayout();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgAlimentos).BeginInit();
            panel4.SuspendLayout();
            panel2.SuspendLayout();
            panel8.SuspendLayout();
            panel7.SuspendLayout();
            gbEnviarPolloIndustria.SuspendLayout();
            groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(panel1);
            groupBox2.Controls.Add(panel2);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            groupBox2.ForeColor = Color.White;
            groupBox2.Location = new Point(0, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(984, 661);
            groupBox2.TabIndex = 23;
            groupBox2.TabStop = false;
            groupBox2.Text = "Busqueda y Carga de todos los Articulos Comprados";
            // 
            // panel1
            // 
            panel1.Controls.Add(tabControl1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 444);
            panel1.Name = "panel1";
            panel1.Size = new Size(978, 214);
            panel1.TabIndex = 76;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(978, 214);
            tabControl1.TabIndex = 23;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.FromArgb(141, 181, 146);
            tabPage1.Controls.Add(panel5);
            tabPage1.Controls.Add(panel3);
            tabPage1.ForeColor = Color.Black;
            tabPage1.Location = new Point(4, 33);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(970, 177);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Articulos";
            tabPage1.Click += tabPage1_Click;
            // 
            // panel5
            // 
            panel5.Controls.Add(dtgArticulos);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(3, 53);
            panel5.Name = "panel5";
            panel5.Size = new Size(964, 121);
            panel5.TabIndex = 57;
            // 
            // dtgArticulos
            // 
            dtgArticulos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgArticulos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgArticulos.Dock = DockStyle.Fill;
            dtgArticulos.Location = new Point(0, 0);
            dtgArticulos.Margin = new Padding(3, 2, 3, 2);
            dtgArticulos.Name = "dtgArticulos";
            dtgArticulos.ReadOnly = true;
            dtgArticulos.RowHeadersWidth = 51;
            dtgArticulos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgArticulos.Size = new Size(964, 121);
            dtgArticulos.TabIndex = 0;
            dtgArticulos.CellClick += dtgArticulos_CellClick;
            dtgArticulos.CellContentClick += dtgArticulos_CellClick;
            // 
            // panel3
            // 
            panel3.Controls.Add(btnImprimir);
            panel3.Controls.Add(txtFiltrarNombre);
            panel3.Controls.Add(label3);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(3, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(964, 50);
            panel3.TabIndex = 56;
            // 
            // btnImprimir
            // 
            btnImprimir.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnImprimir.BackColor = Color.White;
            btnImprimir.FlatAppearance.BorderSize = 0;
            btnImprimir.FlatStyle = FlatStyle.Flat;
            btnImprimir.ForeColor = Color.Green;
            btnImprimir.Image = Properties.Resources.imprimir;
            btnImprimir.ImageAlign = ContentAlignment.MiddleLeft;
            btnImprimir.Location = new Point(769, 3);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(192, 39);
            btnImprimir.TabIndex = 22;
            btnImprimir.Text = "Imprimir";
            btnImprimir.UseVisualStyleBackColor = false;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // txtFiltrarNombre
            // 
            txtFiltrarNombre.Location = new Point(146, 13);
            txtFiltrarNombre.MaxLength = 30;
            txtFiltrarNombre.Name = "txtFiltrarNombre";
            txtFiltrarNombre.Size = new Size(223, 29);
            txtFiltrarNombre.TabIndex = 21;
            txtFiltrarNombre.TextChanged += txtFiltrarNombre_TextChanged;
            txtFiltrarNombre.KeyDown += CopiaryPegar_KeyDown;
            txtFiltrarNombre.KeyPress += SoloTextoNumeroEspacio_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.ImageAlign = ContentAlignment.MiddleLeft;
            label3.Location = new Point(49, 16);
            label3.Name = "label3";
            label3.Size = new Size(91, 24);
            label3.TabIndex = 41;
            label3.Text = "Nombre:";
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.FromArgb(141, 181, 146);
            tabPage2.Controls.Add(panel6);
            tabPage2.Controls.Add(panel4);
            tabPage2.Location = new Point(4, 33);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(970, 177);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Alimentos Proveedor";
            // 
            // panel6
            // 
            panel6.Controls.Add(dtgAlimentos);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(3, 52);
            panel6.Name = "panel6";
            panel6.Size = new Size(964, 122);
            panel6.TabIndex = 59;
            // 
            // dtgAlimentos
            // 
            dtgAlimentos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgAlimentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgAlimentos.Dock = DockStyle.Fill;
            dtgAlimentos.Location = new Point(0, 0);
            dtgAlimentos.Margin = new Padding(3, 2, 3, 2);
            dtgAlimentos.Name = "dtgAlimentos";
            dtgAlimentos.ReadOnly = true;
            dtgAlimentos.RowHeadersWidth = 51;
            dtgAlimentos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgAlimentos.Size = new Size(964, 122);
            dtgAlimentos.TabIndex = 0;
            dtgAlimentos.CellClick += dtgAlimentos_CellClick;
            dtgAlimentos.CellContentClick += dtgAlimentos_CellClick;
            // 
            // panel4
            // 
            panel4.Controls.Add(btnImprimirAlimentos);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(3, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(964, 49);
            panel4.TabIndex = 58;
            // 
            // btnImprimirAlimentos
            // 
            btnImprimirAlimentos.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnImprimirAlimentos.BackColor = Color.White;
            btnImprimirAlimentos.FlatAppearance.BorderSize = 0;
            btnImprimirAlimentos.FlatStyle = FlatStyle.Flat;
            btnImprimirAlimentos.ForeColor = Color.Green;
            btnImprimirAlimentos.Image = Properties.Resources.imprimir;
            btnImprimirAlimentos.ImageAlign = ContentAlignment.MiddleLeft;
            btnImprimirAlimentos.Location = new Point(769, 3);
            btnImprimirAlimentos.Name = "btnImprimirAlimentos";
            btnImprimirAlimentos.Size = new Size(192, 39);
            btnImprimirAlimentos.TabIndex = 57;
            btnImprimirAlimentos.Text = "Imprimir";
            btnImprimirAlimentos.UseVisualStyleBackColor = false;
            btnImprimirAlimentos.Click += btnImprimirAlimentos_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel8);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(3, 25);
            panel2.Name = "panel2";
            panel2.Size = new Size(978, 419);
            panel2.TabIndex = 77;
            // 
            // panel8
            // 
            panel8.Controls.Add(panel7);
            panel8.Controls.Add(groupBox5);
            panel8.Dock = DockStyle.Top;
            panel8.Location = new Point(0, 0);
            panel8.Name = "panel8";
            panel8.Size = new Size(978, 411);
            panel8.TabIndex = 73;
            // 
            // panel7
            // 
            panel7.Controls.Add(gbEnviarPolloIndustria);
            panel7.Dock = DockStyle.Top;
            panel7.Location = new Point(0, 199);
            panel7.Name = "panel7";
            panel7.Size = new Size(978, 209);
            panel7.TabIndex = 75;
            // 
            // gbEnviarPolloIndustria
            // 
            gbEnviarPolloIndustria.Controls.Add(btnModificarArticulo);
            gbEnviarPolloIndustria.Controls.Add(btnLimpiar);
            gbEnviarPolloIndustria.Controls.Add(btnAgregar);
            gbEnviarPolloIndustria.Controls.Add(label6);
            gbEnviarPolloIndustria.Controls.Add(cmbKgUnidad);
            gbEnviarPolloIndustria.Controls.Add(txtPrecio);
            gbEnviarPolloIndustria.Controls.Add(txtCantidad);
            gbEnviarPolloIndustria.Controls.Add(cmbEntornoFormativo);
            gbEnviarPolloIndustria.Controls.Add(label2);
            gbEnviarPolloIndustria.Controls.Add(dtpFechaIngreso);
            gbEnviarPolloIndustria.Controls.Add(label7);
            gbEnviarPolloIndustria.Controls.Add(txtNombreProducto);
            gbEnviarPolloIndustria.Controls.Add(lblEntorno);
            gbEnviarPolloIndustria.Controls.Add(label4);
            gbEnviarPolloIndustria.Controls.Add(lblID);
            gbEnviarPolloIndustria.Controls.Add(txtResponsableCargo);
            gbEnviarPolloIndustria.Controls.Add(label1);
            gbEnviarPolloIndustria.Dock = DockStyle.Fill;
            gbEnviarPolloIndustria.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbEnviarPolloIndustria.ForeColor = Color.White;
            gbEnviarPolloIndustria.Location = new Point(0, 0);
            gbEnviarPolloIndustria.Name = "gbEnviarPolloIndustria";
            gbEnviarPolloIndustria.Size = new Size(978, 209);
            gbEnviarPolloIndustria.TabIndex = 71;
            gbEnviarPolloIndustria.TabStop = false;
            gbEnviarPolloIndustria.Text = "Carga de Articulos";
            gbEnviarPolloIndustria.Enter += gbEnviarPolloIndustria_Enter;
            // 
            // btnModificarArticulo
            // 
            btnModificarArticulo.BackColor = Color.White;
            btnModificarArticulo.FlatAppearance.BorderSize = 0;
            btnModificarArticulo.FlatStyle = FlatStyle.Flat;
            btnModificarArticulo.ForeColor = Color.Green;
            btnModificarArticulo.Image = Properties.Resources.Modificar77;
            btnModificarArticulo.ImageAlign = ContentAlignment.MiddleLeft;
            btnModificarArticulo.Location = new Point(224, 151);
            btnModificarArticulo.Name = "btnModificarArticulo";
            btnModificarArticulo.Size = new Size(192, 39);
            btnModificarArticulo.TabIndex = 19;
            btnModificarArticulo.Text = "Modificar";
            btnModificarArticulo.UseVisualStyleBackColor = false;
            btnModificarArticulo.Click += btnModificarArticulo_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.White;
            btnLimpiar.FlatAppearance.BorderSize = 0;
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.ForeColor = Color.Green;
            btnLimpiar.Image = Properties.Resources.escoba;
            btnLimpiar.ImageAlign = ContentAlignment.MiddleLeft;
            btnLimpiar.Location = new Point(443, 151);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(192, 39);
            btnLimpiar.TabIndex = 20;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.White;
            btnAgregar.FlatAppearance.BorderSize = 0;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.ForeColor = Color.Green;
            btnAgregar.Image = Properties.Resources.guardar_datos;
            btnAgregar.ImageAlign = ContentAlignment.MiddleLeft;
            btnAgregar.Location = new Point(14, 151);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(192, 39);
            btnAgregar.TabIndex = 18;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label6.ForeColor = Color.White;
            label6.Location = new Point(596, 29);
            label6.Name = "label6";
            label6.Size = new Size(113, 24);
            label6.TabIndex = 52;
            label6.Text = "Kg /Unidad";
            // 
            // cmbKgUnidad
            // 
            cmbKgUnidad.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbKgUnidad.FormattingEnabled = true;
            cmbKgUnidad.Location = new Point(715, 21);
            cmbKgUnidad.Name = "cmbKgUnidad";
            cmbKgUnidad.Size = new Size(97, 32);
            cmbKgUnidad.TabIndex = 13;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(152, 108);
            txtPrecio.MaxLength = 10;
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(97, 29);
            txtPrecio.TabIndex = 17;
            txtPrecio.KeyDown += CopiaryPegar_KeyDown;
            txtPrecio.KeyPress += SoloNumerosYComa_KeyPress;
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(462, 24);
            txtCantidad.MaxLength = 5;
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(105, 29);
            txtCantidad.TabIndex = 12;
            txtCantidad.KeyDown += CopiaryPegar_KeyDown;
            txtCantidad.KeyPress += SoloNumeros_KeyPress;
            // 
            // cmbEntornoFormativo
            // 
            cmbEntornoFormativo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEntornoFormativo.FormattingEnabled = true;
            cmbEntornoFormativo.Location = new Point(715, 64);
            cmbEntornoFormativo.Name = "cmbEntornoFormativo";
            cmbEntornoFormativo.Size = new Size(182, 32);
            cmbEntornoFormativo.TabIndex = 16;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(19, 111);
            label2.Name = "label2";
            label2.Size = new Size(132, 24);
            label2.TabIndex = 15;
            label2.Text = "Responsable";
            // 
            // dtpFechaIngreso
            // 
            dtpFechaIngreso.Format = DateTimePickerFormat.Short;
            dtpFechaIngreso.Location = new Point(462, 67);
            dtpFechaIngreso.Margin = new Padding(3, 2, 3, 2);
            dtpFechaIngreso.Name = "dtpFechaIngreso";
            dtpFechaIngreso.Size = new Size(138, 29);
            dtpFechaIngreso.TabIndex = 15;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label7.ForeColor = Color.White;
            label7.Location = new Point(361, 29);
            label7.Name = "label7";
            label7.Size = new Size(92, 24);
            label7.TabIndex = 20;
            label7.Text = "Cantidad";
            // 
            // txtNombreProducto
            // 
            txtNombreProducto.Location = new Point(152, 26);
            txtNombreProducto.MaxLength = 40;
            txtNombreProducto.Name = "txtNombreProducto";
            txtNombreProducto.Size = new Size(187, 29);
            txtNombreProducto.TabIndex = 11;
            txtNombreProducto.KeyDown += CopiaryPegar_KeyDown;
            txtNombreProducto.KeyPress += SoloTextoNumeroEspacio_KeyPress;
            // 
            // lblEntorno
            // 
            lblEntorno.AutoSize = true;
            lblEntorno.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblEntorno.ForeColor = Color.White;
            lblEntorno.Location = new Point(613, 72);
            lblEntorno.Name = "lblEntorno";
            lblEntorno.Size = new Size(85, 24);
            lblEntorno.TabIndex = 21;
            lblEntorno.Text = "Nombre";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(48, 31);
            label4.Name = "label4";
            label4.Size = new Size(84, 24);
            label4.TabIndex = 44;
            label4.Text = "Entorno";
            // 
            // lblID
            // 
            lblID.AutoSize = true;
            lblID.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblID.ForeColor = Color.White;
            lblID.Location = new Point(361, 72);
            lblID.Name = "lblID";
            lblID.Size = new Size(69, 24);
            lblID.TabIndex = 34;
            lblID.Text = "Fecha";
            // 
            // txtResponsableCargo
            // 
            txtResponsableCargo.Location = new Point(152, 67);
            txtResponsableCargo.MaxLength = 40;
            txtResponsableCargo.Name = "txtResponsableCargo";
            txtResponsableCargo.Size = new Size(182, 29);
            txtResponsableCargo.TabIndex = 14;
            txtResponsableCargo.KeyDown += CopiaryPegar_KeyDown;
            txtResponsableCargo.KeyPress += SoloTextoNumeroEspacio_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(62, 72);
            label1.Name = "label1";
            label1.Size = new Size(70, 24);
            label1.TabIndex = 39;
            label1.Text = "Precio";
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(btnModificarAlimentos);
            groupBox5.Controls.Add(cmbProveedores);
            groupBox5.Controls.Add(btnLimpiarAlimentos);
            groupBox5.Controls.Add(btnAgregarAlimentos);
            groupBox5.Controls.Add(label5);
            groupBox5.Controls.Add(cmbMedidaProveedor);
            groupBox5.Controls.Add(txtPrecioProveedor);
            groupBox5.Controls.Add(txtCantidadProveedor);
            groupBox5.Controls.Add(cmbTipoEntorno2);
            groupBox5.Controls.Add(label8);
            groupBox5.Controls.Add(dtpFechaIngresoAlimento);
            groupBox5.Controls.Add(label9);
            groupBox5.Controls.Add(txtNombreAlimentoProveedor);
            groupBox5.Controls.Add(label10);
            groupBox5.Controls.Add(label11);
            groupBox5.Controls.Add(label12);
            groupBox5.Controls.Add(label13);
            groupBox5.Dock = DockStyle.Top;
            groupBox5.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox5.ForeColor = Color.White;
            groupBox5.Location = new Point(0, 0);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(978, 199);
            groupBox5.TabIndex = 74;
            groupBox5.TabStop = false;
            groupBox5.Text = "Carga de Alimentos Comprados";
            groupBox5.Enter += groupBox5_Enter;
            // 
            // btnModificarAlimentos
            // 
            btnModificarAlimentos.BackColor = Color.White;
            btnModificarAlimentos.FlatAppearance.BorderSize = 0;
            btnModificarAlimentos.FlatStyle = FlatStyle.Flat;
            btnModificarAlimentos.ForeColor = Color.Green;
            btnModificarAlimentos.Image = Properties.Resources.Modificar77;
            btnModificarAlimentos.ImageAlign = ContentAlignment.MiddleLeft;
            btnModificarAlimentos.Location = new Point(214, 146);
            btnModificarAlimentos.Name = "btnModificarAlimentos";
            btnModificarAlimentos.Size = new Size(192, 39);
            btnModificarAlimentos.TabIndex = 9;
            btnModificarAlimentos.Text = "Modificar";
            btnModificarAlimentos.UseVisualStyleBackColor = false;
            btnModificarAlimentos.Click += btnModificarAlimentos_Click;
            // 
            // cmbProveedores
            // 
            cmbProveedores.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProveedores.FormattingEnabled = true;
            cmbProveedores.Location = new Point(135, 98);
            cmbProveedores.Name = "cmbProveedores";
            cmbProveedores.Size = new Size(169, 32);
            cmbProveedores.TabIndex = 7;
            // 
            // btnLimpiarAlimentos
            // 
            btnLimpiarAlimentos.BackColor = Color.White;
            btnLimpiarAlimentos.FlatAppearance.BorderSize = 0;
            btnLimpiarAlimentos.FlatStyle = FlatStyle.Flat;
            btnLimpiarAlimentos.ForeColor = Color.Green;
            btnLimpiarAlimentos.Image = Properties.Resources.escoba;
            btnLimpiarAlimentos.ImageAlign = ContentAlignment.MiddleLeft;
            btnLimpiarAlimentos.Location = new Point(430, 146);
            btnLimpiarAlimentos.Name = "btnLimpiarAlimentos";
            btnLimpiarAlimentos.Size = new Size(192, 39);
            btnLimpiarAlimentos.TabIndex = 10;
            btnLimpiarAlimentos.Text = "Limpiar";
            btnLimpiarAlimentos.UseVisualStyleBackColor = false;
            btnLimpiarAlimentos.Click += btnLimpiarAlimentos_Click;
            // 
            // btnAgregarAlimentos
            // 
            btnAgregarAlimentos.BackColor = Color.White;
            btnAgregarAlimentos.FlatAppearance.BorderSize = 0;
            btnAgregarAlimentos.FlatStyle = FlatStyle.Flat;
            btnAgregarAlimentos.ForeColor = Color.Green;
            btnAgregarAlimentos.Image = Properties.Resources.guardar_datos;
            btnAgregarAlimentos.ImageAlign = ContentAlignment.MiddleLeft;
            btnAgregarAlimentos.Location = new Point(16, 146);
            btnAgregarAlimentos.Name = "btnAgregarAlimentos";
            btnAgregarAlimentos.Size = new Size(192, 39);
            btnAgregarAlimentos.TabIndex = 8;
            btnAgregarAlimentos.Text = "Agregar";
            btnAgregarAlimentos.UseVisualStyleBackColor = false;
            btnAgregarAlimentos.Click += btnAgregarAlimentos_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(597, 33);
            label5.Name = "label5";
            label5.Size = new Size(113, 24);
            label5.TabIndex = 52;
            label5.Text = "Kg /Unidad";
            // 
            // cmbMedidaProveedor
            // 
            cmbMedidaProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMedidaProveedor.FormattingEnabled = true;
            cmbMedidaProveedor.Location = new Point(723, 25);
            cmbMedidaProveedor.Name = "cmbMedidaProveedor";
            cmbMedidaProveedor.Size = new Size(128, 32);
            cmbMedidaProveedor.TabIndex = 3;
            // 
            // txtPrecioProveedor
            // 
            txtPrecioProveedor.Location = new Point(134, 63);
            txtPrecioProveedor.MaxLength = 10;
            txtPrecioProveedor.Name = "txtPrecioProveedor";
            txtPrecioProveedor.Size = new Size(92, 29);
            txtPrecioProveedor.TabIndex = 4;
            txtPrecioProveedor.KeyDown += CopiaryPegar_KeyDown;
            txtPrecioProveedor.KeyPress += SoloNumerosYComa_KeyPress;
            // 
            // txtCantidadProveedor
            // 
            txtCantidadProveedor.Location = new Point(480, 28);
            txtCantidadProveedor.MaxLength = 10;
            txtCantidadProveedor.Name = "txtCantidadProveedor";
            txtCantidadProveedor.Size = new Size(92, 29);
            txtCantidadProveedor.TabIndex = 2;
            txtCantidadProveedor.KeyDown += CopiaryPegar_KeyDown;
            txtCantidadProveedor.KeyPress += SoloNumeros_KeyPress;
            // 
            // cmbTipoEntorno2
            // 
            cmbTipoEntorno2.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoEntorno2.FormattingEnabled = true;
            cmbTipoEntorno2.Location = new Point(724, 68);
            cmbTipoEntorno2.Name = "cmbTipoEntorno2";
            cmbTipoEntorno2.Size = new Size(169, 32);
            cmbTipoEntorno2.TabIndex = 6;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label8.ForeColor = Color.White;
            label8.Location = new Point(16, 106);
            label8.Name = "label8";
            label8.Size = new Size(107, 24);
            label8.TabIndex = 15;
            label8.Text = "Proveedor";
            // 
            // dtpFechaIngresoAlimento
            // 
            dtpFechaIngresoAlimento.Format = DateTimePickerFormat.Short;
            dtpFechaIngresoAlimento.Location = new Point(480, 68);
            dtpFechaIngresoAlimento.Margin = new Padding(3, 2, 3, 2);
            dtpFechaIngresoAlimento.Name = "dtpFechaIngresoAlimento";
            dtpFechaIngresoAlimento.Size = new Size(142, 29);
            dtpFechaIngresoAlimento.TabIndex = 5;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label9.ForeColor = Color.White;
            label9.Location = new Point(376, 33);
            label9.Name = "label9";
            label9.Size = new Size(92, 24);
            label9.TabIndex = 20;
            label9.Text = "Cantidad";
            // 
            // txtNombreAlimentoProveedor
            // 
            txtNombreAlimentoProveedor.Location = new Point(135, 28);
            txtNombreAlimentoProveedor.MaxLength = 40;
            txtNombreAlimentoProveedor.Name = "txtNombreAlimentoProveedor";
            txtNombreAlimentoProveedor.Size = new Size(223, 29);
            txtNombreAlimentoProveedor.TabIndex = 1;
            txtNombreAlimentoProveedor.KeyDown += CopiaryPegar_KeyDown;
            txtNombreAlimentoProveedor.KeyPress += SoloTextoNumeroEspacio_KeyPress;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label10.ForeColor = Color.White;
            label10.Location = new Point(37, 33);
            label10.Name = "label10";
            label10.Size = new Size(85, 24);
            label10.TabIndex = 21;
            label10.Text = "Nombre";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label11.ForeColor = Color.White;
            label11.Location = new Point(622, 75);
            label11.Name = "label11";
            label11.Size = new Size(90, 24);
            label11.TabIndex = 44;
            label11.Text = "Entorno ";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label12.ForeColor = Color.White;
            label12.Location = new Point(398, 72);
            label12.Name = "label12";
            label12.Size = new Size(69, 24);
            label12.TabIndex = 34;
            label12.Text = "Fecha";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label13.ForeColor = Color.White;
            label13.Location = new Point(51, 68);
            label13.Name = "label13";
            label13.Size = new Size(70, 24);
            label13.TabIndex = 39;
            label13.Text = "Precio";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // Inventario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(141, 181, 146);
            ClientSize = new Size(984, 661);
            Controls.Add(groupBox2);
            Name = "Inventario";
            Text = "Inventario";
            Load += Inventario_Load;
            groupBox2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtgArticulos).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            tabPage2.ResumeLayout(false);
            panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtgAlimentos).EndInit();
            panel4.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel7.ResumeLayout(false);
            gbEnviarPolloIndustria.ResumeLayout(false);
            gbEnviarPolloIndustria.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox2;
        private Tienda.RJButton btnAgregar;
        private TextBox txtResponsableCargo;
        private Tienda.RJButton btnLimpiar;
        private Label lblID;
        private Label lblEntorno;
        private TextBox txtNombreProducto;
        private Label label7;
        private Label label2;
        private TextBox txtCantidad;
        private Label label1;
        private TextBox txtPrecio;
        private Label label3;
        private TextBox txtFiltrarNombre;
        private Label label4;
        private DataGridView dtgArticulos;
        private DateTimePicker dtpFechaIngreso;
        private ComboBox cmbEntornoFormativo;
        private GroupBox gbEnviarPolloIndustria;
        private Tienda.RJButton btnModificarArticulo;
        private Label label6;
        private ComboBox cmbKgUnidad;
        private ErrorProvider errorProvider1;
        private GroupBox groupBox5;
        private Tienda.RJButton btnLimpiarAlimentos;
        private Tienda.RJButton btnAgregarAlimentos;
        private Label label5;
        private ComboBox cmbMedidaProveedor;
        private TextBox txtPrecioProveedor;
        private TextBox txtCantidadProveedor;
        private ComboBox cmbTipoEntorno2;
        private Label label8;
        private DateTimePicker dtpFechaIngresoAlimento;
        private Label label9;
        private TextBox txtNombreAlimentoProveedor;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private ComboBox cmbProveedores;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private Tienda.RJButton btnImprimir;
        private TabPage tabPage2;
        private Tienda.RJButton btnImprimirAlimentos;
        private DataGridView dtgAlimentos;
        private Tienda.RJButton btnModificarAlimentos;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Panel panel8;
        private Panel panel7;
    }
}
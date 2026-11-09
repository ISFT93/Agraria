namespace Agraria.Formularios
{
    partial class AbmCiclos
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
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            btnCancelar = new Button();
            btnSiguente = new Button();
            label9 = new Label();
            label8 = new Label();
            label6 = new Label();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            cmbModoInicio = new ComboBox();
            txtCreadoPor = new TextBox();
            txtDescripcion = new TextBox();
            txtNombreCicloModelo = new TextBox();
            tabControl = new TabControl();
            tabPageCicloModelo = new TabPage();
            dtpFechaCreacion = new DateTimePicker();
            mskDuracionEstimada = new MaskedTextBox();
            chkActivo = new CheckBox();
            tabPageActividadesCicloModelo = new TabPage();
            panel2 = new Panel();
            dtgvActividadesCicloModelo = new DataGridView();
            panel3 = new Panel();
            btnAnterior = new Button();
            panel1 = new Panel();
            btnAgregar = new Button();
            tabPageActividadesElementos = new TabPage();
            panel6 = new Panel();
            dtgvActividadesElementos = new DataGridView();
            panel5 = new Panel();
            btnGuardar = new Button();
            btnAnterior1 = new Button();
            panel4 = new Panel();
            btnAgregarElemento = new Button();
            tabControl.SuspendLayout();
            tabPageCicloModelo.SuspendLayout();
            tabPageActividadesCicloModelo.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgvActividadesCicloModelo).BeginInit();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            tabPageActividadesElementos.SuspendLayout();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgvActividadesElementos).BeginInit();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(1109, 681);
            btnCancelar.Margin = new Padding(4, 5, 4, 5);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(109, 49);
            btnCancelar.TabIndex = 9;
            btnCancelar.Text = "&Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnSiguente
            // 
            btnSiguente.Location = new Point(1109, 624);
            btnSiguente.Margin = new Padding(4, 5, 4, 5);
            btnSiguente.Name = "btnSiguente";
            btnSiguente.Size = new Size(109, 49);
            btnSiguente.TabIndex = 8;
            btnSiguente.Text = "&Siguiente";
            btnSiguente.UseVisualStyleBackColor = true;
            btnSiguente.Click += btnSiguiente_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label9.ForeColor = Color.White;
            label9.Location = new Point(193, 593);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(173, 33);
            label9.TabIndex = 23;
            label9.Text = "Creado Por";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label8.ForeColor = Color.White;
            label8.Location = new Point(0, 484);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(278, 33);
            label8.TabIndex = 22;
            label8.Text = "Fecha de Creacion";
            label8.Click += label8_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label6.ForeColor = Color.White;
            label6.Location = new Point(707, 485);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(175, 33);
            label6.TabIndex = 20;
            label6.Text = "Modo Inicio";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(290, 484);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(393, 33);
            label4.TabIndex = 18;
            label4.Text = "Duración Estimada (Horas)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(9, 114);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(180, 33);
            label3.TabIndex = 17;
            label3.Text = "Descripción";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(11, 11);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(125, 33);
            label1.TabIndex = 16;
            label1.Text = "Nombre";
            // 
            // cmbModoInicio
            // 
            cmbModoInicio.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbModoInicio.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            cmbModoInicio.FormattingEnabled = true;
            cmbModoInicio.Location = new Point(707, 529);
            cmbModoInicio.Margin = new Padding(1, 4, 1, 4);
            cmbModoInicio.Name = "cmbModoInicio";
            cmbModoInicio.Size = new Size(222, 41);
            cmbModoInicio.TabIndex = 3;
            // 
            // txtCreadoPor
            // 
            txtCreadoPor.BorderStyle = BorderStyle.FixedSingle;
            txtCreadoPor.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtCreadoPor.Location = new Point(193, 637);
            txtCreadoPor.Margin = new Padding(1, 4, 1, 4);
            txtCreadoPor.MaxLength = 40;
            txtCreadoPor.Name = "txtCreadoPor";
            txtCreadoPor.Size = new Size(263, 40);
            txtCreadoPor.TabIndex = 6;
            // 
            // txtDescripcion
            // 
            txtDescripcion.BorderStyle = BorderStyle.FixedSingle;
            txtDescripcion.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtDescripcion.Location = new Point(11, 154);
            txtDescripcion.Margin = new Padding(1, 4, 1, 4);
            txtDescripcion.MaxLength = 0;
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(1202, 311);
            txtDescripcion.TabIndex = 7;
            // 
            // txtNombreCicloModelo
            // 
            txtNombreCicloModelo.BorderStyle = BorderStyle.FixedSingle;
            txtNombreCicloModelo.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtNombreCicloModelo.Location = new Point(11, 51);
            txtNombreCicloModelo.Margin = new Padding(1, 4, 1, 4);
            txtNombreCicloModelo.MaxLength = 40;
            txtNombreCicloModelo.Name = "txtNombreCicloModelo";
            txtNombreCicloModelo.Size = new Size(1202, 40);
            txtNombreCicloModelo.TabIndex = 1;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPageCicloModelo);
            tabControl.Controls.Add(tabPageActividadesCicloModelo);
            tabControl.Controls.Add(tabPageActividadesElementos);
            tabControl.Font = new Font("Segoe UI", 9F);
            tabControl.Location = new Point(9, 111);
            tabControl.Margin = new Padding(4, 5, 4, 5);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1266, 789);
            tabControl.TabIndex = 29;
            // 
            // tabPageCicloModelo
            // 
            tabPageCicloModelo.BackColor = Color.FromArgb(141, 181, 146);
            tabPageCicloModelo.Controls.Add(dtpFechaCreacion);
            tabPageCicloModelo.Controls.Add(mskDuracionEstimada);
            tabPageCicloModelo.Controls.Add(chkActivo);
            tabPageCicloModelo.Controls.Add(txtNombreCicloModelo);
            tabPageCicloModelo.Controls.Add(btnCancelar);
            tabPageCicloModelo.Controls.Add(btnSiguente);
            tabPageCicloModelo.Controls.Add(label1);
            tabPageCicloModelo.Controls.Add(label3);
            tabPageCicloModelo.Controls.Add(label9);
            tabPageCicloModelo.Controls.Add(label4);
            tabPageCicloModelo.Controls.Add(label8);
            tabPageCicloModelo.Controls.Add(txtCreadoPor);
            tabPageCicloModelo.Controls.Add(txtDescripcion);
            tabPageCicloModelo.Controls.Add(label6);
            tabPageCicloModelo.Controls.Add(cmbModoInicio);
            tabPageCicloModelo.Location = new Point(4, 34);
            tabPageCicloModelo.Margin = new Padding(4, 5, 4, 5);
            tabPageCicloModelo.Name = "tabPageCicloModelo";
            tabPageCicloModelo.Padding = new Padding(4, 5, 4, 5);
            tabPageCicloModelo.Size = new Size(1258, 751);
            tabPageCicloModelo.TabIndex = 0;
            tabPageCicloModelo.Text = "Ciclo Modelo";
            // 
            // dtpFechaCreacion
            // 
            dtpFechaCreacion.CalendarFont = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            dtpFechaCreacion.CustomFormat = "dd/MM/yyyy";
            dtpFechaCreacion.Format = DateTimePickerFormat.Short;
            dtpFechaCreacion.Location = new Point(4, 539);
            dtpFechaCreacion.Margin = new Padding(4);
            dtpFechaCreacion.Name = "dtpFechaCreacion";
            dtpFechaCreacion.Size = new Size(273, 31);
            dtpFechaCreacion.TabIndex = 27;
            // 
            // mskDuracionEstimada
            // 
            mskDuracionEstimada.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            mskDuracionEstimada.Location = new Point(301, 534);
            mskDuracionEstimada.Margin = new Padding(4);
            mskDuracionEstimada.Mask = "00000";
            mskDuracionEstimada.Name = "mskDuracionEstimada";
            mskDuracionEstimada.Size = new Size(102, 40);
            mskDuracionEstimada.TabIndex = 26;
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.Checked = true;
            chkActivo.CheckState = CheckState.Checked;
            chkActivo.Location = new Point(25, 644);
            chkActivo.Margin = new Padding(4);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(88, 29);
            chkActivo.TabIndex = 24;
            chkActivo.Text = "Activo";
            chkActivo.UseVisualStyleBackColor = true;
            // 
            // tabPageActividadesCicloModelo
            // 
            tabPageActividadesCicloModelo.BackColor = Color.FromArgb(141, 181, 146);
            tabPageActividadesCicloModelo.Controls.Add(panel2);
            tabPageActividadesCicloModelo.Controls.Add(panel3);
            tabPageActividadesCicloModelo.Controls.Add(panel1);
            tabPageActividadesCicloModelo.Location = new Point(4, 34);
            tabPageActividadesCicloModelo.Margin = new Padding(4, 5, 4, 5);
            tabPageActividadesCicloModelo.Name = "tabPageActividadesCicloModelo";
            tabPageActividadesCicloModelo.Padding = new Padding(4, 5, 4, 5);
            tabPageActividadesCicloModelo.Size = new Size(1258, 751);
            tabPageActividadesCicloModelo.TabIndex = 1;
            tabPageActividadesCicloModelo.Text = "Actividades Ciclo Modelo";
            // 
            // panel2
            // 
            panel2.Controls.Add(dtgvActividadesCicloModelo);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(4, 60);
            panel2.Margin = new Padding(4, 5, 4, 5);
            panel2.Name = "panel2";
            panel2.Size = new Size(1250, 542);
            panel2.TabIndex = 58;
            // 
            // dtgvActividadesCicloModelo
            // 
            dtgvActividadesCicloModelo.AllowUserToAddRows = false;
            dtgvActividadesCicloModelo.AllowUserToResizeColumns = false;
            dtgvActividadesCicloModelo.AllowUserToResizeRows = false;
            dtgvActividadesCicloModelo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = SystemColors.Control;
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle7.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dtgvActividadesCicloModelo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dtgvActividadesCicloModelo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = SystemColors.Window;
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle8.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            dtgvActividadesCicloModelo.DefaultCellStyle = dataGridViewCellStyle8;
            dtgvActividadesCicloModelo.Dock = DockStyle.Fill;
            dtgvActividadesCicloModelo.Location = new Point(0, 0);
            dtgvActividadesCicloModelo.Margin = new Padding(4, 5, 4, 5);
            dtgvActividadesCicloModelo.Name = "dtgvActividadesCicloModelo";
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = SystemColors.Control;
            dataGridViewCellStyle9.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle9.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
            dtgvActividadesCicloModelo.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dtgvActividadesCicloModelo.RowHeadersWidth = 51;
            dtgvActividadesCicloModelo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgvActividadesCicloModelo.Size = new Size(1250, 542);
            dtgvActividadesCicloModelo.TabIndex = 53;
            dtgvActividadesCicloModelo.CellContentClick += dtgvActividadesCicloModelo_CellContentClick;
            // 
            // panel3
            // 
            panel3.Controls.Add(btnAnterior);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(4, 602);
            panel3.Margin = new Padding(4, 5, 4, 5);
            panel3.Name = "panel3";
            panel3.Size = new Size(1250, 144);
            panel3.TabIndex = 59;
            // 
            // btnAnterior
            // 
            btnAnterior.Location = new Point(1106, 79);
            btnAnterior.Margin = new Padding(4, 5, 4, 5);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(109, 49);
            btnAnterior.TabIndex = 32;
            btnAnterior.Text = "&Anterior";
            btnAnterior.UseVisualStyleBackColor = true;
            btnAnterior.Click += btnAnterior_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnAgregar);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(4, 5);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(1250, 55);
            panel1.TabIndex = 57;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(990, 5);
            btnAgregar.Margin = new Padding(4, 5, 4, 5);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(251, 39);
            btnAgregar.TabIndex = 55;
            btnAgregar.Text = "Agregar Actividad";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // tabPageActividadesElementos
            // 
            tabPageActividadesElementos.BackColor = Color.FromArgb(141, 181, 146);
            tabPageActividadesElementos.Controls.Add(panel6);
            tabPageActividadesElementos.Controls.Add(panel5);
            tabPageActividadesElementos.Controls.Add(panel4);
            tabPageActividadesElementos.Location = new Point(4, 34);
            tabPageActividadesElementos.Margin = new Padding(4, 5, 4, 5);
            tabPageActividadesElementos.Name = "tabPageActividadesElementos";
            tabPageActividadesElementos.Padding = new Padding(4, 5, 4, 5);
            tabPageActividadesElementos.Size = new Size(1258, 751);
            tabPageActividadesElementos.TabIndex = 2;
            tabPageActividadesElementos.Text = "Actividades Elementos";
            // 
            // panel6
            // 
            panel6.Controls.Add(dtgvActividadesElementos);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(4, 61);
            panel6.Margin = new Padding(4, 5, 4, 5);
            panel6.Name = "panel6";
            panel6.Size = new Size(1250, 541);
            panel6.TabIndex = 86;
            // 
            // dtgvActividadesElementos
            // 
            dtgvActividadesElementos.AllowUserToAddRows = false;
            dtgvActividadesElementos.AllowUserToResizeColumns = false;
            dtgvActividadesElementos.AllowUserToResizeRows = false;
            dtgvActividadesElementos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = SystemColors.Control;
            dataGridViewCellStyle10.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle10.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.True;
            dtgvActividadesElementos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            dtgvActividadesElementos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = SystemColors.Window;
            dataGridViewCellStyle11.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle11.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = DataGridViewTriState.False;
            dtgvActividadesElementos.DefaultCellStyle = dataGridViewCellStyle11;
            dtgvActividadesElementos.Dock = DockStyle.Fill;
            dtgvActividadesElementos.Location = new Point(0, 0);
            dtgvActividadesElementos.Margin = new Padding(4, 5, 4, 5);
            dtgvActividadesElementos.Name = "dtgvActividadesElementos";
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = SystemColors.Control;
            dataGridViewCellStyle12.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle12.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = DataGridViewTriState.True;
            dtgvActividadesElementos.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            dtgvActividadesElementos.RowHeadersWidth = 51;
            dtgvActividadesElementos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgvActividadesElementos.Size = new Size(1250, 541);
            dtgvActividadesElementos.TabIndex = 83;
            dtgvActividadesElementos.CellContentClick += dtgvActividadesElementos_CellContentClick;
            // 
            // panel5
            // 
            panel5.Controls.Add(btnGuardar);
            panel5.Controls.Add(btnAnterior1);
            panel5.Dock = DockStyle.Bottom;
            panel5.Location = new Point(4, 602);
            panel5.Margin = new Padding(4, 5, 4, 5);
            panel5.Name = "panel5";
            panel5.Size = new Size(1250, 144);
            panel5.TabIndex = 85;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(1109, 15);
            btnGuardar.Margin = new Padding(4, 5, 4, 5);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(109, 49);
            btnGuardar.TabIndex = 55;
            btnGuardar.Text = "&Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnAnterior1
            // 
            btnAnterior1.Location = new Point(1109, 74);
            btnAnterior1.Margin = new Padding(4, 5, 4, 5);
            btnAnterior1.Name = "btnAnterior1";
            btnAnterior1.Size = new Size(109, 49);
            btnAnterior1.TabIndex = 78;
            btnAnterior1.Text = "&Anterior";
            btnAnterior1.UseVisualStyleBackColor = true;
            btnAnterior1.Click += btnAnterior1_Click;
            // 
            // panel4
            // 
            panel4.Controls.Add(btnAgregarElemento);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(4, 5);
            panel4.Margin = new Padding(4, 5, 4, 5);
            panel4.Name = "panel4";
            panel4.Size = new Size(1250, 56);
            panel4.TabIndex = 84;
            // 
            // btnAgregarElemento
            // 
            btnAgregarElemento.Location = new Point(990, 9);
            btnAgregarElemento.Margin = new Padding(4, 5, 4, 5);
            btnAgregarElemento.Name = "btnAgregarElemento";
            btnAgregarElemento.Size = new Size(251, 39);
            btnAgregarElemento.TabIndex = 79;
            btnAgregarElemento.Text = "Agregar Elemento";
            btnAgregarElemento.UseVisualStyleBackColor = true;
            btnAgregarElemento.Click += btnAgregarElemento_Click;
            // 
            // AbmCiclos
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(141, 181, 146);
            ClientSize = new Size(1279, 900);
            Controls.Add(tabControl);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(1, 4, 1, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AbmCiclos";
            Padding = new Padding(4, 106, 4, 5);
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "AbmCiclos";
            Load += AbmCiclos_Load;
            tabControl.ResumeLayout(false);
            tabPageCicloModelo.ResumeLayout(false);
            tabPageCicloModelo.PerformLayout();
            tabPageActividadesCicloModelo.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtgvActividadesCicloModelo).EndInit();
            panel3.ResumeLayout(false);
            panel1.ResumeLayout(false);
            tabPageActividadesElementos.ResumeLayout(false);
            panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtgvActividadesElementos).EndInit();
            panel5.ResumeLayout(false);
            panel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private ComboBox cmbModoInicio;
        private TextBox txtCreadoPor;
        private TextBox txtDescripcion;
        private TextBox txtNombreCicloModelo;
        private Label label9;
        private Label label8;
        private Label label4;
        private Label label3;
        private Label label1;
        private Label label6;
        private Button btnCancelar;
        private Button btnSiguente;
        private TabControl tabControl;
        private TabPage tabPageCicloModelo;
        private TabPage tabPageActividadesCicloModelo;
        private TabPage tabPageActividadesElementos;
        private Button btnAnterior;
        private ComboBox cmbTipoElemento;
        private Label label20;
        private ComboBox cmbPermiteSustitucion;
        private Label label21;
        private ComboBox cmbObligatorio;
        private Label label22;
        private NumericUpDown numCodigoElemento;
        private Button btnGuardar;
        private Label label23;
        private Label label24;
        private Label label25;
        private TextBox txtObservacion;
        private Label label27;
        private ComboBox cmbTipoUnidad;
        private ComboBox cmbTipoMovimiento;
        private Label label26;
        private ComboBox cmbVendible;
        private NumericUpDown numCantPrevista;
        private Label label19;
        private NumericUpDown numActividadModelo;
        private Label label28;
        private Button btnAnterior1;
        private Button btnAgregar;
        private DataGridView dtgvActividadesCicloModelo;
        private Panel panel2;
        private Panel panel3;
        private Panel panel1;
        private DataGridView dtgvActividadesElementos;
        private Button btnAgregarElemento;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private CheckBox chkActivo;
        private MaskedTextBox mskDuracionEstimada;
        private DateTimePicker dtpFechaCreacion;
    }
}
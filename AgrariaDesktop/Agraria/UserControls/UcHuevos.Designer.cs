namespace Agraria.UserControls
{
    partial class UcHuevos
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcHuevos));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            lblFecha = new Label();
            btnGuardarAves = new Tienda.RJButton();
            lblNumeroAves = new Label();
            txtNumeroAves = new TextBox();
            groupBox3 = new GroupBox();
            txtIngresoAvess = new TextBox();
            dtpFechaIngresoAvess = new DateTimePicker();
            label5 = new Label();
            bnGuardarAvess = new Tienda.RJButton();
            label6 = new Label();
            btnImprimir = new Tienda.RJButton();
            dtgRegistro = new DataGridView();
            groupBox2 = new GroupBox();
            dtpAvesRetiradass = new DateTimePicker();
            label1 = new Label();
            btnRetirarAves = new Tienda.RJButton();
            label4 = new Label();
            txtAvesRetiradas = new TextBox();
            groupBox1 = new GroupBox();
            txtHuevosRecolectadoss = new TextBox();
            dtpRegistrosHuevos = new DateTimePicker();
            label2 = new Label();
            btnGuardarHuevos = new Tienda.RJButton();
            label3 = new Label();
            gbEnviarHuevosIndustria = new GroupBox();
            cmbEnviarIndustria = new ComboBox();
            dtpFechaEgresoHuevos = new DateTimePicker();
            btnEnviarHuevosIndustria = new Tienda.RJButton();
            lblFechaEgreso = new Label();
            lblCantidad = new Label();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgRegistro).BeginInit();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            gbEnviarHuevosIndustria.SuspendLayout();
            SuspendLayout();
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblFecha.ForeColor = Color.White;
            lblFecha.Location = new Point(211, 48);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(75, 24);
            lblFecha.TabIndex = 76;
            lblFecha.Text = "Fecha:";
            // 
            // btnGuardarAves
            // 
            btnGuardarAves.BackColor = Color.White;
            btnGuardarAves.FlatAppearance.BorderSize = 0;
            btnGuardarAves.FlatStyle = FlatStyle.Flat;
            btnGuardarAves.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            btnGuardarAves.ForeColor = Color.FromArgb(56, 124, 31);
            btnGuardarAves.Image = (Image)resources.GetObject("btnGuardarAves.Image");
            btnGuardarAves.ImageAlign = ContentAlignment.MiddleLeft;
            btnGuardarAves.Location = new Point(817, 69);
            btnGuardarAves.Name = "btnGuardarAves";
            btnGuardarAves.Size = new Size(161, 41);
            btnGuardarAves.TabIndex = 77;
            btnGuardarAves.Text = "Guardar";
            btnGuardarAves.UseVisualStyleBackColor = false;
            // 
            // lblNumeroAves
            // 
            lblNumeroAves.AutoSize = true;
            lblNumeroAves.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblNumeroAves.ForeColor = Color.White;
            lblNumeroAves.Location = new Point(113, 81);
            lblNumeroAves.Name = "lblNumeroAves";
            lblNumeroAves.Size = new Size(173, 24);
            lblNumeroAves.TabIndex = 78;
            lblNumeroAves.Text = "Número de Aves:";
            // 
            // txtNumeroAves
            // 
            txtNumeroAves.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtNumeroAves.Location = new Point(292, 81);
            txtNumeroAves.Name = "txtNumeroAves";
            txtNumeroAves.Size = new Size(378, 29);
            txtNumeroAves.TabIndex = 79;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(txtIngresoAvess);
            groupBox3.Controls.Add(dtpFechaIngresoAvess);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(bnGuardarAvess);
            groupBox3.Controls.Add(label6);
            groupBox3.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox3.ForeColor = Color.White;
            groupBox3.Location = new Point(3, 0);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(439, 103);
            groupBox3.TabIndex = 105;
            groupBox3.TabStop = false;
            groupBox3.Text = "Registro de Aves";
            // 
            // txtIngresoAvess
            // 
            txtIngresoAvess.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtIngresoAvess.Location = new Point(121, 63);
            txtIngresoAvess.MaxLength = 7;
            txtIngresoAvess.Name = "txtIngresoAvess";
            txtIngresoAvess.Size = new Size(140, 29);
            txtIngresoAvess.TabIndex = 2;
            txtIngresoAvess.KeyDown += CopiaryPegar_KeyDown;
            txtIngresoAvess.KeyPress += SoloNumeros_KeyPress;
            // 
            // dtpFechaIngresoAvess
            // 
            dtpFechaIngresoAvess.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            dtpFechaIngresoAvess.Format = DateTimePickerFormat.Short;
            dtpFechaIngresoAvess.Location = new Point(121, 28);
            dtpFechaIngresoAvess.Name = "dtpFechaIngresoAvess";
            dtpFechaIngresoAvess.Size = new Size(140, 29);
            dtpFechaIngresoAvess.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(40, 31);
            label5.Name = "label5";
            label5.Size = new Size(75, 24);
            label5.TabIndex = 76;
            label5.Text = "Fecha:";
            // 
            // bnGuardarAvess
            // 
            bnGuardarAvess.BackColor = Color.White;
            bnGuardarAvess.FlatAppearance.BorderSize = 0;
            bnGuardarAvess.FlatStyle = FlatStyle.Flat;
            bnGuardarAvess.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            bnGuardarAvess.ForeColor = Color.FromArgb(56, 124, 31);
            bnGuardarAvess.Image = Properties.Resources.huevo;
            bnGuardarAvess.ImageAlign = ContentAlignment.MiddleLeft;
            bnGuardarAvess.Location = new Point(267, 44);
            bnGuardarAvess.Name = "bnGuardarAvess";
            bnGuardarAvess.Size = new Size(161, 41);
            bnGuardarAvess.TabIndex = 3;
            bnGuardarAvess.Text = "Guardar";
            bnGuardarAvess.UseVisualStyleBackColor = false;
            bnGuardarAvess.Click += bnGuardarAvess_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label6.ForeColor = Color.White;
            label6.Location = new Point(11, 66);
            label6.Name = "label6";
            label6.Size = new Size(104, 24);
            label6.TabIndex = 78;
            label6.Text = "Cantidad :";
            // 
            // btnImprimir
            // 
            btnImprimir.BackColor = Color.White;
            btnImprimir.FlatAppearance.BorderSize = 0;
            btnImprimir.FlatStyle = FlatStyle.Flat;
            btnImprimir.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            btnImprimir.ForeColor = Color.FromArgb(56, 124, 31);
            btnImprimir.Image = Properties.Resources.imprimir;
            btnImprimir.ImageAlign = ContentAlignment.MiddleLeft;
            btnImprimir.Location = new Point(298, 17);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(161, 41);
            btnImprimir.TabIndex = 12;
            btnImprimir.Text = "Imprimir";
            btnImprimir.UseVisualStyleBackColor = false;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // dtgRegistro
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dtgRegistro.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dtgRegistro.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dtgRegistro.DefaultCellStyle = dataGridViewCellStyle2;
            dtgRegistro.Dock = DockStyle.Bottom;
            dtgRegistro.Location = new Point(0, 229);
            dtgRegistro.Name = "dtgRegistro";
            dtgRegistro.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dtgRegistro.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dtgRegistro.Size = new Size(950, 271);
            dtgRegistro.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dtpAvesRetiradass);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(btnRetirarAves);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(txtAvesRetiradas);
            groupBox2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.ForeColor = Color.White;
            groupBox2.Location = new Point(3, 109);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(439, 114);
            groupBox2.TabIndex = 102;
            groupBox2.TabStop = false;
            groupBox2.Text = "Aves retiradas:";
            // 
            // dtpAvesRetiradass
            // 
            dtpAvesRetiradass.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            dtpAvesRetiradass.Format = DateTimePickerFormat.Short;
            dtpAvesRetiradass.Location = new Point(121, 32);
            dtpAvesRetiradass.Name = "dtpAvesRetiradass";
            dtpAvesRetiradass.Size = new Size(140, 29);
            dtpAvesRetiradass.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(40, 36);
            label1.Name = "label1";
            label1.Size = new Size(75, 24);
            label1.TabIndex = 76;
            label1.Text = "Fecha:";
            // 
            // btnRetirarAves
            // 
            btnRetirarAves.BackColor = Color.White;
            btnRetirarAves.FlatAppearance.BorderSize = 0;
            btnRetirarAves.FlatStyle = FlatStyle.Flat;
            btnRetirarAves.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            btnRetirarAves.ForeColor = Color.FromArgb(56, 124, 31);
            btnRetirarAves.Image = (Image)resources.GetObject("btnRetirarAves.Image");
            btnRetirarAves.ImageAlign = ContentAlignment.MiddleLeft;
            btnRetirarAves.Location = new Point(267, 55);
            btnRetirarAves.Name = "btnRetirarAves";
            btnRetirarAves.Size = new Size(161, 41);
            btnRetirarAves.TabIndex = 6;
            btnRetirarAves.Text = "Guardar";
            btnRetirarAves.UseVisualStyleBackColor = false;
            btnRetirarAves.Click += btnRetirarAves_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(21, 63);
            label4.Name = "label4";
            label4.Size = new Size(98, 24);
            label4.TabIndex = 78;
            label4.Text = "Cantidad:";
            // 
            // txtAvesRetiradas
            // 
            txtAvesRetiradas.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtAvesRetiradas.Location = new Point(121, 67);
            txtAvesRetiradas.MaxLength = 7;
            txtAvesRetiradas.Name = "txtAvesRetiradas";
            txtAvesRetiradas.Size = new Size(140, 29);
            txtAvesRetiradas.TabIndex = 5;
            txtAvesRetiradas.KeyDown += CopiaryPegar_KeyDown;
            txtAvesRetiradas.KeyPress += SoloNumeros_KeyPress;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtHuevosRecolectadoss);
            groupBox1.Controls.Add(dtpRegistrosHuevos);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(btnGuardarHuevos);
            groupBox1.Controls.Add(label3);
            groupBox1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(448, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(484, 100);
            groupBox1.TabIndex = 101;
            groupBox1.TabStop = false;
            groupBox1.Text = "Registro de Huevos";
            // 
            // txtHuevosRecolectadoss
            // 
            txtHuevosRecolectadoss.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtHuevosRecolectadoss.Location = new Point(111, 63);
            txtHuevosRecolectadoss.MaxLength = 7;
            txtHuevosRecolectadoss.Name = "txtHuevosRecolectadoss";
            txtHuevosRecolectadoss.Size = new Size(140, 29);
            txtHuevosRecolectadoss.TabIndex = 8;
            txtHuevosRecolectadoss.KeyDown += CopiaryPegar_KeyDown;
            txtHuevosRecolectadoss.KeyPress += SoloNumeros_KeyPress;
            // 
            // dtpRegistrosHuevos
            // 
            dtpRegistrosHuevos.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            dtpRegistrosHuevos.Format = DateTimePickerFormat.Short;
            dtpRegistrosHuevos.Location = new Point(111, 28);
            dtpRegistrosHuevos.Name = "dtpRegistrosHuevos";
            dtpRegistrosHuevos.Size = new Size(140, 29);
            dtpRegistrosHuevos.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(18, 28);
            label2.Name = "label2";
            label2.Size = new Size(75, 24);
            label2.TabIndex = 76;
            label2.Text = "Fecha:";
            // 
            // btnGuardarHuevos
            // 
            btnGuardarHuevos.BackColor = Color.White;
            btnGuardarHuevos.FlatAppearance.BorderSize = 0;
            btnGuardarHuevos.FlatStyle = FlatStyle.Flat;
            btnGuardarHuevos.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            btnGuardarHuevos.ForeColor = Color.FromArgb(56, 124, 31);
            btnGuardarHuevos.Image = (Image)resources.GetObject("btnGuardarHuevos.Image");
            btnGuardarHuevos.ImageAlign = ContentAlignment.MiddleLeft;
            btnGuardarHuevos.Location = new Point(278, 48);
            btnGuardarHuevos.Name = "btnGuardarHuevos";
            btnGuardarHuevos.Size = new Size(161, 41);
            btnGuardarHuevos.TabIndex = 9;
            btnGuardarHuevos.Text = "Guardar";
            btnGuardarHuevos.UseVisualStyleBackColor = false;
            btnGuardarHuevos.Click += btnGuardarHuevos_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(11, 63);
            label3.Name = "label3";
            label3.Size = new Size(93, 24);
            label3.TabIndex = 78;
            label3.Text = "Huevos :";
            // 
            // gbEnviarHuevosIndustria
            // 
            gbEnviarHuevosIndustria.Controls.Add(cmbEnviarIndustria);
            gbEnviarHuevosIndustria.Controls.Add(btnImprimir);
            gbEnviarHuevosIndustria.Controls.Add(dtpFechaEgresoHuevos);
            gbEnviarHuevosIndustria.Controls.Add(btnEnviarHuevosIndustria);
            gbEnviarHuevosIndustria.Controls.Add(lblFechaEgreso);
            gbEnviarHuevosIndustria.Controls.Add(lblCantidad);
            gbEnviarHuevosIndustria.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbEnviarHuevosIndustria.ForeColor = Color.White;
            gbEnviarHuevosIndustria.Location = new Point(448, 109);
            gbEnviarHuevosIndustria.Name = "gbEnviarHuevosIndustria";
            gbEnviarHuevosIndustria.Size = new Size(477, 114);
            gbEnviarHuevosIndustria.TabIndex = 100;
            gbEnviarHuevosIndustria.TabStop = false;
            gbEnviarHuevosIndustria.Text = "Enviar Huevos a Industria";
            // 
            // cmbEnviarIndustria
            // 
            cmbEnviarIndustria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEnviarIndustria.FormattingEnabled = true;
            cmbEnviarIndustria.Location = new Point(108, 62);
            cmbEnviarIndustria.Name = "cmbEnviarIndustria";
            cmbEnviarIndustria.Size = new Size(140, 32);
            cmbEnviarIndustria.TabIndex = 11;
            // 
            // dtpFechaEgresoHuevos
            // 
            dtpFechaEgresoHuevos.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            dtpFechaEgresoHuevos.Format = DateTimePickerFormat.Short;
            dtpFechaEgresoHuevos.Location = new Point(108, 27);
            dtpFechaEgresoHuevos.Name = "dtpFechaEgresoHuevos";
            dtpFechaEgresoHuevos.Size = new Size(140, 29);
            dtpFechaEgresoHuevos.TabIndex = 10;
            // 
            // btnEnviarHuevosIndustria
            // 
            btnEnviarHuevosIndustria.BackColor = Color.White;
            btnEnviarHuevosIndustria.FlatAppearance.BorderSize = 0;
            btnEnviarHuevosIndustria.FlatStyle = FlatStyle.Flat;
            btnEnviarHuevosIndustria.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            btnEnviarHuevosIndustria.ForeColor = Color.FromArgb(56, 124, 31);
            btnEnviarHuevosIndustria.Image = Properties.Resources.fabrica;
            btnEnviarHuevosIndustria.ImageAlign = ContentAlignment.MiddleLeft;
            btnEnviarHuevosIndustria.Location = new Point(298, 64);
            btnEnviarHuevosIndustria.Name = "btnEnviarHuevosIndustria";
            btnEnviarHuevosIndustria.Size = new Size(161, 41);
            btnEnviarHuevosIndustria.TabIndex = 13;
            btnEnviarHuevosIndustria.Text = "Enviar";
            btnEnviarHuevosIndustria.UseVisualStyleBackColor = false;
            btnEnviarHuevosIndustria.Click += btnEnviarHuevosIndustria_Click;
            // 
            // lblFechaEgreso
            // 
            lblFechaEgreso.AutoSize = true;
            lblFechaEgreso.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblFechaEgreso.ForeColor = Color.White;
            lblFechaEgreso.Location = new Point(21, 32);
            lblFechaEgreso.Name = "lblFechaEgreso";
            lblFechaEgreso.Size = new Size(81, 24);
            lblFechaEgreso.TabIndex = 74;
            lblFechaEgreso.Text = "Fecha :";
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblCantidad.ForeColor = Color.White;
            lblCantidad.Location = new Point(6, 67);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(98, 24);
            lblCantidad.TabIndex = 72;
            lblCantidad.Text = "Cantidad:";
            // 
            // UcHuevos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(141, 181, 146);
            Controls.Add(groupBox3);
            Controls.Add(dtgRegistro);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(gbEnviarHuevosIndustria);
            Name = "UcHuevos";
            Size = new Size(950, 500);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgRegistro).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            gbEnviarHuevosIndustria.ResumeLayout(false);
            gbEnviarHuevosIndustria.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbRegistroProduccion;
        private Label lblFecha;
        private Tienda.RJButton btnGuardarAves;
        private DateTimePicker dtpFecha;
        private Label lblNumeroAves;
        private TextBox txtNumeroAves;
        private TextBox txtCantidadHuevosTotal;
        private DateTimePicker dateTimePicker2;
        private TextBox textBox1;
        private DateTimePicker dateTimePicker1;
        private GroupBox groupBox3;
        private TextBox txtIngresoAvess;
        private DateTimePicker dtpFechaIngresoAvess;
        private Label label5;
        private Tienda.RJButton bnGuardarAvess;
        private Label label6;
        private Tienda.RJButton btnImprimir;
        private DataGridView dtgRegistro;
        private GroupBox groupBox2;
        private DateTimePicker dtpAvesRetiradass;
        private Label label1;
        private Tienda.RJButton btnRetirarAves;
        private Label label4;
        private TextBox txtAvesRetiradas;
        private GroupBox groupBox1;
        private TextBox txtHuevosRecolectadoss;
        private DateTimePicker dtpRegistrosHuevos;
        private Label label2;
        private Tienda.RJButton btnGuardarHuevos;
        private Label label3;
        private GroupBox gbEnviarHuevosIndustria;
        private ComboBox cmbEnviarIndustria;
        private DateTimePicker dtpFechaEgresoHuevos;
        private Tienda.RJButton btnEnviarHuevosIndustria;
        private Label lblFechaEgreso;
        private Label lblCantidad;
    }
}

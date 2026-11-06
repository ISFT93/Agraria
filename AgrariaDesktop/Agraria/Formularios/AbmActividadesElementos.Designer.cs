namespace Agraria.Formularios
{
    partial class AbmActividadesElementos
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
            numActividadModelo = new NumericUpDown();
            label28 = new Label();
            label26 = new Label();
            numCantPrevista = new NumericUpDown();
            label19 = new Label();
            cmbTipoElemento = new ComboBox();
            label20 = new Label();
            label21 = new Label();
            label22 = new Label();
            label23 = new Label();
            label24 = new Label();
            label25 = new Label();
            txtObservacion = new TextBox();
            label27 = new Label();
            cmbTipoUnidad = new ComboBox();
            cmbTipoMovimiento = new ComboBox();
            btnAceptar = new Button();
            txtOrdenElemento = new Label();
            cmbElemento = new ComboBox();
            chkObligatorio = new CheckBox();
            chkVendible = new CheckBox();
            chkPermiteSustitucion = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)numActividadModelo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCantPrevista).BeginInit();
            SuspendLayout();
            // 
            // numActividadModelo
            // 
            numActividadModelo.DecimalPlaces = 2;
            numActividadModelo.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            numActividadModelo.Location = new Point(27, 141);
            numActividadModelo.Margin = new Padding(3, 4, 3, 4);
            numActividadModelo.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            numActividadModelo.Name = "numActividadModelo";
            numActividadModelo.Size = new Size(171, 34);
            numActividadModelo.TabIndex = 96;
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label28.ForeColor = Color.White;
            label28.Location = new Point(27, 97);
            label28.Name = "label28";
            label28.Size = new Size(306, 29);
            label28.TabIndex = 97;
            label28.Text = "Código Actividad Modelo";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label26.ForeColor = Color.White;
            label26.Location = new Point(471, 547);
            label26.Name = "label26";
            label26.Size = new Size(117, 29);
            label26.TabIndex = 95;
            label26.Text = "Vendible";
            // 
            // numCantPrevista
            // 
            numCantPrevista.DecimalPlaces = 2;
            numCantPrevista.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            numCantPrevista.Location = new Point(32, 488);
            numCantPrevista.Margin = new Padding(3, 4, 3, 4);
            numCantPrevista.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numCantPrevista.Name = "numCantPrevista";
            numCantPrevista.Size = new Size(191, 34);
            numCantPrevista.TabIndex = 92;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label19.ForeColor = Color.White;
            label19.Location = new Point(27, 448);
            label19.Name = "label19";
            label19.Size = new Size(218, 29);
            label19.TabIndex = 93;
            label19.Text = "Cantidad Prevista";
            // 
            // cmbTipoElemento
            // 
            cmbTipoElemento.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoElemento.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            cmbTipoElemento.FormattingEnabled = true;
            cmbTipoElemento.Location = new Point(31, 224);
            cmbTipoElemento.Margin = new Padding(1, 3, 1, 3);
            cmbTipoElemento.Name = "cmbTipoElemento";
            cmbTipoElemento.Size = new Size(227, 37);
            cmbTipoElemento.TabIndex = 91;
            cmbTipoElemento.SelectedIndexChanged += cmbTipoElemento_SelectedIndexChanged;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label20.ForeColor = Color.White;
            label20.Location = new Point(606, 547);
            label20.Name = "label20";
            label20.Size = new Size(239, 29);
            label20.TabIndex = 90;
            label20.Text = "Permite Sustitución";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label21.ForeColor = Color.White;
            label21.Location = new Point(318, 547);
            label21.Name = "label21";
            label21.Size = new Size(144, 29);
            label21.TabIndex = 88;
            label21.Text = "Obligatorio";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label22.ForeColor = Color.White;
            label22.Location = new Point(31, 545);
            label22.Name = "label22";
            label22.Size = new Size(194, 29);
            label22.TabIndex = 86;
            label22.Text = "Tipo de Unidad";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label23.ForeColor = Color.White;
            label23.Location = new Point(27, 189);
            label23.Name = "label23";
            label23.Size = new Size(185, 29);
            label23.TabIndex = 82;
            label23.Text = "Tipo Elemento";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label24.ForeColor = Color.White;
            label24.Location = new Point(368, 97);
            label24.Name = "label24";
            label24.Size = new Size(160, 29);
            label24.TabIndex = 83;
            label24.Text = "Observación";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label25.ForeColor = Color.White;
            label25.Location = new Point(31, 275);
            label25.Name = "label25";
            label25.Size = new Size(124, 29);
            label25.TabIndex = 84;
            label25.Text = "Elemento";
            // 
            // txtObservacion
            // 
            txtObservacion.BorderStyle = BorderStyle.FixedSingle;
            txtObservacion.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtObservacion.Location = new Point(368, 141);
            txtObservacion.Margin = new Padding(1, 3, 1, 3);
            txtObservacion.MaxLength = 40;
            txtObservacion.Multiline = true;
            txtObservacion.Name = "txtObservacion";
            txtObservacion.Size = new Size(635, 381);
            txtObservacion.TabIndex = 81;
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label27.ForeColor = Color.White;
            label27.Location = new Point(27, 353);
            label27.Name = "label27";
            label27.Size = new Size(245, 29);
            label27.TabIndex = 85;
            label27.Text = "Tipo de Movimiento";
            // 
            // cmbTipoUnidad
            // 
            cmbTipoUnidad.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoUnidad.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            cmbTipoUnidad.FormattingEnabled = true;
            cmbTipoUnidad.Location = new Point(32, 580);
            cmbTipoUnidad.Margin = new Padding(1, 3, 1, 3);
            cmbTipoUnidad.Name = "cmbTipoUnidad";
            cmbTipoUnidad.Size = new Size(167, 37);
            cmbTipoUnidad.TabIndex = 80;
            // 
            // cmbTipoMovimiento
            // 
            cmbTipoMovimiento.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoMovimiento.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            cmbTipoMovimiento.FormattingEnabled = true;
            cmbTipoMovimiento.Location = new Point(32, 388);
            cmbTipoMovimiento.Margin = new Padding(1, 3, 1, 3);
            cmbTipoMovimiento.Name = "cmbTipoMovimiento";
            cmbTipoMovimiento.Size = new Size(227, 37);
            cmbTipoMovimiento.TabIndex = 79;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(947, 601);
            btnAceptar.Margin = new Padding(3, 4, 3, 4);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(87, 31);
            btnAceptar.TabIndex = 98;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // txtOrdenElemento
            // 
            txtOrdenElemento.AutoSize = true;
            txtOrdenElemento.Location = new Point(883, 548);
            txtOrdenElemento.Name = "txtOrdenElemento";
            txtOrdenElemento.Size = new Size(50, 20);
            txtOrdenElemento.TabIndex = 99;
            txtOrdenElemento.Text = "label1";
            txtOrdenElemento.Visible = false;
            // 
            // cmbElemento
            // 
            cmbElemento.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbElemento.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            cmbElemento.FormattingEnabled = true;
            cmbElemento.Location = new Point(27, 308);
            cmbElemento.Margin = new Padding(1, 3, 1, 3);
            cmbElemento.Name = "cmbElemento";
            cmbElemento.Size = new Size(267, 37);
            cmbElemento.TabIndex = 100;
            // 
            // chkObligatorio
            // 
            chkObligatorio.AutoSize = true;
            chkObligatorio.Location = new Point(318, 593);
            chkObligatorio.Name = "chkObligatorio";
            chkObligatorio.Size = new Size(108, 24);
            chkObligatorio.TabIndex = 101;
            chkObligatorio.Text = "Obligatorio";
            chkObligatorio.UseVisualStyleBackColor = true;
            // 
            // chkVendible
            // 
            chkVendible.AutoSize = true;
            chkVendible.Location = new Point(471, 593);
            chkVendible.Name = "chkVendible";
            chkVendible.Size = new Size(89, 24);
            chkVendible.TabIndex = 102;
            chkVendible.Text = "Vendible";
            chkVendible.UseVisualStyleBackColor = true;
            // 
            // chkPermiteSustitucion
            // 
            chkPermiteSustitucion.AutoSize = true;
            chkPermiteSustitucion.Location = new Point(606, 593);
            chkPermiteSustitucion.Name = "chkPermiteSustitucion";
            chkPermiteSustitucion.Size = new Size(157, 24);
            chkPermiteSustitucion.TabIndex = 103;
            chkPermiteSustitucion.Text = "Permite Sustitución";
            chkPermiteSustitucion.UseVisualStyleBackColor = true;
            // 
            // AbmActividadesElementos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(141, 181, 146);
            ClientSize = new Size(1041, 639);
            Controls.Add(chkPermiteSustitucion);
            Controls.Add(chkVendible);
            Controls.Add(chkObligatorio);
            Controls.Add(cmbElemento);
            Controls.Add(txtOrdenElemento);
            Controls.Add(btnAceptar);
            Controls.Add(numActividadModelo);
            Controls.Add(label28);
            Controls.Add(label26);
            Controls.Add(numCantPrevista);
            Controls.Add(label19);
            Controls.Add(cmbTipoElemento);
            Controls.Add(label20);
            Controls.Add(label21);
            Controls.Add(label22);
            Controls.Add(label23);
            Controls.Add(label24);
            Controls.Add(label25);
            Controls.Add(txtObservacion);
            Controls.Add(label27);
            Controls.Add(cmbTipoUnidad);
            Controls.Add(cmbTipoMovimiento);
            Margin = new Padding(3, 4, 3, 4);
            Name = "AbmActividadesElementos";
            Text = "Actividades Elementos";
            Load += AbmActividadesElementos_Load;
            ((System.ComponentModel.ISupportInitialize)numActividadModelo).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCantPrevista).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown numActividadModelo;
        private Label label28;
        private Label label26;
        private NumericUpDown numCantPrevista;
        private Label label19;
        private ComboBox cmbTipoElemento;
        private Label label20;
        private Label label21;
        private Label label22;
        private Label label23;
        private Label label24;
        private Label label25;
        private TextBox txtObservacion;
        private Label label27;
        private ComboBox cmbTipoUnidad;
        private ComboBox cmbTipoMovimiento;
        private Button btnAceptar;
        private Label txtOrdenElemento;
        private ComboBox cmbElemento;
        private CheckBox chkObligatorio;
        private CheckBox chkVendible;
        private CheckBox chkPermiteSustitucion;
    }
}
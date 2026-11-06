namespace Agraria.Formularios
{
    partial class AbmActividadesCicloModelo
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
            btnAceptarActividad = new Button();
            label12 = new Label();
            txtOrden = new TextBox();
            label10 = new Label();
            txtCondicionAvance = new TextBox();
            label18 = new Label();
            label17 = new Label();
            label16 = new Label();
            label15 = new Label();
            numCicloModelo = new NumericUpDown();
            txtNombre = new TextBox();
            label2 = new Label();
            label5 = new Label();
            label11 = new Label();
            label13 = new Label();
            txtDescripcionActividad = new TextBox();
            label14 = new Label();
            cmbTipoActividad = new ComboBox();
            chkActivo = new CheckBox();
            chkDemora = new CheckBox();
            chkRequiereAprobacion = new CheckBox();
            chkPermiteEjecucionParcial = new CheckBox();
            mskDuracionEstimada = new MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)numCicloModelo).BeginInit();
            SuspendLayout();
            // 
            // btnAceptarActividad
            // 
            btnAceptarActividad.Location = new Point(947, 619);
            btnAceptarActividad.Margin = new Padding(3, 4, 3, 4);
            btnAceptarActividad.Name = "btnAceptarActividad";
            btnAceptarActividad.Size = new Size(86, 31);
            btnAceptarActividad.TabIndex = 98;
            btnAceptarActividad.Text = "Aceptar";
            btnAceptarActividad.UseVisualStyleBackColor = true;
            btnAceptarActividad.Click += btnAceptarActividad_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label12.ForeColor = Color.White;
            label12.Location = new Point(163, 565);
            label12.Name = "label12";
            label12.Size = new Size(261, 29);
            label12.TabIndex = 97;
            label12.Text = "Requiere Aprobacion";
            // 
            // txtOrden
            // 
            txtOrden.BorderStyle = BorderStyle.FixedSingle;
            txtOrden.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtOrden.Location = new Point(943, 132);
            txtOrden.Margin = new Padding(2, 3, 2, 3);
            txtOrden.MaxLength = 40;
            txtOrden.Name = "txtOrden";
            txtOrden.Size = new Size(90, 34);
            txtOrden.TabIndex = 95;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label10.ForeColor = Color.White;
            label10.Location = new Point(46, 329);
            label10.Name = "label10";
            label10.Size = new Size(259, 29);
            label10.TabIndex = 94;
            label10.Text = "Condición de Avance";
            // 
            // txtCondicionAvance
            // 
            txtCondicionAvance.BorderStyle = BorderStyle.FixedSingle;
            txtCondicionAvance.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtCondicionAvance.Location = new Point(46, 361);
            txtCondicionAvance.Margin = new Padding(2, 3, 2, 3);
            txtCondicionAvance.MaxLength = 0;
            txtCondicionAvance.Multiline = true;
            txtCondicionAvance.Name = "txtCondicionAvance";
            txtCondicionAvance.Size = new Size(944, 95);
            txtCondicionAvance.TabIndex = 93;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label18.ForeColor = Color.White;
            label18.Location = new Point(799, 565);
            label18.Name = "label18";
            label18.Size = new Size(83, 29);
            label18.TabIndex = 92;
            label18.Text = "Activo";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label17.ForeColor = Color.White;
            label17.Location = new Point(439, 565);
            label17.Name = "label17";
            label17.Size = new Size(314, 29);
            label17.TabIndex = 90;
            label17.Text = "Permite Ejecución Parcial";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label16.ForeColor = Color.White;
            label16.Location = new Point(41, 565);
            label16.Name = "label16";
            label16.Size = new Size(105, 29);
            label16.TabIndex = 88;
            label16.Text = "Demora";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label15.ForeColor = Color.White;
            label15.Location = new Point(264, 476);
            label15.Name = "label15";
            label15.Size = new Size(232, 29);
            label15.TabIndex = 86;
            label15.Text = "Duración Estimada";
            // 
            // numCicloModelo
            // 
            numCicloModelo.DecimalPlaces = 2;
            numCicloModelo.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            numCicloModelo.Location = new Point(557, 516);
            numCicloModelo.Margin = new Padding(3, 4, 3, 4);
            numCicloModelo.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            numCicloModelo.Name = "numCicloModelo";
            numCicloModelo.Size = new Size(149, 34);
            numCicloModelo.TabIndex = 77;
            // 
            // txtNombre
            // 
            txtNombre.BorderStyle = BorderStyle.FixedSingle;
            txtNombre.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtNombre.Location = new Point(46, 135);
            txtNombre.Margin = new Padding(2, 3, 2, 3);
            txtNombre.MaxLength = 150;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(836, 34);
            txtNombre.TabIndex = 76;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(46, 100);
            label2.Name = "label2";
            label2.Size = new Size(107, 29);
            label2.TabIndex = 80;
            label2.Text = "Nombre";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(46, 185);
            label5.Name = "label5";
            label5.Size = new Size(152, 29);
            label5.TabIndex = 81;
            label5.Text = "Descripción";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label11.ForeColor = Color.White;
            label11.Location = new Point(552, 476);
            label11.Name = "label11";
            label11.Size = new Size(168, 29);
            label11.TabIndex = 82;
            label11.Text = "Ciclo Modelo";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label13.ForeColor = Color.White;
            label13.Location = new Point(41, 476);
            label13.Name = "label13";
            label13.Size = new Size(217, 29);
            label13.TabIndex = 84;
            label13.Text = "Tipo de Actividad";
            // 
            // txtDescripcionActividad
            // 
            txtDescripcionActividad.BorderStyle = BorderStyle.FixedSingle;
            txtDescripcionActividad.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtDescripcionActividad.Location = new Point(46, 217);
            txtDescripcionActividad.Margin = new Padding(2, 3, 2, 3);
            txtDescripcionActividad.MaxLength = 0;
            txtDescripcionActividad.Multiline = true;
            txtDescripcionActividad.Name = "txtDescripcionActividad";
            txtDescripcionActividad.Size = new Size(939, 91);
            txtDescripcionActividad.TabIndex = 79;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label14.ForeColor = Color.White;
            label14.Location = new Point(943, 97);
            label14.Name = "label14";
            label14.Size = new Size(86, 29);
            label14.TabIndex = 83;
            label14.Text = "Orden";
            // 
            // cmbTipoActividad
            // 
            cmbTipoActividad.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoActividad.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            cmbTipoActividad.FormattingEnabled = true;
            cmbTipoActividad.Location = new Point(41, 515);
            cmbTipoActividad.Margin = new Padding(2, 3, 2, 3);
            cmbTipoActividad.Name = "cmbTipoActividad";
            cmbTipoActividad.Size = new Size(193, 37);
            cmbTipoActividad.TabIndex = 78;
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.Location = new Point(799, 607);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(73, 24);
            chkActivo.TabIndex = 99;
            chkActivo.Text = "Activo";
            chkActivo.UseVisualStyleBackColor = true;
            // 
            // chkDemora
            // 
            chkDemora.AutoSize = true;
            chkDemora.Location = new Point(41, 607);
            chkDemora.Name = "chkDemora";
            chkDemora.Size = new Size(85, 24);
            chkDemora.TabIndex = 100;
            chkDemora.Text = "Demora";
            chkDemora.UseVisualStyleBackColor = true;
            // 
            // chkRequiereAprobacion
            // 
            chkRequiereAprobacion.AutoSize = true;
            chkRequiereAprobacion.Location = new Point(163, 609);
            chkRequiereAprobacion.Name = "chkRequiereAprobacion";
            chkRequiereAprobacion.Size = new Size(109, 24);
            chkRequiereAprobacion.TabIndex = 101;
            chkRequiereAprobacion.Text = "Aprobacion";
            chkRequiereAprobacion.UseVisualStyleBackColor = true;
            // 
            // chkPermiteEjecucionParcial
            // 
            chkPermiteEjecucionParcial.AutoSize = true;
            chkPermiteEjecucionParcial.Location = new Point(439, 609);
            chkPermiteEjecucionParcial.Name = "chkPermiteEjecucionParcial";
            chkPermiteEjecucionParcial.Size = new Size(141, 24);
            chkPermiteEjecucionParcial.TabIndex = 102;
            chkPermiteEjecucionParcial.Text = "Ejecucion Parcial";
            chkPermiteEjecucionParcial.UseVisualStyleBackColor = true;
            // 
            // mskDuracionEstimada
            // 
            mskDuracionEstimada.Location = new Point(273, 521);
            mskDuracionEstimada.Mask = "00000";
            mskDuracionEstimada.Name = "mskDuracionEstimada";
            mskDuracionEstimada.Size = new Size(101, 27);
            mskDuracionEstimada.TabIndex = 103;
            // 
            // AbmActividadesCicloModelo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(141, 181, 146);
            ClientSize = new Size(1040, 657);
            Controls.Add(mskDuracionEstimada);
            Controls.Add(chkPermiteEjecucionParcial);
            Controls.Add(chkRequiereAprobacion);
            Controls.Add(chkDemora);
            Controls.Add(chkActivo);
            Controls.Add(btnAceptarActividad);
            Controls.Add(label12);
            Controls.Add(txtOrden);
            Controls.Add(label10);
            Controls.Add(txtCondicionAvance);
            Controls.Add(label18);
            Controls.Add(label17);
            Controls.Add(label16);
            Controls.Add(label15);
            Controls.Add(numCicloModelo);
            Controls.Add(txtNombre);
            Controls.Add(label2);
            Controls.Add(label5);
            Controls.Add(label11);
            Controls.Add(label13);
            Controls.Add(txtDescripcionActividad);
            Controls.Add(label14);
            Controls.Add(cmbTipoActividad);
            Margin = new Padding(3, 4, 3, 4);
            Name = "AbmActividadesCicloModelo";
            Padding = new Padding(3, 85, 3, 4);
            Text = "AbmActividadesCicloModelo";
            Load += AbmActividadesCicloModelo_Load;
            ((System.ComponentModel.ISupportInitialize)numCicloModelo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAceptarActividad;
        private Label label12;
        private TextBox txtOrden;
        private Label label10;
        private TextBox txtCondicionAvance;
        private Label label18;
        private Label label17;
        private Label label16;
        private Label label15;
        private NumericUpDown numCicloModelo;
        private TextBox txtNombre;
        private Label label2;
        private Label label5;
        private Label label11;
        private Label label13;
        private TextBox txtDescripcionActividad;
        private Label label14;
        private ComboBox cmbTipoActividad;
        private CheckBox chkActivo;
        private CheckBox chkDemora;
        private CheckBox chkRequiereAprobacion;
        private CheckBox chkPermiteEjecucionParcial;
        private MaskedTextBox mskDuracionEstimada;
    }
}
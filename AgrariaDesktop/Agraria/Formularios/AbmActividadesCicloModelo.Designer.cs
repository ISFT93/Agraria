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
            cmbAprobacion1 = new ComboBox();
            txtOrden = new TextBox();
            label10 = new Label();
            txtCondicionAvance = new TextBox();
            label18 = new Label();
            cmbActiva = new ComboBox();
            label17 = new Label();
            cmbEjecucion = new ComboBox();
            label16 = new Label();
            cmbDemora = new ComboBox();
            numDuracion = new NumericUpDown();
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
            ((System.ComponentModel.ISupportInitialize)numDuracion).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCicloModelo).BeginInit();
            SuspendLayout();
            // 
            // btnAceptarActividad
            // 
            btnAceptarActividad.Location = new Point(930, 586);
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
            label12.Location = new Point(146, 534);
            label12.Name = "label12";
            label12.Size = new Size(261, 29);
            label12.TabIndex = 97;
            label12.Text = "Requiere Aprobacion";
            // 
            // cmbAprobacion1
            // 
            cmbAprobacion1.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAprobacion1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            cmbAprobacion1.FormattingEnabled = true;
            cmbAprobacion1.Location = new Point(146, 576);
            cmbAprobacion1.Margin = new Padding(2, 3, 2, 3);
            cmbAprobacion1.Name = "cmbAprobacion1";
            cmbAprobacion1.Size = new Size(101, 37);
            cmbAprobacion1.TabIndex = 96;
            // 
            // txtOrden
            // 
            txtOrden.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtOrden.Location = new Point(926, 100);
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
            label10.Location = new Point(29, 297);
            label10.Name = "label10";
            label10.Size = new Size(259, 29);
            label10.TabIndex = 94;
            label10.Text = "Condición de Avance";
            // 
            // txtCondicionAvance
            // 
            txtCondicionAvance.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtCondicionAvance.Location = new Point(29, 329);
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
            label18.Location = new Point(782, 534);
            label18.Name = "label18";
            label18.Size = new Size(83, 29);
            label18.TabIndex = 92;
            label18.Text = "Activo";
            // 
            // cmbActiva
            // 
            cmbActiva.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbActiva.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            cmbActiva.FormattingEnabled = true;
            cmbActiva.Location = new Point(782, 569);
            cmbActiva.Margin = new Padding(2, 3, 2, 3);
            cmbActiva.Name = "cmbActiva";
            cmbActiva.Size = new Size(83, 37);
            cmbActiva.TabIndex = 91;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label17.ForeColor = Color.White;
            label17.Location = new Point(422, 534);
            label17.Name = "label17";
            label17.Size = new Size(314, 29);
            label17.TabIndex = 90;
            label17.Text = "Permite Ejecución Parcial";
            // 
            // cmbEjecucion
            // 
            cmbEjecucion.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEjecucion.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            cmbEjecucion.FormattingEnabled = true;
            cmbEjecucion.Location = new Point(422, 577);
            cmbEjecucion.Margin = new Padding(2, 3, 2, 3);
            cmbEjecucion.Name = "cmbEjecucion";
            cmbEjecucion.Size = new Size(101, 37);
            cmbEjecucion.TabIndex = 89;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label16.ForeColor = Color.White;
            label16.Location = new Point(24, 534);
            label16.Name = "label16";
            label16.Size = new Size(105, 29);
            label16.TabIndex = 88;
            label16.Text = "Demora";
            // 
            // cmbDemora
            // 
            cmbDemora.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDemora.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            cmbDemora.FormattingEnabled = true;
            cmbDemora.Location = new Point(24, 575);
            cmbDemora.Margin = new Padding(2, 3, 2, 3);
            cmbDemora.Name = "cmbDemora";
            cmbDemora.Size = new Size(94, 37);
            cmbDemora.TabIndex = 87;
            // 
            // numDuracion
            // 
            numDuracion.DecimalPlaces = 2;
            numDuracion.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            numDuracion.Location = new Point(252, 484);
            numDuracion.Margin = new Padding(3, 4, 3, 4);
            numDuracion.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numDuracion.Name = "numDuracion";
            numDuracion.Size = new Size(131, 34);
            numDuracion.TabIndex = 85;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label15.ForeColor = Color.White;
            label15.Location = new Point(247, 444);
            label15.Name = "label15";
            label15.Size = new Size(232, 29);
            label15.TabIndex = 86;
            label15.Text = "Duración Estimada";
            // 
            // numCicloModelo
            // 
            numCicloModelo.DecimalPlaces = 2;
            numCicloModelo.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            numCicloModelo.Location = new Point(540, 484);
            numCicloModelo.Margin = new Padding(3, 4, 3, 4);
            numCicloModelo.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            numCicloModelo.Name = "numCicloModelo";
            numCicloModelo.Size = new Size(149, 34);
            numCicloModelo.TabIndex = 77;
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtNombre.Location = new Point(29, 103);
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
            label2.Location = new Point(29, 68);
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
            label5.Location = new Point(29, 153);
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
            label11.Location = new Point(535, 444);
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
            label13.Location = new Point(24, 444);
            label13.Name = "label13";
            label13.Size = new Size(217, 29);
            label13.TabIndex = 84;
            label13.Text = "Tipo de Actividad";
            // 
            // txtDescripcionActividad
            // 
            txtDescripcionActividad.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtDescripcionActividad.Location = new Point(29, 185);
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
            label14.Location = new Point(930, 68);
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
            cmbTipoActividad.Location = new Point(24, 483);
            cmbTipoActividad.Margin = new Padding(2, 3, 2, 3);
            cmbTipoActividad.Name = "cmbTipoActividad";
            cmbTipoActividad.Size = new Size(193, 37);
            cmbTipoActividad.TabIndex = 78;
            // 
            // AbmActividadesCicloModelo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(141, 181, 146);
            ClientSize = new Size(1025, 629);
            Controls.Add(btnAceptarActividad);
            Controls.Add(label12);
            Controls.Add(cmbAprobacion1);
            Controls.Add(txtOrden);
            Controls.Add(label10);
            Controls.Add(txtCondicionAvance);
            Controls.Add(label18);
            Controls.Add(cmbActiva);
            Controls.Add(label17);
            Controls.Add(cmbEjecucion);
            Controls.Add(label16);
            Controls.Add(cmbDemora);
            Controls.Add(numDuracion);
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
            ((System.ComponentModel.ISupportInitialize)numDuracion).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCicloModelo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAceptarActividad;
        private Label label12;
        private ComboBox cmbAprobacion1;
        private TextBox txtOrden;
        private Label label10;
        private TextBox txtCondicionAvance;
        private Label label18;
        private ComboBox cmbActiva;
        private Label label17;
        private ComboBox cmbEjecucion;
        private Label label16;
        private ComboBox cmbDemora;
        private NumericUpDown numDuracion;
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
    }
}
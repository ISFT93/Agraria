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
            txtOrden = new TextBox();
            label10 = new Label();
            txtCondicionAvance = new TextBox();
            label15 = new Label();
            txtNombre = new TextBox();
            label2 = new Label();
            label5 = new Label();
            label13 = new Label();
            txtDescripcionActividad = new TextBox();
            label14 = new Label();
            cmbTipoActividad = new ComboBox();
            chkActivo = new CheckBox();
            chkDemora = new CheckBox();
            chkRequiereAprobacion = new CheckBox();
            chkPermiteEjecucionParcial = new CheckBox();
            mskDuracionEstimada = new MaskedTextBox();
            SuspendLayout();
            // 
            // btnAceptarActividad
            // 
            btnAceptarActividad.Location = new Point(1184, 774);
            btnAceptarActividad.Margin = new Padding(4, 5, 4, 5);
            btnAceptarActividad.Name = "btnAceptarActividad";
            btnAceptarActividad.Size = new Size(108, 39);
            btnAceptarActividad.TabIndex = 98;
            btnAceptarActividad.Text = "Aceptar";
            btnAceptarActividad.UseVisualStyleBackColor = true;
            btnAceptarActividad.Click += btnAceptarActividad_Click;
            // 
            // txtOrden
            // 
            txtOrden.BorderStyle = BorderStyle.FixedSingle;
            txtOrden.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtOrden.Location = new Point(1179, 165);
            txtOrden.Margin = new Padding(2, 4, 2, 4);
            txtOrden.MaxLength = 40;
            txtOrden.Name = "txtOrden";
            txtOrden.Size = new Size(112, 40);
            txtOrden.TabIndex = 95;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label10.ForeColor = Color.White;
            label10.Location = new Point(58, 411);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(309, 33);
            label10.TabIndex = 94;
            label10.Text = "Condición de Avance";
            // 
            // txtCondicionAvance
            // 
            txtCondicionAvance.BorderStyle = BorderStyle.FixedSingle;
            txtCondicionAvance.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtCondicionAvance.Location = new Point(58, 451);
            txtCondicionAvance.Margin = new Padding(2, 4, 2, 4);
            txtCondicionAvance.MaxLength = 0;
            txtCondicionAvance.Multiline = true;
            txtCondicionAvance.Name = "txtCondicionAvance";
            txtCondicionAvance.Size = new Size(1180, 118);
            txtCondicionAvance.TabIndex = 93;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label15.ForeColor = Color.White;
            label15.Location = new Point(330, 595);
            label15.Margin = new Padding(4, 0, 4, 0);
            label15.Name = "label15";
            label15.Size = new Size(418, 33);
            label15.TabIndex = 86;
            label15.Text = "Duración Estimada (HORAS)";
            // 
            // txtNombre
            // 
            txtNombre.BorderStyle = BorderStyle.FixedSingle;
            txtNombre.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtNombre.Location = new Point(58, 169);
            txtNombre.Margin = new Padding(2, 4, 2, 4);
            txtNombre.MaxLength = 150;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(1044, 40);
            txtNombre.TabIndex = 76;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(58, 125);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(125, 33);
            label2.TabIndex = 80;
            label2.Text = "Nombre";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(58, 231);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(180, 33);
            label5.TabIndex = 81;
            label5.Text = "Descripción";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label13.ForeColor = Color.White;
            label13.Location = new Point(51, 595);
            label13.Margin = new Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new Size(256, 33);
            label13.TabIndex = 84;
            label13.Text = "Tipo de Actividad";
            // 
            // txtDescripcionActividad
            // 
            txtDescripcionActividad.BorderStyle = BorderStyle.FixedSingle;
            txtDescripcionActividad.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtDescripcionActividad.Location = new Point(58, 271);
            txtDescripcionActividad.Margin = new Padding(2, 4, 2, 4);
            txtDescripcionActividad.MaxLength = 0;
            txtDescripcionActividad.Multiline = true;
            txtDescripcionActividad.Name = "txtDescripcionActividad";
            txtDescripcionActividad.Size = new Size(1173, 113);
            txtDescripcionActividad.TabIndex = 79;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label14.ForeColor = Color.White;
            label14.Location = new Point(1179, 121);
            label14.Margin = new Padding(4, 0, 4, 0);
            label14.Name = "label14";
            label14.Size = new Size(101, 33);
            label14.TabIndex = 83;
            label14.Text = "Orden";
            // 
            // cmbTipoActividad
            // 
            cmbTipoActividad.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoActividad.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            cmbTipoActividad.FormattingEnabled = true;
            cmbTipoActividad.Location = new Point(51, 644);
            cmbTipoActividad.Margin = new Padding(2, 4, 2, 4);
            cmbTipoActividad.Name = "cmbTipoActividad";
            cmbTipoActividad.Size = new Size(240, 41);
            cmbTipoActividad.TabIndex = 78;
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.Location = new Point(822, 722);
            chkActivo.Margin = new Padding(4);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(88, 29);
            chkActivo.TabIndex = 99;
            chkActivo.Text = "Activo";
            chkActivo.UseVisualStyleBackColor = true;
            // 
            // chkDemora
            // 
            chkDemora.AutoSize = true;
            chkDemora.Location = new Point(56, 722);
            chkDemora.Margin = new Padding(4);
            chkDemora.Name = "chkDemora";
            chkDemora.Size = new Size(102, 29);
            chkDemora.TabIndex = 100;
            chkDemora.Text = "Demora";
            chkDemora.UseVisualStyleBackColor = true;
            // 
            // chkRequiereAprobacion
            // 
            chkRequiereAprobacion.AutoSize = true;
            chkRequiereAprobacion.Location = new Point(241, 722);
            chkRequiereAprobacion.Margin = new Padding(4);
            chkRequiereAprobacion.Name = "chkRequiereAprobacion";
            chkRequiereAprobacion.Size = new Size(204, 29);
            chkRequiereAprobacion.TabIndex = 101;
            chkRequiereAprobacion.Text = "Requiere Aprobación";
            chkRequiereAprobacion.UseVisualStyleBackColor = true;
            // 
            // chkPermiteEjecucionParcial
            // 
            chkPermiteEjecucionParcial.AutoSize = true;
            chkPermiteEjecucionParcial.Location = new Point(554, 722);
            chkPermiteEjecucionParcial.Margin = new Padding(4);
            chkPermiteEjecucionParcial.Name = "chkPermiteEjecucionParcial";
            chkPermiteEjecucionParcial.Size = new Size(165, 29);
            chkPermiteEjecucionParcial.TabIndex = 102;
            chkPermiteEjecucionParcial.Text = "Ejecución Parcial";
            chkPermiteEjecucionParcial.UseVisualStyleBackColor = true;
            // 
            // mskDuracionEstimada
            // 
            mskDuracionEstimada.Location = new Point(341, 651);
            mskDuracionEstimada.Margin = new Padding(4);
            mskDuracionEstimada.Mask = "00000";
            mskDuracionEstimada.Name = "mskDuracionEstimada";
            mskDuracionEstimada.Size = new Size(125, 31);
            mskDuracionEstimada.TabIndex = 103;
            // 
            // AbmActividadesCicloModelo
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(141, 181, 146);
            ClientSize = new Size(1300, 821);
            Controls.Add(mskDuracionEstimada);
            Controls.Add(chkPermiteEjecucionParcial);
            Controls.Add(chkRequiereAprobacion);
            Controls.Add(chkDemora);
            Controls.Add(chkActivo);
            Controls.Add(btnAceptarActividad);
            Controls.Add(txtOrden);
            Controls.Add(label10);
            Controls.Add(txtCondicionAvance);
            Controls.Add(label15);
            Controls.Add(txtNombre);
            Controls.Add(label2);
            Controls.Add(label5);
            Controls.Add(label13);
            Controls.Add(txtDescripcionActividad);
            Controls.Add(label14);
            Controls.Add(cmbTipoActividad);
            Margin = new Padding(4, 5, 4, 5);
            Name = "AbmActividadesCicloModelo";
            Padding = new Padding(4, 106, 4, 5);
            Text = "Actividad";
            Load += AbmActividadesCicloModelo_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAceptarActividad;
        private TextBox txtOrden;
        private Label label10;
        private TextBox txtCondicionAvance;
        private Label label15;
        private TextBox txtNombre;
        private Label label2;
        private Label label5;
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
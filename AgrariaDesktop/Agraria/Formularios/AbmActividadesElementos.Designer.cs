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
            numCantPrevista = new NumericUpDown();
            label19 = new Label();
            cmbTipoElemento = new ComboBox();
            label22 = new Label();
            label23 = new Label();
            label24 = new Label();
            label25 = new Label();
            txtObservacion = new TextBox();
            cmbTipoUnidad = new ComboBox();
            btnAceptar = new Button();
            txtOrdenElemento = new Label();
            cmbElemento = new ComboBox();
            chkObligatorio = new CheckBox();
            chkVendible = new CheckBox();
            chkPermiteSustitucion = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)numCantPrevista).BeginInit();
            SuspendLayout();
            // 
            // numCantPrevista
            // 
            numCantPrevista.DecimalPlaces = 2;
            numCantPrevista.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            numCantPrevista.Location = new Point(33, 361);
            numCantPrevista.Margin = new Padding(4, 5, 4, 5);
            numCantPrevista.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numCantPrevista.Name = "numCantPrevista";
            numCantPrevista.Size = new Size(239, 40);
            numCantPrevista.TabIndex = 92;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label19.ForeColor = Color.White;
            label19.Location = new Point(27, 311);
            label19.Margin = new Padding(4, 0, 4, 0);
            label19.Name = "label19";
            label19.Size = new Size(262, 33);
            label19.TabIndex = 93;
            label19.Text = "Cantidad Prevista";
            // 
            // cmbTipoElemento
            // 
            cmbTipoElemento.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoElemento.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            cmbTipoElemento.FormattingEnabled = true;
            cmbTipoElemento.Location = new Point(32, 137);
            cmbTipoElemento.Margin = new Padding(1, 4, 1, 4);
            cmbTipoElemento.Name = "cmbTipoElemento";
            cmbTipoElemento.Size = new Size(283, 41);
            cmbTipoElemento.TabIndex = 91;
            cmbTipoElemento.SelectedIndexChanged += cmbTipoElemento_SelectedIndexChanged;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label22.ForeColor = Color.White;
            label22.Location = new Point(32, 432);
            label22.Margin = new Padding(4, 0, 4, 0);
            label22.Name = "label22";
            label22.Size = new Size(226, 33);
            label22.TabIndex = 86;
            label22.Text = "Tipo de Unidad";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label23.ForeColor = Color.White;
            label23.Location = new Point(27, 93);
            label23.Margin = new Padding(4, 0, 4, 0);
            label23.Name = "label23";
            label23.Size = new Size(216, 33);
            label23.TabIndex = 82;
            label23.Text = "Tipo Elemento";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label24.ForeColor = Color.White;
            label24.Location = new Point(460, 121);
            label24.Margin = new Padding(4, 0, 4, 0);
            label24.Name = "label24";
            label24.Size = new Size(191, 33);
            label24.TabIndex = 83;
            label24.Text = "Observación";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label25.ForeColor = Color.White;
            label25.Location = new Point(32, 201);
            label25.Margin = new Padding(4, 0, 4, 0);
            label25.Name = "label25";
            label25.Size = new Size(146, 33);
            label25.TabIndex = 84;
            label25.Text = "Elemento";
            // 
            // txtObservacion
            // 
            txtObservacion.BorderStyle = BorderStyle.FixedSingle;
            txtObservacion.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtObservacion.Location = new Point(460, 176);
            txtObservacion.Margin = new Padding(1, 4, 1, 4);
            txtObservacion.MaxLength = 40;
            txtObservacion.Multiline = true;
            txtObservacion.Name = "txtObservacion";
            txtObservacion.Size = new Size(793, 476);
            txtObservacion.TabIndex = 81;
            // 
            // cmbTipoUnidad
            // 
            cmbTipoUnidad.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoUnidad.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            cmbTipoUnidad.FormattingEnabled = true;
            cmbTipoUnidad.Location = new Point(33, 476);
            cmbTipoUnidad.Margin = new Padding(1, 4, 1, 4);
            cmbTipoUnidad.Name = "cmbTipoUnidad";
            cmbTipoUnidad.Size = new Size(208, 41);
            cmbTipoUnidad.TabIndex = 80;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(1184, 751);
            btnAceptar.Margin = new Padding(4, 5, 4, 5);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(109, 39);
            btnAceptar.TabIndex = 98;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // txtOrdenElemento
            // 
            txtOrdenElemento.AutoSize = true;
            txtOrdenElemento.Location = new Point(361, 80);
            txtOrdenElemento.Margin = new Padding(4, 0, 4, 0);
            txtOrdenElemento.Name = "txtOrdenElemento";
            txtOrdenElemento.Size = new Size(59, 25);
            txtOrdenElemento.TabIndex = 99;
            txtOrdenElemento.Text = "label1";
            txtOrdenElemento.Visible = false;
            // 
            // cmbElemento
            // 
            cmbElemento.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbElemento.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            cmbElemento.FormattingEnabled = true;
            cmbElemento.Location = new Point(27, 242);
            cmbElemento.Margin = new Padding(1, 4, 1, 4);
            cmbElemento.Name = "cmbElemento";
            cmbElemento.Size = new Size(333, 41);
            cmbElemento.TabIndex = 100;
            // 
            // chkObligatorio
            // 
            chkObligatorio.AutoSize = true;
            chkObligatorio.Location = new Point(33, 542);
            chkObligatorio.Margin = new Padding(4);
            chkObligatorio.Name = "chkObligatorio";
            chkObligatorio.Size = new Size(129, 29);
            chkObligatorio.TabIndex = 101;
            chkObligatorio.Text = "Obligatorio";
            chkObligatorio.UseVisualStyleBackColor = true;
            // 
            // chkVendible
            // 
            chkVendible.AutoSize = true;
            chkVendible.Location = new Point(33, 594);
            chkVendible.Margin = new Padding(4);
            chkVendible.Name = "chkVendible";
            chkVendible.Size = new Size(106, 29);
            chkVendible.TabIndex = 102;
            chkVendible.Text = "Vendible";
            chkVendible.UseVisualStyleBackColor = true;
            // 
            // chkPermiteSustitucion
            // 
            chkPermiteSustitucion.AutoSize = true;
            chkPermiteSustitucion.Location = new Point(33, 645);
            chkPermiteSustitucion.Margin = new Padding(4);
            chkPermiteSustitucion.Name = "chkPermiteSustitucion";
            chkPermiteSustitucion.Size = new Size(189, 29);
            chkPermiteSustitucion.TabIndex = 103;
            chkPermiteSustitucion.Text = "Permite Sustitución";
            chkPermiteSustitucion.UseVisualStyleBackColor = true;
            // 
            // AbmActividadesElementos
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(141, 181, 146);
            ClientSize = new Size(1301, 799);
            Controls.Add(chkPermiteSustitucion);
            Controls.Add(chkVendible);
            Controls.Add(chkObligatorio);
            Controls.Add(cmbElemento);
            Controls.Add(txtOrdenElemento);
            Controls.Add(btnAceptar);
            Controls.Add(numCantPrevista);
            Controls.Add(label19);
            Controls.Add(cmbTipoElemento);
            Controls.Add(label22);
            Controls.Add(label23);
            Controls.Add(label24);
            Controls.Add(label25);
            Controls.Add(txtObservacion);
            Controls.Add(cmbTipoUnidad);
            Margin = new Padding(4, 5, 4, 5);
            Name = "AbmActividadesElementos";
            Padding = new Padding(4, 80, 4, 4);
            Text = "Elementos";
            Load += AbmActividadesElementos_Load;
            ((System.ComponentModel.ISupportInitialize)numCantPrevista).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private NumericUpDown numCantPrevista;
        private Label label19;
        private ComboBox cmbTipoElemento;
        private Label label22;
        private Label label23;
        private Label label24;
        private Label label25;
        private TextBox txtObservacion;
        private ComboBox cmbTipoUnidad;
        private Button btnAceptar;
        private Label txtOrdenElemento;
        private ComboBox cmbElemento;
        private CheckBox chkObligatorio;
        private CheckBox chkVendible;
        private CheckBox chkPermiteSustitucion;
        private ComboBox cmbTipoMovimiento;
        private Label label27;
    }
}
namespace Agraria.Formularios
{
    partial class AbmArticulos
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
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblMarca = new Label();
            cbmMarca = new ComboBox();
            lblcategoria = new Label();
            cmbcategoria = new ComboBox();
            label1 = new Label();
            dypFechaAlta = new DateTimePicker();
            txtcodigoArticulo = new TextBox();
            lblNumArticulo = new Label();
            rjBAceptar = new Button();
            rjBCancelar = new Button();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblNombre.ForeColor = Color.White;
            lblNombre.Location = new Point(16, 121);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(256, 29);
            lblNombre.TabIndex = 22;
            lblNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            txtNombre.BackColor = SystemColors.Window;
            txtNombre.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtNombre.ForeColor = SystemColors.WindowText;
            txtNombre.Location = new Point(22, 154);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(380, 34);
            txtNombre.TabIndex = 2;
            // 
            // lblMarca
            // 
            lblMarca.AutoSize = true;
            lblMarca.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblMarca.ForeColor = Color.White;
            lblMarca.Location = new Point(22, 208);
            lblMarca.Name = "lblMarca";
            lblMarca.Size = new Size(84, 29);
            lblMarca.TabIndex = 2;
            lblMarca.Text = "Marca";
            // 
            // cbmMarca
            // 
            cbmMarca.BackColor = SystemColors.Window;
            cbmMarca.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            cbmMarca.ForeColor = SystemColors.WindowText;
            cbmMarca.FormattingEnabled = true;
            cbmMarca.Location = new Point(22, 239);
            cbmMarca.Name = "cbmMarca";
            cbmMarca.Size = new Size(250, 37);
            cbmMarca.TabIndex = 3;
            // 
            // lblcategoria
            // 
            lblcategoria.AutoSize = true;
            lblcategoria.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblcategoria.ForeColor = Color.White;
            lblcategoria.Location = new Point(28, 371);
            lblcategoria.Name = "lblcategoria";
            lblcategoria.Size = new Size(127, 29);
            lblcategoria.TabIndex = 4;
            lblcategoria.Text = "Categoría";
            // 
            // cmbcategoria
            // 
            cmbcategoria.BackColor = SystemColors.Window;
            cmbcategoria.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            cmbcategoria.ForeColor = SystemColors.WindowText;
            cmbcategoria.FormattingEnabled = true;
            cmbcategoria.Location = new Point(28, 402);
            cmbcategoria.Name = "cmbcategoria";
            cmbcategoria.Size = new Size(250, 37);
            cmbcategoria.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(22, 297);
            label1.Name = "label1";
            label1.Size = new Size(173, 29);
            label1.TabIndex = 12;
            label1.Text = "Fecha de Alta";
            // 
            // dypFechaAlta
            // 
            dypFechaAlta.CalendarFont = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            dypFechaAlta.Location = new Point(28, 328);
            dypFechaAlta.Name = "dypFechaAlta";
            dypFechaAlta.Size = new Size(180, 27);
            dypFechaAlta.TabIndex = 4;
            // 
            // txtcodigoArticulo
            // 
            txtcodigoArticulo.BackColor = SystemColors.Window;
            txtcodigoArticulo.Enabled = false;
            txtcodigoArticulo.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtcodigoArticulo.ForeColor = SystemColors.WindowText;
            txtcodigoArticulo.Location = new Point(22, 69);
            txtcodigoArticulo.Name = "txtcodigoArticulo";
            txtcodigoArticulo.ReadOnly = true;
            txtcodigoArticulo.Size = new Size(120, 34);
            txtcodigoArticulo.TabIndex = 1;
            // 
            // lblNumArticulo
            // 
            lblNumArticulo.FlatStyle = FlatStyle.Flat;
            lblNumArticulo.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblNumArticulo.ForeColor = Color.White;
            lblNumArticulo.Location = new Point(22, 36);
            lblNumArticulo.Name = "lblNumArticulo";
            lblNumArticulo.Size = new Size(256, 29);
            lblNumArticulo.TabIndex = 22;
            lblNumArticulo.Text = "Código";
            // 
            // rjBAceptar
            // 
            rjBAceptar.Location = new Point(527, 517);
            rjBAceptar.Name = "rjBAceptar";
            rjBAceptar.Size = new Size(94, 29);
            rjBAceptar.TabIndex = 6;
            rjBAceptar.Text = "&Aceptar";
            rjBAceptar.UseVisualStyleBackColor = true;
            rjBAceptar.Click += rjBAceptar_Click;
            // 
            // rjBCancelar
            // 
            rjBCancelar.Location = new Point(527, 565);
            rjBCancelar.Name = "rjBCancelar";
            rjBCancelar.Size = new Size(94, 29);
            rjBCancelar.TabIndex = 7;
            rjBCancelar.Text = "&Cancelar";
            rjBCancelar.UseVisualStyleBackColor = true;
            rjBCancelar.Click += rjBCancelar_Click;
            // 
            // FormArticulosDetalle
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(141, 181, 146);
            ClientSize = new Size(658, 626);
            Controls.Add(rjBCancelar);
            Controls.Add(rjBAceptar);
            Controls.Add(txtcodigoArticulo);
            Controls.Add(lblNumArticulo);
            Controls.Add(dypFechaAlta);
            Controls.Add(label1);
            Controls.Add(cmbcategoria);
            Controls.Add(lblcategoria);
            Controls.Add(cbmMarca);
            Controls.Add(lblMarca);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormArticulosDetalle";
            Text = "Detalle de Artículo";
            Load += FormArticulosDetalle_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblMarca;
        private ComboBox cbmMarca;
        private Label lblcategoria;
       
        private Label label4;
        private TextBox textBox2;
        private Button rjBAceptar;
        private ComboBox cmbcategoria;
        private Label label1;
        private DateTimePicker dypFechaAlta;
        private TextBox txtcodigoArticulo;
        private Label lblNumArticulo;
        private Button rjBCancelar;
    }
}
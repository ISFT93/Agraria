namespace Agraria.Formularios
{
    partial class AbmStock
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
            btnCancelar = new Button();
            btnAceptar = new Button();
            chkVerano = new CheckBox();
            chkPrimavera = new CheckBox();
            chkInvierno = new CheckBox();
            chkOtoño = new CheckBox();
            Precio = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            laaa = new Label();
            cmbActivo = new ComboBox();
            cmbVendible = new ComboBox();
            cmbProveedor = new ComboBox();
            txtCantidad = new TextBox();
            txtNombre = new TextBox();
            txtCodigoBloque = new TextBox();
            txtCodigoStock = new TextBox();
            cmbTipoElemento = new ComboBox();
            label2 = new Label();
            dtpFechaAlta = new DateTimePicker();
            dtpFechaBaja = new DateTimePicker();
            label10 = new Label();
            label13 = new Label();
            label14 = new Label();
            numPrecio = new NumericUpDown();
            btnSearch = new Button();
            cmbDatos = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)numPrecio).BeginInit();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(416, 538);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(90, 40);
            btnCancelar.TabIndex = 21;
            btnCancelar.Text = "&Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(319, 538);
            btnAceptar.Margin = new Padding(3, 4, 3, 4);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(90, 40);
            btnAceptar.TabIndex = 20;
            btnAceptar.Text = "&Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // chkVerano
            // 
            chkVerano.AutoSize = true;
            chkVerano.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold);
            chkVerano.ForeColor = Color.White;
            chkVerano.Location = new Point(391, 478);
            chkVerano.Name = "chkVerano";
            chkVerano.Size = new Size(100, 28);
            chkVerano.TabIndex = 18;
            chkVerano.Text = "Verano";
            chkVerano.UseVisualStyleBackColor = true;
            // 
            // chkPrimavera
            // 
            chkPrimavera.AutoSize = true;
            chkPrimavera.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold);
            chkPrimavera.ForeColor = Color.White;
            chkPrimavera.Location = new Point(246, 478);
            chkPrimavera.Name = "chkPrimavera";
            chkPrimavera.Size = new Size(125, 28);
            chkPrimavera.TabIndex = 17;
            chkPrimavera.Text = "Primavera";
            chkPrimavera.UseVisualStyleBackColor = true;
            // 
            // chkInvierno
            // 
            chkInvierno.AutoSize = true;
            chkInvierno.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold);
            chkInvierno.ForeColor = Color.White;
            chkInvierno.Location = new Point(121, 478);
            chkInvierno.Name = "chkInvierno";
            chkInvierno.Size = new Size(107, 28);
            chkInvierno.TabIndex = 16;
            chkInvierno.Text = "Invierno";
            chkInvierno.UseVisualStyleBackColor = true;
            // 
            // chkOtoño
            // 
            chkOtoño.AutoSize = true;
            chkOtoño.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold);
            chkOtoño.ForeColor = Color.White;
            chkOtoño.Location = new Point(16, 478);
            chkOtoño.Name = "chkOtoño";
            chkOtoño.Size = new Size(89, 28);
            chkOtoño.TabIndex = 15;
            chkOtoño.Text = "Otoño";
            chkOtoño.UseVisualStyleBackColor = true;
            // 
            // Precio
            // 
            Precio.AutoSize = true;
            Precio.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            Precio.ForeColor = Color.White;
            Precio.Location = new Point(16, 230);
            Precio.Name = "Precio";
            Precio.Size = new Size(73, 25);
            Precio.TabIndex = 24;
            Precio.Text = "Precio";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label9.ForeColor = Color.White;
            label9.Location = new Point(191, 158);
            label9.Name = "label9";
            label9.Size = new Size(121, 25);
            label9.TabIndex = 23;
            label9.Text = "Fecha Baja";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label8.ForeColor = Color.White;
            label8.Location = new Point(16, 158);
            label8.Name = "label8";
            label8.Size = new Size(116, 25);
            label8.TabIndex = 22;
            label8.Text = "Fecha Alta";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label7.ForeColor = Color.White;
            label7.Location = new Point(16, 374);
            label7.Name = "label7";
            label7.Size = new Size(72, 25);
            label7.TabIndex = 21;
            label7.Text = "Activo";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(366, 158);
            label4.Name = "label4";
            label4.Size = new Size(99, 25);
            label4.TabIndex = 18;
            label4.Text = "Cantidad";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(16, 85);
            label3.Name = "label3";
            label3.Size = new Size(55, 25);
            label3.TabIndex = 17;
            label3.Text = "Tipo";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(16, 302);
            label1.Name = "label1";
            label1.Size = new Size(154, 25);
            label1.TabIndex = 16;
            label1.Text = "Codigo Bloque";
            // 
            // laaa
            // 
            laaa.AutoSize = true;
            laaa.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            laaa.ForeColor = Color.White;
            laaa.Location = new Point(231, 85);
            laaa.Name = "laaa";
            laaa.Size = new Size(81, 25);
            laaa.TabIndex = 15;
            laaa.Text = "Código";
            // 
            // cmbActivo
            // 
            cmbActivo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbActivo.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            cmbActivo.FormattingEnabled = true;
            cmbActivo.Location = new Point(16, 404);
            cmbActivo.Margin = new Padding(2, 3, 2, 3);
            cmbActivo.Name = "cmbActivo";
            cmbActivo.Size = new Size(125, 33);
            cmbActivo.TabIndex = 10;
            // 
            // cmbVendible
            // 
            cmbVendible.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbVendible.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            cmbVendible.FormattingEnabled = true;
            cmbVendible.Location = new Point(161, 404);
            cmbVendible.Margin = new Padding(2, 3, 2, 3);
            cmbVendible.Name = "cmbVendible";
            cmbVendible.Size = new Size(125, 33);
            cmbVendible.TabIndex = 11;
            // 
            // cmbProveedor
            // 
            cmbProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProveedor.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            cmbProveedor.FormattingEnabled = true;
            cmbProveedor.Location = new Point(191, 257);
            cmbProveedor.Margin = new Padding(2, 3, 2, 3);
            cmbProveedor.Name = "cmbProveedor";
            cmbProveedor.Size = new Size(325, 33);
            cmbProveedor.TabIndex = 9;
            // 
            // txtCantidad
            // 
            txtCantidad.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            txtCantidad.Location = new Point(366, 186);
            txtCantidad.Margin = new Padding(2, 3, 2, 3);
            txtCantidad.MaxLength = 10;
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(92, 30);
            txtCantidad.TabIndex = 7;
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            txtNombre.Location = new Point(191, 332);
            txtNombre.Margin = new Padding(2, 3, 2, 3);
            txtNombre.MaxLength = 20;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(325, 30);
            txtNombre.TabIndex = 4;
            // 
            // txtCodigoBloque
            // 
            txtCodigoBloque.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            txtCodigoBloque.Location = new Point(16, 332);
            txtCodigoBloque.Margin = new Padding(2, 3, 2, 3);
            txtCodigoBloque.MaxLength = 10;
            txtCodigoBloque.Name = "txtCodigoBloque";
            txtCodigoBloque.Size = new Size(159, 30);
            txtCodigoBloque.TabIndex = 2;
            // 
            // txtCodigoStock
            // 
            txtCodigoStock.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            txtCodigoStock.Location = new Point(380, 113);
            txtCodigoStock.Margin = new Padding(2, 3, 2, 3);
            txtCodigoStock.MaxLength = 10;
            txtCodigoStock.Name = "txtCodigoStock";
            txtCodigoStock.Size = new Size(85, 30);
            txtCodigoStock.TabIndex = 1;
            // 
            // cmbTipoElemento
            // 
            cmbTipoElemento.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoElemento.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            cmbTipoElemento.FormattingEnabled = true;
            cmbTipoElemento.Location = new Point(16, 113);
            cmbTipoElemento.Margin = new Padding(3, 4, 3, 4);
            cmbTipoElemento.Name = "cmbTipoElemento";
            cmbTipoElemento.Size = new Size(201, 33);
            cmbTipoElemento.TabIndex = 3;
            cmbTipoElemento.SelectedIndexChanged += cmbTipoElemento_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(16, 448);
            label2.Name = "label2";
            label2.Size = new Size(61, 25);
            label2.TabIndex = 30;
            label2.Text = "Ciclo";
            // 
            // dtpFechaAlta
            // 
            dtpFechaAlta.CustomFormat = "dd/MM/yyyy";
            dtpFechaAlta.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            dtpFechaAlta.Format = DateTimePickerFormat.Short;
            dtpFechaAlta.Location = new Point(16, 186);
            dtpFechaAlta.Margin = new Padding(3, 4, 3, 4);
            dtpFechaAlta.Name = "dtpFechaAlta";
            dtpFechaAlta.Size = new Size(159, 30);
            dtpFechaAlta.TabIndex = 5;
            // 
            // dtpFechaBaja
            // 
            dtpFechaBaja.CustomFormat = "dd/MM/yyyy";
            dtpFechaBaja.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            dtpFechaBaja.Format = DateTimePickerFormat.Short;
            dtpFechaBaja.Location = new Point(191, 186);
            dtpFechaBaja.Margin = new Padding(3, 4, 3, 4);
            dtpFechaBaja.Name = "dtpFechaBaja";
            dtpFechaBaja.Size = new Size(159, 30);
            dtpFechaBaja.TabIndex = 6;
            dtpFechaBaja.ValueChanged += dtpFechaBaja_ValueChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label10.ForeColor = Color.White;
            label10.Location = new Point(191, 230);
            label10.Name = "label10";
            label10.Size = new Size(111, 25);
            label10.TabIndex = 38;
            label10.Text = "Proveedor";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label13.ForeColor = Color.White;
            label13.Location = new Point(161, 374);
            label13.Name = "label13";
            label13.Size = new Size(97, 25);
            label13.TabIndex = 39;
            label13.Text = "Vendible";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label14.ForeColor = Color.White;
            label14.Location = new Point(191, 302);
            label14.Name = "label14";
            label14.Size = new Size(87, 25);
            label14.TabIndex = 41;
            label14.Text = "Nombre";
            // 
            // numPrecio
            // 
            numPrecio.DecimalPlaces = 2;
            numPrecio.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            numPrecio.Location = new Point(16, 260);
            numPrecio.Margin = new Padding(3, 4, 3, 4);
            numPrecio.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            numPrecio.Name = "numPrecio";
            numPrecio.Size = new Size(160, 30);
            numPrecio.TabIndex = 8;
            // 
            // btnSearch
            // 
            btnSearch.Image = Properties.Resources.buscar66;
            btnSearch.Location = new Point(465, 186);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(41, 35);
            btnSearch.TabIndex = 42;
            btnSearch.Text = "Ver";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // cmbDatos
            // 
            cmbDatos.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbDatos.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            cmbDatos.FormattingEnabled = true;
            cmbDatos.Location = new Point(231, 113);
            cmbDatos.Name = "cmbDatos";
            cmbDatos.Size = new Size(140, 33);
            cmbDatos.TabIndex = 43;
            cmbDatos.SelectedIndexChanged += cmbDatos_SelectedIndexChanged;
            // 
            // AbmStock
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(141, 181, 146);
            ClientSize = new Size(555, 586);
            Controls.Add(cmbDatos);
            Controls.Add(btnSearch);
            Controls.Add(numPrecio);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(label10);
            Controls.Add(dtpFechaBaja);
            Controls.Add(dtpFechaAlta);
            Controls.Add(label2);
            Controls.Add(cmbTipoElemento);
            Controls.Add(chkVerano);
            Controls.Add(btnCancelar);
            Controls.Add(chkPrimavera);
            Controls.Add(chkInvierno);
            Controls.Add(btnAceptar);
            Controls.Add(chkOtoño);
            Controls.Add(txtNombre);
            Controls.Add(Precio);
            Controls.Add(txtCodigoStock);
            Controls.Add(label9);
            Controls.Add(txtCodigoBloque);
            Controls.Add(label8);
            Controls.Add(txtCantidad);
            Controls.Add(label7);
            Controls.Add(cmbProveedor);
            Controls.Add(cmbVendible);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(cmbActivo);
            Controls.Add(label1);
            Controls.Add(laaa);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(2, 3, 2, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AbmStock";
            Padding = new Padding(3, 85, 3, 4);
            Text = "Stock";
            Load += AbmStock_Load;
            ((System.ComponentModel.ISupportInitialize)numPrecio).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox cmbActivo;
        private ComboBox cmbVendible;
        private ComboBox cmbProveedor;
        private TextBox txtCantidad;
        private TextBox txtNombre;
        private TextBox txtCodigoBloque;
        private TextBox txtCodigoStock;
        private Label Precio;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label4;
        private Label label3;
        private Label label1;
        private Label laaa;
        private CheckBox chkVerano;
        private CheckBox chkPrimavera;
        private CheckBox chkInvierno;
        private CheckBox chkOtoño;
        private Button btnCancelar;
        private Button btnAceptar;
        private ComboBox cmbTipoElemento;
        private Label label2;
        private DateTimePicker dtpFechaAlta;
        private DateTimePicker dtpFechaBaja;
        private Label label10;
        private Label label13;
        private Label label14;
        private NumericUpDown numPrecio;
        private Button btnSearch;
        private ComboBox cmbDatos;
    }
}
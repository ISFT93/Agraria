namespace Agraria.Formularios
{
    partial class AbmVegetales
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
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            laaa = new Label();
            cmbRequerimientosHidrico = new ComboBox();
            cmbEstadoFenologico = new ComboBox();
            cmbMetodoSiembra = new ComboBox();
            cmbCicloVida = new ComboBox();
            cmbTipoCultivo = new ComboBox();
            txtVariedadHibrido = new TextBox();
            txtNombreCientifico = new TextBox();
            txtNombreComun = new TextBox();
            txtCodigoVegetal = new TextBox();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(799, 421);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 29);
            btnCancelar.TabIndex = 0;
            btnCancelar.Text = "&Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += cmbCancelar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(799, 386);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 29);
            btnAceptar.TabIndex = 1;
            btnAceptar.Text = "&Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += cmbAceptar_Click;
            // 
            // chkVerano
            // 
            chkVerano.AutoSize = true;
            chkVerano.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            chkVerano.ForeColor = Color.White;
            chkVerano.Location = new Point(404, 413);
            chkVerano.Margin = new Padding(3, 2, 3, 2);
            chkVerano.Name = "chkVerano";
            chkVerano.Size = new Size(97, 28);
            chkVerano.TabIndex = 28;
            chkVerano.Text = "Verano";
            chkVerano.UseVisualStyleBackColor = true;
            // 
            // chkPrimavera
            // 
            chkPrimavera.AutoSize = true;
            chkPrimavera.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            chkPrimavera.ForeColor = Color.White;
            chkPrimavera.Location = new Point(265, 413);
            chkPrimavera.Margin = new Padding(3, 2, 3, 2);
            chkPrimavera.Name = "chkPrimavera";
            chkPrimavera.Size = new Size(122, 28);
            chkPrimavera.TabIndex = 27;
            chkPrimavera.Text = "Primavera";
            chkPrimavera.UseVisualStyleBackColor = true;
            // 
            // chkInvierno
            // 
            chkInvierno.AutoSize = true;
            chkInvierno.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            chkInvierno.ForeColor = Color.White;
            chkInvierno.Location = new Point(153, 413);
            chkInvierno.Margin = new Padding(3, 2, 3, 2);
            chkInvierno.Name = "chkInvierno";
            chkInvierno.Size = new Size(104, 28);
            chkInvierno.TabIndex = 26;
            chkInvierno.Text = "Invierno";
            chkInvierno.UseVisualStyleBackColor = true;
            // 
            // chkOtoño
            // 
            chkOtoño.AutoSize = true;
            chkOtoño.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            chkOtoño.ForeColor = Color.White;
            chkOtoño.Location = new Point(62, 413);
            chkOtoño.Margin = new Padding(3, 2, 3, 2);
            chkOtoño.Name = "chkOtoño";
            chkOtoño.Size = new Size(86, 28);
            chkOtoño.TabIndex = 25;
            chkOtoño.Text = "Otoño";
            chkOtoño.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label10.ForeColor = Color.White;
            label10.Location = new Point(531, 235);
            label10.Name = "label10";
            label10.Size = new Size(217, 24);
            label10.TabIndex = 24;
            label10.Text = "Requerimiento hídrico";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label9.ForeColor = Color.White;
            label9.Location = new Point(531, 167);
            label9.Name = "label9";
            label9.Size = new Size(178, 24);
            label9.TabIndex = 23;
            label9.Text = "Estado fenológico";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label8.ForeColor = Color.White;
            label8.Location = new Point(531, 100);
            label8.Name = "label8";
            label8.Size = new Size(190, 24);
            label8.TabIndex = 22;
            label8.Text = "Método de siembra";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label7.ForeColor = Color.White;
            label7.Location = new Point(531, 302);
            label7.Name = "label7";
            label7.Size = new Size(131, 24);
            label7.TabIndex = 21;
            label7.Text = "Ciclo de vida";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label6.ForeColor = Color.White;
            label6.Location = new Point(32, 302);
            label6.Name = "label6";
            label6.Size = new Size(148, 24);
            label6.TabIndex = 20;
            label6.Text = "Tipo de cultivo";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(32, 386);
            label5.Name = "label5";
            label5.Size = new Size(206, 24);
            label5.TabIndex = 19;
            label5.Text = "Períodos de Siembra";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(32, 230);
            label4.Name = "label4";
            label4.Size = new Size(165, 24);
            label4.TabIndex = 18;
            label4.Text = "Variedad híbrido";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(32, 165);
            label3.Name = "label3";
            label3.Size = new Size(174, 24);
            label3.TabIndex = 17;
            label3.Text = "Nombre científico";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(32, 100);
            label1.Name = "label1";
            label1.Size = new Size(155, 24);
            label1.TabIndex = 16;
            label1.Text = "Nombre común";
            // 
            // laaa
            // 
            laaa.AutoSize = true;
            laaa.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            laaa.ForeColor = Color.White;
            laaa.Location = new Point(32, 8);
            laaa.Name = "laaa";
            laaa.Size = new Size(77, 24);
            laaa.TabIndex = 15;
            laaa.Text = "Código";
            // 
            // cmbRequerimientosHidrico
            // 
            cmbRequerimientosHidrico.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRequerimientosHidrico.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            cmbRequerimientosHidrico.FormattingEnabled = true;
            cmbRequerimientosHidrico.Location = new Point(531, 259);
            cmbRequerimientosHidrico.Margin = new Padding(2);
            cmbRequerimientosHidrico.Name = "cmbRequerimientosHidrico";
            cmbRequerimientosHidrico.Size = new Size(204, 32);
            cmbRequerimientosHidrico.TabIndex = 13;
            // 
            // cmbEstadoFenologico
            // 
            cmbEstadoFenologico.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstadoFenologico.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            cmbEstadoFenologico.FormattingEnabled = true;
            cmbEstadoFenologico.Location = new Point(531, 191);
            cmbEstadoFenologico.Margin = new Padding(2);
            cmbEstadoFenologico.Name = "cmbEstadoFenologico";
            cmbEstadoFenologico.Size = new Size(204, 32);
            cmbEstadoFenologico.TabIndex = 12;
            // 
            // cmbMetodoSiembra
            // 
            cmbMetodoSiembra.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMetodoSiembra.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            cmbMetodoSiembra.FormattingEnabled = true;
            cmbMetodoSiembra.Location = new Point(531, 123);
            cmbMetodoSiembra.Margin = new Padding(2);
            cmbMetodoSiembra.Name = "cmbMetodoSiembra";
            cmbMetodoSiembra.Size = new Size(265, 32);
            cmbMetodoSiembra.TabIndex = 11;
            // 
            // cmbCicloVida
            // 
            cmbCicloVida.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCicloVida.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            cmbCicloVida.FormattingEnabled = true;
            cmbCicloVida.Location = new Point(531, 325);
            cmbCicloVida.Margin = new Padding(2);
            cmbCicloVida.Name = "cmbCicloVida";
            cmbCicloVida.Size = new Size(148, 32);
            cmbCicloVida.TabIndex = 10;
            // 
            // cmbTipoCultivo
            // 
            cmbTipoCultivo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoCultivo.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            cmbTipoCultivo.FormattingEnabled = true;
            cmbTipoCultivo.Location = new Point(32, 328);
            cmbTipoCultivo.Margin = new Padding(2);
            cmbTipoCultivo.Name = "cmbTipoCultivo";
            cmbTipoCultivo.Size = new Size(148, 32);
            cmbTipoCultivo.TabIndex = 9;
            // 
            // txtVariedadHibrido
            // 
            txtVariedadHibrido.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtVariedadHibrido.Location = new Point(32, 254);
            txtVariedadHibrido.Margin = new Padding(2);
            txtVariedadHibrido.MaxLength = 40;
            txtVariedadHibrido.Name = "txtVariedadHibrido";
            txtVariedadHibrido.Size = new Size(424, 29);
            txtVariedadHibrido.TabIndex = 7;
            // 
            // txtNombreCientifico
            // 
            txtNombreCientifico.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtNombreCientifico.Location = new Point(32, 189);
            txtNombreCientifico.Margin = new Padding(2);
            txtNombreCientifico.MaxLength = 40;
            txtNombreCientifico.Name = "txtNombreCientifico";
            txtNombreCientifico.Size = new Size(424, 29);
            txtNombreCientifico.TabIndex = 6;
            // 
            // txtNombreComun
            // 
            txtNombreComun.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtNombreComun.Location = new Point(32, 124);
            txtNombreComun.Margin = new Padding(2);
            txtNombreComun.MaxLength = 40;
            txtNombreComun.Name = "txtNombreComun";
            txtNombreComun.Size = new Size(424, 29);
            txtNombreComun.TabIndex = 5;
            // 
            // txtCodigoVegetal
            // 
            txtCodigoVegetal.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtCodigoVegetal.Location = new Point(32, 32);
            txtCodigoVegetal.Margin = new Padding(2);
            txtCodigoVegetal.Name = "txtCodigoVegetal";
            txtCodigoVegetal.Size = new Size(148, 29);
            txtCodigoVegetal.TabIndex = 4;
            // 
            // AbmVegetales
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(141, 181, 146);
            ClientSize = new Size(884, 461);
            Controls.Add(chkVerano);
            Controls.Add(btnCancelar);
            Controls.Add(chkPrimavera);
            Controls.Add(chkInvierno);
            Controls.Add(btnAceptar);
            Controls.Add(chkOtoño);
            Controls.Add(txtNombreCientifico);
            Controls.Add(label10);
            Controls.Add(txtCodigoVegetal);
            Controls.Add(label9);
            Controls.Add(txtNombreComun);
            Controls.Add(label8);
            Controls.Add(txtVariedadHibrido);
            Controls.Add(label7);
            Controls.Add(cmbTipoCultivo);
            Controls.Add(label6);
            Controls.Add(cmbCicloVida);
            Controls.Add(label5);
            Controls.Add(cmbMetodoSiembra);
            Controls.Add(label4);
            Controls.Add(cmbEstadoFenologico);
            Controls.Add(label3);
            Controls.Add(cmbRequerimientosHidrico);
            Controls.Add(label1);
            Controls.Add(laaa);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AbmVegetales";
            Text = "AbmVegetales";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox cmbRequerimientosHidrico;
        private ComboBox cmbEstadoFenologico;
        private ComboBox cmbMetodoSiembra;
        private ComboBox cmbCicloVida;
        private ComboBox cmbTipoCultivo;
        private TextBox txtVariedadHibrido;
        private TextBox txtNombreCientifico;
        private TextBox txtNombreComun;
        private TextBox txtCodigoVegetal;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label1;
        private Label laaa;
        private CheckBox chkVerano;
        private CheckBox chkPrimavera;
        private CheckBox chkInvierno;
        private CheckBox chkOtoño;
        private Label label6;
        private Button btnCancelar;
        private Button btnAceptar;
    }
}
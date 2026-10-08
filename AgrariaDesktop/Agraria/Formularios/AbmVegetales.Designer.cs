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
            btnCancelar.Location = new Point(913, 561);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(86, 39);
            btnCancelar.TabIndex = 0;
            btnCancelar.Text = "&Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += cmbCancelar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(913, 515);
            btnAceptar.Margin = new Padding(3, 4, 3, 4);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(86, 39);
            btnAceptar.TabIndex = 1;
            btnAceptar.Text = "&Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += cmbAceptar_Click;
            // 
            // chkVerano
            // 
            chkVerano.AutoSize = true;
            chkVerano.Font = new Font("Segoe UI", 9F);
            chkVerano.ForeColor = SystemColors.ControlText;
            chkVerano.Location = new Point(462, 551);
            chkVerano.Name = "chkVerano";
            chkVerano.Size = new Size(77, 24);
            chkVerano.TabIndex = 28;
            chkVerano.Text = "Verano";
            chkVerano.UseVisualStyleBackColor = true;
            // 
            // chkPrimavera
            // 
            chkPrimavera.AutoSize = true;
            chkPrimavera.Font = new Font("Segoe UI", 9F);
            chkPrimavera.ForeColor = SystemColors.ControlText;
            chkPrimavera.Location = new Point(303, 551);
            chkPrimavera.Name = "chkPrimavera";
            chkPrimavera.Size = new Size(97, 24);
            chkPrimavera.TabIndex = 27;
            chkPrimavera.Text = "Primavera";
            chkPrimavera.UseVisualStyleBackColor = true;
            // 
            // chkInvierno
            // 
            chkInvierno.AutoSize = true;
            chkInvierno.Font = new Font("Segoe UI", 9F);
            chkInvierno.ForeColor = SystemColors.ControlText;
            chkInvierno.Location = new Point(175, 551);
            chkInvierno.Name = "chkInvierno";
            chkInvierno.Size = new Size(84, 24);
            chkInvierno.TabIndex = 26;
            chkInvierno.Text = "Invierno";
            chkInvierno.UseVisualStyleBackColor = true;
            // 
            // chkOtoño
            // 
            chkOtoño.AutoSize = true;
            chkOtoño.Font = new Font("Segoe UI", 9F);
            chkOtoño.ForeColor = SystemColors.ControlText;
            chkOtoño.Location = new Point(71, 551);
            chkOtoño.Name = "chkOtoño";
            chkOtoño.Size = new Size(73, 24);
            chkOtoño.TabIndex = 25;
            chkOtoño.Text = "Otoño";
            chkOtoño.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F);
            label10.ForeColor = SystemColors.ControlText;
            label10.Location = new Point(607, 313);
            label10.Name = "label10";
            label10.Size = new Size(157, 20);
            label10.TabIndex = 24;
            label10.Text = "Requerimiento hídrico";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F);
            label9.ForeColor = SystemColors.ControlText;
            label9.Location = new Point(607, 223);
            label9.Name = "label9";
            label9.Size = new Size(130, 20);
            label9.TabIndex = 23;
            label9.Text = "Estado fenológico";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F);
            label8.ForeColor = SystemColors.ControlText;
            label8.Location = new Point(607, 133);
            label8.Name = "label8";
            label8.Size = new Size(140, 20);
            label8.TabIndex = 22;
            label8.Text = "Método de siembra";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F);
            label7.ForeColor = SystemColors.ControlText;
            label7.Location = new Point(607, 403);
            label7.Name = "label7";
            label7.Size = new Size(95, 20);
            label7.TabIndex = 21;
            label7.Text = "Ciclo de vida";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F);
            label6.ForeColor = SystemColors.ControlText;
            label6.Location = new Point(37, 403);
            label6.Name = "label6";
            label6.Size = new Size(108, 20);
            label6.TabIndex = 20;
            label6.Text = "Tipo de cultivo";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F);
            label5.ForeColor = SystemColors.ControlText;
            label5.Location = new Point(37, 515);
            label5.Name = "label5";
            label5.Size = new Size(146, 20);
            label5.TabIndex = 19;
            label5.Text = "Períodos de Siembra";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F);
            label4.ForeColor = SystemColors.ControlText;
            label4.Location = new Point(37, 307);
            label4.Name = "label4";
            label4.Size = new Size(120, 20);
            label4.TabIndex = 18;
            label4.Text = "Variedad híbrido";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F);
            label3.ForeColor = SystemColors.ControlText;
            label3.Location = new Point(37, 220);
            label3.Name = "label3";
            label3.Size = new Size(129, 20);
            label3.TabIndex = 17;
            label3.Text = "Nombre científico";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(37, 133);
            label1.Name = "label1";
            label1.Size = new Size(113, 20);
            label1.TabIndex = 16;
            label1.Text = "Nombre común";
            // 
            // laaa
            // 
            laaa.AutoSize = true;
            laaa.Font = new Font("Segoe UI", 9F);
            laaa.ForeColor = SystemColors.ControlText;
            laaa.Location = new Point(37, 11);
            laaa.Name = "laaa";
            laaa.Size = new Size(58, 20);
            laaa.TabIndex = 15;
            laaa.Text = "Código";
            // 
            // cmbRequerimientosHidrico
            // 
            cmbRequerimientosHidrico.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRequerimientosHidrico.Font = new Font("Segoe UI", 9F);
            cmbRequerimientosHidrico.FormattingEnabled = true;
            cmbRequerimientosHidrico.Location = new Point(607, 345);
            cmbRequerimientosHidrico.Margin = new Padding(2, 3, 2, 3);
            cmbRequerimientosHidrico.Name = "cmbRequerimientosHidrico";
            cmbRequerimientosHidrico.Size = new Size(233, 28);
            cmbRequerimientosHidrico.TabIndex = 13;
            // 
            // cmbEstadoFenologico
            // 
            cmbEstadoFenologico.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstadoFenologico.Font = new Font("Segoe UI", 9F);
            cmbEstadoFenologico.FormattingEnabled = true;
            cmbEstadoFenologico.Location = new Point(607, 255);
            cmbEstadoFenologico.Margin = new Padding(2, 3, 2, 3);
            cmbEstadoFenologico.Name = "cmbEstadoFenologico";
            cmbEstadoFenologico.Size = new Size(233, 28);
            cmbEstadoFenologico.TabIndex = 12;
            // 
            // cmbMetodoSiembra
            // 
            cmbMetodoSiembra.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMetodoSiembra.Font = new Font("Segoe UI", 9F);
            cmbMetodoSiembra.FormattingEnabled = true;
            cmbMetodoSiembra.Location = new Point(607, 164);
            cmbMetodoSiembra.Margin = new Padding(2, 3, 2, 3);
            cmbMetodoSiembra.Name = "cmbMetodoSiembra";
            cmbMetodoSiembra.Size = new Size(302, 28);
            cmbMetodoSiembra.TabIndex = 11;
            // 
            // cmbCicloVida
            // 
            cmbCicloVida.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCicloVida.Font = new Font("Segoe UI", 9F);
            cmbCicloVida.FormattingEnabled = true;
            cmbCicloVida.Location = new Point(607, 433);
            cmbCicloVida.Margin = new Padding(2, 3, 2, 3);
            cmbCicloVida.Name = "cmbCicloVida";
            cmbCicloVida.Size = new Size(169, 28);
            cmbCicloVida.TabIndex = 10;
            // 
            // cmbTipoCultivo
            // 
            cmbTipoCultivo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoCultivo.Font = new Font("Segoe UI", 9F);
            cmbTipoCultivo.FormattingEnabled = true;
            cmbTipoCultivo.Location = new Point(37, 437);
            cmbTipoCultivo.Margin = new Padding(2, 3, 2, 3);
            cmbTipoCultivo.Name = "cmbTipoCultivo";
            cmbTipoCultivo.Size = new Size(169, 28);
            cmbTipoCultivo.TabIndex = 9;
            // 
            // txtVariedadHibrido
            // 
            txtVariedadHibrido.Font = new Font("Segoe UI", 9F);
            txtVariedadHibrido.Location = new Point(37, 339);
            txtVariedadHibrido.Margin = new Padding(2, 3, 2, 3);
            txtVariedadHibrido.MaxLength = 40;
            txtVariedadHibrido.Name = "txtVariedadHibrido";
            txtVariedadHibrido.Size = new Size(484, 27);
            txtVariedadHibrido.TabIndex = 7;
            // 
            // txtNombreCientifico
            // 
            txtNombreCientifico.Font = new Font("Segoe UI", 9F);
            txtNombreCientifico.Location = new Point(37, 252);
            txtNombreCientifico.Margin = new Padding(2, 3, 2, 3);
            txtNombreCientifico.MaxLength = 40;
            txtNombreCientifico.Name = "txtNombreCientifico";
            txtNombreCientifico.Size = new Size(484, 27);
            txtNombreCientifico.TabIndex = 6;
            // 
            // txtNombreComun
            // 
            txtNombreComun.Font = new Font("Segoe UI", 9F);
            txtNombreComun.Location = new Point(37, 165);
            txtNombreComun.Margin = new Padding(2, 3, 2, 3);
            txtNombreComun.MaxLength = 40;
            txtNombreComun.Name = "txtNombreComun";
            txtNombreComun.Size = new Size(484, 27);
            txtNombreComun.TabIndex = 5;
            // 
            // txtCodigoVegetal
            // 
            txtCodigoVegetal.Font = new Font("Segoe UI", 9F);
            txtCodigoVegetal.Location = new Point(37, 89);
            txtCodigoVegetal.Margin = new Padding(2, 3, 2, 3);
            txtCodigoVegetal.Name = "txtCodigoVegetal";
            txtCodigoVegetal.Size = new Size(169, 27);
            txtCodigoVegetal.TabIndex = 4;
            // 
            // AbmVegetales
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1028, 662);
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
            Margin = new Padding(2, 3, 2, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AbmVegetales";
            Text = "AbmVegetales";
            Load += AbmVegetales_Load;
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
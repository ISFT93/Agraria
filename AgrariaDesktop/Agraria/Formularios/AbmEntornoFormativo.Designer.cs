namespace Agraria.Formularios
{
    partial class AbmEntornoFormativo
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
            components = new System.ComponentModel.Container();
            errorProvider1 = new ErrorProvider(components);
            txtAño = new TextBox();
            lblApellido = new Label();
            txtObservacion = new TextBox();
            label5 = new Label();
            cmbTipoEntorno = new ComboBox();
            txtDivision = new TextBox();
            txtProfesorResponsable = new TextBox();
            label7 = new Label();
            txtGrupo = new TextBox();
            label2 = new Label();
            txtNombreEntorno = new TextBox();
            label3 = new Label();
            lblTipoEntorno = new Label();
            lblEntorno = new Label();
            PanelDatos = new Panel();
            label1 = new Label();
            dtpFecha = new DateTimePicker();
            btnCancelar = new Button();
            btnAceptar = new Button();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            PanelDatos.SuspendLayout();
            SuspendLayout();
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // txtAño
            // 
            txtAño.BorderStyle = BorderStyle.FixedSingle;
            txtAño.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtAño.Location = new Point(70, 129);
            txtAño.Margin = new Padding(3, 4, 3, 4);
            txtAño.MaxLength = 4;
            txtAño.Name = "txtAño";
            txtAño.Size = new Size(126, 34);
            txtAño.TabIndex = 5;
            txtAño.KeyDown += CopiaryPegar_KeyDown;
            txtAño.KeyPress += SoloNumeros_KeyPress;
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblApellido.ForeColor = Color.White;
            lblApellido.Location = new Point(8, 224);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(188, 29);
            lblApellido.TabIndex = 14;
            lblApellido.Text = "Observaciones";
            // 
            // txtObservacion
            // 
            txtObservacion.BorderStyle = BorderStyle.FixedSingle;
            txtObservacion.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtObservacion.Location = new Point(200, 220);
            txtObservacion.Margin = new Padding(3, 4, 3, 4);
            txtObservacion.Multiline = true;
            txtObservacion.Name = "txtObservacion";
            txtObservacion.Size = new Size(677, 248);
            txtObservacion.TabIndex = 8;
            txtObservacion.KeyDown += CopiaryPegar_KeyDown;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(482, 136);
            label5.Name = "label5";
            label5.Size = new Size(106, 29);
            label5.TabIndex = 18;
            label5.Text = "División";
            // 
            // cmbTipoEntorno
            // 
            cmbTipoEntorno.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoEntorno.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            cmbTipoEntorno.FormattingEnabled = true;
            cmbTipoEntorno.Location = new Point(216, 5);
            cmbTipoEntorno.Margin = new Padding(3, 4, 3, 4);
            cmbTipoEntorno.Name = "cmbTipoEntorno";
            cmbTipoEntorno.Size = new Size(177, 37);
            cmbTipoEntorno.TabIndex = 1;
            // 
            // txtDivision
            // 
            txtDivision.BorderStyle = BorderStyle.FixedSingle;
            txtDivision.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtDivision.Location = new Point(594, 133);
            txtDivision.Margin = new Padding(3, 4, 3, 4);
            txtDivision.MaxLength = 5;
            txtDivision.Name = "txtDivision";
            txtDivision.Size = new Size(126, 34);
            txtDivision.TabIndex = 7;
            txtDivision.KeyDown += CopiaryPegar_KeyDown;
            // 
            // txtProfesorResponsable
            // 
            txtProfesorResponsable.BorderStyle = BorderStyle.FixedSingle;
            txtProfesorResponsable.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtProfesorResponsable.Location = new Point(287, 66);
            txtProfesorResponsable.Margin = new Padding(3, 4, 3, 4);
            txtProfesorResponsable.MaxLength = 40;
            txtProfesorResponsable.Name = "txtProfesorResponsable";
            txtProfesorResponsable.Size = new Size(254, 34);
            txtProfesorResponsable.TabIndex = 3;
            txtProfesorResponsable.KeyDown += CopiaryPegar_KeyDown;
            txtProfesorResponsable.KeyPress += SoloTextoNumeroEspacio_KeyPress;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label7.ForeColor = Color.White;
            label7.Location = new Point(8, 71);
            label7.Name = "label7";
            label7.Size = new Size(274, 29);
            label7.TabIndex = 20;
            label7.Text = "Profesor Responsable";
            // 
            // txtGrupo
            // 
            txtGrupo.BorderStyle = BorderStyle.FixedSingle;
            txtGrupo.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtGrupo.Location = new Point(330, 133);
            txtGrupo.Margin = new Padding(3, 4, 3, 4);
            txtGrupo.MaxLength = 5;
            txtGrupo.Name = "txtGrupo";
            txtGrupo.Size = new Size(126, 34);
            txtGrupo.TabIndex = 6;
            txtGrupo.KeyDown += CopiaryPegar_KeyDown;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(239, 136);
            label2.Name = "label2";
            label2.Size = new Size(85, 29);
            label2.TabIndex = 15;
            label2.Text = "Grupo";
            // 
            // txtNombreEntorno
            // 
            txtNombreEntorno.BorderStyle = BorderStyle.FixedSingle;
            txtNombreEntorno.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtNombreEntorno.Location = new Point(646, 13);
            txtNombreEntorno.Margin = new Padding(3, 4, 3, 4);
            txtNombreEntorno.MaxLength = 40;
            txtNombreEntorno.Name = "txtNombreEntorno";
            txtNombreEntorno.Size = new Size(325, 34);
            txtNombreEntorno.TabIndex = 2;
            txtNombreEntorno.KeyDown += CopiaryPegar_KeyDown;
            txtNombreEntorno.KeyPress += SoloTextoNumeroEspacio_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(8, 133);
            label3.Name = "label3";
            label3.Size = new Size(58, 29);
            label3.TabIndex = 16;
            label3.Text = "Año";
            // 
            // lblTipoEntorno
            // 
            lblTipoEntorno.AutoSize = true;
            lblTipoEntorno.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblTipoEntorno.ForeColor = Color.White;
            lblTipoEntorno.Location = new Point(8, 16);
            lblTipoEntorno.Name = "lblTipoEntorno";
            lblTipoEntorno.Size = new Size(202, 29);
            lblTipoEntorno.TabIndex = 19;
            lblTipoEntorno.Text = "Tipo de Entorno";
            // 
            // lblEntorno
            // 
            lblEntorno.AutoSize = true;
            lblEntorno.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblEntorno.ForeColor = Color.White;
            lblEntorno.Location = new Point(403, 16);
            lblEntorno.Name = "lblEntorno";
            lblEntorno.Size = new Size(242, 29);
            lblEntorno.TabIndex = 21;
            lblEntorno.Text = "Nombre de Entorno";
            // 
            // PanelDatos
            // 
            PanelDatos.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            PanelDatos.BackColor = Color.FromArgb(141, 181, 146);
            PanelDatos.Controls.Add(label1);
            PanelDatos.Controls.Add(dtpFecha);
            PanelDatos.Controls.Add(btnCancelar);
            PanelDatos.Controls.Add(btnAceptar);
            PanelDatos.Controls.Add(lblEntorno);
            PanelDatos.Controls.Add(txtAño);
            PanelDatos.Controls.Add(lblTipoEntorno);
            PanelDatos.Controls.Add(lblApellido);
            PanelDatos.Controls.Add(txtObservacion);
            PanelDatos.Controls.Add(label3);
            PanelDatos.Controls.Add(label5);
            PanelDatos.Controls.Add(txtNombreEntorno);
            PanelDatos.Controls.Add(cmbTipoEntorno);
            PanelDatos.Controls.Add(label2);
            PanelDatos.Controls.Add(txtDivision);
            PanelDatos.Controls.Add(txtGrupo);
            PanelDatos.Controls.Add(txtProfesorResponsable);
            PanelDatos.Controls.Add(label7);
            PanelDatos.Dock = DockStyle.Fill;
            PanelDatos.Location = new Point(3, 85);
            PanelDatos.Margin = new Padding(3, 4, 3, 4);
            PanelDatos.Name = "PanelDatos";
            PanelDatos.Size = new Size(998, 486);
            PanelDatos.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(547, 71);
            label1.Name = "label1";
            label1.Size = new Size(85, 29);
            label1.TabIndex = 45;
            label1.Text = "Fecha";
            // 
            // dtpFecha
            // 
            dtpFecha.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(633, 64);
            dtpFecha.Margin = new Padding(3, 4, 3, 4);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(165, 34);
            dtpFecha.TabIndex = 4;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(885, 439);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(86, 31);
            btnCancelar.TabIndex = 10;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(885, 395);
            btnAceptar.Margin = new Padding(3, 4, 3, 4);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(86, 31);
            btnAceptar.TabIndex = 9;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // AbmEntornoFormativo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1004, 575);
            Controls.Add(PanelDatos);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            Name = "AbmEntornoFormativo";
            Padding = new Padding(3, 85, 3, 4);
            Text = "AbmEntornoFormativo";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            PanelDatos.ResumeLayout(false);
            PanelDatos.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private ErrorProvider errorProvider1;
        private Panel PanelDatos;
        private Label lblEntorno;
        private TextBox txtAño;
        private Label lblTipoEntorno;
        private Label lblApellido;
        private TextBox txtObservacion;
        private Label label3;
        private Label label5;
        private TextBox txtNombreEntorno;
        private ComboBox cmbTipoEntorno;
        private Label label2;
        private TextBox txtDivision;
        private TextBox txtGrupo;
        private TextBox txtProfesorResponsable;
        private Label label7;
        private Button btnCancelar;
        private Button btnAceptar;
        private Label label1;
        private DateTimePicker dtpFecha;
    }
}
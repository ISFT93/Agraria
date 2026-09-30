namespace Agraria.Formularios
{
    partial class Industria
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            groupBox1 = new GroupBox();
            txtDetalle = new TextBox();
            btnGuardarIndustria = new Tienda.RJButton();
            btnImprimir = new Tienda.RJButton();
            btnQuitar = new Tienda.RJButton();
            btnAgregar = new Tienda.RJButton();
            txtCantidadInsumos = new TextBox();
            txtCantidadProduccion = new TextBox();
            label3 = new Label();
            txtRecetas = new TextBox();
            label2 = new Label();
            cmbInsumos = new ComboBox();
            label7 = new Label();
            label6 = new Label();
            dtpFecha = new DateTimePicker();
            label4 = new Label();
            label1 = new Label();
            cmbProducto = new ComboBox();
            panel2 = new Panel();
            dtgArticulosIndustria = new DataGridView();
            panel1 = new Panel();
            dtgInsumos = new DataGridView();
            errorProvider1 = new ErrorProvider(components);
            groupBox1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgArticulosIndustria).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgInsumos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.FromArgb(141, 181, 146);
            groupBox1.Controls.Add(txtDetalle);
            groupBox1.Controls.Add(btnGuardarIndustria);
            groupBox1.Controls.Add(btnImprimir);
            groupBox1.Controls.Add(btnQuitar);
            groupBox1.Controls.Add(btnAgregar);
            groupBox1.Controls.Add(txtCantidadInsumos);
            groupBox1.Controls.Add(txtCantidadProduccion);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtRecetas);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(cmbInsumos);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(dtpFecha);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(cmbProducto);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(1008, 721);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Elaboracion de Productos a Base de Producción Vegetal y Animal";
            // 
            // txtDetalle
            // 
            txtDetalle.Location = new Point(295, 110);
            txtDetalle.MaxLength = 5;
            txtDetalle.Name = "txtDetalle";
            txtDetalle.Size = new Size(111, 29);
            txtDetalle.TabIndex = 5;
            txtDetalle.KeyDown += CopiaryPegar_KeyDown;
            txtDetalle.KeyPress += SoloNumeros_KeyPress;
            // 
            // btnGuardarIndustria
            // 
            btnGuardarIndustria.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnGuardarIndustria.BackColor = Color.White;
            btnGuardarIndustria.FlatAppearance.BorderSize = 0;
            btnGuardarIndustria.FlatStyle = FlatStyle.Flat;
            btnGuardarIndustria.ForeColor = Color.Green;
            btnGuardarIndustria.Image = Properties.Resources.guardar_datos;
            btnGuardarIndustria.ImageAlign = ContentAlignment.MiddleLeft;
            btnGuardarIndustria.Location = new Point(602, 199);
            btnGuardarIndustria.Name = "btnGuardarIndustria";
            btnGuardarIndustria.Size = new Size(192, 39);
            btnGuardarIndustria.TabIndex = 9;
            btnGuardarIndustria.Text = "Guardar";
            btnGuardarIndustria.UseVisualStyleBackColor = false;
            btnGuardarIndustria.Click += btnGuardar_Click;
            // 
            // btnImprimir
            // 
            btnImprimir.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnImprimir.BackColor = Color.White;
            btnImprimir.FlatAppearance.BorderSize = 0;
            btnImprimir.FlatStyle = FlatStyle.Flat;
            btnImprimir.ForeColor = Color.Green;
            btnImprimir.Image = Properties.Resources.imprimir;
            btnImprimir.ImageAlign = ContentAlignment.MiddleLeft;
            btnImprimir.Location = new Point(810, 200);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(192, 39);
            btnImprimir.TabIndex = 11;
            btnImprimir.Text = "Imprimir";
            btnImprimir.UseVisualStyleBackColor = false;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // btnQuitar
            // 
            btnQuitar.BackColor = Color.White;
            btnQuitar.FlatAppearance.BorderSize = 0;
            btnQuitar.FlatStyle = FlatStyle.Flat;
            btnQuitar.ForeColor = Color.Green;
            btnQuitar.Image = Properties.Resources.cruz66;
            btnQuitar.ImageAlign = ContentAlignment.MiddleLeft;
            btnQuitar.Location = new Point(225, 199);
            btnQuitar.Name = "btnQuitar";
            btnQuitar.Size = new Size(192, 39);
            btnQuitar.TabIndex = 10;
            btnQuitar.Text = "Quitar";
            btnQuitar.UseVisualStyleBackColor = false;
            btnQuitar.Click += btnQuitar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.White;
            btnAgregar.FlatAppearance.BorderSize = 0;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.ForeColor = Color.Green;
            btnAgregar.Image = Properties.Resources.salida;
            btnAgregar.ImageAlign = ContentAlignment.MiddleLeft;
            btnAgregar.Location = new Point(13, 198);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(192, 39);
            btnAgregar.TabIndex = 8;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // txtCantidadInsumos
            // 
            txtCantidadInsumos.Location = new Point(225, 144);
            txtCantidadInsumos.MaxLength = 5;
            txtCantidadInsumos.Name = "txtCantidadInsumos";
            txtCantidadInsumos.Size = new Size(111, 29);
            txtCantidadInsumos.TabIndex = 6;
            txtCantidadInsumos.KeyDown += CopiaryPegar_KeyDown;
            txtCantidadInsumos.KeyPress += SoloNumeros_KeyPress;
            // 
            // txtCantidadProduccion
            // 
            txtCantidadProduccion.Location = new Point(113, 73);
            txtCantidadProduccion.MaxLength = 4;
            txtCantidadProduccion.Name = "txtCantidadProduccion";
            txtCantidadProduccion.Size = new Size(92, 29);
            txtCantidadProduccion.TabIndex = 2;
            txtCantidadProduccion.KeyDown += CopiaryPegar_KeyDown;
            txtCantidadProduccion.KeyPress += SoloNumeros_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(507, 24);
            label3.Name = "label3";
            label3.Size = new Size(85, 24);
            label3.TabIndex = 51;
            label3.Text = "Recetas";
            // 
            // txtRecetas
            // 
            txtRecetas.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtRecetas.Location = new Point(468, 51);
            txtRecetas.Multiline = true;
            txtRecetas.Name = "txtRecetas";
            txtRecetas.Size = new Size(530, 138);
            txtRecetas.TabIndex = 7;
            txtRecetas.KeyDown += CopiaryPegar_KeyDown;
            txtRecetas.KeyPress += TextoyNumero_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(13, 149);
            label2.Name = "label2";
            label2.Size = new Size(206, 24);
            label2.TabIndex = 49;
            label2.Text = "Cantidad de Insumos";
            // 
            // cmbInsumos
            // 
            cmbInsumos.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbInsumos.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            cmbInsumos.FormattingEnabled = true;
            cmbInsumos.Location = new Point(113, 107);
            cmbInsumos.Margin = new Padding(3, 2, 3, 2);
            cmbInsumos.Name = "cmbInsumos";
            cmbInsumos.Size = new Size(162, 32);
            cmbInsumos.TabIndex = 4;
            cmbInsumos.SelectedIndexChanged += cmbInsumos_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label7.ForeColor = Color.White;
            label7.Location = new Point(6, 113);
            label7.Name = "label7";
            label7.Size = new Size(88, 24);
            label7.TabIndex = 42;
            label7.Text = "Insumos";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label6.ForeColor = Color.White;
            label6.Location = new Point(239, 71);
            label6.Name = "label6";
            label6.Size = new Size(69, 24);
            label6.TabIndex = 41;
            label6.Text = "Fecha";
            // 
            // dtpFecha
            // 
            dtpFecha.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(315, 71);
            dtpFecha.Margin = new Padding(3, 2, 3, 2);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(125, 29);
            dtpFecha.TabIndex = 3;
            dtpFecha.Value = new DateTime(2025, 9, 16, 20, 46, 43, 0);
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(13, 76);
            label4.Name = "label4";
            label4.Size = new Size(92, 24);
            label4.TabIndex = 2;
            label4.Text = "Cantidad";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(13, 40);
            label1.Name = "label1";
            label1.Size = new Size(94, 24);
            label1.TabIndex = 0;
            label1.Text = "Producto";
            // 
            // cmbProducto
            // 
            cmbProducto.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProducto.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            cmbProducto.FormattingEnabled = true;
            cmbProducto.Location = new Point(113, 34);
            cmbProducto.Margin = new Padding(3, 2, 3, 2);
            cmbProducto.Name = "cmbProducto";
            cmbProducto.Size = new Size(162, 32);
            cmbProducto.TabIndex = 1;
            cmbProducto.SelectedIndexChanged += cmbProducto_SelectedIndexChanged;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Yellow;
            panel2.Controls.Add(dtgArticulosIndustria);
            panel2.Dock = DockStyle.Bottom;
            panel2.ForeColor = Color.Black;
            panel2.Location = new Point(0, 510);
            panel2.Name = "panel2";
            panel2.Size = new Size(1008, 211);
            panel2.TabIndex = 60;
            // 
            // dtgArticulosIndustria
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dtgArticulosIndustria.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dtgArticulosIndustria.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dtgArticulosIndustria.DefaultCellStyle = dataGridViewCellStyle2;
            dtgArticulosIndustria.Dock = DockStyle.Fill;
            dtgArticulosIndustria.Location = new Point(0, 0);
            dtgArticulosIndustria.Margin = new Padding(3, 2, 3, 2);
            dtgArticulosIndustria.Name = "dtgArticulosIndustria";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dtgArticulosIndustria.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dtgArticulosIndustria.RowHeadersWidth = 51;
            dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            dtgArticulosIndustria.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dtgArticulosIndustria.Size = new Size(1008, 211);
            dtgArticulosIndustria.TabIndex = 54;
            dtgArticulosIndustria.CellContentClick += dtgArticulosIndustria_CellContentClick;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Yellow;
            panel1.Controls.Add(dtgInsumos);
            panel1.Dock = DockStyle.Bottom;
            panel1.ForeColor = Color.Black;
            panel1.Location = new Point(0, 299);
            panel1.Name = "panel1";
            panel1.Size = new Size(1008, 211);
            panel1.TabIndex = 59;
            // 
            // dtgInsumos
            // 
            dataGridViewCellStyle5.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            dtgInsumos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Control;
            dataGridViewCellStyle6.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dtgInsumos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dtgInsumos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = SystemColors.Window;
            dataGridViewCellStyle7.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            dataGridViewCellStyle7.ForeColor = Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.False;
            dtgInsumos.DefaultCellStyle = dataGridViewCellStyle7;
            dtgInsumos.Dock = DockStyle.Fill;
            dtgInsumos.Location = new Point(0, 0);
            dtgInsumos.Margin = new Padding(3, 2, 3, 2);
            dtgInsumos.Name = "dtgInsumos";
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = SystemColors.Control;
            dataGridViewCellStyle8.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            dataGridViewCellStyle8.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
            dtgInsumos.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            dtgInsumos.RowHeadersWidth = 51;
            dtgInsumos.Size = new Size(1008, 211);
            dtgInsumos.TabIndex = 45;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // Industria
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(141, 181, 146);
            ClientSize = new Size(1008, 721);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Controls.Add(groupBox1);
            Name = "Industria";
            Text = "Industria";
            Load += Industria_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtgArticulosIndustria).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtgInsumos).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Tienda.RJButton btn_imprimir;
        private Tienda.RJButton btn_eliminar;
        private Tienda.RJButton btn_agregar;
        private DataGridView dgv_producion;
        private NumericUpDown nud_insumos;
        private ComboBox cmbInsumos;
        private Label label7;
        private Label label6;
        private DateTimePicker dtpFecha;
        private DateTimePicker dtp_fecha;
        private Tienda.RJButton btnGuardar;
        private NumericUpDown nud_cantidad;
        private Label label4;
        private Label label1;
        private ComboBox cmbProducto;
        private Label label2;
        private Label label3;
        private TextBox txtRecetas;
        private TextBox txtCantidadInsumos;
        private DataGridView dtgArticulosIndustria;
        private TextBox txtCantidadProduccion;
        private DataGridView dtgInsumos;
        private Tienda.RJButton btnGuardarIndustria;
        private Tienda.RJButton btnImprimir;
        private Tienda.RJButton btnQuitar;
        private Tienda.RJButton btnAgregar;
        private Panel panel1;
        private TextBox txtDetalle;
        private ErrorProvider errorProvider1;
        private Panel panel2;
    }
}
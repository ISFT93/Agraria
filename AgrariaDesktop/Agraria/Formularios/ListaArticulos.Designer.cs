namespace Agraria.Formularios
{
    partial class ListaArticulos
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
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            txtBuscar = new TextBox();
            panel1 = new Panel();
            panel2 = new Panel();
            btnSalir = new Button();
            btnImprimir = new Button();
            btnModificar = new Button();
            btnNuevo = new Button();
            panel3 = new Panel();
            btnBuscar = new Button();
            lblNombre = new Label();
            lblCategorias = new Label();
            cmbFiltroCategoria = new ComboBox();
            dgvArticulos = new DataGridView();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvArticulos).BeginInit();
            SuspendLayout();
            // 
            // txtBuscar
            // 
            txtBuscar.BorderStyle = BorderStyle.FixedSingle;
            txtBuscar.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtBuscar.Location = new Point(96, 67);
            txtBuscar.Margin = new Padding(3, 2, 3, 2);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(362, 29);
            txtBuscar.TabIndex = 1;
            txtBuscar.TextChanged += textBox1_TextChanged;
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 114);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(0, 263);
            panel1.TabIndex = 7;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(141, 181, 146);
            panel2.Controls.Add(btnSalir);
            panel2.Controls.Add(btnImprimir);
            panel2.Controls.Add(btnModificar);
            panel2.Controls.Add(btnNuevo);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(719, 114);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(131, 263);
            panel2.TabIndex = 8;
            panel2.Paint += panel2_Paint;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(28, 227);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 28;
            btnSalir.Text = "&Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += rjBSalir_Click;
            // 
            // btnImprimir
            // 
            btnImprimir.Location = new Point(31, 68);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(75, 23);
            btnImprimir.TabIndex = 27;
            btnImprimir.Text = "Im&primir";
            btnImprimir.UseVisualStyleBackColor = true;
            btnImprimir.Click += rjImprimir_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(31, 39);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(75, 23);
            btnModificar.TabIndex = 26;
            btnModificar.Text = "&Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += rjModificar_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(31, 10);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(75, 23);
            btnNuevo.TabIndex = 24;
            btnNuevo.Text = "&Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += rjBNuevo_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(141, 181, 146);
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(btnBuscar);
            panel3.Controls.Add(lblNombre);
            panel3.Controls.Add(lblCategorias);
            panel3.Controls.Add(cmbFiltroCategoria);
            panel3.Controls.Add(txtBuscar);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(1);
            panel3.Size = new Size(850, 114);
            panel3.TabIndex = 9;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(749, 73);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 24;
            btnBuscar.Text = "&Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += rjBBuscar_Click;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblNombre.ForeColor = Color.White;
            lblNombre.Location = new Point(5, 67);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(85, 24);
            lblNombre.TabIndex = 5;
            lblNombre.Text = "Nombre";
            // 
            // lblCategorias
            // 
            lblCategorias.AutoSize = true;
            lblCategorias.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblCategorias.ForeColor = Color.White;
            lblCategorias.Location = new Point(5, 32);
            lblCategorias.Name = "lblCategorias";
            lblCategorias.Size = new Size(109, 24);
            lblCategorias.TabIndex = 4;
            lblCategorias.Text = "Categorias";
            // 
            // cmbFiltroCategoria
            // 
            cmbFiltroCategoria.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            cmbFiltroCategoria.FormattingEnabled = true;
            cmbFiltroCategoria.Location = new Point(120, 24);
            cmbFiltroCategoria.Margin = new Padding(3, 2, 3, 2);
            cmbFiltroCategoria.Name = "cmbFiltroCategoria";
            cmbFiltroCategoria.Size = new Size(140, 32);
            cmbFiltroCategoria.TabIndex = 3;
            // 
            // dgvArticulos
            // 
            dgvArticulos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = Color.MediumSeaGreen;
            dataGridViewCellStyle7.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            dataGridViewCellStyle7.ForeColor = Color.White;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dgvArticulos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dgvArticulos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = SystemColors.Window;
            dataGridViewCellStyle8.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            dataGridViewCellStyle8.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            dgvArticulos.DefaultCellStyle = dataGridViewCellStyle8;
            dgvArticulos.Dock = DockStyle.Fill;
            dgvArticulos.EnableHeadersVisualStyles = false;
            dgvArticulos.Location = new Point(0, 114);
            dgvArticulos.Margin = new Padding(3, 2, 3, 2);
            dgvArticulos.Name = "dgvArticulos";
            dgvArticulos.ReadOnly = true;
            dgvArticulos.RowHeadersWidth = 51;
            dgvArticulos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvArticulos.Size = new Size(719, 263);
            dgvArticulos.TabIndex = 10;
            // 
            // ListaArticulos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(850, 377);
            Controls.Add(dgvArticulos);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(panel3);
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ListaArticulos";
            Text = "FormArticulosLista";
            Load += FormArticulosLista_Load;
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvArticulos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtBuscar;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Label lblCategorias;
        private ComboBox cmbFiltroCategoria;
        private Label lblNombre;
        private DataGridView dgvArticulos;
        private Button btnSalir;
        private Button btnImprimir;
        private Button btnModificar;
        private Button btnNuevo;
        private Button btnBuscar;
    }
}
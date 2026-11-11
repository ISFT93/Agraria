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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
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
            txtBuscar.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtBuscar.Location = new Point(156, 115);
            txtBuscar.Margin = new Padding(4, 4, 4, 4);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(515, 40);
            txtBuscar.TabIndex = 1;
            txtBuscar.TextChanged += textBox1_TextChanged;
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(4, 294);
            panel1.Margin = new Padding(4, 4, 4, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(0, 330);
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
            panel2.Location = new Point(1022, 294);
            panel2.Margin = new Padding(4, 4, 4, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(188, 330);
            panel2.TabIndex = 8;
            panel2.Paint += panel2_Paint;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(40, 379);
            btnSalir.Margin = new Padding(4, 5, 4, 5);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(108, 39);
            btnSalir.TabIndex = 28;
            btnSalir.Text = "&Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += rjBSalir_Click;
            // 
            // btnImprimir
            // 
            btnImprimir.Location = new Point(44, 114);
            btnImprimir.Margin = new Padding(4, 5, 4, 5);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(108, 39);
            btnImprimir.TabIndex = 27;
            btnImprimir.Text = "Im&primir";
            btnImprimir.UseVisualStyleBackColor = true;
            btnImprimir.Click += rjImprimir_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(44, 65);
            btnModificar.Margin = new Padding(4, 5, 4, 5);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(108, 39);
            btnModificar.TabIndex = 26;
            btnModificar.Text = "&Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += rjModificar_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(44, 16);
            btnNuevo.Margin = new Padding(4, 5, 4, 5);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(108, 39);
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
            panel3.Location = new Point(4, 106);
            panel3.Margin = new Padding(4, 4, 4, 4);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(1);
            panel3.Size = new Size(1206, 188);
            panel3.TabIndex = 9;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(1070, 121);
            btnBuscar.Margin = new Padding(4, 5, 4, 5);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(108, 39);
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
            lblNombre.Location = new Point(8, 111);
            lblNombre.Margin = new Padding(4, 0, 4, 0);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(125, 33);
            lblNombre.TabIndex = 5;
            lblNombre.Text = "Nombre";
            // 
            // lblCategorias
            // 
            lblCategorias.AutoSize = true;
            lblCategorias.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblCategorias.ForeColor = Color.White;
            lblCategorias.Location = new Point(8, 54);
            lblCategorias.Margin = new Padding(4, 0, 4, 0);
            lblCategorias.Name = "lblCategorias";
            lblCategorias.Size = new Size(166, 33);
            lblCategorias.TabIndex = 4;
            lblCategorias.Text = "Categorias";
            // 
            // cmbFiltroCategoria
            // 
            cmbFiltroCategoria.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            cmbFiltroCategoria.FormattingEnabled = true;
            cmbFiltroCategoria.Location = new Point(190, 44);
            cmbFiltroCategoria.Margin = new Padding(4, 4, 4, 4);
            cmbFiltroCategoria.Name = "cmbFiltroCategoria";
            cmbFiltroCategoria.Size = new Size(198, 41);
            cmbFiltroCategoria.TabIndex = 3;
            // 
            // dgvArticulos
            // 
            dgvArticulos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.MediumSeaGreen;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvArticulos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvArticulos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvArticulos.DefaultCellStyle = dataGridViewCellStyle2;
            dgvArticulos.Dock = DockStyle.Fill;
            dgvArticulos.EnableHeadersVisualStyles = false;
            dgvArticulos.Location = new Point(4, 294);
            dgvArticulos.Margin = new Padding(4, 4, 4, 4);
            dgvArticulos.Name = "dgvArticulos";
            dgvArticulos.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvArticulos.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvArticulos.RowHeadersWidth = 51;
            dgvArticulos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvArticulos.Size = new Size(1018, 330);
            dgvArticulos.TabIndex = 10;
            // 
            // ListaArticulos
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1214, 629);
            Controls.Add(dgvArticulos);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(panel3);
            Margin = new Padding(4, 4, 4, 4);
            Name = "ListaArticulos";
            Padding = new Padding(4, 106, 4, 5);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lista de Articulos";
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
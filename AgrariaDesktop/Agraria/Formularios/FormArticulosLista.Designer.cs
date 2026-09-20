namespace Agraria.Formularios
{
    partial class FormArticulosLista
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            dgvArticulos = new DataGridView();
            txtBuscar = new TextBox();
            panel1 = new Panel();
            panel2 = new Panel();
            rjBSalir = new Tienda.RJButton();
            rjImprimir = new Tienda.RJButton();
            rjModificar = new Tienda.RJButton();
            rjBNuevo = new Tienda.RJButton();
            panel3 = new Panel();
            lblNombre = new Label();
            lblCategorias = new Label();
            cmbFiltroCategoria = new ComboBox();
            rjBBuscar = new Tienda.RJButton();
            ((System.ComponentModel.ISupportInitialize)dgvArticulos).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // dgvArticulos
            // 
            dgvArticulos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.MediumSeaGreen;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvArticulos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvArticulos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvArticulos.DefaultCellStyle = dataGridViewCellStyle4;
            dgvArticulos.Dock = DockStyle.Fill;
            dgvArticulos.EnableHeadersVisualStyles = false;
            dgvArticulos.Location = new Point(0, 0);
            dgvArticulos.Name = "dgvArticulos";
            dgvArticulos.ReadOnly = true;
            dgvArticulos.RowHeadersWidth = 51;
            dgvArticulos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvArticulos.Size = new Size(723, 351);
            dgvArticulos.TabIndex = 0;
            dgvArticulos.CellContentClick += dgvArticulos_CellContentClick;
            // 
            // txtBuscar
            // 
            txtBuscar.BorderStyle = BorderStyle.FixedSingle;
            txtBuscar.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtBuscar.Location = new Point(112, 95);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(414, 34);
            txtBuscar.TabIndex = 1;
            txtBuscar.TextChanged += textBox1_TextChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvArticulos);
            panel1.Location = new Point(0, 152);
            panel1.Name = "panel1";
            panel1.Size = new Size(723, 351);
            panel1.TabIndex = 7;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(141, 181, 146);
            panel2.Controls.Add(rjBSalir);
            panel2.Controls.Add(rjImprimir);
            panel2.Controls.Add(rjModificar);
            panel2.Controls.Add(rjBNuevo);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(723, 152);
            panel2.Name = "panel2";
            panel2.Size = new Size(159, 351);
            panel2.TabIndex = 8;
            panel2.Paint += panel2_Paint;
            // 
            // rjBSalir
            // 
            rjBSalir.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            rjBSalir.BackColor = SystemColors.Window;
            rjBSalir.FlatAppearance.BorderSize = 0;
            rjBSalir.FlatStyle = FlatStyle.Flat;
            rjBSalir.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            rjBSalir.ForeColor = Color.Green;
            rjBSalir.Location = new Point(6, 247);
            rjBSalir.Name = "rjBSalir";
            rjBSalir.Size = new Size(153, 53);
            rjBSalir.TabIndex = 3;
            rjBSalir.Text = "Salir";
            rjBSalir.UseVisualStyleBackColor = false;
            rjBSalir.Click += rjBSalir_Click;
            // 
            // rjImprimir
            // 
            rjImprimir.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            rjImprimir.BackColor = Color.AliceBlue;
            rjImprimir.FlatAppearance.BorderSize = 0;
            rjImprimir.FlatStyle = FlatStyle.Flat;
            rjImprimir.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            rjImprimir.ForeColor = Color.Green;
            rjImprimir.Location = new Point(6, 166);
            rjImprimir.Name = "rjImprimir";
            rjImprimir.Size = new Size(153, 53);
            rjImprimir.TabIndex = 2;
            rjImprimir.Text = "imprimir";
            rjImprimir.UseVisualStyleBackColor = false;
            rjImprimir.Click += rjImprimir_Click;
            // 
            // rjModificar
            // 
            rjModificar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            rjModificar.BackColor = Color.AliceBlue;
            rjModificar.FlatAppearance.BorderSize = 0;
            rjModificar.FlatStyle = FlatStyle.Flat;
            rjModificar.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            rjModificar.ForeColor = Color.Green;
            rjModificar.Location = new Point(6, 87);
            rjModificar.Name = "rjModificar";
            rjModificar.Size = new Size(153, 53);
            rjModificar.TabIndex = 1;
            rjModificar.Text = "Modificar";
            rjModificar.UseVisualStyleBackColor = false;
            rjModificar.Click += rjModificar_Click;
            // 
            // rjBNuevo
            // 
            rjBNuevo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            rjBNuevo.BackColor = Color.AliceBlue;
            rjBNuevo.FlatAppearance.BorderSize = 0;
            rjBNuevo.FlatStyle = FlatStyle.Flat;
            rjBNuevo.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            rjBNuevo.ForeColor = Color.Green;
            rjBNuevo.Location = new Point(6, 6);
            rjBNuevo.Name = "rjBNuevo";
            rjBNuevo.Size = new Size(153, 53);
            rjBNuevo.TabIndex = 0;
            rjBNuevo.Text = "Nuevo";
            rjBNuevo.UseVisualStyleBackColor = false;
            rjBNuevo.Click += rjBNuevo_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(141, 181, 146);
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(lblNombre);
            panel3.Controls.Add(lblCategorias);
            panel3.Controls.Add(cmbFiltroCategoria);
            panel3.Controls.Add(rjBBuscar);
            panel3.Controls.Add(txtBuscar);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(1);
            panel3.Size = new Size(882, 152);
            panel3.TabIndex = 9;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblNombre.ForeColor = Color.White;
            lblNombre.Location = new Point(-1, 95);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(107, 29);
            lblNombre.TabIndex = 5;
            lblNombre.Text = "Nombre";
            // 
            // lblCategorias
            // 
            lblCategorias.AutoSize = true;
            lblCategorias.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblCategorias.ForeColor = Color.White;
            lblCategorias.Location = new Point(-1, 21);
            lblCategorias.Name = "lblCategorias";
            lblCategorias.Size = new Size(140, 29);
            lblCategorias.TabIndex = 4;
            lblCategorias.Text = "Categorias";
            // 
            // cmbFiltroCategoria
            // 
            cmbFiltroCategoria.FormattingEnabled = true;
            cmbFiltroCategoria.Location = new Point(-1, 53);
            cmbFiltroCategoria.Name = "cmbFiltroCategoria";
            cmbFiltroCategoria.Size = new Size(159, 28);
            cmbFiltroCategoria.TabIndex = 3;
            // 
            // rjBBuscar
            // 
            rjBBuscar.BackColor = Color.AliceBlue;
            rjBBuscar.FlatAppearance.BorderSize = 0;
            rjBBuscar.FlatStyle = FlatStyle.Flat;
            rjBBuscar.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            rjBBuscar.ForeColor = Color.Green;
            rjBBuscar.Location = new Point(532, 83);
            rjBBuscar.Name = "rjBBuscar";
            rjBBuscar.Size = new Size(153, 53);
            rjBBuscar.TabIndex = 2;
            rjBBuscar.Text = "Buscar";
            rjBBuscar.UseVisualStyleBackColor = false;
            rjBBuscar.Click += rjBBuscar_Click;
            // 
            // FormArticulosLista
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 503);
            ControlBox = false;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(panel3);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormArticulosLista";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormArticulosLista";
            Load += FormArticulosLista_Load;
            ((System.ComponentModel.ISupportInitialize)dgvArticulos).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvArticulos;
        private TextBox txtBuscar;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Tienda.RJButton rjBSalir;
        private Tienda.RJButton rjImprimir;
        private Tienda.RJButton rjModificar;
        private Tienda.RJButton rjBNuevo;
        private Tienda.RJButton rjBBuscar;
        private Label lblCategorias;
        private ComboBox cmbFiltroCategoria;
        private Label lblNombre;
    }
}
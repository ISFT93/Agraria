namespace Agraria.Formularios
{
    partial class ListarVegetales
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
            panel1 = new Panel();
            btnNuevo = new Button();
            btnModificar = new Button();
            btnImprimir = new Button();
            btnSalir = new Button();
            panel2 = new Panel();
            btnBuscar = new Button();
            cmbFiltrarPor = new ComboBox();
            label1 = new Label();
            laaa = new Label();
            txtBuscar = new TextBox();
            panel3 = new Panel();
            dtgvListarVegetales = new DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgvListarVegetales).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnNuevo);
            panel1.Controls.Add(btnModificar);
            panel1.Controls.Add(btnImprimir);
            panel1.Controls.Add(btnSalir);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(822, 152);
            panel1.Margin = new Padding(2, 3, 2, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(150, 351);
            panel1.TabIndex = 0;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(42, 19);
            btnNuevo.Margin = new Padding(3, 4, 3, 4);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(86, 31);
            btnNuevo.TabIndex = 19;
            btnNuevo.Text = "&Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(42, 58);
            btnModificar.Margin = new Padding(3, 4, 3, 4);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(86, 31);
            btnModificar.TabIndex = 20;
            btnModificar.Text = "&Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnImprimir
            // 
            btnImprimir.Location = new Point(42, 97);
            btnImprimir.Margin = new Padding(3, 4, 3, 4);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(86, 31);
            btnImprimir.TabIndex = 21;
            btnImprimir.Text = "Im&primir";
            btnImprimir.UseVisualStyleBackColor = true;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(42, 307);
            btnSalir.Margin = new Padding(3, 4, 3, 4);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(86, 31);
            btnSalir.TabIndex = 22;
            btnSalir.Text = "&Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnBuscar);
            panel2.Controls.Add(cmbFiltrarPor);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(laaa);
            panel2.Controls.Add(txtBuscar);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(2, 3, 2, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(972, 152);
            panel2.TabIndex = 1;
            panel2.Paint += panel2_Paint;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(864, 101);
            btnBuscar.Margin = new Padding(3, 4, 3, 4);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(86, 31);
            btnBuscar.TabIndex = 20;
            btnBuscar.Text = "&Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // cmbFiltrarPor
            // 
            cmbFiltrarPor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltrarPor.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            cmbFiltrarPor.FormattingEnabled = true;
            cmbFiltrarPor.Location = new Point(207, 34);
            cmbFiltrarPor.Name = "cmbFiltrarPor";
            cmbFiltrarPor.Size = new Size(202, 37);
            cmbFiltrarPor.TabIndex = 18;
            cmbFiltrarPor.SelectedIndexChanged += cmbFiltrarPor_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(3, 34);
            label1.Name = "label1";
            label1.Size = new Size(198, 29);
            label1.TabIndex = 17;
            label1.Text = "Tipo de Cultivo:";
            // 
            // laaa
            // 
            laaa.AutoSize = true;
            laaa.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            laaa.ForeColor = Color.White;
            laaa.Location = new Point(3, 84);
            laaa.Name = "laaa";
            laaa.Size = new Size(114, 29);
            laaa.TabIndex = 16;
            laaa.Text = "Nombre:";
            // 
            // txtBuscar
            // 
            txtBuscar.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtBuscar.Location = new Point(122, 77);
            txtBuscar.Margin = new Padding(2, 3, 2, 3);
            txtBuscar.MaxLength = 40;
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(455, 34);
            txtBuscar.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.Controls.Add(dtgvListarVegetales);
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(0, 152);
            panel3.Margin = new Padding(2, 3, 2, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(830, 351);
            panel3.TabIndex = 2;
            // 
            // dtgvListarVegetales
            // 
            dtgvListarVegetales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.MediumSeaGreen;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dtgvListarVegetales.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dtgvListarVegetales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dtgvListarVegetales.DefaultCellStyle = dataGridViewCellStyle4;
            dtgvListarVegetales.Dock = DockStyle.Fill;
            dtgvListarVegetales.EnableHeadersVisualStyles = false;
            dtgvListarVegetales.Location = new Point(0, 0);
            dtgvListarVegetales.Margin = new Padding(2, 3, 2, 3);
            dtgvListarVegetales.Name = "dtgvListarVegetales";
            dtgvListarVegetales.ReadOnly = true;
            dtgvListarVegetales.RowHeadersWidth = 62;
            dtgvListarVegetales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgvListarVegetales.Size = new Size(830, 351);
            dtgvListarVegetales.TabIndex = 0;
            // 
            // ListarVegetales
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(141, 181, 146);
            ClientSize = new Size(972, 503);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Margin = new Padding(2, 3, 2, 3);
            Name = "ListarVegetales";
            Text = "ListarVegetales";
            Load += ListarVegetales_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtgvListarVegetales).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private DataGridView dtgvListarVegetales;
        private TextBox txtBuscar;
        private Label laaa;
        private ComboBox cmbFiltrarPor;
        private Label label1;
        private Button btnNuevo;
        private Button btnImprimir;
        private Button btnModificar;
        private Button btnSalir;
        private Button btnBuscar;
    }
}
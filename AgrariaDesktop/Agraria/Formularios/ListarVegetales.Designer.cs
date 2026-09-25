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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
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
            panel1.Location = new Point(667, 91);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(105, 286);
            panel1.TabIndex = 0;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(18, 14);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(75, 23);
            btnNuevo.TabIndex = 19;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(18, 96);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(75, 23);
            btnModificar.TabIndex = 20;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnImprimir
            // 
            btnImprimir.Location = new Point(18, 178);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(75, 23);
            btnImprimir.TabIndex = 21;
            btnImprimir.Text = "Imprimir";
            btnImprimir.UseVisualStyleBackColor = true;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(18, 260);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 22;
            btnSalir.Text = "Salir";
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
            panel2.Margin = new Padding(2);
            panel2.Name = "panel2";
            panel2.Size = new Size(772, 91);
            panel2.TabIndex = 1;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(587, 63);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 20;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // cmbFiltrarPor
            // 
            cmbFiltrarPor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltrarPor.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            cmbFiltrarPor.FormattingEnabled = true;
            cmbFiltrarPor.Location = new Point(3, 24);
            cmbFiltrarPor.Margin = new Padding(3, 2, 3, 2);
            cmbFiltrarPor.Name = "cmbFiltrarPor";
            cmbFiltrarPor.Size = new Size(177, 32);
            cmbFiltrarPor.TabIndex = 18;
            cmbFiltrarPor.SelectedIndexChanged += cmbFiltrarPor_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(253, 24);
            label1.TabIndex = 17;
            label1.Text = "Filtrar por Tipo de Cultivo:";
            // 
            // laaa
            // 
            laaa.AutoSize = true;
            laaa.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            laaa.ForeColor = Color.White;
            laaa.Location = new Point(3, 63);
            laaa.Name = "laaa";
            laaa.Size = new Size(91, 24);
            laaa.TabIndex = 16;
            laaa.Text = "Nombre:";
            // 
            // txtBuscar
            // 
            txtBuscar.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtBuscar.Location = new Point(110, 58);
            txtBuscar.Margin = new Padding(2);
            txtBuscar.MaxLength = 40;
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(399, 29);
            txtBuscar.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.Controls.Add(dtgvListarVegetales);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 91);
            panel3.Margin = new Padding(2);
            panel3.Name = "panel3";
            panel3.Size = new Size(667, 286);
            panel3.TabIndex = 2;
            // 
            // dtgvListarVegetales
            // 
            dtgvListarVegetales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.MediumSeaGreen;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dtgvListarVegetales.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dtgvListarVegetales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dtgvListarVegetales.DefaultCellStyle = dataGridViewCellStyle2;
            dtgvListarVegetales.Dock = DockStyle.Fill;
            dtgvListarVegetales.EnableHeadersVisualStyles = false;
            dtgvListarVegetales.Location = new Point(0, 0);
            dtgvListarVegetales.Margin = new Padding(2);
            dtgvListarVegetales.Name = "dtgvListarVegetales";
            dtgvListarVegetales.ReadOnly = true;
            dtgvListarVegetales.RowHeadersWidth = 62;
            dtgvListarVegetales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgvListarVegetales.Size = new Size(667, 286);
            dtgvListarVegetales.TabIndex = 0;
            // 
            // ListarVegetales
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(141, 181, 146);
            ClientSize = new Size(772, 377);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Margin = new Padding(2);
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
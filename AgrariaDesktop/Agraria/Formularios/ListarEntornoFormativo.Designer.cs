namespace Agraria.Formularios
{
    partial class ListarEntornoFormativo	
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
            panel1 = new Panel();
            btnNuevo = new Button();
            btnModificar = new Button();
            btnImprimir = new Button();
            btnSalir = new Button();
            panel2 = new Panel();
            btnBuscar = new Button();
            laaa = new Label();
            txtBuscar = new TextBox();
            panel3 = new Panel();
            dtgvListarEntornoFormativo = new DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgvListarEntornoFormativo).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnNuevo);
            panel1.Controls.Add(btnModificar);
            panel1.Controls.Add(btnImprimir);
            panel1.Controls.Add(btnSalir);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(719, 114);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(131, 263);
            panel1.TabIndex = 0;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(37, 14);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(75, 23);
            btnNuevo.TabIndex = 4;
            btnNuevo.Text = "&Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(37, 44);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(75, 23);
            btnModificar.TabIndex = 5;
            btnModificar.Text = "&Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnImprimir
            // 
            btnImprimir.Location = new Point(37, 73);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(75, 23);
            btnImprimir.TabIndex = 6;
            btnImprimir.Text = "Im&primir";
            btnImprimir.UseVisualStyleBackColor = true;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(37, 230);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 7;
            btnSalir.Text = "&Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnBuscar);
            panel2.Controls.Add(laaa);
            panel2.Controls.Add(txtBuscar);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(2);
            panel2.Name = "panel2";
            panel2.Size = new Size(850, 114);
            panel2.TabIndex = 1;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(756, 70);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 3;
            btnBuscar.Text = "&Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // laaa
            // 
            laaa.AutoSize = true;
            laaa.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            laaa.ForeColor = Color.White;
            laaa.Location = new Point(5, 67);
            laaa.Name = "laaa";
            laaa.Size = new Size(85, 24);
            laaa.TabIndex = 16;
            laaa.Text = "Nombre";
            // 
            // txtBuscar
            // 
            txtBuscar.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtBuscar.Location = new Point(95, 62);
            txtBuscar.Margin = new Padding(2);
            txtBuscar.MaxLength = 40;
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(149, 29);
            txtBuscar.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.Controls.Add(dtgvListarEntornoFormativo);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 114);
            panel3.Margin = new Padding(2);
            panel3.Name = "panel3";
            panel3.Size = new Size(719, 263);
            panel3.TabIndex = 2;
            // 
            // dtgvListarEntornoFormativo
            // 
            dtgvListarEntornoFormativo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.MediumSeaGreen;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dtgvListarEntornoFormativo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dtgvListarEntornoFormativo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dtgvListarEntornoFormativo.DefaultCellStyle = dataGridViewCellStyle2;
            dtgvListarEntornoFormativo.Dock = DockStyle.Fill;
            dtgvListarEntornoFormativo.EnableHeadersVisualStyles = false;
            dtgvListarEntornoFormativo.Location = new Point(0, 0);
            dtgvListarEntornoFormativo.Margin = new Padding(2);
            dtgvListarEntornoFormativo.Name = "dtgvListarEntornoFormativo";
            dtgvListarEntornoFormativo.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dtgvListarEntornoFormativo.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dtgvListarEntornoFormativo.RowHeadersWidth = 62;
            dtgvListarEntornoFormativo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgvListarEntornoFormativo.Size = new Size(719, 263);
            dtgvListarEntornoFormativo.TabIndex = 0;
            // 
            // ListarEntornoFormativo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(141, 181, 146);
            ClientSize = new Size(850, 377);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Margin = new Padding(2);
            Name = "ListarEntornoFormativo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Listar Entorno Formativo";
            Load += ListarEntornoFormativo_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtgvListarEntornoFormativo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private DataGridView dtgvListarEntornoFormativo;
        private TextBox txtBuscar;
        private Label laaa;
        private Button btnNuevo;
        private Button btnImprimir;
        private Button btnModificar;
        private Button btnSalir;
        private Button btnBuscar;
    }
}
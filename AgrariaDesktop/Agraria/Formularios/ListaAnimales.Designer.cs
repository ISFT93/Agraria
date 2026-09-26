namespace Agraria.Formularios
{
    partial class ListaAnimales
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
            timer1 = new System.Windows.Forms.Timer(components);
            panel = new Panel();
            BtnBuscar = new Button();
            CbFiltrar = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            TxtNombre = new TextBox();
            LblBuscar = new Label();
            label9 = new Label();
            panel1 = new Panel();
            DtgAnimal = new DataGridView();
            panel3 = new Panel();
            BtnImprimir = new Button();
            BtnModificar = new Button();
            BtnSalir = new Button();
            BtnNuevo = new Button();
            panel.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DtgAnimal).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel
            // 
            panel.Controls.Add(BtnBuscar);
            panel.Controls.Add(CbFiltrar);
            panel.Controls.Add(label1);
            panel.Controls.Add(label2);
            panel.Controls.Add(TxtNombre);
            panel.Controls.Add(LblBuscar);
            panel.Controls.Add(label9);
            panel.Dock = DockStyle.Top;
            panel.Location = new Point(0, 0);
            panel.Name = "panel";
            panel.Size = new Size(850, 132);
            panel.TabIndex = 22;
            // 
            // BtnBuscar
            // 
            BtnBuscar.Location = new Point(750, 72);
            BtnBuscar.Margin = new Padding(3, 2, 3, 2);
            BtnBuscar.Name = "BtnBuscar";
            BtnBuscar.Size = new Size(75, 23);
            BtnBuscar.TabIndex = 37;
            BtnBuscar.Text = "&Buscar";
            BtnBuscar.UseVisualStyleBackColor = true;
            BtnBuscar.Click += BtnBuscar_Click;
            // 
            // CbFiltrar
            // 
            CbFiltrar.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CbFiltrar.FormattingEnabled = true;
            CbFiltrar.Location = new Point(131, 36);
            CbFiltrar.Name = "CbFiltrar";
            CbFiltrar.Size = new Size(187, 32);
            CbFiltrar.TabIndex = 35;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(19, 39);
            label1.Name = "label1";
            label1.Size = new Size(106, 24);
            label1.TabIndex = 34;
            label1.Text = "Filtrar por:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(172, 22);
            label2.Name = "label2";
            label2.Size = new Size(0, 15);
            label2.TabIndex = 33;
            // 
            // TxtNombre
            // 
            TxtNombre.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            TxtNombre.Location = new Point(131, 70);
            TxtNombre.Name = "TxtNombre";
            TxtNombre.Size = new Size(232, 29);
            TxtNombre.TabIndex = 32;
            // 
            // LblBuscar
            // 
            LblBuscar.AutoSize = true;
            LblBuscar.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            LblBuscar.ForeColor = Color.White;
            LblBuscar.Location = new Point(12, 74);
            LblBuscar.Name = "LblBuscar";
            LblBuscar.Size = new Size(91, 24);
            LblBuscar.TabIndex = 31;
            LblBuscar.Text = "Nombre:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(172, 57);
            label9.Name = "label9";
            label9.Size = new Size(0, 15);
            label9.TabIndex = 29;
            // 
            // panel1
            // 
            panel2.Controls.Add(DtgAnimal);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 152);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(972, 354);
            panel2.TabIndex = 23;
            // 
            // DtgAnimal
            // 
            DtgAnimal.AllowUserToAddRows = false;
            DtgAnimal.AllowUserToResizeColumns = false;
            DtgAnimal.AllowUserToResizeRows = false;
            DtgAnimal.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.MediumSeaGreen;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            DtgAnimal.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            DtgAnimal.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            DtgAnimal.DefaultCellStyle = dataGridViewCellStyle2;
            DtgAnimal.Dock = DockStyle.Fill;
            DtgAnimal.EnableHeadersVisualStyles = false;
            DtgAnimal.Location = new Point(0, 0);
            DtgAnimal.Name = "DtgAnimal";
            DtgAnimal.ReadOnly = true;
            DtgAnimal.RowHeadersWidth = 51;
            DtgAnimal.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DtgAnimal.Size = new Size(972, 354);
            DtgAnimal.TabIndex = 26;
            // 
            // panel3
            // 
            panel3.Controls.Add(BtnImprimir);
            panel3.Controls.Add(BtnModificar);
            panel3.Controls.Add(BtnSalir);
            panel3.Controls.Add(BtnNuevo);
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(719, 132);
            panel3.Name = "panel3";
            panel3.Size = new Size(131, 248);
            panel3.TabIndex = 24;
            // 
            // BtnImprimir
            // 
            BtnImprimir.Location = new Point(31, 61);
            BtnImprimir.Margin = new Padding(3, 2, 3, 2);
            BtnImprimir.Name = "BtnImprimir";
            BtnImprimir.Size = new Size(75, 23);
            BtnImprimir.TabIndex = 46;
            BtnImprimir.Text = "Im&primir";
            BtnImprimir.UseVisualStyleBackColor = true;
            BtnImprimir.Click += BtnImprimir_Click_1;
            // 
            // BtnModificar
            // 
            BtnModificar.Location = new Point(31, 33);
            BtnModificar.Margin = new Padding(3, 2, 3, 2);
            BtnModificar.Name = "BtnModificar";
            BtnModificar.Size = new Size(75, 23);
            BtnModificar.TabIndex = 46;
            BtnModificar.Text = "&Modificar";
            BtnModificar.UseVisualStyleBackColor = true;
            BtnModificar.Click += BtnModificar_Click_1;
            // 
            // BtnSalir
            // 
            BtnSalir.Location = new Point(31, 233);
            BtnSalir.Margin = new Padding(3, 2, 3, 2);
            BtnSalir.Name = "BtnSalir";
            BtnSalir.Size = new Size(75, 23);
            BtnSalir.TabIndex = 46;
            BtnSalir.Text = "&Salir";
            BtnSalir.UseVisualStyleBackColor = true;
            BtnSalir.Click += BtnSalir_Click_1;
            // 
            // BtnNuevo
            // 
            BtnNuevo.Location = new Point(31, 5);
            BtnNuevo.Margin = new Padding(3, 2, 3, 2);
            BtnNuevo.Name = "BtnNuevo";
            BtnNuevo.Size = new Size(75, 23);
            BtnNuevo.TabIndex = 46;
            BtnNuevo.Text = "&Nuevo";
            BtnNuevo.UseVisualStyleBackColor = true;
            BtnNuevo.Click += BtnNuevo_Click_1;
            // 
            // FormAnimal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(141, 181, 146);
            ClientSize = new Size(850, 380);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(panel);
            Name = "FormAnimal";
            Text = "Reino Animal";
            Load += FormAnimal_Load;
            panel.ResumeLayout(false);
            panel.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DtgAnimal).EndInit();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private Panel panel;
        private ComboBox CbFiltrar;
        private Label label1;
        private Label label2;
        private TextBox TxtNombre;
        private Label LblBuscar;
        private Label label9;
        private Panel panel1;
        private Panel panel3;
        private Button BtnBuscar;
        private Button BtnNuevo;
        private Button BtnImprimir;
        private Button BtnModificar;
        private Button BtnSalir;
        private DataGridView DtgAnimal;
    }
}
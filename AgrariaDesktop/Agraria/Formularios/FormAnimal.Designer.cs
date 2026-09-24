namespace Agraria.Formularios
{
    partial class FormAnimal
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
            panel1 = new Panel();
            CbFiltrar = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            TxtNombre = new TextBox();
            LblBuscar = new Label();
            label9 = new Label();
            panel2 = new Panel();
            DtgAnimal = new DataGridView();
            panel3 = new Panel();
            BtnSalir = new Tienda.RJButton();
            BtnImprimir = new Tienda.RJButton();
            BtnModificar = new Tienda.RJButton();
            BtnBuscar = new Button();
            BtnNuevo = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DtgAnimal).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(BtnBuscar);
            panel1.Controls.Add(CbFiltrar);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(TxtNombre);
            panel1.Controls.Add(LblBuscar);
            panel1.Controls.Add(label9);
            panel1.Location = new Point(14, 40);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(983, 229);
            panel1.TabIndex = 22;
            // 
            // CbFiltrar
            // 
            CbFiltrar.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CbFiltrar.FormattingEnabled = true;
            CbFiltrar.Location = new Point(150, 48);
            CbFiltrar.Margin = new Padding(3, 4, 3, 4);
            CbFiltrar.Name = "CbFiltrar";
            CbFiltrar.Size = new Size(213, 37);
            CbFiltrar.TabIndex = 35;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(22, 52);
            label1.Name = "label1";
            label1.Size = new Size(135, 29);
            label1.TabIndex = 34;
            label1.Text = "Filtrar por:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(197, 29);
            label2.Name = "label2";
            label2.Size = new Size(0, 20);
            label2.TabIndex = 33;
            // 
            // TxtNombre
            // 
            TxtNombre.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            TxtNombre.Location = new Point(150, 147);
            TxtNombre.Margin = new Padding(3, 4, 3, 4);
            TxtNombre.Name = "TxtNombre";
            TxtNombre.Size = new Size(265, 34);
            TxtNombre.TabIndex = 32;
            // 
            // LblBuscar
            // 
            LblBuscar.AutoSize = true;
            LblBuscar.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            LblBuscar.ForeColor = Color.White;
            LblBuscar.Location = new Point(22, 151);
            LblBuscar.Name = "LblBuscar";
            LblBuscar.Size = new Size(114, 29);
            LblBuscar.TabIndex = 31;
            LblBuscar.Text = "Nombre:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(197, 76);
            label9.Name = "label9";
            label9.Size = new Size(0, 20);
            label9.TabIndex = 29;
            // 
            // panel2
            // 
            panel2.Controls.Add(DtgAnimal);
            panel2.Location = new Point(14, 277);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(746, 355);
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
            DtgAnimal.EnableHeadersVisualStyles = false;
            DtgAnimal.Location = new Point(0, 0);
            DtgAnimal.Margin = new Padding(3, 4, 3, 4);
            DtgAnimal.Name = "DtgAnimal";
            DtgAnimal.ReadOnly = true;
            DtgAnimal.RowHeadersWidth = 51;
            DtgAnimal.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DtgAnimal.Size = new Size(746, 355);
            DtgAnimal.TabIndex = 0;
            DtgAnimal.CellContentClick += DtgAnimal_CellContentClick;
            // 
            // panel3
            // 
            panel3.Controls.Add(BtnNuevo);
            panel3.Controls.Add(BtnSalir);
            panel3.Controls.Add(BtnImprimir);
            panel3.Controls.Add(BtnModificar);
            panel3.Location = new Point(767, 277);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(230, 355);
            panel3.TabIndex = 24;
            // 
            // BtnSalir
            // 
            BtnSalir.BackColor = Color.White;
            BtnSalir.FlatAppearance.BorderSize = 0;
            BtnSalir.FlatStyle = FlatStyle.Flat;
            BtnSalir.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            BtnSalir.ForeColor = Color.Green;
            BtnSalir.Location = new Point(29, 245);
            BtnSalir.Margin = new Padding(3, 4, 3, 4);
            BtnSalir.Name = "BtnSalir";
            BtnSalir.Size = new Size(171, 53);
            BtnSalir.TabIndex = 42;
            BtnSalir.Text = "Salir";
            BtnSalir.UseVisualStyleBackColor = false;
            BtnSalir.Click += BtnSalir_Click_1;
            // 
            // BtnImprimir
            // 
            BtnImprimir.BackColor = Color.White;
            BtnImprimir.FlatAppearance.BorderSize = 0;
            BtnImprimir.FlatStyle = FlatStyle.Flat;
            BtnImprimir.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            BtnImprimir.ForeColor = Color.Green;
            BtnImprimir.Location = new Point(29, 184);
            BtnImprimir.Margin = new Padding(3, 4, 3, 4);
            BtnImprimir.Name = "BtnImprimir";
            BtnImprimir.Size = new Size(171, 53);
            BtnImprimir.TabIndex = 43;
            BtnImprimir.Text = "Imprimir";
            BtnImprimir.UseVisualStyleBackColor = false;
            BtnImprimir.Click += BtnImprimir_Click_1;
            // 
            // BtnModificar
            // 
            BtnModificar.BackColor = Color.White;
            BtnModificar.FlatAppearance.BorderSize = 0;
            BtnModificar.FlatStyle = FlatStyle.Flat;
            BtnModificar.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            BtnModificar.ForeColor = Color.Green;
            BtnModificar.Location = new Point(29, 123);
            BtnModificar.Margin = new Padding(3, 4, 3, 4);
            BtnModificar.Name = "BtnModificar";
            BtnModificar.Size = new Size(171, 53);
            BtnModificar.TabIndex = 44;
            BtnModificar.Text = "Modificar";
            BtnModificar.UseVisualStyleBackColor = false;
            BtnModificar.Click += BtnModificar_Click_1;
            // 
            // BtnBuscar
            // 
            BtnBuscar.Location = new Point(799, 147);
            BtnBuscar.Name = "BtnBuscar";
            BtnBuscar.Size = new Size(140, 46);
            BtnBuscar.TabIndex = 37;
            BtnBuscar.Text = "Buscar";
            BtnBuscar.UseVisualStyleBackColor = true;
            BtnBuscar.Click += BtnBuscar_Click;
            // 
            // BtnNuevo
            // 
            BtnNuevo.Location = new Point(46, 29);
            BtnNuevo.Name = "BtnNuevo";
            BtnNuevo.Size = new Size(142, 39);
            BtnNuevo.TabIndex = 46;
            BtnNuevo.Text = "Nuevo";
            BtnNuevo.UseVisualStyleBackColor = true;
            BtnNuevo.Click += BtnNuevo_Click_1;
            // 
            // FormAnimal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(141, 181, 146);
            ClientSize = new Size(1010, 681);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormAnimal";
            Text = "FormAnimal";
            Load += FormAnimal_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DtgAnimal).EndInit();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private Panel panel1;
        private ComboBox CbFiltrar;
        private Label label1;
        private Label label2;
        private TextBox TxtNombre;
        private Label LblBuscar;
        private Label label9;
        private Panel panel2;
        private Panel panel3;
        private Tienda.RJButton BtnSalir;
        private Tienda.RJButton BtnImprimir;
        private Tienda.RJButton BtnModificar;
        private DataGridView DtgAnimal;
        private Button BtnBuscar;
        private Button BtnNuevo;
    }
}
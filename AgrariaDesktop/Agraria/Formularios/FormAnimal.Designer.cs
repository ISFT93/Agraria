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
            BtnBuscar = new Tienda.RJButton();
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
            BtnNuevo = new Tienda.RJButton();
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
            panel1.Location = new Point(12, 30);
            panel1.Name = "panel1";
            panel1.Size = new Size(860, 172);
            panel1.TabIndex = 22;
            // 
            // BtnBuscar
            // 
            BtnBuscar.BackColor = Color.White;
            BtnBuscar.FlatAppearance.BorderSize = 0;
            BtnBuscar.FlatStyle = FlatStyle.Flat;
            BtnBuscar.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnBuscar.ForeColor = Color.Green;
            BtnBuscar.Location = new Point(684, 113);
            BtnBuscar.Name = "BtnBuscar";
            BtnBuscar.Size = new Size(150, 40);
            BtnBuscar.TabIndex = 36;
            BtnBuscar.Text = "Buscar";
            BtnBuscar.UseVisualStyleBackColor = false;
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
            TxtNombre.Location = new Point(131, 110);
            TxtNombre.Name = "TxtNombre";
            TxtNombre.Size = new Size(232, 29);
            TxtNombre.TabIndex = 32;
            // 
            // LblBuscar
            // 
            LblBuscar.AutoSize = true;
            LblBuscar.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            LblBuscar.ForeColor = Color.White;
            LblBuscar.Location = new Point(19, 113);
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
            // panel2
            // 
            panel2.Controls.Add(DtgAnimal);
            panel2.Location = new Point(12, 208);
            panel2.Name = "panel2";
            panel2.Size = new Size(653, 266);
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
            DtgAnimal.Name = "DtgAnimal";
            DtgAnimal.ReadOnly = true;
            DtgAnimal.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DtgAnimal.Size = new Size(653, 266);
            DtgAnimal.TabIndex = 0;
            DtgAnimal.CellContentClick += DtgAnimal_CellContentClick;
            // 
            // panel3
            // 
            panel3.Controls.Add(BtnSalir);
            panel3.Controls.Add(BtnImprimir);
            panel3.Controls.Add(BtnModificar);
            panel3.Controls.Add(BtnNuevo);
            panel3.Location = new Point(671, 208);
            panel3.Name = "panel3";
            panel3.Size = new Size(201, 266);
            panel3.TabIndex = 24;
            // 
            // BtnSalir
            // 
            BtnSalir.BackColor = Color.White;
            BtnSalir.FlatAppearance.BorderSize = 0;
            BtnSalir.FlatStyle = FlatStyle.Flat;
            BtnSalir.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            BtnSalir.ForeColor = Color.Green;
            BtnSalir.Location = new Point(25, 184);
            BtnSalir.Name = "BtnSalir";
            BtnSalir.Size = new Size(150, 40);
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
            BtnImprimir.Location = new Point(25, 138);
            BtnImprimir.Name = "BtnImprimir";
            BtnImprimir.Size = new Size(150, 40);
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
            BtnModificar.Location = new Point(25, 92);
            BtnModificar.Name = "BtnModificar";
            BtnModificar.Size = new Size(150, 40);
            BtnModificar.TabIndex = 44;
            BtnModificar.Text = "Modificar";
            BtnModificar.UseVisualStyleBackColor = false;
            BtnModificar.Click += BtnModificar_Click_1;
            // 
            // BtnNuevo
            // 
            BtnNuevo.BackColor = Color.White;
            BtnNuevo.FlatAppearance.BorderSize = 0;
            BtnNuevo.FlatStyle = FlatStyle.Flat;
            BtnNuevo.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            BtnNuevo.ForeColor = Color.Green;
            BtnNuevo.Location = new Point(25, 46);
            BtnNuevo.Name = "BtnNuevo";
            BtnNuevo.Size = new Size(150, 40);
            BtnNuevo.TabIndex = 45;
            BtnNuevo.Text = "Nuevo";
            BtnNuevo.UseVisualStyleBackColor = false;
            BtnNuevo.Click += BtnNuevo_Click_1;
            // 
            // FormAnimal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(141, 181, 146);
            ClientSize = new Size(884, 511);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
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
        private Tienda.RJButton BtnBuscar;
        private Label label9;
        private Panel panel2;
        private Panel panel3;
        private Tienda.RJButton BtnSalir;
        private Tienda.RJButton BtnImprimir;
        private Tienda.RJButton BtnModificar;
        private Tienda.RJButton BtnNuevo;
        private DataGridView DtgAnimal;
    }
}
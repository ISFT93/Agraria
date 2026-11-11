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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            timer1 = new System.Windows.Forms.Timer(components);
            panel1 = new Panel();
            BtnBuscar = new Button();
            CbFiltrar = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            TxtNombre = new TextBox();
            LblBuscar = new Label();
            label9 = new Label();
            panel2 = new Panel();
            DtgAnimal = new DataGridView();
            panel3 = new Panel();
            BtnImprimir = new Button();
            BtnModificar = new Button();
            BtnSalir = new Button();
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
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(4, 106);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(1206, 190);
            panel1.TabIndex = 22;
            // 
            // BtnBuscar
            // 
            BtnBuscar.Location = new Point(1071, 120);
            BtnBuscar.Margin = new Padding(4, 4, 4, 4);
            BtnBuscar.Name = "BtnBuscar";
            BtnBuscar.Size = new Size(108, 39);
            BtnBuscar.TabIndex = 37;
            BtnBuscar.Text = "&Buscar";
            BtnBuscar.UseVisualStyleBackColor = true;
            BtnBuscar.Click += BtnBuscar_Click;
            // 
            // CbFiltrar
            // 
            CbFiltrar.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CbFiltrar.FormattingEnabled = true;
            CbFiltrar.Location = new Point(166, 41);
            CbFiltrar.Margin = new Padding(4, 5, 4, 5);
            CbFiltrar.Name = "CbFiltrar";
            CbFiltrar.Size = new Size(265, 41);
            CbFiltrar.TabIndex = 35;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(6, 46);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(152, 33);
            label1.TabIndex = 34;
            label1.Text = "Filtrar por";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(224, 19);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(0, 25);
            label2.TabIndex = 33;
            // 
            // TxtNombre
            // 
            TxtNombre.BorderStyle = BorderStyle.FixedSingle;
            TxtNombre.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            TxtNombre.Location = new Point(136, 106);
            TxtNombre.Margin = new Padding(4, 5, 4, 5);
            TxtNombre.Name = "TxtNombre";
            TxtNombre.Size = new Size(536, 40);
            TxtNombre.TabIndex = 32;
            // 
            // LblBuscar
            // 
            LblBuscar.AutoSize = true;
            LblBuscar.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            LblBuscar.ForeColor = Color.White;
            LblBuscar.Location = new Point(6, 106);
            LblBuscar.Margin = new Padding(4, 0, 4, 0);
            LblBuscar.Name = "LblBuscar";
            LblBuscar.Size = new Size(125, 33);
            LblBuscar.TabIndex = 31;
            LblBuscar.Text = "Nombre";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(224, 76);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(0, 25);
            label9.TabIndex = 29;
            // 
            // panel2
            // 
            panel2.Controls.Add(DtgAnimal);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(4, 296);
            panel2.Margin = new Padding(4, 6, 4, 6);
            panel2.Name = "panel2";
            panel2.Size = new Size(1018, 333);
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
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            DtgAnimal.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            DtgAnimal.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            DtgAnimal.DefaultCellStyle = dataGridViewCellStyle2;
            DtgAnimal.Dock = DockStyle.Fill;
            DtgAnimal.EnableHeadersVisualStyles = false;
            DtgAnimal.Location = new Point(0, 0);
            DtgAnimal.Margin = new Padding(4, 5, 4, 5);
            DtgAnimal.Name = "DtgAnimal";
            DtgAnimal.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            DtgAnimal.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            DtgAnimal.RowHeadersWidth = 51;
            DtgAnimal.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DtgAnimal.Size = new Size(1018, 333);
            DtgAnimal.TabIndex = 26;
            // 
            // panel3
            // 
            panel3.Controls.Add(BtnImprimir);
            panel3.Controls.Add(BtnModificar);
            panel3.Controls.Add(BtnSalir);
            panel3.Controls.Add(BtnNuevo);
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(1022, 296);
            panel3.Margin = new Padding(4, 5, 4, 5);
            panel3.Name = "panel3";
            panel3.Size = new Size(188, 333);
            panel3.TabIndex = 24;
            // 
            // BtnImprimir
            // 
            BtnImprimir.Location = new Point(44, 119);
            BtnImprimir.Margin = new Padding(4, 4, 4, 4);
            BtnImprimir.Name = "BtnImprimir";
            BtnImprimir.Size = new Size(108, 39);
            BtnImprimir.TabIndex = 46;
            BtnImprimir.Text = "Im&primir";
            BtnImprimir.UseVisualStyleBackColor = true;
            BtnImprimir.Click += BtnImprimir_Click_1;
            // 
            // BtnModificar
            // 
            BtnModificar.Location = new Point(44, 71);
            BtnModificar.Margin = new Padding(4, 4, 4, 4);
            BtnModificar.Name = "BtnModificar";
            BtnModificar.Size = new Size(108, 39);
            BtnModificar.TabIndex = 46;
            BtnModificar.Text = "&Modificar";
            BtnModificar.UseVisualStyleBackColor = true;
            BtnModificar.Click += BtnModificar_Click_1;
            // 
            // BtnSalir
            // 
            BtnSalir.Location = new Point(44, 386);
            BtnSalir.Margin = new Padding(4, 4, 4, 4);
            BtnSalir.Name = "BtnSalir";
            BtnSalir.Size = new Size(108, 39);
            BtnSalir.TabIndex = 46;
            BtnSalir.Text = "&Salir";
            BtnSalir.UseVisualStyleBackColor = true;
            BtnSalir.Click += BtnSalir_Click_1;
            // 
            // BtnNuevo
            // 
            BtnNuevo.Location = new Point(44, 25);
            BtnNuevo.Margin = new Padding(4, 4, 4, 4);
            BtnNuevo.Name = "BtnNuevo";
            BtnNuevo.Size = new Size(108, 39);
            BtnNuevo.TabIndex = 46;
            BtnNuevo.Text = "&Nuevo";
            BtnNuevo.UseVisualStyleBackColor = true;
            BtnNuevo.Click += BtnNuevo_Click_1;
            // 
            // ListaAnimales
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(141, 181, 146);
            ClientSize = new Size(1214, 634);
            Controls.Add(panel2);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "ListaAnimales";
            Padding = new Padding(4, 106, 4, 5);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lista de Animales";
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
        private Button BtnBuscar;
        private Button BtnNuevo;
        private Button BtnImprimir;
        private Button BtnModificar;
        private Button BtnSalir;
        private DataGridView DtgAnimal;
    }
}
namespace Agraria.Formularios
{
    partial class ItemAnimalControl
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            lblIdAnimal = new Label();
            txtIdAnimal = new TextBox();
            lblSexoAnimal = new Label();
            cmbSexoAnimal = new ComboBox();
            chkEsProductor = new CheckBox();
            SuspendLayout();
            // 
            // lblIdAnimal
            // 
            lblIdAnimal.AutoSize = true;
            lblIdAnimal.ForeColor = Color.White;
            lblIdAnimal.Location = new Point(-9, 13);
            lblIdAnimal.Name = "lblIdAnimal";
            lblIdAnimal.Size = new Size(78, 20);
            lblIdAnimal.TabIndex = 0;
            lblIdAnimal.Text = "ID Animal:";
            // 
            // txtIdAnimal
            // 
            txtIdAnimal.Location = new Point(75, 10);
            txtIdAnimal.Margin = new Padding(3, 4, 3, 4);
            txtIdAnimal.Name = "txtIdAnimal";
            txtIdAnimal.Size = new Size(100, 27);
            txtIdAnimal.TabIndex = 1;
            // 
            // lblSexoAnimal
            // 
            lblSexoAnimal.AutoSize = true;
            lblSexoAnimal.ForeColor = Color.White;
            lblSexoAnimal.Location = new Point(190, 13);
            lblSexoAnimal.Name = "lblSexoAnimal";
            lblSexoAnimal.Size = new Size(44, 20);
            lblSexoAnimal.TabIndex = 2;
            lblSexoAnimal.Text = "Sexo:";
            // 
            // cmbSexoAnimal
            // 
            cmbSexoAnimal.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSexoAnimal.FormattingEnabled = true;
            cmbSexoAnimal.Location = new Point(249, 10);
            cmbSexoAnimal.Margin = new Padding(3, 4, 3, 4);
            cmbSexoAnimal.Name = "cmbSexoAnimal";
            cmbSexoAnimal.Size = new Size(100, 28);
            cmbSexoAnimal.TabIndex = 3;
            // 
            // chkEsProductor
            // 
            chkEsProductor.AutoSize = true;
            chkEsProductor.ForeColor = Color.White;
            chkEsProductor.Location = new Point(355, 12);
            chkEsProductor.Margin = new Padding(3, 4, 3, 4);
            chkEsProductor.Name = "chkEsProductor";
            chkEsProductor.Size = new Size(114, 24);
            chkEsProductor.TabIndex = 4;
            chkEsProductor.Text = "Es Productor";
            chkEsProductor.UseVisualStyleBackColor = true;
            // 
            // ItemAnimalControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(chkEsProductor);
            Controls.Add(cmbSexoAnimal);
            Controls.Add(lblSexoAnimal);
            Controls.Add(txtIdAnimal);
            Controls.Add(lblIdAnimal);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ItemAnimalControl";
            Size = new Size(480, 50);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIdAnimal;
        private System.Windows.Forms.TextBox txtIdAnimal;
        private System.Windows.Forms.Label lblSexoAnimal;
        private System.Windows.Forms.ComboBox cmbSexoAnimal;
        private System.Windows.Forms.CheckBox chkEsProductor;
    }
}
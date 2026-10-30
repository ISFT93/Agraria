namespace Agraria.Formularios
{
    partial class DetallesAnimal
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            btnAceptar = new Button();
            btnCancelar = new Button();
            panelContenedor = new Panel();
            SuspendLayout();
            // 
            // btnAceptar
            // 
            btnAceptar.Font = new Font("Segoe UI", 9F);
            btnAceptar.Location = new Point(447, 425);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(90, 35);
            btnAceptar.TabIndex = 1;
            btnAceptar.Text = "&Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Font = new Font("Segoe UI", 9F);
            btnCancelar.Location = new Point(552, 425);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(90, 35);
            btnCancelar.TabIndex = 2;
            btnCancelar.Text = "&Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // panelContenedor
            // 
            panelContenedor.AutoScroll = true;
            panelContenedor.BackColor = Color.FromArgb(141, 181, 146);
            panelContenedor.Dock = DockStyle.Fill;
            panelContenedor.Location = new Point(3, 85);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(654, 417);
            panelContenedor.TabIndex = 3;
            // 
            // DetallesAnimal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(141, 181, 146);
            ClientSize = new Size(660, 506);
            Controls.Add(panelContenedor);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DetallesAnimal";
            Padding = new Padding(3, 85, 3, 4);
            StartPosition = FormStartPosition.CenterParent;
            Text = "Detalle de Animales";
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel panelContenedor;
    }
}
namespace Agraria
{
    partial class Inicio
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
            menuStrip1 = new MenuStrip();
            archivoToolStripMenuItem = new ToolStripMenuItem();
            iniciarSesionToolStripMenuItem = new ToolStripMenuItem();
            cerrarSesionToolStripMenuItem = new ToolStripMenuItem();
            editarToolStripMenuItem = new ToolStripMenuItem();
            altaDeUsuarioToolStripMenuItem = new ToolStripMenuItem();
            administracionToolStripMenuItem = new ToolStripMenuItem();
            entornosFormativosToolStripMenuItem = new ToolStripMenuItem();
            verToolStripMenuItem = new ToolStripMenuItem();
            ArticulosToolStripMenuItem = new ToolStripMenuItem();
            EntornoAnimalToolStripMenuItem = new ToolStripMenuItem();
            EntornoVegetalToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            herramientasToolStripMenuItem = new ToolStripMenuItem();
            ayudaToolStripMenuItem = new ToolStripMenuItem();
            manualDeUsuarioToolStripMenuItem = new ToolStripMenuItem();
            ciclosToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { archivoToolStripMenuItem, editarToolStripMenuItem, verToolStripMenuItem, herramientasToolStripMenuItem, ayudaToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 3, 0, 3);
            menuStrip1.Size = new Size(1262, 30);
            menuStrip1.TabIndex = 9;
            menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            archivoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { iniciarSesionToolStripMenuItem, cerrarSesionToolStripMenuItem });
            archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            archivoToolStripMenuItem.Size = new Size(73, 24);
            archivoToolStripMenuItem.Text = "Archivo";
            // 
            // iniciarSesionToolStripMenuItem
            // 
            iniciarSesionToolStripMenuItem.Name = "iniciarSesionToolStripMenuItem";
            iniciarSesionToolStripMenuItem.Size = new Size(179, 26);
            iniciarSesionToolStripMenuItem.Text = "Iniciar Sesion";
            iniciarSesionToolStripMenuItem.Click += btnIniciar_Click;
            // 
            // cerrarSesionToolStripMenuItem
            // 
            cerrarSesionToolStripMenuItem.Name = "cerrarSesionToolStripMenuItem";
            cerrarSesionToolStripMenuItem.Size = new Size(179, 26);
            cerrarSesionToolStripMenuItem.Text = "Cerrar Sesion";
            cerrarSesionToolStripMenuItem.Click += btnCerrarSesion_Click;
            // 
            // editarToolStripMenuItem
            // 
            editarToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { altaDeUsuarioToolStripMenuItem, administracionToolStripMenuItem, entornosFormativosToolStripMenuItem });
            editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            editarToolStripMenuItem.Size = new Size(62, 24);
            editarToolStripMenuItem.Text = "Editar";
            // 
            // altaDeUsuarioToolStripMenuItem
            // 
            altaDeUsuarioToolStripMenuItem.Name = "altaDeUsuarioToolStripMenuItem";
            altaDeUsuarioToolStripMenuItem.Size = new Size(227, 26);
            altaDeUsuarioToolStripMenuItem.Text = "Alta de Usuario";
            altaDeUsuarioToolStripMenuItem.Click += btnUsuarioAlta_Click;
            // 
            // administracionToolStripMenuItem
            // 
            administracionToolStripMenuItem.Name = "administracionToolStripMenuItem";
            administracionToolStripMenuItem.Size = new Size(227, 26);
            administracionToolStripMenuItem.Text = "Administracion";
            administracionToolStripMenuItem.Click += btnAdministracion_Click;
            // 
            // entornosFormativosToolStripMenuItem
            // 
            entornosFormativosToolStripMenuItem.Name = "entornosFormativosToolStripMenuItem";
            entornosFormativosToolStripMenuItem.Size = new Size(227, 26);
            entornosFormativosToolStripMenuItem.Text = "Entornos Formativos";
            entornosFormativosToolStripMenuItem.Click += btnEntornoFormativo_Click;
            // 
            // verToolStripMenuItem
            // 
            verToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ArticulosToolStripMenuItem, EntornoAnimalToolStripMenuItem, EntornoVegetalToolStripMenuItem, toolStripMenuItem2 });
            verToolStripMenuItem.Name = "verToolStripMenuItem";
            verToolStripMenuItem.Size = new Size(44, 24);
            verToolStripMenuItem.Text = "Ver";
            // 
            // ArticulosToolStripMenuItem
            // 
            ArticulosToolStripMenuItem.Name = "ArticulosToolStripMenuItem";
            ArticulosToolStripMenuItem.Size = new Size(224, 26);
            ArticulosToolStripMenuItem.Text = "Artículos";
            ArticulosToolStripMenuItem.Click += btnArticulos_Click;
            // 
            // EntornoAnimalToolStripMenuItem
            // 
            EntornoAnimalToolStripMenuItem.Name = "EntornoAnimalToolStripMenuItem";
            EntornoAnimalToolStripMenuItem.Size = new Size(224, 26);
            EntornoAnimalToolStripMenuItem.Text = "Animales";
            EntornoAnimalToolStripMenuItem.Click += btnEntornoAnimal_Click;
            // 
            // EntornoVegetalToolStripMenuItem
            // 
            EntornoVegetalToolStripMenuItem.Name = "EntornoVegetalToolStripMenuItem";
            EntornoVegetalToolStripMenuItem.Size = new Size(224, 26);
            EntornoVegetalToolStripMenuItem.Text = "Vegetales";
            EntornoVegetalToolStripMenuItem.Click += btnEntornoVegetal_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(224, 26);
            toolStripMenuItem2.Text = "Stock";
            toolStripMenuItem2.Click += StocktoolStripMenuItem_Click;
            // 
            // herramientasToolStripMenuItem
            // 
            herramientasToolStripMenuItem.Name = "herramientasToolStripMenuItem";
            herramientasToolStripMenuItem.Size = new Size(112, 24);
            herramientasToolStripMenuItem.Text = "Herramientas";
            // 
            // ayudaToolStripMenuItem
            // 
            ayudaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { manualDeUsuarioToolStripMenuItem });
            ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            ayudaToolStripMenuItem.Size = new Size(65, 24);
            ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // manualDeUsuarioToolStripMenuItem
            // 
            manualDeUsuarioToolStripMenuItem.Name = "manualDeUsuarioToolStripMenuItem";
            manualDeUsuarioToolStripMenuItem.Size = new Size(216, 26);
            manualDeUsuarioToolStripMenuItem.Text = "Manual de Usuario";
            // 
            // ciclosToolStripMenuItem
            // 
            ciclosToolStripMenuItem.Name = "ciclosToolStripMenuItem";
            ciclosToolStripMenuItem.Size = new Size(180, 22);
            ciclosToolStripMenuItem.Text = "Ciclos";
            ciclosToolStripMenuItem.Click += ciclosToolStripMenuItem_Click;
            // 
            // Inicio
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1262, 749);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Inicio";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Escuela Agraria";
            Load += Inicio_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem archivoToolStripMenuItem;
        private ToolStripMenuItem editarToolStripMenuItem;
        private ToolStripMenuItem verToolStripMenuItem;
        private ToolStripMenuItem herramientasToolStripMenuItem;
        private ToolStripMenuItem ayudaToolStripMenuItem;
        private ToolStripMenuItem iniciarSesionToolStripMenuItem;
        private ToolStripMenuItem cerrarSesionToolStripMenuItem;
        private ToolStripMenuItem altaDeUsuarioToolStripMenuItem;
        private ToolStripMenuItem administracionToolStripMenuItem;
        private ToolStripMenuItem EntornoVegetalToolStripMenuItem;
        private ToolStripMenuItem ArticulosToolStripMenuItem;
        private ToolStripMenuItem manualDeUsuarioToolStripMenuItem;
        private ToolStripMenuItem entornosFormativosToolStripMenuItem;
        private ToolStripMenuItem EntornoAnimalToolStripMenuItem;
        private PictureBox pictureBox1;
        private ToolStripMenuItem stockToolStripMenuItem;
        private ToolStripMenuItem ciclosToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem2;
    }
}
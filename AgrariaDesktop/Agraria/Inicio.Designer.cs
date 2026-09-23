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
            produccionVegetalToolStripMenuItem = new ToolStripMenuItem();
            produccionAnimalToolStripMenuItem = new ToolStripMenuItem();
            industriaToolStripMenuItem = new ToolStripMenuItem();
            pañolToolStripMenuItem = new ToolStripMenuItem();
            herramientasToolStripMenuItem = new ToolStripMenuItem();
            inventarioToolStripMenuItem = new ToolStripMenuItem();
            ventasToolStripMenuItem = new ToolStripMenuItem();
            ayudaToolStripMenuItem = new ToolStripMenuItem();
            manualDeUsuarioToolStripMenuItem = new ToolStripMenuItem();
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
            verToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { produccionVegetalToolStripMenuItem, produccionAnimalToolStripMenuItem, industriaToolStripMenuItem, pañolToolStripMenuItem });
            verToolStripMenuItem.Name = "verToolStripMenuItem";
            verToolStripMenuItem.Size = new Size(44, 24);
            verToolStripMenuItem.Text = "Ver";
            // 
            // produccionVegetalToolStripMenuItem
            // 
            produccionVegetalToolStripMenuItem.Name = "produccionVegetalToolStripMenuItem";
            produccionVegetalToolStripMenuItem.Size = new Size(220, 26);
            produccionVegetalToolStripMenuItem.Text = "Produccion Vegetal";
            produccionVegetalToolStripMenuItem.Click += btnProduccionVegetal_Click;
            // 
            // produccionAnimalToolStripMenuItem
            // 
            produccionAnimalToolStripMenuItem.Name = "produccionAnimalToolStripMenuItem";
            produccionAnimalToolStripMenuItem.Size = new Size(220, 26);
            produccionAnimalToolStripMenuItem.Text = "Produccion Animal";
            produccionAnimalToolStripMenuItem.Click += btnProduccionAnimal_Click;
            // 
            // industriaToolStripMenuItem
            // 
            industriaToolStripMenuItem.Name = "industriaToolStripMenuItem";
            industriaToolStripMenuItem.Size = new Size(220, 26);
            industriaToolStripMenuItem.Text = "Industria";
            industriaToolStripMenuItem.Click += btnIndustria_Click;
            // 
            // pañolToolStripMenuItem
            // 
            pañolToolStripMenuItem.Name = "pañolToolStripMenuItem";
            pañolToolStripMenuItem.Size = new Size(220, 26);
            pañolToolStripMenuItem.Text = "Pañol";
            pañolToolStripMenuItem.Click += btnPañol_Click;
            // 
            // herramientasToolStripMenuItem
            // 
            herramientasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { inventarioToolStripMenuItem, ventasToolStripMenuItem });
            herramientasToolStripMenuItem.Name = "herramientasToolStripMenuItem";
            herramientasToolStripMenuItem.Size = new Size(112, 24);
            herramientasToolStripMenuItem.Text = "Herramientas";
            // 
            // inventarioToolStripMenuItem
            // 
            inventarioToolStripMenuItem.Name = "inventarioToolStripMenuItem";
            inventarioToolStripMenuItem.Size = new Size(158, 26);
            inventarioToolStripMenuItem.Text = "Inventario";
            inventarioToolStripMenuItem.Click += btnInventario_Click;
            // 
            // ventasToolStripMenuItem
            // 
            ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            ventasToolStripMenuItem.Size = new Size(158, 26);
            ventasToolStripMenuItem.Text = "Ventas";
            ventasToolStripMenuItem.Click += btnVenta_Click;
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
            // Inicio
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1262, 977);
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
        private ToolStripMenuItem produccionVegetalToolStripMenuItem;
        private ToolStripMenuItem produccionAnimalToolStripMenuItem;
        private ToolStripMenuItem industriaToolStripMenuItem;
        private ToolStripMenuItem pañolToolStripMenuItem;
        private ToolStripMenuItem inventarioToolStripMenuItem;
        private ToolStripMenuItem ventasToolStripMenuItem;
        private ToolStripMenuItem manualDeUsuarioToolStripMenuItem;
        private ToolStripMenuItem entornosFormativosToolStripMenuItem;
    }
}
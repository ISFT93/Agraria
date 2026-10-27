using Agraria.Datos.DAL;
using Agraria.Datos.DTO;
using Agraria.Datos.Entidades;
using Agraria.Negocio.BLL;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agraria.Formularios
{
    public partial class ListarCiclos : MaterialForm
    {


        private readonly UsuarioLoginDTO _usuarioLogeado;
        private readonly bool _esInvitado;
        private ListarCiclosBLL CiclosModeloBLL = new ListarCiclosBLL();
        public ListarCiclos(UsuarioLoginDTO usuarioLogeado, bool esInvitado)
        {
            InitializeComponent();
            _usuarioLogeado = usuarioLogeado;
            _esInvitado = esInvitado;


            // Configurar el MaterialSkinManager
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT; // O DARK

            // Configurar esquemas de color (Ejemplo: Azul / Indigo)
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Cyan800,
                Primary.Cyan900,
                Primary.Cyan500,
                Accent.Cyan200,
          TextShade.WHITE
            );
        }



        private void ListarCiclos_Load(object sender, EventArgs e)
        {
            CargarCiclosModelo();

        }
        private void CargarCiclosModelo(string filtro = "")
        {
            try
            {
                DataTable dt = CiclosModeloBLL.ObtenerCiclos(filtro);

                // Se asigna la fuente de datos directamente.
                // (El filtro local por 'tipo_cultivo' fue removido ya que la columna no existe en el nuevo esquema)
                dtgvListarCiclos.DataSource = dt;

                // Configuración de las nuevas columnas de ciclos_modelo
                if (dtgvListarCiclos.Columns["id_ciclo"] != null)
                {
                    dtgvListarCiclos.Columns["id_ciclo"].Visible = true;
                    dtgvListarCiclos.Columns["id_ciclo"].HeaderText = "Código";
                    dtgvListarCiclos.Columns["id_ciclo"].DisplayIndex = 0;
                }

                if (dtgvListarCiclos.Columns["nombre"] != null)
                    dtgvListarCiclos.Columns["nombre"].HeaderText = "Nombre del Ciclo";

                if (dtgvListarCiclos.Columns["descripcion"] != null)
                    dtgvListarCiclos.Columns["descripcion"].HeaderText = "Descripción";

                if (dtgvListarCiclos.Columns["duracion_estimada"] != null)
                    dtgvListarCiclos.Columns["duracion_estimada"].HeaderText = "Duración (Días)";

                if (dtgvListarCiclos.Columns["modo_inicio"] != null)
                    dtgvListarCiclos.Columns["modo_inicio"].HeaderText = "Modo de Inicio";

                if (dtgvListarCiclos.Columns["activo"] != null)
                    dtgvListarCiclos.Columns["activo"].HeaderText = "Activo"; // Se mostrará como CheckBox si el DataGridView lo autogenera

                if (dtgvListarCiclos.Columns["fecha_creacion"] != null)
                    dtgvListarCiclos.Columns["fecha_creacion"].HeaderText = "Fecha de Creación";

                if (dtgvListarCiclos.Columns["creado_por"] != null)
                    dtgvListarCiclos.Columns["creado_por"].HeaderText = "Creado Por";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los ciclos modelo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarCiclosModelo(txtBuscar.Text.Trim());
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            AbmCiclos frm = new AbmCiclos(_usuarioLogeado); // <--- Le pasamos el usuario real
            frm.Text = "Nuevo Ciclo Modelo";
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CargarCiclosModelo();
            }
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dtgvListarCiclos.SelectedRows.Count > 0)
            {
                long idCiclo = Convert.ToInt64(dtgvListarCiclos.SelectedRows[0].Cells["id_ciclo"].Value);

                AbmCiclos frm = new AbmCiclos(idCiclo, _usuarioLogeado);
                frm.Text = "Modificar Ciclo Modelo";

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargarCiclosModelo(txtBuscar.Text.Trim());
                }
            }
            else
            {
                MessageBox.Show("Seleccione un ciclo de la lista para modificar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       

        private void cmbFiltrarPor_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarCiclosModelo(txtBuscar.Text.Trim());
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
           
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dtgvListarVegetales_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }
    }
}
using Agraria.Datos.DAL;
using Agraria.Datos.DTO;
using Agraria.Datos.Entidades;
using Agraria.Negocio.BLL;
using Agraria.UserControls;
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
    public partial class ListarCiclos : Form
    {


        private readonly UsuarioLoginDTO _usuarioLogeado;
        private readonly bool _esInvitado;
        private ListarCiclosBLL CiclosModeloBLL = new ListarCiclosBLL();
        public ListarCiclos(UsuarioLoginDTO usuarioLogeado, bool esInvitado)
        {
            InitializeComponent();
            _usuarioLogeado = usuarioLogeado;
            _esInvitado = esInvitado;
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
                long idVegetal = Convert.ToInt64(dtgvListarCiclos.SelectedRows[0].Cells["id_vegetal"].Value);
                AbmVegetales frm = new AbmVegetales(idVegetal, _usuarioLogeado); // <--- Le pasamos el ID y el usuario
                frm.Text = "Modificar Ciclo Modelo";
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargarCiclosModelo();
                }
            }
            else
            {
                MessageBox.Show("Por favor seleccione un vegetal de la grilla.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            if (dtgvListarCiclos.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos en la grilla para imprimir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = $"ReporteVegetales_{DateTime.Now:ddMMyyyy_HHmmss}.pdf";
                savefile.Filter = "PDF files (*.pdf)|*.pdf";

                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    string rutaPlantilla = Path.Combine(Application.StartupPath, "Recursos", "Vegetales.html");
                    string PaginaHTML_Texto = File.ReadAllText(rutaPlantilla);

                    PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FECHA", DateTime.Now.ToString("dd/MM/yyyy"));
                    string cabeceras = string.Empty;
                    foreach (DataGridViewColumn col in dtgvListarCiclos.Columns)
                    {
                        if (col.Visible) // Solo imprime las que el usuario está viendo
                        {
                            cabeceras += $"<th>{col.HeaderText}</th>";
                        }
                    }
                    PaginaHTML_Texto = PaginaHTML_Texto.Replace("@CABECERAS", cabeceras);
                    string filas = string.Empty;
                    foreach (DataGridViewRow row in dtgvListarCiclos.Rows)
                    {
                        if (row.IsNewRow) continue;

                        filas += "<tr>";
                        foreach (DataGridViewColumn col in dtgvListarCiclos.Columns)
                        {
                            if (col.Visible) // Solo extrae el dato si la columna es visible
                            {
                                string valorCelda = row.Cells[col.Name].Value != null ? row.Cells[col.Name].Value.ToString() : "-";
                                filas += $"<td>{valorCelda}</td>";
                            }
                        }
                        filas += "</tr>";
                    }
                    PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FILAS", filas);
                    using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
                    {
                        iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.Rotate(), 25, 25, 25, 25);
                        iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(pdfDoc, stream);
                        pdfDoc.Open();
                        pdfDoc.Add(new iTextSharp.text.Phrase(""));
                        if (Properties.Resources.agr != null)
                        {
                            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(Properties.Resources.agr, System.Drawing.Imaging.ImageFormat.Png);
                            img.ScaleToFit(60, 60);
                            img.Alignment = iTextSharp.text.Image.UNDERLYING;
                            img.SetAbsolutePosition(pdfDoc.LeftMargin, pdfDoc.PageSize.Height - 85);
                            pdfDoc.Add(img);
                        }
                        using (StringReader sr = new StringReader(PaginaHTML_Texto))
                        {
                            iTextSharp.tool.xml.XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                        }

                        pdfDoc.Close();
                        stream.Close();
                    }

                    MessageBox.Show("Reporte generado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dtgvListarVegetales_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }
    }
}
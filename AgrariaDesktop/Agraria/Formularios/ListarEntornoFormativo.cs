using Agraria.Datos.DTO;
using Agraria.Negocio.BLL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Agraria.Formularios
{
    public partial class ListarEntornoFormativo : Form
    {
        private readonly UsuarioLoginDTO _usuarioLogeado;
        private readonly bool _esInvitado;
        private EntornoFormativoBLL entornoBLL = new EntornoFormativoBLL();

        public ListarEntornoFormativo(UsuarioLoginDTO usuarioLogeado, bool esInvitado)
        {
            InitializeComponent();
            _usuarioLogeado = usuarioLogeado;
            _esInvitado = esInvitado;
        }

        private void ListarEntornoFormativo_Load(object sender, EventArgs e)
        {
            CargarEntornos();
        }

        private void CargarEntornos(string filtro = "")
        {
            try
            {
                List<EntornoFormativoDTO> lista = entornoBLL.ObtenerEntornos();

                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    filtro = filtro.ToLower();
                    lista = lista.Where(x =>
                        x.Nombre.ToLower().Contains(filtro) ||
                        x.Responsable.ToLower().Contains(filtro) ||
                        x.IdTipoEntorno.ToLower().Contains(filtro)
                    ).ToList();
                }

                dtgvListarEntornoFormativo.DataSource = null;
                dtgvListarEntornoFormativo.DataSource = lista;

                if (dtgvListarEntornoFormativo.Columns["IdEntorno"] != null)
                {
                    dtgvListarEntornoFormativo.Columns["IdEntorno"].Visible = false;
                }
                if (dtgvListarEntornoFormativo.Columns["Fecha"] != null)
                {
                    dtgvListarEntornoFormativo.Columns["Fecha"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dtgvListarEntornoFormativo.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los entornos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarEntornos(txtBuscar.Text.Trim());
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar_Click(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            AbmEntornoFormativo frm = new AbmEntornoFormativo(_usuarioLogeado, _esInvitado);
            frm.Text = "Nuevo Entorno Formativo";

            if (frm.ShowDialog() == DialogResult.OK)
            {
                CargarEntornos();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dtgvListarEntornoFormativo.SelectedRows.Count > 0)
            {
                int idEntorno = Convert.ToInt32(dtgvListarEntornoFormativo.SelectedRows[0].Cells["IdEntorno"].Value);
                AbmEntornoFormativo frm = new AbmEntornoFormativo(idEntorno, _usuarioLogeado, _esInvitado);
                frm.Text = "Modificar Entorno Formativo";

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargarEntornos();
                }
            }
            else
            {
                MessageBox.Show("Por favor seleccione un entorno de la grilla.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (dtgvListarEntornoFormativo.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos en la grilla para imprimir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = $"ReporteEntornos_{DateTime.Now:ddMMyyyy_HHmmss}.pdf";
                savefile.Filter = "PDF files (*.pdf)|*.pdf";

                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    string rutaPlantilla = Path.Combine(Application.StartupPath, "Recursos", "EntornoFormativo.html");
                    string PaginaHTML_Texto = File.ReadAllText(rutaPlantilla);

                    PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FECHA", DateTime.Now.ToString("dd/MM/yyyy"));

                    string cabeceras = string.Empty;
                    foreach (DataGridViewColumn col in dtgvListarEntornoFormativo.Columns)
                    {
                        if (col.Visible)
                        {
                            cabeceras += $"<th>{col.HeaderText}</th>";
                        }
                    }
                    PaginaHTML_Texto = PaginaHTML_Texto.Replace("@CABECERAS", cabeceras);

                    string filas = string.Empty;
                    foreach (DataGridViewRow row in dtgvListarEntornoFormativo.Rows)
                    {
                        if (row.IsNewRow) continue;

                        filas += "<tr>";
                        foreach (DataGridViewColumn col in dtgvListarEntornoFormativo.Columns)
                        {
                            if (col.Visible)
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
    }
}
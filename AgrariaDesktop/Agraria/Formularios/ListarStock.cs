using Agraria.Datos.DTO;
using Agraria.Negocio.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Agraria.Formularios
{
    public partial class ListarStock : Form
    {
        private readonly UsuarioLoginDTO _usuarioLogeado;
        private readonly bool _esInvitado;
        private ListarStockBLL bll = new ListarStockBLL();

        public ListarStock(UsuarioLoginDTO usuarioLogeado, bool esInvitado)
        {
            InitializeComponent();
            _usuarioLogeado = usuarioLogeado;
            _esInvitado = esInvitado;
        }

        private void ListarStock_Load(object sender, EventArgs e)
        {
            cmbFiltrarPor.Items.AddRange(new object[] { "Todos", "Animal", "Vegetal", "Articulo" });
            cmbFiltrarPor.SelectedIndex = 0;
            CargarStock();
        }

        private void CargarStock(string filtro = "")
        {
            try
            {
                string tipo = cmbFiltrarPor.Text;
                if (tipo == "Todos") tipo = "";

                DataTable dt = bll.Listar(tipo, "");

                if (!string.IsNullOrEmpty(filtro))
                {
                    dt.DefaultView.RowFilter = $"nombre LIKE '%{filtro}%'";
                    dtgvListarStock.DataSource = dt.DefaultView;
                }
                else
                {
                    dtgvListarStock.DataSource = dt;
                }

                if (dtgvListarStock.Columns["id_stock"] != null) dtgvListarStock.Columns["id_stock"].Visible = false;
                if (dtgvListarStock.Columns["id_proveedor"] != null) dtgvListarStock.Columns["id_proveedor"].Visible = false;
                if (dtgvListarStock.Columns["NombreProveedor"] != null) dtgvListarStock.Columns["NombreProveedor"].HeaderText = "Proveedor";
                if (dtgvListarStock.Columns["id_elemento"] != null) dtgvListarStock.Columns["id_elemento"].HeaderText = "Código Bloque";
                if (dtgvListarStock.Columns["tipo_elemento"] != null) dtgvListarStock.Columns["tipo_elemento"].HeaderText = "Tipo de Elemento";
                if (dtgvListarStock.Columns["Nombre"] != null) dtgvListarStock.Columns["Nombre"].HeaderText = "Nombre";
                if (dtgvListarStock.Columns["ciclo"] != null) dtgvListarStock.Columns["ciclo"].HeaderText = "Ciclo (Sumatoria)";
                if (dtgvListarStock.Columns["fecha_alta"] != null) dtgvListarStock.Columns["fecha_alta"].HeaderText = "Fecha de Alta";
                if (dtgvListarStock.Columns["fecha_baja"] != null) dtgvListarStock.Columns["fecha_baja"].HeaderText = "Fecha de Baja";
                if (dtgvListarStock.Columns["cantidad"] != null) dtgvListarStock.Columns["cantidad"].HeaderText = "Cantidad";
                if (dtgvListarStock.Columns["precio"] != null)
                {
                    dtgvListarStock.Columns["precio"].HeaderText = "Precio";
                    dtgvListarStock.Columns["precio"].DefaultCellStyle.Format = "N2";
                }
                if (dtgvListarStock.Columns["activo"] != null) dtgvListarStock.Columns["activo"].HeaderText = "Activo";
                if (dtgvListarStock.Columns["vendible"] != null) dtgvListarStock.Columns["vendible"].HeaderText = "Vendible";
                if (dtgvListarStock.Columns["motivo_movimiento"] != null) dtgvListarStock.Columns["motivo_movimiento"].HeaderText = "Motivo de Movimiento";

                dtgvListarStock.EnableHeadersVisualStyles = false;
                dtgvListarStock.ColumnHeadersDefaultCellStyle.BackColor = Color.MediumSeaGreen;
                dtgvListarStock.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dtgvListarStock.ColumnHeadersDefaultCellStyle.Font = new Font(dtgvListarStock.Font, FontStyle.Bold);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el stock: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim();

            if (dtgvListarStock.DataSource is DataView dv)
            {
                dv.RowFilter = string.IsNullOrEmpty(filtro) ? "" : $"Nombre LIKE '%{filtro}%'";
            }
            else if (dtgvListarStock.DataSource is DataTable dt)
            {
                dt.DefaultView.RowFilter = string.IsNullOrEmpty(filtro) ? "" : $"Nombre LIKE '%{filtro}%'";
                dtgvListarStock.DataSource = dt.DefaultView;
            }
        }

        private void cmbFiltrarPor_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarStock();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            AbmStock frm = new AbmStock(_usuarioLogeado);
            frm.Text = "Nuevo Stock";
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CargarStock();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dtgvListarStock.SelectedRows.Count > 0)
            {
                long idStock = Convert.ToInt64(dtgvListarStock.SelectedRows[0].Cells["id_stock"].Value);
                AbmStock frm = new AbmStock(idStock, _usuarioLogeado);
                frm.Text = "Modificar Stock";
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargarStock();
                }
            }
            else
            {
                MessageBox.Show("Seleccione un registro de la grilla.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (dtgvListarStock.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos en la grilla para imprimir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = $"ReporteStock_{DateTime.Now:ddMMyyyy_HHmmss}.pdf";
                savefile.Filter = "PDF files (*.pdf)|*.pdf";

                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    string rutaPlantilla = Path.Combine(Application.StartupPath, "Recursos", "ListarStock.html");
                    string PaginaHTML_Texto = File.ReadAllText(rutaPlantilla);

                    PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FECHA", DateTime.Now.ToString("dd/MM/yyyy"));

                    string cabeceras = string.Empty;
                    foreach (DataGridViewColumn col in dtgvListarStock.Columns)
                    {
                        if (col.Visible)
                        {
                            cabeceras += $"<th>{col.HeaderText}</th>";
                        }
                    }
                    PaginaHTML_Texto = PaginaHTML_Texto.Replace("@CABECERAS", cabeceras);

                    string filas = string.Empty;
                    foreach (DataGridViewRow row in dtgvListarStock.Rows)
                    {
                        if (row.IsNewRow) continue;

                        filas += "<tr>";
                        foreach (DataGridViewColumn col in dtgvListarStock.Columns)
                        {
                            if (col.Visible)
                            {
                                string valorCelda = "-";
                                if (row.Cells[col.Name].Value != null)
                                {
                                    if (row.Cells[col.Name].Value is bool valorBooleano)
                                    {
                                        valorCelda = valorBooleano ? "Sí" : "No";
                                    }
                                    else
                                    {
                                        valorCelda = row.Cells[col.Name].Value.ToString();
                                    }
                                }
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

        private void dtgvListarStock_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dtgvListarStock.Columns[e.ColumnIndex].Name == "ciclo" && e.Value != null)
            {
                if (int.TryParse(e.Value.ToString(), out int cicloGuardado))
                {
                    List<string> periodos = new List<string>();

                    if ((cicloGuardado & 2) == 2) periodos.Add("Verano");
                    if ((cicloGuardado & 4) == 4) periodos.Add("Otoño");
                    if ((cicloGuardado & 8) == 8) periodos.Add("Invierno");
                    if ((cicloGuardado & 16) == 16) periodos.Add("Primavera");

                    e.Value = periodos.Count > 0 ? string.Join(", ", periodos) : "Ninguno";
                    e.FormattingApplied = true;
                }
            }
        }
    }
}
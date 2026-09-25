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
    public partial class ListarVegetales : Form
    {


        private readonly UsuarioLoginDTO _usuarioLogeado;
        private readonly bool _esInvitado;
        private VegetalBLL vegetalBLL = new VegetalBLL();
        private AbmVegetalesBLL abmBll = new AbmVegetalesBLL();
        public ListarVegetales(UsuarioLoginDTO usuarioLogeado, bool esInvitado)
        {
            InitializeComponent();
            _usuarioLogeado = usuarioLogeado;
            _esInvitado = esInvitado;
        }



        private void ListarVegetales_Load(object sender, EventArgs e)
        {
            CargarComboFiltro();
            CargarVegetales();

        }



        private void CargarVegetales(string filtro = "")
        {
            try
            {
                DataTable dt = vegetalBLL.ObtenerVegetales(filtro);

                if (cmbFiltrarPor.SelectedIndex > 0)
                {
                    string tipoSeleccionado = cmbFiltrarPor.Text;
                    dt.DefaultView.RowFilter = $"tipo_cultivo = '{tipoSeleccionado}'";
                    dtgvListarVegetales.DataSource = dt.DefaultView;
                }
                else
                {
                    dtgvListarVegetales.DataSource = dt;
                }

                if (dtgvListarVegetales.Columns["id_vegetal"] != null)
                {
                    dtgvListarVegetales.Columns["id_vegetal"].Visible = true;
                    dtgvListarVegetales.Columns["id_vegetal"].HeaderText = "Código";
                    dtgvListarVegetales.Columns["id_vegetal"].DisplayIndex = 0;
                }

                if (dtgvListarVegetales.Columns["nombre_comun"] != null) dtgvListarVegetales.Columns["nombre_comun"].HeaderText = "Nombre Común";
                if (dtgvListarVegetales.Columns["nombre_cientifico"] != null) dtgvListarVegetales.Columns["nombre_cientifico"].HeaderText = "Nombre Científico";
                if (dtgvListarVegetales.Columns["variedad_hibrido"] != null) dtgvListarVegetales.Columns["variedad_hibrido"].HeaderText = "Variedad / Híbrido";
                if (dtgvListarVegetales.Columns["tipo_cultivo"] != null) dtgvListarVegetales.Columns["tipo_cultivo"].HeaderText = "Tipo de Cultivo";
                if (dtgvListarVegetales.Columns["ciclo_vida"] != null) dtgvListarVegetales.Columns["ciclo_vida"].HeaderText = "Ciclo de Vida";
                if (dtgvListarVegetales.Columns["periodosiembra"] != null) dtgvListarVegetales.Columns["periodosiembra"].HeaderText = "Período de Siembra";
                if (dtgvListarVegetales.Columns["metodo_siembra"] != null) dtgvListarVegetales.Columns["metodo_siembra"].HeaderText = "Método de Siembra";
                if (dtgvListarVegetales.Columns["estado_fenologico"] != null) dtgvListarVegetales.Columns["estado_fenologico"].HeaderText = "Estado Fenológico";
                if (dtgvListarVegetales.Columns["requerimiento_hidrico"] != null) dtgvListarVegetales.Columns["requerimiento_hidrico"].HeaderText = "Req. Hídrico";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los vegetales: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarVegetales(txtBuscar.Text.Trim());
        }


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            AbmVegetales frm = new AbmVegetales(_usuarioLogeado); // <--- Le pasamos el usuario real
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CargarVegetales();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dtgvListarVegetales.SelectedRows.Count > 0)
            {
                long idVegetal = Convert.ToInt64(dtgvListarVegetales.SelectedRows[0].Cells["id_vegetal"].Value);
                AbmVegetales frm = new AbmVegetales(idVegetal, _usuarioLogeado); // <--- Le pasamos el ID y el usuario
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargarVegetales();
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

        /* Para probar una busqueda automatica
        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar_Click(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        */

        private void CargarComboFiltro()
        {
            try
            {
                DataTable dt = abmBll.CargarCombo("tipo_cultivo");

                DataRow row = dt.NewRow();
                row["id_tipo_cultivo"] = 0;
                row["nombre"] = "Todos";
                dt.Rows.InsertAt(row, 0);

                cmbFiltrarPor.DataSource = dt;
                cmbFiltrarPor.DisplayMember = "nombre";
                cmbFiltrarPor.ValueMember = "id_tipo_cultivo";
                cmbFiltrarPor.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el filtro: " + ex.Message);
            }
        }

        private void cmbFiltrarPor_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarVegetales(txtBuscar.Text.Trim());
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (dtgvListarVegetales.Rows.Count == 0)
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
                    foreach (DataGridViewColumn col in dtgvListarVegetales.Columns)
                    {
                        if (col.Visible) // Solo imprime las que el usuario está viendo
                        {
                            cabeceras += $"<th>{col.HeaderText}</th>";
                        }
                    }
                    PaginaHTML_Texto = PaginaHTML_Texto.Replace("@CABECERAS", cabeceras);
                    string filas = string.Empty;
                    foreach (DataGridViewRow row in dtgvListarVegetales.Rows)
                    {
                        if (row.IsNewRow) continue;

                        filas += "<tr>";
                        foreach (DataGridViewColumn col in dtgvListarVegetales.Columns)
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
    }
}
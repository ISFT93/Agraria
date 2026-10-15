using Agraria.Datos.DTO;
using Agraria.Negocio.BLL;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Agraria.Formularios
{
    public partial class ListarUsuario : Form
    {
        private readonly UsuarioLoginDTO _usuarioLogeado;
        private readonly bool _esInvitado;
        private AbmUsuarioBLL usuarioBLL = new AbmUsuarioBLL();

        public ListarUsuario(UsuarioLoginDTO usuarioLogeado, bool esInvitado)
        {
            InitializeComponent();
            _usuarioLogeado = usuarioLogeado;
            _esInvitado = esInvitado;
        }

        private void ListarUsuario_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
        }

        private void CargarUsuarios(string filtro = "")
        {
            try
            {
                if (string.IsNullOrWhiteSpace(filtro))
                {
                    dtgvListarUsuarios.DataSource = usuarioBLL.CargarTodoslosUsuarios();
                }
                else
                {
                    dtgvListarUsuarios.DataSource = usuarioBLL.BuscarUsuarioPorNombreODni(filtro);
                }

                // Ocultamos las columnas tal como lo hacías en el ABM original
                if (dtgvListarUsuarios.Columns["Id"] != null) dtgvListarUsuarios.Columns["Id"].Visible = false;
                if (dtgvListarUsuarios.Columns["Contraseña"] != null) dtgvListarUsuarios.Columns["Contraseña"].Visible = false;
                if (dtgvListarUsuarios.Columns["PreguntaSeguridad"] != null) dtgvListarUsuarios.Columns["PreguntaSeguridad"].Visible = false;
                if (dtgvListarUsuarios.Columns["RespuestaSeguridad"] != null) dtgvListarUsuarios.Columns["RespuestaSeguridad"].Visible = false;
                if (dtgvListarUsuarios.Columns["Documento"] != null) dtgvListarUsuarios.Columns["Documento"].Visible = false;
                if (dtgvListarUsuarios.Columns["Telefono"] != null) dtgvListarUsuarios.Columns["Telefono"].Visible = false;
                if (dtgvListarUsuarios.Columns["Direccion"] != null) dtgvListarUsuarios.Columns["Direccion"].Visible = false;
                if (dtgvListarUsuarios.Columns["NombreUsuario"] != null) dtgvListarUsuarios.Columns["NombreUsuario"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los usuarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarUsuarios(txtBuscar.Text.Trim());
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
            AbmUsuario frm = new AbmUsuario(_usuarioLogeado); // <--- Constructor NUEVO
            frm.Text = "Nuevo Usuario";
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CargarUsuarios();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dtgvListarUsuarios.SelectedRows.Count > 0)
            {
                int idUsuario = Convert.ToInt32(dtgvListarUsuarios.SelectedRows[0].Cells["Id"].Value);
                AbmUsuario frm = new AbmUsuario(idUsuario, _usuarioLogeado); // <--- Constructor MODIFICAR
                frm.Text = "Modificar Usuario";
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargarUsuarios();
                }
            }
            else
            {
                MessageBox.Show("Por favor seleccione un usuario de la grilla.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (dtgvListarUsuarios.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos en la grilla para imprimir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = $"ReporteUsuarios_{DateTime.Now:ddMMyyyy_HHmmss}.pdf";
                savefile.Filter = "PDF files (*.pdf)|*.pdf";

                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    string rutaPlantilla = Path.Combine(Application.StartupPath, "Recursos", "Usuarios.html");
                    string PaginaHTML_Texto = File.ReadAllText(rutaPlantilla);

                    PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FECHA", DateTime.Now.ToString("dd/MM/yyyy"));
                    string cabeceras = string.Empty;
                    foreach (DataGridViewColumn col in dtgvListarUsuarios.Columns)
                    {
                        if (col.Visible)
                        {
                            cabeceras += $"<th>{col.HeaderText}</th>";
                        }
                    }
                    PaginaHTML_Texto = PaginaHTML_Texto.Replace("@CABECERAS", cabeceras);

                    string filas = string.Empty;
                    foreach (DataGridViewRow row in dtgvListarUsuarios.Rows)
                    {
                        if (row.IsNewRow) continue;

                        filas += "<tr>";
                        foreach (DataGridViewColumn col in dtgvListarUsuarios.Columns)
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
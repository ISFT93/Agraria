using System;
using System.Data;
using System.Windows.Forms;

namespace Agraria.Formularios
{
    public partial class FormArticulosLista : Form
    {
        // Instancia de la BLL para conectar con la lógica del negocio
        private Agraria.BLL.ArticulosBLL articulosBLL = new Agraria.BLL.ArticulosBLL();
        private object _usuarioActual; // Objeto de sesión del usuario logueado

        // Constructor que recibe el usuario logueado (opcional para pruebas individuales)
        public FormArticulosLista(object usuarioLogeado = null)
        {
            InitializeComponent();
            _usuarioActual = usuarioLogeado;

            // Forzamos la actualización automática de la grilla cada vez que la ventana recupera el foco
            this.Activated += new EventHandler(FormArticulosLista_Activated);
        }

        private void FormArticulosLista_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
           // this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Cargamos el combo de categorías y la grilla al iniciar
            CargarComboCategorias();
            CargarGrilla();
        }

        // Se ejecuta automáticamente al volver de crear o editar un artículo
        private void FormArticulosLista_Activated(object? sender, EventArgs e)
        {
            CargarGrilla();
        }

        // Método para cargar el ComboBox de Categorías
        private void CargarComboCategorias()
        {
            try
            {
                if (cmbFiltroCategoria != null)
                {
                    DataTable dtCat = articulosBLL.CargarComboCategorias();
                    cmbFiltroCategoria.DataSource = dtCat;
                    cmbFiltroCategoria.DisplayMember = "nombre";
                    cmbFiltroCategoria.ValueMember = "id_categoria";
                    cmbFiltroCategoria.SelectedIndex = -1; // Arranca sin seleccionar nada
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar categorías: " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Método privado para reutilizar la carga de datos en la grilla con filtros opcionales
        private void CargarGrilla()
        {
            try
            {
                int? idCategoria = null;
                if (cmbFiltroCategoria != null && cmbFiltroCategoria.SelectedValue != null && cmbFiltroCategoria.SelectedIndex != -1)
                {
                    idCategoria = Convert.ToInt32(cmbFiltroCategoria.SelectedValue);
                }

                string textoBusqueda = txtBuscar != null ? txtBuscar.Text.Trim() : string.Empty;

                // Llamamos al método que acepta filtros en la BLL
                dgvArticulos.DataSource = articulosBLL.ObtenerArticulos(idCategoria, textoBusqueda);

                if (dgvArticulos.Columns.Count > 0)
                {
                    // 1. Títulos visibles en los encabezados
                    if (dgvArticulos.Columns["id_articulo"] != null) dgvArticulos.Columns["id_articulo"].HeaderText = "ID";
                    if (dgvArticulos.Columns["nombre"] != null) dgvArticulos.Columns["nombre"].HeaderText = "Nombre";
                    if (dgvArticulos.Columns["marca"] != null) dgvArticulos.Columns["marca"].HeaderText = "Marca";
                    if (dgvArticulos.Columns["categoria"] != null) dgvArticulos.Columns["categoria"].HeaderText = "Categoría";
                    if (dgvArticulos.Columns["fecha_alta"] != null) dgvArticulos.Columns["fecha_alta"].HeaderText = "Fecha Alta";

                    // 2. Anchos específicos para que ninguna columna se comprima ni quede invisible
                    if (dgvArticulos.Columns["id_articulo"] != null) dgvArticulos.Columns["id_articulo"].Width = 70;
                    if (dgvArticulos.Columns["nombre"] != null) dgvArticulos.Columns["nombre"].Width = 160;
                    if (dgvArticulos.Columns["marca"] != null) dgvArticulos.Columns["marca"].Width = 120;
                    if (dgvArticulos.Columns["categoria"] != null) dgvArticulos.Columns["categoria"].Width = 120;
                    if (dgvArticulos.Columns["fecha_alta"] != null) dgvArticulos.Columns["fecha_alta"].Width = 110;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la grilla: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rjBNuevo_Click(object sender, EventArgs e)
        {
            // Creamos el formulario de detalle pasándole el usuario actual para la lógica de bloques
            FormArticulosDetalle formDetalle = new FormArticulosDetalle(_usuarioActual);
            formDetalle.idArticuloActual = null; // Es null para indicar alta nueva

            if (formDetalle.ShowDialog() == DialogResult.OK)
            {
                CargarGrilla(); // Actualiza la grilla al guardar con éxito
            }
        }

        private void rjModificar_Click(object sender, EventArgs e)
        {
            if (dgvArticulos.SelectedRows.Count > 0)
            {
                // Obtenemos el ID del artículo seleccionado en la grilla
                long idSeleccionado = Convert.ToInt64(dgvArticulos.SelectedRows[0].Cells["id_articulo"].Value);

                // Creamos el formulario de detalle pasándole el usuario actual y el ID para modificar
                FormArticulosDetalle formDetalle = new FormArticulosDetalle(_usuarioActual);
                formDetalle.idArticuloActual = idSeleccionado;

                if (formDetalle.ShowDialog() == DialogResult.OK)
                {
                    CargarGrilla(); // Actualiza la grilla al modificar con éxito
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un artículo para modificar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void rjImprimir_Click(object sender, EventArgs e)
        {
            // Validar que haya datos para imprimir
            if (dgvArticulos.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos en la grilla para imprimir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 1) Configuración del diálogo para guardar el PDF
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = $"ReporteArticulos_{DateTime.Now:ddMMyyyy_HHmmss}.pdf";
                savefile.Filter = "PDF files (*.pdf)|*.pdf";

                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    // 2) Cargar plantilla de artículos
                    string rutaPlantilla = Path.Combine(Application.StartupPath, "Recursos", "Articulos.html");
                    string PaginaHTML_Texto = File.ReadAllText(rutaPlantilla);

                    // 3) Reemplazo de la fecha
                    PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FECHA", DateTime.Now.ToString("dd/MM/yyyy"));

                    // 4) Construir CABECERAS dinámicamente según lo que se ve en la grilla
                    string cabeceras = string.Empty;
                    foreach (DataGridViewColumn col in dgvArticulos.Columns)
                    {
                        if (col.Visible) // Solo imprime las columnas visibles
                        {
                            cabeceras += $"<th>{col.HeaderText}</th>";
                        }
                    }
                    PaginaHTML_Texto = PaginaHTML_Texto.Replace("@CABECERAS", cabeceras);

                    // 5) Construir FILAS dinámicamente según los datos de la grilla
                    string filas = string.Empty;
                    foreach (DataGridViewRow row in dgvArticulos.Rows)
                    {
                        if (row.IsNewRow) continue;

                        filas += "<tr>";
                        foreach (DataGridViewColumn col in dgvArticulos.Columns)
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

                    // 6) Generar el archivo PDF usando iTextSharp
                    using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
                    {
                        // Usamos A4.Rotate() para hoja apaisada, ideal para tablas anchas
                        iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.Rotate(), 25, 25, 25, 25);
                        iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(pdfDoc, stream);
                        pdfDoc.Open();

                        // Espaciado inicial
                        pdfDoc.Add(new iTextSharp.text.Phrase(""));

                        // Logo opcional (si tenés la imagen en los recursos)
                        if (Properties.Resources.agr != null)
                        {
                            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(Properties.Resources.agr, System.Drawing.Imaging.ImageFormat.Png);
                            img.ScaleToFit(60, 60);
                            img.Alignment = iTextSharp.text.Image.UNDERLYING;
                            img.SetAbsolutePosition(pdfDoc.LeftMargin, pdfDoc.PageSize.Height - 85);
                            pdfDoc.Add(img);
                        }

                        // Escribir el HTML convertido a PDF
                        using (StringReader sr = new StringReader(PaginaHTML_Texto))
                        {
                            iTextSharp.tool.xml.XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                        }

                        pdfDoc.Close();
                        stream.Close();
                    }

                    MessageBox.Show("Reporte de artículos generado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rjBSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rjBBuscar_Click(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvArticulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
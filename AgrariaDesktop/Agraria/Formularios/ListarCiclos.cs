using Agraria.Datos.DAL;
using Agraria.Datos.DTO;
using Agraria.Datos.Entidades;
using Agraria.Negocio.BLL;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
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
        private AbmCiclosBLL _ciclosBLL = new AbmCiclosBLL();
        public ListarCiclos(UsuarioLoginDTO usuarioLogeado, bool esInvitado)
        {
            InitializeComponent();
            _usuarioLogeado = usuarioLogeado;
            _esInvitado = esInvitado;


            // Configurar el MaterialSkinManager
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT; // O DARK

            // Configurar esquemas de color (Ejemplo:  Green , LightGreen  y Teal )
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Green800,
                Primary.Green900,
                Primary.Green500,
                Accent.Green200,
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
                dtgvListarCiclos.DataSource = dt;

                ConfigurarColumna("id_ciclo", "Código", visible: true, displayIndex: 0);
                ConfigurarColumna("nombre", "Nombre del Ciclo");
                ConfigurarColumna("descripcion", "Descripción");
                ConfigurarColumna("duracion_estimada", "Duración (Días)");

                // Mostrar la duración como número entero (48 en vez de 48,00)
                if (dtgvListarCiclos.Columns["duracion_estimada"] != null)
                {
                    dtgvListarCiclos.Columns["duracion_estimada"].DefaultCellStyle.Format = "0";
                    dtgvListarCiclos.Columns["duracion_estimada"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                ConfigurarColumna("activo", "Activo");
                ConfigurarColumna("fecha_creacion", "Fecha de Creación");

                // El SP ahora devuelve también los NOMBRES; los IDs se ocultan
                bool hayNombreModo = dt.Columns.Contains("modo_inicio_nombre");
                ConfigurarColumna("modo_inicio", "Modo de Inicio", visible: !hayNombreModo);
                ConfigurarColumna("modo_inicio_nombre", "Modo de Inicio");

                bool hayNombreCreador = dt.Columns.Contains("creado_por_nombre");
                ConfigurarColumna("creado_por", "Creado Por", visible: !hayNombreCreador);
                ConfigurarColumna("creado_por_nombre", "Creado Por");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los ciclos modelo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarColumna(string nombre, string encabezado, bool visible = true, int displayIndex = -1)
        {
            var col = dtgvListarCiclos.Columns[nombre];
            if (col == null) return;
            col.HeaderText = encabezado;
            col.Visible = visible;
            if (displayIndex >= 0) col.DisplayIndex = displayIndex;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarCiclosModelo(txtBuscar.Text.Trim());
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            AbmCiclos frm = new AbmCiclos(_usuarioLogeado);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CargarCiclosModelo(txtBuscar.Text.Trim());
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            // CurrentRow cubre el caso en que se hizo clic en una celda sin seleccionar la fila completa
            DataGridViewRow fila = dtgvListarCiclos.SelectedRows.Count > 0
                ? dtgvListarCiclos.SelectedRows[0]
                : dtgvListarCiclos.CurrentRow;

            if (fila == null || fila.Cells["id_ciclo"].Value == null || fila.Cells["id_ciclo"].Value == DBNull.Value)
            {
                MessageBox.Show("Seleccione un ciclo de la lista para modificar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            long idCiclo = Convert.ToInt64(fila.Cells["id_ciclo"].Value);

            AbmCiclos frm = new AbmCiclos(idCiclo, _usuarioLogeado);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                CargarCiclosModelo(txtBuscar.Text.Trim());
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

        // ========================================================
        // IMPRIMIR: Ciclos + Actividades + Elementos
        // ========================================================
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (dtgvListarCiclos.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos en la grilla para imprimir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 1. Preguntar: fila seleccionada o todas
            var btnSeleccionado = new TaskDialogButton("Solo el seleccionado");
            var btnTodos = new TaskDialogButton("Todos los ciclos");

            TaskDialogButton respuesta = TaskDialog.ShowDialog(this, new TaskDialogPage
            {
                Caption = "Imprimir Ciclos",
                Heading = "¿Qué ciclos desea imprimir?",
                Text = "Se incluyen sus actividades y los elementos de cada actividad.",
                Icon = TaskDialogIcon.Information,
                AllowCancel = true,
                Buttons = { btnSeleccionado, btnTodos, TaskDialogButton.Cancel }
            });

            List<DataGridViewRow> filas;
            if (respuesta == btnSeleccionado)
            {
                DataGridViewRow fila = dtgvListarCiclos.SelectedRows.Count > 0
                    ? dtgvListarCiclos.SelectedRows[0]
                    : dtgvListarCiclos.CurrentRow;

                if (fila == null)
                {
                    MessageBox.Show("Seleccione un ciclo de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                filas = new List<DataGridViewRow> { fila };
            }
            else if (respuesta == btnTodos)
            {
                filas = dtgvListarCiclos.Rows.Cast<DataGridViewRow>().Where(r => !r.IsNewRow).ToList();
            }
            else
            {
                return; // Canceló
            }

            // 2. Elegir dónde guardar y generar
            using (SaveFileDialog savefile = new SaveFileDialog())
            {
                savefile.FileName = filas.Count == 1
                    ? $"Ciclo_{Celda(filas[0], "id_ciclo")}_{DateTime.Now:ddMMyyyy_HHmmss}.pdf"
                    : $"ReporteCiclos_{DateTime.Now:ddMMyyyy_HHmmss}.pdf";
                savefile.Filter = "PDF files (*.pdf)|*.pdf";

                if (savefile.ShowDialog() != DialogResult.OK) return;

                try
                {
                    Cursor = Cursors.WaitCursor;
                    string html = ArmarHtmlReporte(filas);
                    GenerarPdf(html, savefile.FileName);
                    Cursor = Cursors.Default;

                    MessageBox.Show("Reporte generado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    Cursor = Cursors.Default;
                    MessageBox.Show("Error al generar reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Arma las filas de las 3 tablas y las vuelca en Recursos\ListarCiclos.html
        private string ArmarHtmlReporte(List<DataGridViewRow> filasCiclos)
        {
            var tCiclos = new StringBuilder();
            var tActividades = new StringBuilder();
            var tElementos = new StringBuilder();

            foreach (DataGridViewRow fila in filasCiclos)
            {
                long idCiclo = Convert.ToInt64(fila.Cells["id_ciclo"].Value);
                string nombreCiclo = Celda(fila, "nombre");

                // ---- Tabla 1: Ciclos (8 columnas) ----
                tCiclos.Append("<tr>")
                       .Append(Td(idCiclo.ToString()))
                       .Append(Td(nombreCiclo))
                       .Append(Td(Celda(fila, "descripcion")))
                       .Append(Td(Celda(fila, "duracion_estimada", "0")))
                       .Append(Td(Celda(fila, dtgvListarCiclos.Columns.Contains("modo_inicio_nombre") ? "modo_inicio_nombre" : "modo_inicio")))
                       .Append(Td(Celda(fila, "activo")))
                       .Append(Td(Celda(fila, "fecha_creacion", "dd/MM/yyyy")))
                       .Append(Td(Celda(fila, dtgvListarCiclos.Columns.Contains("creado_por_nombre") ? "creado_por_nombre" : "creado_por")))
                       .Append("</tr>");

                // ---- Tabla 2: Actividades del ciclo (9 columnas) ----
                DataTable dtAct = _ciclosBLL.ObtenerActividadesPorCiclo(idCiclo);
                foreach (DataRow act in dtAct.Rows)
                {
                    string nombreAct = Valor(act, "nombre");

                    tActividades.Append("<tr>")
                                .Append(Td(nombreCiclo))
                                .Append(Td(Valor(act, "orden")))
                                .Append(Td(nombreAct))
                                .Append(Td(Valor(act, "tipo_actividad_nombre")))
                                .Append(Td(Valor(act, "duracion_estimada", "0")))
                                .Append(Td(Valor(act, "demora")))
                                .Append(Td(Valor(act, "requiere_aprobacion")))
                                .Append(Td(Valor(act, "permite_ejecucion_parcial")))
                                .Append(Td(Valor(act, "condicion_avance")))
                                .Append("</tr>");

                    // ---- Tabla 3: Elementos de la actividad (11 columnas) ----
                    long idAct = Convert.ToInt64(act["id_actividad_modelo"]);
                    DataTable dtElem = _ciclosBLL.ObtenerElementosPorActividad(idAct);
                    foreach (DataRow el in dtElem.Rows)
                    {
                        bool esSalida = Valor(el, "tipo_movimiento_nombre") == "Salida";

                        tElementos.Append("<tr>")
                                  .Append(Td(nombreCiclo))
                                  .Append(Td(nombreAct))
                                  .Append(Td(Valor(el, "orden")))
                                  .Append(Td(Valor(el, "tipo_elemento_nombre")))
                                  .Append(Td(Valor(el, "nombre_elemento")))
                                  .Append(Td(Valor(el, "tipo_movimiento_nombre")))
                                  .Append(Td(Valor(el, "cantidad_prevista", "0.##")))
                                  .Append(Td(Valor(el, "unidad_nombre")))
                                  .Append(Td(Valor(el, "obligatorio")))
                                  .Append(Td(esSalida ? Valor(el, "vendible_destino") : "-"))
                                  .Append(Td(Valor(el, "observaciones")))
                                  .Append("</tr>");
                    }
                }
            }

            string Vacio(StringBuilder sb, int cols) =>
                sb.Length > 0 ? sb.ToString() : $"<tr><td colspan=\"{cols}\">Sin datos</td></tr>";

            string titulo = filasCiclos.Count == 1
                ? $"Reporte del Ciclo Modelo: {WebUtility.HtmlEncode(Celda(filasCiclos[0], "nombre"))}"
                : "Reporte General de Ciclos Modelo";

            // Se lee la plantilla y se reemplazan las marcas
            string rutaPlantilla = Path.Combine(Application.StartupPath, "Recursos", "ListarCiclos.html");
            string html = File.ReadAllText(rutaPlantilla);

            html = html.Replace("@TITULO", titulo)
                       .Replace("@FECHA", DateTime.Now.ToString("dd/MM/yyyy"))
                       .Replace("@FILAS_CICLOS", Vacio(tCiclos, 8))
                       .Replace("@FILAS_ACTIVIDADES", Vacio(tActividades, 9))
                       .Replace("@FILAS_ELEMENTOS", Vacio(tElementos, 11));

            return html;
        }

        // Convierte el HTML en PDF (mismo formato que los demás reportes)
        private void GenerarPdf(string html, string ruta)
        {
            using (FileStream stream = new FileStream(ruta, FileMode.Create))
            {
                var pdfDoc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.Rotate(), 25, 25, 25, 25);
                var writer = iTextSharp.text.pdf.PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(new iTextSharp.text.Phrase(""));

                if (Properties.Resources.agr != null)
                {
                    var img = iTextSharp.text.Image.GetInstance(Properties.Resources.agr, System.Drawing.Imaging.ImageFormat.Png);
                    img.ScaleToFit(60, 60);
                    img.Alignment = iTextSharp.text.Image.UNDERLYING;
                    img.SetAbsolutePosition(pdfDoc.LeftMargin, pdfDoc.PageSize.Height - 85);
                    pdfDoc.Add(img);
                }

                using (StringReader sr = new StringReader(html))
                {
                    iTextSharp.tool.xml.XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                }

                pdfDoc.Close();
            }
        }

        // ---------- Helpers de formato ----------
        private static string Td(string texto) => $"<td>{WebUtility.HtmlEncode(texto)}</td>";

        private static string Formatear(object valor, string formato = null)
        {
            if (valor == null || valor == DBNull.Value) return "-";
            if (valor is bool b) return b ? "Sí" : "No";
            if (formato != null && valor is IFormattable f) return f.ToString(formato, null);
            string s = valor.ToString();
            return string.IsNullOrWhiteSpace(s) ? "-" : s;
        }

        // Valor de una celda de la grilla de ciclos
        private static string Celda(DataGridViewRow fila, string columna, string formato = null) =>
            fila.DataGridView.Columns.Contains(columna) ? Formatear(fila.Cells[columna].Value, formato) : "-";

        // Valor de una fila de DataTable (actividades / elementos)
        private static string Valor(DataRow fila, string columna, string formato = null) =>
            fila.Table.Columns.Contains(columna) ? Formatear(fila[columna], formato) : "-";

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dtgvListarVegetales_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }
    }
}
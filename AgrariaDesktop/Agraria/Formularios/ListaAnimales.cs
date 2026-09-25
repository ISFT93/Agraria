using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Agraria.Datos.DAL;
using Agraria.Datos.DTO;

namespace Agraria.Formularios
{
    public partial class ListaAnimales : Form
    {
        private AbmAnimalDAL animalDAL = new AbmAnimalDAL();
        private bool esInvitado;
        private int idUsuarioSesion = 1;
        private List<AnimalDTO> listaAnimales = new List<AnimalDTO>();

        public ListaAnimales(bool esInvitado)
        {
            InitializeComponent();
            this.esInvitado = esInvitado;
        }

        public ListaAnimales(bool esInvitado, int idUsuario)
        {
            InitializeComponent();
            this.esInvitado = esInvitado;
            this.idUsuarioSesion = idUsuario;
        }

        public ListaAnimales()
        {
            InitializeComponent();
            this.esInvitado = false;
        }

        private void FormAnimal_Load(object sender, EventArgs e)
        {
            CargarComboFiltros();
            AplicarPermisos();
            CargarGrilla();
        }

        private void CargarComboFiltros()
        {
            CbFiltrar.DropDownStyle = ComboBoxStyle.DropDownList;
            CbFiltrar.Items.Clear();
            CbFiltrar.Items.Add("Todos");
            CbFiltrar.Items.Add("Código");
            CbFiltrar.Items.Add("Nombre");
            CbFiltrar.Items.Add("Tipo de Animal");
            CbFiltrar.Items.Add("Rubro");
            CbFiltrar.Items.Add("Subrubro");
            CbFiltrar.Items.Add("Sexo");
            CbFiltrar.SelectedIndex = 0;
        }

        private void AplicarPermisos()
        {
            if (esInvitado)
            {
                BtnNuevo.Enabled = false;
                BtnModificar.Enabled = false;
            }
        }

        private void CargarGrilla()
        {
            try
            {
                DataTable dt = animalDAL.ObtenerAnimales();
                listaAnimales.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    long idAnimalVal = dt.Columns.Contains("id_animal") ? Convert.ToInt64(row["id_animal"]) : Convert.ToInt64(row["idanimal"]);
                    string nombreComunVal = dt.Columns.Contains("nombre_comun") ? row["nombre_comun"].ToString() : row["nombrecomun"].ToString();
                    string nombreCientificoVal = dt.Columns.Contains("nombre_cientifico") ? row["nombre_cientifico"].ToString() : (dt.Columns.Contains("nombrecientifico") ? row["nombrecientifico"].ToString() : "");

                    int idTipoVal = dt.Columns.Contains("id_tipo") ? (row["id_tipo"] != DBNull.Value ? Convert.ToInt32(row["id_tipo"]) : 0) : 0;
                    int idRubroVal = dt.Columns.Contains("id_rubro") ? (row["id_rubro"] != DBNull.Value ? Convert.ToInt32(row["id_rubro"]) : 0) : 0;
                    int idSubrubroVal = dt.Columns.Contains("id_subrubro") ? (row["id_subrubro"] != DBNull.Value ? Convert.ToInt32(row["id_subrubro"]) : 0) : 0;

                    string tipoVal = dt.Columns.Contains("tipo_animal") ? row["tipo_animal"].ToString() : "";
                    string rubroVal = dt.Columns.Contains("rubro") ? row["rubro"].ToString() : "";
                    string subrubroVal = dt.Columns.Contains("subrubro") ? row["subrubro"].ToString() : "";

                    DateTime fechaNacVal = dt.Columns.Contains("fecha_nacimiento") ? Convert.ToDateTime(row["fecha_nacimiento"]) : Convert.ToDateTime(row["fechanacimiento"]);

                    listaAnimales.Add(new AnimalDTO
                    {
                        IdAnimal = idAnimalVal,
                        NombreComun = nombreComunVal,
                        NombreCientifico = nombreCientificoVal,
                        IdTipo = idTipoVal,
                        IdRubro = idRubroVal,
                        IdSubrubro = idSubrubroVal,
                        TipoAnimal = tipoVal,
                        Rubro = rubroVal,
                        Subrubro = subrubroVal,
                        FechaNacimiento = fechaNacVal,
                        Sexo = row["sexo"].ToString()
                    });
                }

                DtgAnimal.DataSource = null;
                DtgAnimal.DataSource = listaAnimales;

                OcultarColumnasIDs();

                DtgAnimal.ReadOnly = true;
                DtgAnimal.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                DtgAnimal.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la grilla de animales: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CbFiltrar_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltroGrilla();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            AplicarFiltroGrilla();
        }

        private void TxtNombre_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltroGrilla();
        }

        private void AplicarFiltroGrilla()
        {
            if (listaAnimales == null) return;

            string busqueda = TxtNombre.Text.Trim().ToLower();
            string opcionFiltro = CbFiltrar.SelectedItem != null ? CbFiltrar.SelectedItem.ToString().ToLower() : "todos";

            if (string.IsNullOrWhiteSpace(busqueda))
            {
                DtgAnimal.DataSource = null;
                DtgAnimal.DataSource = listaAnimales;
                OcultarColumnasIDs();
                return;
            }

            var filtrados = listaAnimales.Where(a =>
            {
                switch (opcionFiltro)
                {
                    case "código":
                        return a.IdAnimal.ToString().Contains(busqueda);

                    case "nombre":
                        return (!string.IsNullOrEmpty(a.NombreComun) && a.NombreComun.ToLower().Contains(busqueda)) ||
                               (!string.IsNullOrEmpty(a.NombreCientifico) && a.NombreCientifico.ToLower().Contains(busqueda));

                    case "tipo de animal":
                        return !string.IsNullOrEmpty(a.TipoAnimal) && a.TipoAnimal.ToLower().Contains(busqueda);

                    case "rubro":
                        return !string.IsNullOrEmpty(a.Rubro) && a.Rubro.ToLower().Contains(busqueda);

                    case "subrubro":
                        return !string.IsNullOrEmpty(a.Subrubro) && a.Subrubro.ToLower().Contains(busqueda);

                    case "sexo":
                        return !string.IsNullOrEmpty(a.Sexo) && a.Sexo.ToLower().StartsWith(busqueda);

                    case "todos":
                    default:
                        return a.IdAnimal.ToString().Contains(busqueda) ||
                               (!string.IsNullOrEmpty(a.NombreComun) && a.NombreComun.ToLower().Contains(busqueda)) ||
                               (!string.IsNullOrEmpty(a.NombreCientifico) && a.NombreCientifico.ToLower().Contains(busqueda)) ||
                               (!string.IsNullOrEmpty(a.TipoAnimal) && a.TipoAnimal.ToLower().Contains(busqueda)) ||
                               (!string.IsNullOrEmpty(a.Rubro) && a.Rubro.ToLower().Contains(busqueda)) ||
                               (!string.IsNullOrEmpty(a.Subrubro) && a.Subrubro.ToLower().Contains(busqueda)) ||
                               (!string.IsNullOrEmpty(a.Sexo) && a.Sexo.ToLower().Contains(busqueda));
                }
            }).ToList();

            DtgAnimal.DataSource = null;
            DtgAnimal.DataSource = filtrados;

            OcultarColumnasIDs();
        }

        private void OcultarColumnasIDs()
        {
            if (DtgAnimal.Columns.Count == 0) return;

            if (DtgAnimal.Columns["IdTipo"] != null) DtgAnimal.Columns["IdTipo"].Visible = false;
            if (DtgAnimal.Columns["IdRubro"] != null) DtgAnimal.Columns["IdRubro"].Visible = false;
            if (DtgAnimal.Columns["IdSubrubro"] != null) DtgAnimal.Columns["IdSubrubro"].Visible = false;

            if (DtgAnimal.Columns["IdAnimal"] != null) DtgAnimal.Columns["IdAnimal"].HeaderText = "Código";
            if (DtgAnimal.Columns["NombreComun"] != null) DtgAnimal.Columns["NombreComun"].HeaderText = "Nombre Común";
            if (DtgAnimal.Columns["NombreCientifico"] != null) DtgAnimal.Columns["NombreCientifico"].HeaderText = "Nombre Científico";
            if (DtgAnimal.Columns["TipoAnimal"] != null) DtgAnimal.Columns["TipoAnimal"].HeaderText = "Tipo de Animal";
            if (DtgAnimal.Columns["Rubro"] != null) DtgAnimal.Columns["Rubro"].HeaderText = "Rubro";
            if (DtgAnimal.Columns["Subrubro"] != null) DtgAnimal.Columns["Subrubro"].HeaderText = "Subrubro";
            if (DtgAnimal.Columns["FechaNacimiento"] != null) DtgAnimal.Columns["FechaNacimiento"].HeaderText = "Fecha Nacimiento";
            if (DtgAnimal.Columns["Sexo"] != null) DtgAnimal.Columns["Sexo"].HeaderText = "Sexo";
        }

        private void DtgAnimal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                BtnModificar.Enabled = !esInvitado;
            }
        }

        private void BtnNuevo_Click_1(object sender, EventArgs e)
        {
            using (AbmAnimal formRegistro = new AbmAnimal(idUsuarioSesion))
            {
                if (formRegistro.ShowDialog() == DialogResult.OK)
                {
                    CargarGrilla();
                }
            }
        }

        private void BtnModificar_Click_1(object sender, EventArgs e)
        {
            if (DtgAnimal.CurrentRow != null && DtgAnimal.CurrentRow.DataBoundItem != null)
            {
                AnimalDTO seleccionado = (AnimalDTO)DtgAnimal.CurrentRow.DataBoundItem;

                using (AbmAnimal formEditar = new AbmAnimal(seleccionado))
                {
                    if (formEditar.ShowDialog() == DialogResult.OK)
                    {
                        CargarGrilla();
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un registro de la lista para modificar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnImprimir_Click_1(object sender, EventArgs e)
        {
            if (DtgAnimal.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos en la grilla para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                SaveFileDialog savefile = new SaveFileDialog
                {
                    FileName = $"ReporteAnimales_{DateTime.Now:ddMMyyyy_HHmmss}.pdf",
                    Filter = "Archivos PDF (*.pdf)|*.pdf"
                };

                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    string rutaPlantilla = Path.Combine(Application.StartupPath, "Recursos", "Animales.html");

                    if (!File.Exists(rutaPlantilla))
                    {
                        MessageBox.Show($"No se encontró el archivo de plantilla HTML en: {rutaPlantilla}", "Error de archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string PaginaHTML_Texto = File.ReadAllText(rutaPlantilla);
                    PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FECHA", DateTime.Now.ToString("dd/MM/yyyy HH:mm"));

                    string cabeceras = string.Empty;
                    foreach (DataGridViewColumn col in DtgAnimal.Columns)
                    {
                        if (col.Visible)
                        {
                            cabeceras += $"<th>{col.HeaderText}</th>";
                        }
                    }
                    PaginaHTML_Texto = PaginaHTML_Texto.Replace("@CABECERAS", cabeceras);

                    string filas = string.Empty;
                    foreach (DataGridViewRow row in DtgAnimal.Rows)
                    {
                        if (row.IsNewRow) continue;

                        filas += "<tr>";
                        foreach (DataGridViewColumn col in DtgAnimal.Columns)
                        {
                            if (col.Visible)
                            {
                                string valorCelda = row.Cells[col.Name].Value != null ? row.Cells[col.Name].Value.ToString() : "-";

                                if (row.Cells[col.Name].Value is DateTime dt)
                                {
                                    valorCelda = dt.ToString("dd/MM/yyyy");
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

                    MessageBox.Show("Reporte de animales generado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el archivo PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSalir_Click_1(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro de que desea salir de esta pantalla?",
                "Confirmar Salida",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (respuesta == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
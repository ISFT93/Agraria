using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Agraria.Formularios
{
    // Clase para almacenar los datos de cada animal individual
    public class AnimalItemDto
    {
        public string NroAnimal { get; set; }
        public string Sexo { get; set; }
        public bool EsProductor { get; set; }
    }

    public partial class DetallesAnimal : Form
    {
        private Panel panelContenedor;

        // Lista pública para que el formulario principal pueda leer los animales cargados
        public List<AnimalItemDto> ListaAnimales { get; private set; } = new List<AnimalItemDto>();

        public DetallesAnimal(int cantidad)
        {
            InitializeComponent();
            ConfigurarVentanaDinamica(cantidad);
        }

        private void ConfigurarVentanaDinamica(int cantidad)
        {
            this.Text = $"Detalle de Animales (Cantidad: {cantidad})";
            this.StartPosition = FormStartPosition.CenterParent;

            // Panel contenedor con scroll para los campos dinámicos
            panelContenedor = new Panel();
            panelContenedor.AutoScroll = true;
            panelContenedor.Location = new Point(15, 15);
            panelContenedor.Size = new Size(645, 380);
            this.Controls.Add(panelContenedor);

            // Tipografía uniforme para los elementos dinámicos
            Font fuenteEstilo = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold); // Ajustado a 10F para que no sea tan gigante y entre bien

            // Generar filas dinámicamente con espacios amplios para que no se amontonen
            int yPos = 15;
            for (int i = 0; i < cantidad; i++)
            {
                // 1. Label ID Animal
                Label lblId = new Label();
                lblId.Text = $"ID Animal {i + 1}:";
                lblId.Location = new Point(15, yPos + 4);
                lblId.AutoSize = true;
                lblId.Font = fuenteEstilo;
                lblId.ForeColor = Color.White;
                panelContenedor.Controls.Add(lblId);

                // 2. TextBox ID Animal
                TextBox txtId = new TextBox();
                txtId.Name = $"txtIdAnimal_{i}";
                txtId.Location = new Point(125, yPos);
                txtId.Size = new Size(90, 27);
                txtId.Font = fuenteEstilo;
                panelContenedor.Controls.Add(txtId);

                // 3. Label Sexo
                Label lblSexo = new Label();
                lblSexo.Text = "Sexo:";
                lblSexo.Location = new Point(235, yPos + 4);
                lblSexo.AutoSize = true;
                lblSexo.Font = fuenteEstilo;
                lblSexo.ForeColor = Color.White;
                panelContenedor.Controls.Add(lblSexo);

                // 4. ComboBox Sexo
                ComboBox cmbSexo = new ComboBox();
                cmbSexo.Name = $"cmbSexo_{i}";
                cmbSexo.Location = new Point(285, yPos);
                cmbSexo.Size = new Size(110, 28);
                cmbSexo.Font = fuenteEstilo;
                cmbSexo.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbSexo.Items.AddRange(new object[] { "Macho", "Hembra" });
                cmbSexo.SelectedIndex = 0;
                panelContenedor.Controls.Add(cmbSexo);

                // 5. Checkbox Es Productor
                CheckBox chkProductor = new CheckBox();
                chkProductor.Name = $"chkProductor_{i}";
                chkProductor.Text = "Es Productor";
                chkProductor.Location = new Point(410, yPos + 2);
                chkProductor.AutoSize = true;
                chkProductor.Font = fuenteEstilo;
                chkProductor.ForeColor = Color.White;
                panelContenedor.Controls.Add(chkProductor);

                yPos += 45; // Salto vertical para la siguiente fila
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ListaAnimales.Clear();

            // Recorremos los controles que agregamos al panel para extraer la información
            // Como sabemos que creamos filas basadas en índices, buscamos por nombre o tipo
            foreach (Control ctrl in panelContenedor.Controls)
            {
                if (ctrl is TextBox txt && txt.Name.StartsWith("txtIdAnimal_"))
                {
                    // Extraemos el índice numérico del control (ej: "txtIdAnimal_0" -> "0")
                    string indice = txt.Name.Split('_')[1];

                    // Buscamos sus compañeros en el mismo panel por el mismo índice
                    ComboBox cmb = panelContenedor.Controls[$"cmbSexo_{indice}"] as ComboBox;
                    CheckBox chk = panelContenedor.Controls[$"chkProductor_{indice}"] as CheckBox;

                    // Creamos el objeto con los datos cargados por el usuario
                    var animal = new AnimalItemDto
                    {
                        NroAnimal = txt.Text.Trim(),
                        Sexo = cmb != null ? cmb.SelectedItem?.ToString() ?? string.Empty : string.Empty,
                        EsProductor = chk != null && chk.Checked
                    };

                    ListaAnimales.Add(animal);
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
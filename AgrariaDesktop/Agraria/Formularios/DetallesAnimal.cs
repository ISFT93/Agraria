using Agraria.Negocio.BLL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Agraria.Formularios
{
    public partial class DetallesAnimal : Form
    {
        public List<AnimalItemDto> ListaAnimales { get; private set; }
        private int cantidadLote;
        private List<ItemAnimalControl> filasAnimales = new List<ItemAnimalControl>();

        public DetallesAnimal(int cantidad)
        {
            InitializeComponent();
            cantidadLote = cantidad;
            ConstruirFilasDinamicas();
        }

        private void ConstruirFilasDinamicas()
        {
            // Asumiendo que en tu diseñador de DetallesAnimal agregaste un Panel llamado 'panelContenedor'
            panelContenedor.Controls.Clear();
            filasAnimales.Clear();

            int yPos = 10;
            for (int i = 0; i < cantidadLote; i++)
            {
                var fila = new ItemAnimalControl();
                fila.Location = new Point(10, yPos);

                // Opcional: si quieres mostrar un identificador o número de orden visual, 
                // puedes ajustar el texto si tu ItemAnimalControl tiene una etiqueta para ello.

                panelContenedor.Controls.Add(fila);
                filasAnimales.Add(fila);
                yPos += fila.Height + 5; // Espacio vertical dinámico basado en la altura del control
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ListaAnimales = new List<AnimalItemDto>();

            foreach (var fila in filasAnimales)
            {
                string nroAnimal = fila.IdAnimal;
                string sexo = fila.Sexo;
                bool esProductor = fila.EsProductor;

                if (string.IsNullOrWhiteSpace(nroAnimal))
                {
                    MessageBox.Show("Por favor, complete el número para todos los animales.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ListaAnimales.Add(new AnimalItemDto
                {
                    NroAnimal = nroAnimal,
                    Sexo = string.IsNullOrEmpty(sexo) ? "Macho" : sexo,
                    EsProductor = esProductor
                });
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
using Agraria.Negocio.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Agraria.Formularios
{
    public partial class DetallesAnimal : Form
    {
        public List<AnimalItemDto> ListaAnimales { get; private set; }
        private int cantidadLote;
        private DataTable datosPrevios;
        private List<ItemAnimalControl> filasAnimales = new List<ItemAnimalControl>();

        // Constructor modificado para recibir datos existentes (opcional)
        public DetallesAnimal(int cantidad, DataTable dtAnimales = null)
        {
            InitializeComponent();
            cantidadLote = cantidad;
            datosPrevios = dtAnimales;
            ConstruirFilasDinamicas();
        }

        private void ConstruirFilasDinamicas()
        {
            panelContenedor.Controls.Clear();
            filasAnimales.Clear();

            int yPos = 10;
            for (int i = 0; i < cantidadLote; i++)
            {
                var fila = new ItemAnimalControl();
                fila.Location = new Point(10, yPos);

                // Si hay datos en la BD para este índice, los cargamos en el control
                if (datosPrevios != null && i < datosPrevios.Rows.Count)
                {
                    DataRow dr = datosPrevios.Rows[i];
                    fila.IdAnimal = dr["nro_animal"]?.ToString();
                    fila.Sexo = dr["sexo"]?.ToString();

                    if (dr["es_productor"] != DBNull.Value)
                    {
                        fila.EsProductor = Convert.ToBoolean(dr["es_productor"]);
                    }
                }

                panelContenedor.Controls.Add(fila);
                filasAnimales.Add(fila);
                yPos += fila.Height + 5;
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
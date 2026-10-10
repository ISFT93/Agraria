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

        // Nueva variable para saber si estamos modificando
        private long? idStockEditar = null;

        // Constructor modificado para recibir el ID del stock
        public DetallesAnimal(int cantidad, DataTable dtAnimales = null, long? idStock = null)
        {
            InitializeComponent();
            cantidadLote = cantidad;
            datosPrevios = dtAnimales;
            idStockEditar = idStock; // Guardamos el ID
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

                var nuevoAnimal = new AnimalItemDto
                {
                    NroAnimal = nroAnimal,
                    Sexo = string.IsNullOrEmpty(sexo) ? "Macho" : sexo,
                    EsProductor = esProductor
                };

                ListaAnimales.Add(nuevoAnimal);

                // SI ESTAMOS MODIFICANDO: Guardamos el animal directo en la BD
                if (idStockEditar != null)
                {
                    AbmStockBLL bll = new AbmStockBLL();
                    bll.UpdateDetalleAnimal(idStockEditar.Value, nuevoAnimal.NroAnimal, nuevoAnimal.Sexo, nuevoAnimal.EsProductor);
                }
            }

            // AVISOS AL USUARIO
            if (idStockEditar != null)
            {
                MessageBox.Show("Detalles de los animales actualizados en la base de datos.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // AVISO DE RETENCIÓN EN MEMORIA (Para registros nuevos)
                MessageBox.Show("Detalles confirmados. Recuerde hacer clic en 'Aceptar' en la ventana principal para guardar el stock en la base de datos.", "Datos en Memoria", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
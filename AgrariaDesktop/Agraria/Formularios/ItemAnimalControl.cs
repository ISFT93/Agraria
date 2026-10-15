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
    public partial class ItemAnimalControl : UserControl
    {
        public ItemAnimalControl()
        {
            InitializeComponent();

            // Si no cargaste los ítems del sexo en el diseñador, podés agregarlos acá:
            if (cmbSexoAnimal.Items.Count == 0)
            {
                cmbSexoAnimal.Items.AddRange(new object[] { "Macho", "Hembra" });
                cmbSexoAnimal.SelectedIndex = 0;
            }
        }

        // Propiedades públicas con GET y SET para permitir lectura y escritura
        public string IdAnimal
        {
            get { return txtIdAnimal.Text.Trim(); }
            set { txtIdAnimal.Text = value; }
        }

        public string Sexo
        {
            get { return cmbSexoAnimal.Text; }
            set { cmbSexoAnimal.Text = value; }
        }

        public bool EsProductor
        {
            get { return chkEsProductor.Checked; }
            set { chkEsProductor.Checked = value; }
        }
    }
}

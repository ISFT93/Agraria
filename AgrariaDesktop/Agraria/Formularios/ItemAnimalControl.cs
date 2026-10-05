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

        // Propiedades públicas para que DetallesAnimal pueda extraer lo que cargó el usuario
        // (Asegurate de que los nombres de tus controles en el diseñador coincidan con estos)
        public string IdAnimal => txtIdAnimal.Text.Trim();
        public string Sexo => cmbSexoAnimal.Text;
        public bool EsProductor => chkEsProductor.Checked;
    }
}

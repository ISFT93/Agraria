using System;
using System.Data;
using System.Windows.Forms;
using Agraria.Datos.DAL;
using Agraria.Datos.DTO;
using Agraria.Datos.Entidades;
using Agraria.Negocio.BLL;

namespace Agraria.Formularios
{
    public partial class AbmAnimales : Form
    {
        private AbmAnimalDAL AbmanimalDAL = new AbmAnimalDAL();
        private AbmAnimalBLL abmAnimalBLL = new AbmAnimalBLL();
        private AnimalDTO animalEdicion = null;
        private UsuarioLoginDTO _usuarioActual;

     
        public AbmAnimales(UsuarioLoginDTO usuarioLogeado)
        {
            InitializeComponent();
            _usuarioActual = usuarioLogeado;
        }

      
        public AbmAnimales(AnimalDTO animalParaEditar, UsuarioLoginDTO usuarioLogeado) : this(usuarioLogeado)
        {
            this.animalEdicion = animalParaEditar;
        }

        private void AbmAnimal_Load(object sender, EventArgs e)
        {
            if (_usuarioActual == null)
            {
                _usuarioActual = new UsuarioLoginDTO { Id = 1 };
            }

            CargarCombos();
            TxtCodigo.Enabled = false;

            if (animalEdicion != null)
            {
                TxtCodigo.Text = animalEdicion.IdAnimal.ToString();
                txtNombreComun.Text = animalEdicion.NombreComun;
                txtNombreCientifico.Text = animalEdicion.NombreCientifico;
                txtStock.Text = animalEdicion.MinimoStock.ToString();

                if (animalEdicion.IdTipo > 0) CbTipoAnimal.SelectedValue = animalEdicion.IdTipo;
                if (animalEdicion.IdRubro > 0) CbRubro.SelectedValue = animalEdicion.IdRubro;
                if (animalEdicion.IdSubrubro > 0) CbSubrubro.SelectedValue = animalEdicion.IdSubrubro;
            }
            else
            {
                long proximoId = abmAnimalBLL.GenerarIdBloque(_usuarioActual.Id);
                TxtCodigo.Text = proximoId.ToString();
                TxtCodigo.Focus();
            }
        }

        private void CargarCombos()
        {
            try
            {
                CbTipoAnimal.DropDownStyle = ComboBoxStyle.DropDownList;
                CbRubro.DropDownStyle = ComboBoxStyle.DropDownList;
                CbSubrubro.DropDownStyle = ComboBoxStyle.DropDownList;

                CbTipoAnimal.DataSource = abmAnimalBLL.CargarCombo("Tipo_animal");
                CbTipoAnimal.DisplayMember = "Nombre";
                CbTipoAnimal.ValueMember = "Id_tipo_animal";

                CbRubro.DataSource = abmAnimalBLL.CargarCombo("rubro");
                CbRubro.DisplayMember = "Nombre";
                CbRubro.ValueMember = "Id_rubro";

                CbSubrubro.DataSource = abmAnimalBLL.CargarCombo("subrubro");
                CbSubrubro.DisplayMember = "Nombre";
                CbSubrubro.ValueMember = "Id_subrubro";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los desplegables: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombreComun.Text))
                {
                    MessageBox.Show("El nombre común es obligatorio.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombreComun.Focus();
                    return;
                }

                bool esModificacion = (animalEdicion != null);
                long idAnimalFinal = esModificacion ? animalEdicion.IdAnimal : abmAnimalBLL.GenerarIdBloque(_usuarioActual.Id);

                Animal animal = new Animal
                {
                    IdAnimal = idAnimalFinal,
                    NombreComun = txtNombreComun.Text.Trim(),
                    NombreCientifico = txtNombreCientifico.Text.Trim(),
                    IdTipo = Convert.ToInt32(CbTipoAnimal.SelectedValue),
                    IdRubro = Convert.ToInt32(CbRubro.SelectedValue),
                    IdSubrubro = Convert.ToInt32(CbSubrubro.SelectedValue),
                    MinimoStock = float.Parse(txtStock.Text)
                };

                abmAnimalBLL.Guardar(animal, esModificacion, _usuarioActual.Id);

                MessageBox.Show("Datos guardados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AbmAnimal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
            {
                DialogResult respuesta = MessageBox.Show(
                    "¿Está seguro de que desea salir? Los datos no guardados se perderán.",
                    "Confirmar Salida",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (respuesta == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
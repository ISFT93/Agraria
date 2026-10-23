using Agraria.Datos.DAL;
using Agraria.Datos.DTO;
using Agraria.Datos.Entidades;
using Agraria.Negocio.BLL;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Data;
using System.Windows.Forms;

namespace Agraria.Formularios
{
    public partial class AbmAnimales : MaterialForm
    {
        private AbmAnimalDAL AbmanimalDAL = new AbmAnimalDAL();
        private AbmAnimalesBLL abmAnimalBLL = new AbmAnimalesBLL();
        private AnimalDTO animalEdicion = null;
        private UsuarioLoginDTO _usuarioActual;

     
        public AbmAnimales(UsuarioLoginDTO usuarioLogeado)
        {
            InitializeComponent();
            _usuarioActual = usuarioLogeado;
            // Configurar el MaterialSkinManager
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT; // O DARK

            // Configurar esquemas de color (Ejemplo: Azul / Indigo)
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Cyan800,
                Primary.Cyan900,
                Primary.Cyan500,
                Accent.Cyan200,
                TextShade.WHITE
            );
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

                CbTipoAnimal.DataSource = abmAnimalBLL.CargarTipoAnimal();
                CbTipoAnimal.DisplayMember = "Nombre";
                CbTipoAnimal.ValueMember = "Id_catalogo_item";

                CbRubro.DataSource = abmAnimalBLL.CargarCombo("rubros");
                CbRubro.DisplayMember = "Nombre";
                CbRubro.ValueMember = "Id_rubro";

                CbSubrubro.DataSource = abmAnimalBLL.CargarCombo("subrubros");
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

                Animales animal = new Animales
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
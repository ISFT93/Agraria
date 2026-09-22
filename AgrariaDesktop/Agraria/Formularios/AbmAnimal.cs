using System;
using System.Data;
using System.Windows.Forms;
using Agraria.Datos.DAL;
using Agraria.Datos.DTO;
using Agraria.Datos.Entidades;
using Agraria.Negocio.BLL;

namespace Agraria.Formularios
{
    public partial class AbmAnimal : Form
    {
        private AbmAnimalDAL AbmanimalDAL = new AbmAnimalDAL();
        private AbmAnimalBLL abmAnimalBLL = new AbmAnimalBLL();
        private AnimalDTO animalEdicion = null;
        private int _idUsuarioActual = 1; // ID de usuario logueado en sesión

        // Constructor para registros NUEVOS
        public AbmAnimal()
        {
            InitializeComponent();
        }

        // Constructor para registros NUEVOS especificando el usuario
        public AbmAnimal(int idUsuarioLogueado)
        {
            InitializeComponent();
            this._idUsuarioActual = idUsuarioLogueado;
        }

        // Constructor para MODIFICAR un registro existente
        public AbmAnimal(AnimalDTO animalParaEditar)
        {
            InitializeComponent();
            this.animalEdicion = animalParaEditar;
        }

        private void AbmAnimal_Load(object sender, EventArgs e)
        {
            // Carga datos de los combos y bloquearles la escritura libre
            CargarCombos();

            // Bloquea la caja del código para que no sea editable
            TxtCodigo.Enabled = false;

            if (animalEdicion != null)
            {
                // Modificar: Carga el Id actual del animal
                TxtCodigo.Text = animalEdicion.IdAnimal.ToString();

                txtNombreComun.Text = animalEdicion.NombreComun;
                txtNombreCientifico.Text = animalEdicion.NombreCientifico;
                dtpFechaNacimiento.Value = animalEdicion.FechaNacimiento;

                if (animalEdicion.IdTipo > 0) CbTipoAnimal.SelectedValue = animalEdicion.IdTipo;
                if (animalEdicion.IdRubro > 0) CbRubro.SelectedValue = animalEdicion.IdRubro;
                if (animalEdicion.IdSubrubro > 0) CbSubrubro.SelectedValue = animalEdicion.IdSubrubro;

                if (!string.IsNullOrEmpty(animalEdicion.Sexo))
                {
                    CbSexo.SelectedItem = animalEdicion.Sexo.ToLower();
                }
            }
            else
            {
                // Alta: Genera el código de bloque único
                long proximoId = abmAnimalBLL.GenerarIdBloque(_idUsuarioActual);
                TxtCodigo.Text = proximoId.ToString();
            }
        }

        private void CargarCombos()
        {
            try
            {
                // Configurar DropDownList en todos los combos para BLOQUEAR la escritura encima
                CbTipoAnimal.DropDownStyle = ComboBoxStyle.DropDownList;
                CbRubro.DropDownStyle = ComboBoxStyle.DropDownList;
                CbSubrubro.DropDownStyle = ComboBoxStyle.DropDownList;
                CbSexo.DropDownStyle = ComboBoxStyle.DropDownList;

                // Carga de clasificadores desde la DAL
                CbTipoAnimal.DataSource = AbmanimalDAL.ObtenerTabla("Tipo_animal");
                CbTipoAnimal.DisplayMember = "Nombre";
                CbTipoAnimal.ValueMember = "Id_tipo_animal";

                CbRubro.DataSource = AbmanimalDAL.ObtenerTabla("rubro");
                CbRubro.DisplayMember = "Nombre";
                CbRubro.ValueMember = "Id_rubro";

                CbSubrubro.DataSource = AbmanimalDAL.ObtenerTabla("subrubro");
                CbSubrubro.DisplayMember = "Nombre";
                CbSubrubro.ValueMember = "Id_subrubro";

                // Carga de ítems fijos para 'sexo'
                CbSexo.DataSource = null;
                CbSexo.Items.Clear();
                CbSexo.Items.Add("Hembra");
                CbSexo.Items.Add("Macho");
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
                // Validaciones
                if (string.IsNullOrWhiteSpace(txtNombreComun.Text))
                {
                    MessageBox.Show("El nombre común es obligatorio.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombreComun.Focus();
                    return;
                }

                if (CbSexo.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar el sexo del animal.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CbSexo.Focus();
                    return;
                }

                // Determina si es modificación o alta por bloque
                bool esModificacion = (animalEdicion != null);
                long idAnimalFinal = esModificacion ? animalEdicion.IdAnimal : abmAnimalBLL.GenerarIdBloque(_idUsuarioActual);

                // Captura de datos
                Animal animal = new Animal
                {
                    IdAnimal = idAnimalFinal,
                    NombreComun = txtNombreComun.Text.Trim(),
                    NombreCientifico = txtNombreCientifico.Text.Trim(),
                    IdTipo = Convert.ToInt32(CbTipoAnimal.SelectedValue),
                    IdRubro = Convert.ToInt32(CbRubro.SelectedValue),
                    IdSubrubro = Convert.ToInt32(CbSubrubro.SelectedValue),
                    FechaNacimiento = dtpFechaNacimiento.Value.Date,
                    Sexo = CbSexo.SelectedItem.ToString()
                };

                // 4. Guardado directo
                abmAnimalBLL.Guardar(animal, esModificacion, _idUsuarioActual);

                // 5. Confirmar y cerrar para evitar reenvíos / duplicados
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
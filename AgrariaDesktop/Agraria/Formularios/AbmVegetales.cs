using Agraria.Datos.DTO;
using Agraria.Negocio.BLL;
using System;
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
    public partial class AbmVegetales : Form
    {
        private AbmVegetalesBLL bll = new AbmVegetalesBLL();
        private long? idVegetalEditar = null;
        private UsuarioLoginDTO _usuarioActual; // Recibimos la sesión real

        // Constructor para NUEVO
        public AbmVegetales(UsuarioLoginDTO usuarioLogeado)
        {
            InitializeComponent();
            _usuarioActual = usuarioLogeado; // <--- ¡Faltaba asignar esta variable aquí!
            CargarCombos();
            txtCodigoVegetal.Enabled = false;
            txtNombreComun.Focus();
        }

        // Constructor para MODIFICAR
        public AbmVegetales(long idVegetal, UsuarioLoginDTO usuarioLogeado) : this(usuarioLogeado)
        {
            idVegetalEditar = idVegetal;
            CargarDatos(idVegetalEditar.Value);
            txtCodigoVegetal.Enabled = false; // Deshabilitamos el campo de código para edición
        }

        private void CargarCombos()
        {
            LlenarCombo(cmbTipoCultivo, "tipo_cultivo", "nombre", "id_tipo_cultivo");
            LlenarCombo(cmbCicloVida, "ciclo_vida", "nombre", "id_ciclo_vida");
            LlenarCombo(cmbMetodoSiembra, "metodo_siembra", "nombre", "id_metodo_siembra");
            LlenarCombo(cmbEstadoFenologico, "estado_fenologico", "nombre", "id_estado_fenologico");

            // Este va a buscar los datos directamente ejecutando la consulta en SQL
            DataTable dtReq = bll.CargarRequerimientoHidrico();
            cmbRequerimientosHidrico.DataSource = dtReq;
            cmbRequerimientosHidrico.DisplayMember = "nombre";
            cmbRequerimientosHidrico.ValueMember = "nombre";
            cmbRequerimientosHidrico.SelectedIndex = -1;
        }

        private void LlenarCombo(ComboBox combo, string tabla, string display, string value)
        {
            DataTable dt = bll.CargarCombo(tabla);
            combo.DataSource = dt;
            combo.DisplayMember = display;
            combo.ValueMember = value;
            combo.SelectedIndex = -1;
        }

        private void CargarDatos(long id)
        {
            DataTable dt = bll.BuscarPorId(id);
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                txtCodigoVegetal.Text = dr["id_vegetal"].ToString();
                txtCodigoVegetal.Enabled = false;
                txtNombreComun.Text = dr["nombre_comun"].ToString();
                txtNombreCientifico.Text = dr["nombre_cientifico"]?.ToString();
                txtVariedadHibrido.Text = dr["variedad_hibrido"]?.ToString();
                if (dr["periodosiembra"] != DBNull.Value && int.TryParse(dr["periodosiembra"].ToString(), out int periodoGuardado))
                {
                    // El operador & compara si el número guardado contiene la potencia correspondiente
                    chkVerano.Checked = (periodoGuardado & 2) == 2;
                    chkOtoño.Checked = (periodoGuardado & 4) == 4;
                    chkInvierno.Checked = (periodoGuardado & 8) == 8;
                    chkPrimavera.Checked = (periodoGuardado & 16) == 16;
                }
                else
                {
                    // Si está vacío, destilda todo
                    chkVerano.Checked = false;
                    chkOtoño.Checked = false;
                    chkInvierno.Checked = false;
                    chkPrimavera.Checked = false;
                }

                // Los combos que usan tablas auxiliares buscan por su ID numérico:
                cmbTipoCultivo.SelectedValue = dr["id_tipo_cultivo"] != DBNull.Value ? dr["id_tipo_cultivo"] : -1;
                cmbCicloVida.SelectedValue = dr["id_ciclo_vida"] != DBNull.Value ? dr["id_ciclo_vida"] : -1;
                cmbMetodoSiembra.SelectedValue = dr["id_metodo_siembra"] != DBNull.Value ? dr["id_metodo_siembra"] : -1;
                cmbEstadoFenologico.SelectedValue = dr["id_estado_fenologico"] != DBNull.Value ? dr["id_estado_fenologico"] : -1;

                // Como requerimiento_hidrico es texto directo de la columna, seleccionamos el valor por su texto:
                if (dr["requerimiento_hidrico"] != DBNull.Value)
                {
                    cmbRequerimientosHidrico.SelectedValue = dr["requerimiento_hidrico"] != DBNull.Value ? dr["requerimiento_hidrico"].ToString() : null;
                }
                else
                {
                    cmbRequerimientosHidrico.SelectedIndex = -1;
                }
            }
        }
        private void cmbAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombreComun.Text))
                {
                    MessageBox.Show("El nombre común es obligatorio.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                long idVegetalFinal;
                bool esModificacion = (idVegetalEditar != null);

                if (!esModificacion)
                {    
                    int idUsuarioLogueado = _usuarioActual.Id;
                    idVegetalFinal = bll.GenerarIdBloque(idUsuarioLogueado);
                }
                else
                {
                    idVegetalFinal = idVegetalEditar.Value;
                }
                string nombreComun = txtNombreComun.Text.Trim();
                string nombreCientifico = txtNombreCientifico.Text.Trim();
                string variedad = txtVariedadHibrido.Text.Trim();
                int sumaPeriodo = 0;
                if (chkVerano.Checked) sumaPeriodo += 2;
                if (chkOtoño.Checked) sumaPeriodo += 4;
                if (chkInvierno.Checked) sumaPeriodo += 8;
                if (chkPrimavera.Checked) sumaPeriodo += 16;
                string periodosiembra = sumaPeriodo.ToString();
                int? tipoCultivo = cmbTipoCultivo.SelectedValue != null ? (int?)Convert.ToInt32(cmbTipoCultivo.SelectedValue) : null;
                int? cicloVida = cmbCicloVida.SelectedValue != null ? (int?)Convert.ToInt32(cmbCicloVida.SelectedValue) : null;
                int? metodoSiembra = cmbMetodoSiembra.SelectedValue != null ? (int?)Convert.ToInt32(cmbMetodoSiembra.SelectedValue) : null;
                int? estadoFenologico = cmbEstadoFenologico.SelectedValue != null ? (int?)Convert.ToInt32(cmbEstadoFenologico.SelectedValue) : null;
                string reqHidrico = cmbRequerimientosHidrico.SelectedValue != null ? cmbRequerimientosHidrico.SelectedValue.ToString() : null;
                bll.Guardar(idVegetalFinal, nombreComun, nombreCientifico, variedad, tipoCultivo, cicloVida, periodosiembra, metodoSiembra, estadoFenologico, reqHidrico, esModificacion);

                MessageBox.Show("Datos guardados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
using Agraria.Datos.DTO;
using Agraria.Negocio.BLL;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Agraria.Formularios
{
    public partial class AbmCiclos : MaterialForm
    {
        private AbmCiclosBLL bll = new AbmCiclosBLL();
        private UsuarioLoginDTO _usuarioActual;
        private long? _idCicloEditar = null;
        private long _idCicloGenerado = 0;

        private BindingList<ActividadModeloDTO> listaActividades = new BindingList<ActividadModeloDTO>();

        public AbmCiclos(UsuarioLoginDTO usuarioLogeado)
        {
            InitializeComponent();
            _usuarioActual = usuarioLogeado;
            ConfigurarTabsIniciales();

            dtgvActividadesCicloModelo.DataSource = listaActividades;


            // Configurar el MaterialSkinManager
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT; // O DARK

            // Configurar esquemas de color (Ejemplo:  Green , LightGreen  y Teal )
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Green800,
                Primary.Green900,
                Primary.Green500,
                Accent.Green200,
          TextShade.WHITE
            );
        }

        public AbmCiclos(long idCiclo, UsuarioLoginDTO usuarioLogeado) : this(usuarioLogeado)
        {
            _idCicloEditar = idCiclo;
        }

        private void AbmCiclos_Load(object sender, EventArgs e)
        {
            CargarCombosCatalogos();

            if (_idCicloEditar != null)
            {
                CargarDatosCiclo(_idCicloEditar.Value);
            }
        }

        private void ConfigurarTabsIniciales()
        {
            tabControl.Appearance = TabAppearance.FlatButtons;
            tabControl.ItemSize = new System.Drawing.Size(0, 1);
            tabControl.SizeMode = TabSizeMode.Fixed;
        }

        private void CargarCombosCatalogos()
        {
            LlenarCombo(cmbModoInicio, 14);

            CargarComboBooleano(cmbActivo);


            txtCreadoPor.Text = _usuarioActual.NombreUsuario;
            txtCreadoPor.Enabled = false;
        }

        private void LlenarCombo(ComboBox combo, int idCatalogo)
        {
           
            if (combo == null)
            {
                MessageBox.Show($"El ComboBox asignado para cargar el catálogo {idCatalogo} no existe o tiene otro nombre en el diseño visual.", "Falta Control", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataTable dt = bll.ObtenerItemsCatalogo(idCatalogo);
            combo.DataSource = dt;
            combo.DisplayMember = "Nombre";
            combo.ValueMember = "Id_catalogo_item";
            combo.SelectedIndex = -1;
        }

        private void CargarComboBooleano(ComboBox combo)
        {
            combo.Items.Clear();
            combo.Items.Add(new { Text = "Sí", Value = true });
            combo.Items.Add(new { Text = "No", Value = false });
            combo.DisplayMember = "Text";
            combo.ValueMember = "Value";
            combo.SelectedIndex = -1;
        }

        // ========================================================
        // NAVEGACIÓN ENTRE TABS
        // ========================================================

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreCicloModelo.Text) || cmbModoInicio.SelectedIndex == -1)
            {
                MessageBox.Show("Complete los campos obligatorios: Nombre y Modo de Inicio.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_idCicloEditar == null && _idCicloGenerado == 0)
                _idCicloGenerado = DateTime.Now.Ticks % 100000;

            tabControl.SelectedTab = tabPageActividadesCicloModelo;
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabPageCicloModelo;
        }

        private void btnSiguiente2_Click(object sender, EventArgs e)
        {
            if (listaActividades.Count == 0 || dtgvActividadesCicloModelo.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe agregar y seleccionar al menos una Actividad para cargarle elementos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Atamos la grilla del Tab 3 a la sub-lista de la Actividad seleccionada
            var actividadActual = ObtenerActividadSeleccionada();
            dtgvActividadesElementos.DataSource = actividadActual.ListaElementos;


            tabControl.SelectedTab = tabPageActividadesElementos;
        }

        private void btnAnterior1_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabPageActividadesCicloModelo;
        }

        // ========================================================
        // LÓGICA DE LA PESTAÑA ACTIVIDADES (TAB 2)
        // ========================================================

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int nuevoOrden = listaActividades.Count + 1;
            AbmActividadesCicloModelo frmActividad = new AbmActividadesCicloModelo(nuevoOrden);

            if (frmActividad.ShowDialog() == DialogResult.OK)
            {
                listaActividades.Add(frmActividad.NuevaActividad);
                ReordenarActividades();
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dtgvActividadesCicloModelo.SelectedRows.Count > 0)
            {
                int index = dtgvActividadesCicloModelo.SelectedRows[0].Index;
                listaActividades.RemoveAt(index);
                ReordenarActividades();
            }
        }

        private void btnSubir_Click(object sender, EventArgs e)
        {
            if (dtgvActividadesCicloModelo.SelectedRows.Count > 0)
            {
                int index = dtgvActividadesCicloModelo.SelectedRows[0].Index;
                if (index > 0)
                {
                    var item = listaActividades[index];
                    listaActividades.RemoveAt(index);
                    listaActividades.Insert(index - 1, item);
                    ReordenarActividades();
                    dtgvActividadesCicloModelo.Rows[index - 1].Selected = true;
                }
            }
        }

        private void btnBajar_Click(object sender, EventArgs e)
        {
            if (dtgvActividadesCicloModelo.SelectedRows.Count > 0)
            {
                int index = dtgvActividadesCicloModelo.SelectedRows[0].Index;
                if (index < listaActividades.Count - 1)
                {
                    var item = listaActividades[index];
                    listaActividades.RemoveAt(index);
                    listaActividades.Insert(index + 1, item);
                    ReordenarActividades();
                    dtgvActividadesCicloModelo.Rows[index + 1].Selected = true;
                }
            }
        }

        private void ReordenarActividades()
        {
            for (int i = 0; i < listaActividades.Count; i++)
            {
                listaActividades[i].Orden = i + 1;
            }
            dtgvActividadesCicloModelo.Refresh();
        }

        // ========================================================
        // LÓGICA DE LA PESTAÑA ELEMENTOS (TAB 3)
        // ========================================================

        private ActividadModeloDTO ObtenerActividadSeleccionada()
        {
            if (dtgvActividadesCicloModelo.SelectedRows.Count > 0)
            {
                return (ActividadModeloDTO)dtgvActividadesCicloModelo.SelectedRows[0].DataBoundItem;
            }
            return null;
        }

        private void btnAgregarElemento_Click(object sender, EventArgs e)
        {
            var actividadActual = ObtenerActividadSeleccionada();
            if (actividadActual == null) return;

            int nuevoOrden = actividadActual.ListaElementos.Count + 1;
            AbmActividadesElementos frmElemento = new AbmActividadesElementos(nuevoOrden);

            if (frmElemento.ShowDialog() == DialogResult.OK)
            {
                actividadActual.ListaElementos.Add(frmElemento.NuevoElemento);
                ReordenarElementos(actividadActual);
            }
        }

        private void btnQuitarElemento_Click(object sender, EventArgs e)
        {
            var actividadActual = ObtenerActividadSeleccionada();
            if (actividadActual != null && dtgvActividadesElementos.SelectedRows.Count > 0)
            {
                int index = dtgvActividadesElementos.SelectedRows[0].Index;
                actividadActual.ListaElementos.RemoveAt(index);
                ReordenarElementos(actividadActual);
            }
        }

        private void btnSubirElemento_Click(object sender, EventArgs e)
        {
            var actividadActual = ObtenerActividadSeleccionada();
            if (actividadActual != null && dtgvActividadesElementos.SelectedRows.Count > 0)
            {
                int index = dtgvActividadesElementos.SelectedRows[0].Index;
                if (index > 0)
                {
                    var item = actividadActual.ListaElementos[index];
                    actividadActual.ListaElementos.RemoveAt(index);
                    actividadActual.ListaElementos.Insert(index - 1, item);
                    ReordenarElementos(actividadActual);
                    dtgvActividadesElementos.Rows[index - 1].Selected = true;
                }
            }
        }

        private void btnBajarElemento_Click(object sender, EventArgs e)
        {
            var actividadActual = ObtenerActividadSeleccionada();
            if (actividadActual != null && dtgvActividadesElementos.SelectedRows.Count > 0)
            {
                int index = dtgvActividadesElementos.SelectedRows[0].Index;
                if (index < actividadActual.ListaElementos.Count - 1)
                {
                    var item = actividadActual.ListaElementos[index];
                    actividadActual.ListaElementos.RemoveAt(index);
                    actividadActual.ListaElementos.Insert(index + 1, item);
                    ReordenarElementos(actividadActual);
                    dtgvActividadesElementos.Rows[index + 1].Selected = true;
                }
            }
        }

        private void ReordenarElementos(ActividadModeloDTO actividad)
        {
            for (int i = 0; i < actividad.ListaElementos.Count; i++)
            {
                actividad.ListaElementos[i].Orden = i + 1;
            }
            dtgvActividadesElementos.Refresh();
        }

        // ========================================================
        // GUARDADO FINAL CONSOLIDADO (TAB 3)
        // ========================================================
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Validar Cabecera
                if (string.IsNullOrWhiteSpace(txtNombreCicloModelo.Text) || cmbModoInicio.SelectedIndex == -1)
                {
                    MessageBox.Show("Complete los campos obligatorios del ciclo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. Validar que exista al menos una Actividad
                if (listaActividades == null || listaActividades.Count == 0)
                {
                    MessageBox.Show("Debe agregar al menos una actividad al ciclo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var act = listaActividades[0]; // Tomamos la primera actividad temporalmente para compatibilidad

                // 3. Validar que esa actividad tenga al menos un Elemento
                if (act.ListaElementos == null || act.ListaElementos.Count == 0)
                {
                    MessageBox.Show("Debe agregar al menos un elemento a la actividad seleccionada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var elem = act.ListaElementos[0]; // Extraemos el elemento desde la lista en memoria, no desde la UI

                // Datos del Ciclo
                string nombreCiclo = txtNombreCicloModelo.Text.Trim();
                string descCiclo = txtDescripcion.Text.Trim();
                decimal duracionCiclo = NumDuracionEstimada.Value;
                int modoInicio = Convert.ToInt32(cmbModoInicio.SelectedValue);
                bool activoCiclo = (bool)((dynamic)cmbActivo.SelectedItem).Value;
                DateTime fechaCreacion = dtpFechaCreacion.Value;
                int idCreador = _usuarioActual.Id;

                bool esModificacion = (_idCicloEditar != null);

                // Guardamos todo usando directamente elem.IdTipoMovimiento (Asegurate de que tu DTO tenga esta propiedad)
                bll.GuardarCicloCompleto(
                    _idCicloEditar, nombreCiclo, descCiclo, duracionCiclo, modoInicio, activoCiclo, fechaCreacion, idCreador,
                    act.Nombre, act.Descripcion, act.Orden, act.IdTipoActividad, act.Duracion, act.Demora, act.Aprobacion, act.EjecucionParcial, act.CondicionAvance, act.Activa,
                    elem.IdElemento, elem.IdTipoElemento, elem.IdTipoMovimiento, elem.CantidadPrevista, elem.IdUnidad, elem.Obligatorio, elem.Vendible, elem.PermiteSustitucion, "",
                    esModificacion
                );

                MessageBox.Show("El Modelo del Ciclo se ha guardado y configurado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }


        private void CargarDatosCiclo(long idCiclo)
        {
            // 1. Cargar Cabecera (Ciclo)
            DataTable dtCiclo = bll.ObtenerCicloPorId(idCiclo);
            if (dtCiclo.Rows.Count > 0)
            {
                DataRow row = dtCiclo.Rows[0];
                txtNombreCicloModelo.Text = row["nombre"].ToString();
                txtDescripcion.Text = row["descripcion"].ToString();
                NumDuracionEstimada.Value = Convert.ToDecimal(row["duracion_estimada"] == DBNull.Value ? 0 : row["duracion_estimada"]);
                cmbModoInicio.SelectedValue = row["modo_inicio"];
                cmbActivo.SelectedValue = Convert.ToBoolean(row["activo"]);
            }

            // 2. Cargar Actividades y sus Elementos
            DataTable dtActividades = bll.ObtenerActividadesPorCiclo(idCiclo);
            listaActividades.Clear();

            foreach (DataRow rowAct in dtActividades.Rows)
            {
                long idActividadModelo = Convert.ToInt64(rowAct["id_actividad_modelo"]);

                ActividadModeloDTO nuevaActividad = new ActividadModeloDTO
                {
                    Orden = Convert.ToInt32(rowAct["orden"]),
                    Nombre = rowAct["nombre"].ToString(),
                    Descripcion = rowAct["descripcion"].ToString(),
                    IdTipoActividad = Convert.ToInt32(rowAct["tipo_actividad"]),
                    Duracion = Convert.ToDecimal(rowAct["duracion_estimada"] == DBNull.Value ? 0 : rowAct["duracion_estimada"]),
                    Demora = rowAct["demora"] != DBNull.Value && Convert.ToBoolean(rowAct["demora"]),
                    Aprobacion = Convert.ToBoolean(rowAct["requiere_aprobacion"]),
                    EjecucionParcial = Convert.ToBoolean(rowAct["permite_ejecucion_parcial"]),
                    CondicionAvance = rowAct["condicion_avance"].ToString(),
                    Activa = Convert.ToBoolean(rowAct["activa"])
                };

                // Buscar elementos de esta actividad en específico
                DataTable dtElementos = bll.ObtenerElementosPorActividad(idActividadModelo);
                foreach (DataRow rowElem in dtElementos.Rows)
                {
                    nuevaActividad.ListaElementos.Add(new ActividadElementoModeloDTO
                    {
                        IdElemento = Convert.ToInt64(rowElem["id_elemento"]),
                        IdTipoElemento = Convert.ToInt32(rowElem["tipo_elemento"]),
                        IdTipoMovimiento = Convert.ToInt32(rowElem["tipo_movimiento"]),
                        IdUnidad = Convert.ToInt32(rowElem["id_unidad"]),
                        CantidadPrevista = Convert.ToDecimal(rowElem["cantidad_prevista"]),
                        Obligatorio = Convert.ToBoolean(rowElem["obligatorio"]),
                        PermiteSustitucion = rowElem["permite_sustitucion"] != DBNull.Value && Convert.ToBoolean(rowElem["permite_sustitucion"]),
                        Vendible = rowElem["vendible_destino"] != DBNull.Value && Convert.ToBoolean(rowElem["vendible_destino"])
                    });
                }

                listaActividades.Add(nuevaActividad);
            }
        }
    }
}
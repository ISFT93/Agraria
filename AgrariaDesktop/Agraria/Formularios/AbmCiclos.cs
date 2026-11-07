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

            // 1ro: Configurar la estructura de la grilla
            ConfigurarGrillaActividades();

            // 2do: Asignar los datos
            dtgvActividadesCicloModelo.DataSource = listaActividades;

            ConfigurarGrillaElementos();


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




            txtCreadoPor.Text = _usuarioActual.NombreUsuario;
            txtCreadoPor.Enabled = false;
        }

        private void LlenarCombo(ComboBox combo, int idCatalogo)
        {

            if (_idCicloEditar == null)
            {
                chkActivo.Checked = true;
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
            frmActividad.Text = "Nueva Actividad";

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
            frmElemento.Text = "Nuevo Elemento";

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
                    MessageBox.Show("Complete los campos obligatorios del ciclo (Nombre y Modo de Inicio).", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                // Lectura del MaskedTextBox de Duración Estimada (adaptado a decimal o string según tu DTO)
                // Si la BD espera decimal, puedes parsear el texto limpio:
                decimal duracionCiclo = 0;
                string textoDuracion = mskDuracionEstimada.Text.Replace(":", "").Trim();
                if (!string.IsNullOrEmpty(textoDuracion))
                {
                    decimal.TryParse(textoDuracion, out duracionCiclo);
                }

                int modoInicio = Convert.ToInt32(cmbModoInicio.SelectedValue);
                bool activoCiclo = chkActivo.Checked;
                
                int idCreador = _usuarioActual.Id;
                DateTime fechaCreacion = dtpFechaCreacion.Value;

                bool esModificacion = (_idCicloEditar != null);

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
        private void CargarDatosCiclo(long idCiclo)
        {
            // 1. Cargar Cabecera (Ciclo)
            DataTable dtCiclo = bll.ObtenerCicloPorId(idCiclo);
            if (dtCiclo.Rows.Count > 0)
            {
                DataRow row = dtCiclo.Rows[0];
                txtNombreCicloModelo.Text = row["nombre"].ToString();
                txtDescripcion.Text = row["descripcion"].ToString();

                // Cargar el valor en el MaskedTextBox
                mskDuracionEstimada.Text = row["duracion_estimada"] == DBNull.Value ? "0000000" : row["duracion_estimada"].ToString();

                cmbModoInicio.SelectedValue = row["modo_inicio"];
                chkActivo.Checked = Convert.ToBoolean(row["activo"]);
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

        private void ConfigurarGrillaActividades()
        {
            dtgvActividadesCicloModelo.AutoGenerateColumns = false;
            dtgvActividadesCicloModelo.Columns.Clear();

            // 1. Columnas de Datos 
            dtgvActividadesCicloModelo.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Orden", HeaderText = "Orden", Name = "colOrden", Width = 50 });
            dtgvActividadesCicloModelo.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nombre", HeaderText = "Nombre", Name = "colNombre", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dtgvActividadesCicloModelo.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "IdTipoActividad", HeaderText = "IdTipo", Name = "colIdTipoActividad", Visible = false });
            dtgvActividadesCicloModelo.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TipoActividad", HeaderText = "Tipo Actividad", Name = "colTipoActividad", Width = 120 });
            dtgvActividadesCicloModelo.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Duracion", HeaderText = "Duración", Name = "colDuracion", Width = 70 });

            // 2. Columna Botón: Modificar
            DataGridViewButtonColumn btnModificarGrid = new DataGridViewButtonColumn();
            btnModificarGrid.Name = "colBtnModificar";
            btnModificarGrid.HeaderText = "";
            btnModificarGrid.Text = "Modificar";
            btnModificarGrid.UseColumnTextForButtonValue = true;
            btnModificarGrid.Width = 80;
            dtgvActividadesCicloModelo.Columns.Add(btnModificarGrid);

            // 3. Columna Botón: Subir
            DataGridViewButtonColumn btnSubirGrid = new DataGridViewButtonColumn();
            btnSubirGrid.Name = "colBtnSubir";
            btnSubirGrid.HeaderText = "";
            btnSubirGrid.Text = "Subir ▲";
            btnSubirGrid.UseColumnTextForButtonValue = true;
            btnSubirGrid.Width = 70;
            dtgvActividadesCicloModelo.Columns.Add(btnSubirGrid);

            // 4. Columna Botón: Bajar
            DataGridViewButtonColumn btnBajarGrid = new DataGridViewButtonColumn();
            btnBajarGrid.Name = "colBtnBajar";
            btnBajarGrid.HeaderText = "";
            btnBajarGrid.Text = "Bajar ▼";
            btnBajarGrid.UseColumnTextForButtonValue = true;
            btnBajarGrid.Width = 70;
            dtgvActividadesCicloModelo.Columns.Add(btnBajarGrid);

            // 5. Columna Botón: Agregar Elementos
            DataGridViewButtonColumn btnAgregarElemGrid = new DataGridViewButtonColumn();
            btnAgregarElemGrid.Name = "colBtnAgregarElementos";
            btnAgregarElemGrid.HeaderText = "";
            btnAgregarElemGrid.Text = "Elementos";
            btnAgregarElemGrid.UseColumnTextForButtonValue = true;
            btnAgregarElemGrid.Width = 85;
            dtgvActividadesCicloModelo.Columns.Add(btnAgregarElemGrid);

            // 6. Columna Botón: Quitar Actividad
            DataGridViewButtonColumn btnQuitarGrid = new DataGridViewButtonColumn();
            btnQuitarGrid.Name = "colBtnQuitarActividad";
            btnQuitarGrid.HeaderText = "";
            btnQuitarGrid.Text = "Quitar";
            btnQuitarGrid.UseColumnTextForButtonValue = true;
            btnQuitarGrid.Width = 70;
            dtgvActividadesCicloModelo.Columns.Add(btnQuitarGrid);

            // Estilos visuales de cabecera[cite: 6]
            dtgvActividadesCicloModelo.EnableHeadersVisualStyles = false;
            dtgvActividadesCicloModelo.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.MediumSeaGreen;
            dtgvActividadesCicloModelo.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dtgvActividadesCicloModelo.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font(dtgvActividadesCicloModelo.Font, System.Drawing.FontStyle.Bold);
        }

        private void dtgvActividadesCicloModelo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignorar clics en los encabezados
            if (e.RowIndex < 0) return;

            string nombreColumna = dtgvActividadesCicloModelo.Columns[e.ColumnIndex].Name;
            var actividadSeleccionada = listaActividades[e.RowIndex];
            int index = e.RowIndex;

            // ACCIÓN: MODIFICAR
            if (nombreColumna == "colBtnModificar")
            {
                // Pasamos el objeto DTO seleccionado directamente al formulario
                AbmActividadesCicloModelo frmEdicion = new AbmActividadesCicloModelo(actividadSeleccionada);

                if (frmEdicion.ShowDialog() == DialogResult.OK)
                {
                    // Como la actividad se edita en memoria, solo refrescamos la grilla
                    dtgvActividadesCicloModelo.Refresh();
                }
            }

            // ACCIÓN: SUBIR[cite: 5]
            if (nombreColumna == "colBtnSubir" && index > 0)
            {
                var item = listaActividades[index];
                listaActividades.RemoveAt(index);
                listaActividades.Insert(index - 1, item);
                ReordenarActividades();
            }

            // ACCIÓN: BAJAR[cite: 5]
            if (nombreColumna == "colBtnBajar" && index < listaActividades.Count - 1)
            {
                var item = listaActividades[index];
                listaActividades.RemoveAt(index);
                listaActividades.Insert(index + 1, item);
                ReordenarActividades();
            }

            // ACCIÓN: AGREGAR ELEMENTOS[cite: 4, 7]
            if (nombreColumna == "colBtnAgregarElementos")
            {
                dtgvActividadesElementos.DataSource = actividadSeleccionada.ListaElementos;
                tabControl.SelectedTab = tabPageActividadesElementos;
            }

            // ACCIÓN: QUITAR
            if (nombreColumna == "colBtnQuitarActividad")
            {
                listaActividades.RemoveAt(index);
                ReordenarActividades();
            }
        }

        private void ConfigurarGrillaElementos()
        {
            dtgvActividadesElementos.AutoGenerateColumns = false;
            dtgvActividadesElementos.Columns.Clear();

            // 1. Columnas de Datos 
            dtgvActividadesElementos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Orden", HeaderText = "Orden", Name = "colOrdenElem", Width = 50 });
            dtgvActividadesElementos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TipoElemento", HeaderText = "Tipo", Name = "colTipoElem", Width = 100 });
            dtgvActividadesElementos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NombreElemento", HeaderText = "Elemento", Name = "colNombreElem", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dtgvActividadesElementos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "CantidadPrevista", HeaderText = "Cant. Prevista", Name = "colCantElem", Width = 90 });
            dtgvActividadesElementos.Columns.Add(new DataGridViewCheckBoxColumn { DataPropertyName = "Obligatorio", HeaderText = "Obligatorio", Name = "colObligatorioElem", Width = 75 });

            // 2. Columna Botón: Modificar
            DataGridViewButtonColumn btnModificarGrid = new DataGridViewButtonColumn();
            btnModificarGrid.Name = "colBtnModificarElem";
            btnModificarGrid.HeaderText = "";
            btnModificarGrid.Text = "Modificar";
            btnModificarGrid.UseColumnTextForButtonValue = true;
            btnModificarGrid.Width = 80;
            dtgvActividadesElementos.Columns.Add(btnModificarGrid);

            // 3. Columna Botón: Subir
            DataGridViewButtonColumn btnSubirGrid = new DataGridViewButtonColumn();
            btnSubirGrid.Name = "colBtnSubirElem";
            btnSubirGrid.HeaderText = "";
            btnSubirGrid.Text = "Subir ▲";
            btnSubirGrid.UseColumnTextForButtonValue = true;
            btnSubirGrid.Width = 70;
            dtgvActividadesElementos.Columns.Add(btnSubirGrid);

            // 4. Columna Botón: Bajar
            DataGridViewButtonColumn btnBajarGrid = new DataGridViewButtonColumn();
            btnBajarGrid.Name = "colBtnBajarElem";
            btnBajarGrid.HeaderText = "";
            btnBajarGrid.Text = "Bajar ▼";
            btnBajarGrid.UseColumnTextForButtonValue = true;
            btnBajarGrid.Width = 70;
            dtgvActividadesElementos.Columns.Add(btnBajarGrid);

            // 5. Columna Botón: Quitar Elemento
            DataGridViewButtonColumn btnQuitarGrid = new DataGridViewButtonColumn();
            btnQuitarGrid.Name = "colBtnQuitarElem";
            btnQuitarGrid.HeaderText = "";
            btnQuitarGrid.Text = "Quitar";
            btnQuitarGrid.UseColumnTextForButtonValue = true;
            btnQuitarGrid.Width = 70;
            dtgvActividadesElementos.Columns.Add(btnQuitarGrid);

            // Estilos visuales de cabecera
            dtgvActividadesElementos.EnableHeadersVisualStyles = false;
            dtgvActividadesElementos.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.MediumSeaGreen;
            dtgvActividadesElementos.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dtgvActividadesElementos.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font(dtgvActividadesElementos.Font, System.Drawing.FontStyle.Bold);
        }

        private void dtgvActividadesElementos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var actividadActual = ObtenerActividadSeleccionada();
            if (actividadActual == null) return;

            string nombreColumna = dtgvActividadesElementos.Columns[e.ColumnIndex].Name;
            int index = e.RowIndex;
            var elementoSeleccionado = actividadActual.ListaElementos[index];

            // ACCIÓN: MODIFICAR
            if (nombreColumna == "colBtnModificarElem")
            {
                // Abrimos el formulario de elementos pasándole el DTO actual para edición
                AbmActividadesElementos frmEdicion = new AbmActividadesElementos(elementoSeleccionado);

                if (frmEdicion.ShowDialog() == DialogResult.OK)
                {
                    // El formulario edita las propiedades en memoria, solo refrescamos
                    dtgvActividadesElementos.Refresh();
                }
            }

            // ACCIÓN: SUBIR
            if (nombreColumna == "colBtnSubirElem" && index > 0)
            {
                var item = actividadActual.ListaElementos[index];
                actividadActual.ListaElementos.RemoveAt(index);
                actividadActual.ListaElementos.Insert(index - 1, item);
                ReordenarElementos(actividadActual);
            }

            // ACCIÓN: BAJAR
            if (nombreColumna == "colBtnBajarElem" && index < actividadActual.ListaElementos.Count - 1)
            {
                var item = actividadActual.ListaElementos[index];
                actividadActual.ListaElementos.RemoveAt(index);
                actividadActual.ListaElementos.Insert(index + 1, item);
                ReordenarElementos(actividadActual);
            }

            // ACCIÓN: QUITAR
            if (nombreColumna == "colBtnQuitarElem")
            {
                actividadActual.ListaElementos.RemoveAt(index);
                ReordenarElementos(actividadActual);
            }
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }

}
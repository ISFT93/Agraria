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

        private BindingList<ActividadModeloDTO> listaActividades = new BindingList<ActividadModeloDTO>();

        // Actividad cuyos elementos se están viendo/editando en el Tab 3.
        // Antes se dependía de la fila seleccionada en la grilla del Tab 2, que se pierde
        // al reordenar/quitar y hacía que los elementos se cargaran en la actividad equivocada.
        private ActividadModeloDTO _actividadEnEdicion = null;

        public AbmCiclos(UsuarioLoginDTO usuarioLogeado)
        {
            InitializeComponent();
            _usuarioActual = usuarioLogeado;
            ConfigurarTabsIniciales();

            ConfigurarGrillaActividades();
            dtgvActividadesCicloModelo.DataSource = listaActividades;

            ConfigurarGrillaElementos();
            tabControl.SelectedIndexChanged += (s, e) => ActualizarTitulo();

            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
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
            try
            {
                CargarCombosCatalogos();

                if (_idCicloEditar != null)
                {
                    CargarDatosCiclo(_idCicloEditar.Value);
                }
                else
                {
                    chkActivo.Checked = true;
                    dtpFechaCreacion.Value = DateTime.Now;
                    txtCreadoPor.Text = _usuarioActual?.NombreUsuario;
                }

                txtCreadoPor.Enabled = false;
                dtpFechaCreacion.Enabled = false;

                ActualizarTitulo();   // <-- agregar
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el ciclo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarTabsIniciales()
        {
            tabControl.Appearance = TabAppearance.FlatButtons;
            tabControl.ItemSize = new System.Drawing.Size(0, 1);
            tabControl.SizeMode = TabSizeMode.Fixed;
        }

        // Cambia el título del formulario según la pestaña y el modo (Nuevo / Modificar)
        private void ActualizarTitulo()
        {
            string accion = _idCicloEditar == null ? "Cargar" : "Modificar";
            string seccion;

            if (tabControl.SelectedTab == tabPageCicloModelo)
                seccion = "Ciclo";
            else if (tabControl.SelectedTab == tabPageActividadesCicloModelo)
                seccion = "Actividad";
            else if (tabControl.SelectedTab == tabPageActividadesElementos)
                seccion = "Elemento";
            else
                seccion = "Ciclo";

            this.Text = $"{accion} {seccion}";
            this.Invalidate(); // MaterialForm dibuja el título: fuerza el repintado
        }

        private void CargarCombosCatalogos()
        {
            LlenarCombo(cmbModoInicio, 14);
        }

        private void LlenarCombo(ComboBox combo, int idCatalogo)
        {
            DataTable dt = bll.ObtenerItemsCatalogo(idCatalogo);
            combo.DataSource = dt;
            combo.DisplayMember = "Nombre";
            combo.ValueMember = "Id_catalogo_item";
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

            tabControl.SelectedTab = tabPageActividadesCicloModelo;
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabPageCicloModelo;
        }

        private void btnSiguiente2_Click(object sender, EventArgs e)
        {
            var actividadActual = ObtenerActividadSeleccionada();
            if (actividadActual == null)
            {
                MessageBox.Show("Debe agregar y seleccionar al menos una Actividad para cargarle elementos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            AbrirElementosDe(actividadActual);
        }

        private void btnAnterior1_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabPageActividadesCicloModelo;
        }

        private void AbrirElementosDe(ActividadModeloDTO actividad)
        {
            _actividadEnEdicion = actividad;
            dtgvActividadesElementos.DataSource = null;
            dtgvActividadesElementos.DataSource = actividad.ListaElementos;
            tabControl.SelectedTab = tabPageActividadesElementos;
        }

        // ========================================================
        // LÓGICA DE LA PESTAÑA ACTIVIDADES (TAB 2)
        // ========================================================

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int nuevoOrden = listaActividades.Count + 1;
            // Sin "using": MaterialSkinManager guarda referencia a los forms que maneja
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
                QuitarActividad(dtgvActividadesCicloModelo.SelectedRows[0].Index);
            }
        }

        private void QuitarActividad(int index)
        {
            if (index < 0 || index >= listaActividades.Count) return;

            var act = listaActividades[index];
            if (act.ListaElementos.Count > 0 &&
                MessageBox.Show($"La actividad '{act.Nombre}' tiene {act.ListaElementos.Count} elemento(s). ¿Quitarla igual?",
                                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            if (ReferenceEquals(act, _actividadEnEdicion))
            {
                _actividadEnEdicion = null;
                dtgvActividadesElementos.DataSource = null;
            }

            listaActividades.RemoveAt(index);
            ReordenarActividades();
        }

        private void btnSubir_Click(object sender, EventArgs e)
        {
            if (dtgvActividadesCicloModelo.SelectedRows.Count > 0)
                MoverActividad(dtgvActividadesCicloModelo.SelectedRows[0].Index, -1);
        }

        private void btnBajar_Click(object sender, EventArgs e)
        {
            if (dtgvActividadesCicloModelo.SelectedRows.Count > 0)
                MoverActividad(dtgvActividadesCicloModelo.SelectedRows[0].Index, +1);
        }

        private void MoverActividad(int index, int delta)
        {
            int destino = index + delta;
            if (index < 0 || destino < 0 || destino >= listaActividades.Count) return;

            var item = listaActividades[index];
            listaActividades.RemoveAt(index);
            listaActividades.Insert(destino, item);
            ReordenarActividades();

            dtgvActividadesCicloModelo.ClearSelection();
            dtgvActividadesCicloModelo.Rows[destino].Selected = true;
        }

        private void ReordenarActividades()
        {
            for (int i = 0; i < listaActividades.Count; i++)
            {
                listaActividades[i].Orden = i + 1;
            }
            // El DTO no implementa INotifyPropertyChanged: hay que avisarle a la grilla
            listaActividades.ResetBindings();
        }

        // ========================================================
        // LÓGICA DE LA PESTAÑA ELEMENTOS (TAB 3)
        // ========================================================

        private ActividadModeloDTO ObtenerActividadSeleccionada()
        {
            if (dtgvActividadesCicloModelo.SelectedRows.Count > 0)
            {
                return dtgvActividadesCicloModelo.SelectedRows[0].DataBoundItem as ActividadModeloDTO;
            }
            return null;
        }

        private void btnAgregarElemento_Click(object sender, EventArgs e)
        {
            if (_actividadEnEdicion == null)
            {
                MessageBox.Show("Primero elija una actividad (botón 'Elementos' en la grilla de actividades).", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            AgregarElementoA(_actividadEnEdicion);
        }

        private void btnQuitarElemento_Click(object sender, EventArgs e)
        {
            var actividadActual = _actividadEnEdicion;
            if (actividadActual != null && dtgvActividadesElementos.SelectedRows.Count > 0)
            {
                int index = dtgvActividadesElementos.SelectedRows[0].Index;
                actividadActual.ListaElementos.RemoveAt(index);
                ReordenarElementos(actividadActual);
            }
        }

        private void btnSubirElemento_Click(object sender, EventArgs e)
        {
            if (dtgvActividadesElementos.SelectedRows.Count > 0)
                MoverElemento(dtgvActividadesElementos.SelectedRows[0].Index, -1);
        }

        private void btnBajarElemento_Click(object sender, EventArgs e)
        {
            if (dtgvActividadesElementos.SelectedRows.Count > 0)
                MoverElemento(dtgvActividadesElementos.SelectedRows[0].Index, +1);
        }

        private void MoverElemento(int index, int delta)
        {
            var actividadActual = _actividadEnEdicion;
            if (actividadActual == null) return;

            int destino = index + delta;
            if (index < 0 || destino < 0 || destino >= actividadActual.ListaElementos.Count) return;

            var item = actividadActual.ListaElementos[index];
            actividadActual.ListaElementos.RemoveAt(index);
            actividadActual.ListaElementos.Insert(destino, item);
            ReordenarElementos(actividadActual);

            dtgvActividadesElementos.ClearSelection();
            dtgvActividadesElementos.Rows[destino].Selected = true;
        }

        private void ReordenarElementos(ActividadModeloDTO actividad)
        {
            for (int i = 0; i < actividad.ListaElementos.Count; i++)
            {
                actividad.ListaElementos[i].Orden = i + 1;
            }
            actividad.ListaElementos.ResetBindings();
        }

        // ========================================================
        // GUARDADO FINAL CONSOLIDADO
        // ========================================================
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombreCicloModelo.Text) || cmbModoInicio.SelectedIndex == -1)
                {
                    MessageBox.Show("Complete los campos obligatorios del ciclo (Nombre y Modo de Inicio).", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tabControl.SelectedTab = tabPageCicloModelo;
                    return;
                }

                if (listaActividades.Count == 0)
                {
                    MessageBox.Show("Debe agregar al menos una actividad al ciclo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tabControl.SelectedTab = tabPageActividadesCicloModelo;
                    return;
                }

                var sinElementos = listaActividades.FirstOrDefault(a => a.ListaElementos == null || a.ListaElementos.Count == 0);
                if (sinElementos != null)
                {
                    MessageBox.Show($"La actividad '{sinElementos.Nombre}' no tiene elementos cargados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string nombreCiclo = txtNombreCicloModelo.Text.Trim();
                string descCiclo = txtDescripcion.Text.Trim();
                decimal duracionCiclo = LeerDuracion(mskDuracionEstimada);
                int modoInicio = Convert.ToInt32(cmbModoInicio.SelectedValue);
                bool activoCiclo = chkActivo.Checked;
                int idCreador = _usuarioActual.Id;
                DateTime fechaCreacion = dtpFechaCreacion.Value;

                bll.GuardarCicloCompleto(
                    _idCicloEditar, nombreCiclo, descCiclo, duracionCiclo, modoInicio, activoCiclo, fechaCreacion, idCreador,
                    listaActividades.ToList());

                MessageBox.Show("El Modelo del Ciclo se ha guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Lee el MaskedTextBox "00000" como número entero de días
        internal static decimal LeerDuracion(MaskedTextBox msk)
        {
            string texto = new string(msk.Text.Where(char.IsDigit).ToArray());
            return decimal.TryParse(texto, out decimal valor) ? valor : 0;
        }

        // Escribe la duración SIN decimales: si se asigna "30.00" a la máscara "00000"
        // quedaba "3000" y al volver a guardar se multiplicaba la duración por 100.
        internal static void EscribirDuracion(MaskedTextBox msk, decimal valor)
        {
            msk.Text = valor <= 0 ? "" : decimal.ToInt64(Math.Round(valor, 0)).ToString();
        }

        // ========================================================
        // CARGA PARA MODIFICAR
        // ========================================================
        private void CargarDatosCiclo(long idCiclo)
        {
            // 1. Cabecera
            DataTable dtCiclo = bll.ObtenerCicloPorId(idCiclo);
            if (dtCiclo.Rows.Count == 0)
            {
                MessageBox.Show("No se encontró el ciclo seleccionado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataRow row = dtCiclo.Rows[0];
            txtNombreCicloModelo.Text = Str(row, "nombre");
            txtDescripcion.Text = Str(row, "descripcion");
            EscribirDuracion(mskDuracionEstimada, Dec(row, "duracion_estimada"));

            int modo = Int(row, "modo_inicio");
            if (modo > 0) cmbModoInicio.SelectedValue = modo; else cmbModoInicio.SelectedIndex = -1;

            chkActivo.Checked = Bool(row, "activo");

            if (row.Table.Columns.Contains("fecha_creacion") && row["fecha_creacion"] != DBNull.Value)
                dtpFechaCreacion.Value = Convert.ToDateTime(row["fecha_creacion"]);

            // Mostrar quién lo creó (no el usuario logueado)
            string creador = Str(row, "creado_por_nombre");
            txtCreadoPor.Text = string.IsNullOrEmpty(creador) ? Str(row, "creado_por") : creador;

            // 2. Actividades y sus elementos
            listaActividades.RaiseListChangedEvents = false;
            listaActividades.Clear();

            DataTable dtActividades = bll.ObtenerActividadesPorCiclo(idCiclo);
            foreach (DataRow rowAct in dtActividades.Rows)
            {
                long idActividadModelo = Convert.ToInt64(rowAct["id_actividad_modelo"]);

                ActividadModeloDTO act = new ActividadModeloDTO
                {
                    Orden = Int(rowAct, "orden"),
                    Nombre = Str(rowAct, "nombre"),
                    Descripcion = Str(rowAct, "descripcion"),
                    IdTipoActividad = Int(rowAct, "tipo_actividad"),
                    TipoActividad = Str(rowAct, "tipo_actividad_nombre"),
                    Duracion = Dec(rowAct, "duracion_estimada"),
                    Demora = Bool(rowAct, "demora"),
                    Aprobacion = Bool(rowAct, "requiere_aprobacion"),
                    EjecucionParcial = Bool(rowAct, "permite_ejecucion_parcial"),
                    CondicionAvance = Str(rowAct, "condicion_avance"),
                    Activa = Bool(rowAct, "activa")
                };

                DataTable dtElementos = bll.ObtenerElementosPorActividad(idActividadModelo);
                int ordenElem = 1;
                foreach (DataRow rowElem in dtElementos.Rows)
                {
                    int ordenBD = Int(rowElem, "orden");
                    act.ListaElementos.Add(new ActividadElementoModeloDTO
                    {
                        Orden = ordenBD > 0 ? ordenBD : ordenElem,
                        IdElemento = Convert.ToInt64(rowElem["id_elemento"]),
                        NombreElemento = Str(rowElem, "nombre_elemento"),
                        IdTipoElemento = Int(rowElem, "tipo_elemento"),
                        TipoElemento = Str(rowElem, "tipo_elemento_nombre"),
                        IdTipoMovimiento = Int(rowElem, "tipo_movimiento"),
                        TipoMovimiento = Str(rowElem, "tipo_movimiento_nombre"),
                        IdUnidad = Int(rowElem, "id_unidad"),
                        Unidad = Str(rowElem, "unidad_nombre"),
                        CantidadPrevista = Dec(rowElem, "cantidad_prevista"),
                        Obligatorio = Bool(rowElem, "obligatorio"),
                        PermiteSustitucion = Bool(rowElem, "permite_sustitucion"),
                        Vendible = Bool(rowElem, "vendible_destino"),
                        Observaciones = Str(rowElem, "observaciones")
                    });
                    ordenElem++;
                }

                listaActividades.Add(act);
            }

            listaActividades.RaiseListChangedEvents = true;
            ReordenarActividades(); // también refresca la grilla
        }

        // ---------- Helpers de lectura segura de DataRow ----------
        private static bool Existe(DataRow r, string col) => r.Table.Columns.Contains(col) && r[col] != DBNull.Value;
        private static string Str(DataRow r, string col) => Existe(r, col) ? r[col].ToString() : "";
        private static int Int(DataRow r, string col) => Existe(r, col) ? Convert.ToInt32(r[col]) : 0;
        private static decimal Dec(DataRow r, string col) => Existe(r, col) ? Convert.ToDecimal(r[col]) : 0m;
        private static bool Bool(DataRow r, string col) => Existe(r, col) && Convert.ToBoolean(r[col]);

        // ========================================================
        // GRILLAS
        // ========================================================
        private void ConfigurarGrillaActividades()
        {
            dtgvActividadesCicloModelo.AutoGenerateColumns = false;
            dtgvActividadesCicloModelo.Columns.Clear();

            dtgvActividadesCicloModelo.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Orden", HeaderText = "Orden", Name = "colOrden", Width = 50 });
            dtgvActividadesCicloModelo.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nombre", HeaderText = "Nombre", Name = "colNombre", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dtgvActividadesCicloModelo.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "IdTipoActividad", HeaderText = "IdTipo", Name = "colIdTipoActividad", Visible = false });
            dtgvActividadesCicloModelo.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TipoActividad", HeaderText = "Tipo Actividad", Name = "colTipoActividad", Width = 120 });
            dtgvActividadesCicloModelo.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Duracion",
                HeaderText = "Duración",
                Name = "colDuracion",
                Width = 70,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "0",                                         // 6 en vez de 6,00
                    Alignment = DataGridViewContentAlignment.MiddleRight
                }
            });

            AgregarBoton(dtgvActividadesCicloModelo, "colBtnModificar", "Modificar", 80);
            AgregarBoton(dtgvActividadesCicloModelo, "colBtnSubir", "Subir ▲", 70);
            AgregarBoton(dtgvActividadesCicloModelo, "colBtnBajar", "Bajar ▼", 70);
            AgregarBoton(dtgvActividadesCicloModelo, "colBtnAgregarElementos", "Elementos", 85);
            AgregarBoton(dtgvActividadesCicloModelo, "colBtnQuitarActividad", "Quitar", 70);

            EstiloCabecera(dtgvActividadesCicloModelo);
        }

        private void ConfigurarGrillaElementos()
        {
            dtgvActividadesElementos.AutoGenerateColumns = false;
            dtgvActividadesElementos.Columns.Clear();

            // 1. Columnas de Datos
            dtgvActividadesElementos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Orden", HeaderText = "Orden", Name = "colOrdenElem", Width = 50 });
            dtgvActividadesElementos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TipoElemento", HeaderText = "Tipo", Name = "colTipoElem", Width = 90 });
            dtgvActividadesElementos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NombreElemento", HeaderText = "Elemento", Name = "colNombreElem", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dtgvActividadesElementos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TipoMovimiento", HeaderText = "Movimiento", Name = "colMovElem", Width = 80 });
            dtgvActividadesElementos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CantidadPrevista",
                HeaderText = "Cant. Prevista",
                Name = "colCantElem",
                Width = 90,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "0.##",                                      // 666 en vez de 666,0000
                    Alignment = DataGridViewContentAlignment.MiddleRight
                }
            });
            dtgvActividadesElementos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Unidad", HeaderText = "Unidad", Name = "colUnidadElem", Width = 90 });
            dtgvActividadesElementos.Columns.Add(new DataGridViewCheckBoxColumn { DataPropertyName = "Obligatorio", HeaderText = "Obligatorio", Name = "colObligatorioElem", Width = 75 });

            // 2. Botones (dejá esto como ya lo tenés)
            AgregarBoton(dtgvActividadesElementos, "colBtnModificarElem", "Modificar", 80);
            AgregarBoton(dtgvActividadesElementos, "colBtnSubirElem", "Subir ▲", 70);
            AgregarBoton(dtgvActividadesElementos, "colBtnBajarElem", "Bajar ▼", 70);
            AgregarBoton(dtgvActividadesElementos, "colBtnQuitarElem", "Quitar", 70);

            EstiloCabecera(dtgvActividadesElementos);
        }

        private static void AgregarBoton(DataGridView grilla, string nombre, string texto, int ancho)
        {
            grilla.Columns.Add(new DataGridViewButtonColumn
            {
                Name = nombre,
                HeaderText = "",
                Text = texto,
                UseColumnTextForButtonValue = true,
                Width = ancho
            });
        }

        private static void EstiloCabecera(DataGridView grilla)
        {
            grilla.EnableHeadersVisualStyles = false;
            grilla.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.MediumSeaGreen;
            grilla.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            grilla.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font(grilla.Font, System.Drawing.FontStyle.Bold);
        }

        private void dtgvActividadesCicloModelo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= listaActividades.Count) return;

            string nombreColumna = dtgvActividadesCicloModelo.Columns[e.ColumnIndex].Name;
            int index = e.RowIndex;
            var actividadSeleccionada = listaActividades[index];

            switch (nombreColumna)
            {
                case "colBtnModificar":
                    {
                        AbmActividadesCicloModelo frmEdicion = new AbmActividadesCicloModelo(actividadSeleccionada);
                        if (frmEdicion.ShowDialog() == DialogResult.OK)
                            listaActividades.ResetItem(index);
                    }
                    break;

                case "colBtnSubir":
                    MoverActividad(index, -1);
                    break;

                case "colBtnBajar":
                    MoverActividad(index, +1);
                    break;

                case "colBtnAgregarElementos":
                    AbrirElementosDe(actividadSeleccionada);   // muestra la pestaña con sus elementos
                    AgregarElementoA(actividadSeleccionada);   // pregunta Entrada/Salida y abre el form
                    break;

                case "colBtnQuitarActividad":
                    QuitarActividad(index);
                    break;
            }
        }

        private void dtgvActividadesElementos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var actividadActual = _actividadEnEdicion;
            if (actividadActual == null || e.RowIndex < 0 || e.RowIndex >= actividadActual.ListaElementos.Count) return;

            string nombreColumna = dtgvActividadesElementos.Columns[e.ColumnIndex].Name;
            int index = e.RowIndex;
            var elementoSeleccionado = actividadActual.ListaElementos[index];

            switch (nombreColumna)
            {
                case "colBtnModificarElem":
                    {
                        AbmActividadesElementos frmEdicion = new AbmActividadesElementos(elementoSeleccionado);
                        if (frmEdicion.ShowDialog() == DialogResult.OK)
                            actividadActual.ListaElementos.ResetItem(index);
                    }
                    break;

                case "colBtnSubirElem":
                    MoverElemento(index, -1);
                    break;

                case "colBtnBajarElem":
                    MoverElemento(index, +1);
                    break;

                case "colBtnQuitarElem":
                    actividadActual.ListaElementos.RemoveAt(index);
                    ReordenarElementos(actividadActual);
                    break;
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

        // Pregunta Entrada / Salida y devuelve el Id del catálogo 16. Null si cancela.
        private (int Id, string Nombre)? PedirTipoMovimiento()
        {
            var btnEntrada = new TaskDialogButton("Entrada");
            var btnSalida = new TaskDialogButton("Salida");

            var pagina = new TaskDialogPage
            {
                Caption = "Agregar Elemento",
                Heading = "¿El elemento es de Entrada o de Salida?",
                Icon = TaskDialogIcon.Information,
                AllowCancel = true,
                Buttons = { btnEntrada, btnSalida, TaskDialogButton.Cancel }
            };

            TaskDialogButton resultado = TaskDialog.ShowDialog(this, pagina);

            string nombre = resultado == btnEntrada ? "Entrada"
                          : resultado == btnSalida ? "Salida"
                          : null;
            if (nombre == null) return null;

            DataTable dt = bll.ObtenerItemsCatalogo(16);
            foreach (DataRow fila in dt.Rows)
            {
                if (string.Equals(fila["Nombre"].ToString().Trim(), nombre, StringComparison.OrdinalIgnoreCase))
                    return (Convert.ToInt32(fila["Id_catalogo_item"]), nombre);
            }

            MessageBox.Show($"No se encontró '{nombre}' en el catálogo Tipo Movimiento (16).", "Aviso",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return null;
        }
        // Pregunta Entrada / Salida y abre AbmActividadesElementos para la actividad indicada
        private void AgregarElementoA(ActividadModeloDTO actividad)
        {
            if (actividad == null) return;

            var movimiento = PedirTipoMovimiento();
            if (movimiento == null) return;   // canceló

            int nuevoOrden = actividad.ListaElementos.Count + 1;
            AbmActividadesElementos frmElemento = new AbmActividadesElementos(
                nuevoOrden, movimiento.Value.Id, movimiento.Value.Nombre);

            if (frmElemento.ShowDialog() == DialogResult.OK)
            {
                actividad.ListaElementos.Add(frmElemento.NuevoElemento);
                ReordenarElementos(actividad);
            }
        }


    }
}

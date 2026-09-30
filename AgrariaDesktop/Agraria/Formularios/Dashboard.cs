using Agraria.Datos.DTO;
using Agraria.Negocio.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Agraria.Formularios
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            CargarEntornosHoy();
        }
        private void CargarEntornosHoy()
        {
            EntornoFormativoBLL entornoBLL = new EntornoFormativoBLL();
            List<EntornoFormativoHoyDTO> entornosHoy = entornoBLL.ObtenerEntornosHoy();
            dtgEntornos.DataSource = entornosHoy;
            //dtgEntornos.Columns["IdEntorno"].Visible = false;
            chart1.Series.Clear();
            chart1.Legends.Clear();
            var legend = new Legend("Entornos");
            legend.Docking = Docking.Right;
            legend.Alignment = StringAlignment.Center;
            chart1.Legends.Add(legend);

            // Crear serie tipo torta
            Series serie = new Series("EntornosHoy");
            serie.ChartType = SeriesChartType.Pie;
            serie["PieLabelStyle"] = "Inside";
            serie.BorderColor = Color.Gray;
            serie.BorderWidth = 1;
            serie.IsValueShownAsLabel = true; // muestra valor o etiqueta según Label
            serie.Label = "#VALX: #PERCENT{P0}"; // Nombre: cantidad (porc.)
            //serie.Legend = "Entornos";
            var agrupado = entornosHoy.GroupBy(e => e.Nombre ?? "(Sin nombre)")
                .Select(g => new { Nombre = g.Key, Cantidad = g.Count() })
                .OrderByDescending(x => x.Cantidad)
                .ToList();
            foreach (var item in agrupado)
            {
                var ptIndex = serie.Points.AddXY(item.Nombre, item.Cantidad);
                // tooltip con detalle
                serie.Points[ptIndex].ToolTip = $"{item.Nombre}: {item.Cantidad} ({(double)item.Cantidad / agrupado.Sum(a => a.Cantidad):P1})";
            }

            chart1.Series.Add(serie);
            chart1.ChartAreas[0].Area3DStyle.Enable3D = false;
        }
    }
}

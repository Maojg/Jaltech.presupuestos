using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Jaltech.Data;

namespace Jaltech.App
{
    public partial class FormVistaPreviaZona : Form
    {
        private readonly JaltechDbContext _context;

        public FormVistaPreviaZona(JaltechDbContext context)
        {
            InitializeComponent();
            _context = context;

        }

        private void FormVistaPreviaZona_Load(object sender, EventArgs e)
        {
            var zonas = _context.PresupuestosZonales
                .Select(p => p.Zona)
                .Distinct()
                .OrderBy(z => z)
                .ToList();

            cbZonas.DataSource = zonas;
        }

        private void CbZonas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string zona = cbZonas.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(zona)) return;

            var mes = DateTime.Now.Month;
            var anio = DateTime.Now.Year;

            var dato = _context.PresupuestosZonales
                .Where(p => p.Zona == zona && p.Mes == mes && p.Anio == anio)
                .FirstOrDefault();

            if (dato != null)
            {
                lblSalarioBasico.Text = dato.SalarioBasico.ToString("N0");
                lblPrestacional.Text = dato.Prestacional.ToString("N0");
                lblComisiones.Text = dato.PromedioComisiones.ToString("N0");
                lblSalarioTotal.Text = dato.SalarioPromedioTotal.ToString("N0");
                lblBonoCumpl.Text = dato.BonoCumplVentas.ToString("N0");
                lblBonoBasik.Text = dato.BonoBasik.ToString("N0");
                lblBonoCelulares.Text = dato.BonoCelulares.ToString("N0");
                lblBonoBod.Text = dato.BonoBod.ToString("N0");
                lblBonoDulces.Text = dato.BonoDulces.ToString("N0");
                lblClientes.Text = dato.ClientesActivos.ToString("N0");
                lblKPI.Text = dato.KPIReguladores.ToString("N0");
                lblTotalBonos.Text = dato.TotalBonosMes.ToString("N0");
                lblTotalGanado.Text = dato.TotalSalario.ToString("N0");
            }
        }
    }
}
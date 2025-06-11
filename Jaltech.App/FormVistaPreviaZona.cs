using System;
using System.Linq;
using System.Windows.Forms;
using Jaltech.Data;
using Microsoft.EntityFrameworkCore;
using Jaltech.Core;

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
            try
            {
                // Cargar meses
                cbMes.DataSource = Enumerable.Range(1, 12)
                    .Select(m => new
                    {
                        Value = m,
                        Name = $"{m} - {System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(m)}"
                    })
                    .ToList();
                cbMes.DisplayMember = "Name";
                cbMes.ValueMember = "Value";
                cbMes.SelectedValue = DateTime.Now.Month;

                // Cargar zonas (solo el sector)
                var zonas = _context.Zonas
                    .FromSqlRaw("SELECT LTRIM(RTRIM(Sector)) AS Zona FROM DimSectorEconomico")
                    .AsEnumerable()
                    .Select(z => new ZonaDto { Zona = z.Zona })
                    .Distinct()
                    .OrderBy(z => z.Zona)
                    .ToList();

                cbZonas.DataSource = zonas;
                cbZonas.DisplayMember = "Zona";
                cbZonas.ValueMember = "Zona";

                // Establecer '01' por defecto si existe
                var zona01 = zonas.FirstOrDefault(z => z.Zona == "01");
                if (zona01 != null)
                    cbZonas.SelectedValue = "01";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarDatosZonaYMes();
        }

        private void cbZonas_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarDatosZonaYMes();
        }

        private void MostrarDatosZonaYMes()
        {
            if (cbZonas.SelectedValue == null || cbMes.SelectedValue == null) return;

            string zonaCompleta = cbZonas.SelectedValue.ToString();
            string zona = zonaCompleta.Split('-')[0].Trim();
            int mes = (int)cbMes.SelectedValue;
            int anio = DateTime.Now.Year;

            var dato = _context.PresupuestosZonales
                .FirstOrDefault(p => p.Zona == zona && p.Mes == mes && p.Anio == anio);

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
            else
            {
                lblSalarioBasico.Text = lblPrestacional.Text = lblComisiones.Text =
                lblSalarioTotal.Text = lblBonoCumpl.Text = lblBonoBasik.Text = lblBonoCelulares.Text =
                lblBonoBod.Text = lblBonoDulces.Text = lblClientes.Text = lblKPI.Text =
                lblTotalBonos.Text = lblTotalGanado.Text = "-";

                MessageBox.Show("No se encontraron datos para esta combinación de Zona y Mes.", "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

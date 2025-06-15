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
                cbMes.SelectedIndexChanged -= cbMes_SelectedIndexChanged;
                cbZonas.SelectedIndexChanged -= cbZonas_SelectedIndexChanged;

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

                var zonas = _context.Zonas
                    .FromSqlRaw("SELECT LTRIM(RTRIM(Zona)) AS Zona FROM DimPresupuestoZonal")
                    .AsNoTracking()
                    .Select(z => new ZonaDto { Zona = z.Zona.Trim() })
                    .Distinct()
                    .OrderBy(z => z.Zona)
                    .ToList();

                cbZonas.DataSource = zonas;
                cbZonas.DisplayMember = "Zona";
                cbZonas.ValueMember = "Zona";

                int index = zonas.FindIndex(z => z.Zona == "01");
                if (index >= 0)
                {
                    cbZonas.SelectedIndex = index;
                }

                cbMes.SelectedIndexChanged += cbMes_SelectedIndexChanged;
                cbZonas.SelectedIndexChanged += cbZonas_SelectedIndexChanged;

                MostrarDatosZonaYMes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbMes_SelectedIndexChanged(object sender, EventArgs e) => MostrarDatosZonaYMes();

        private void cbZonas_SelectedIndexChanged(object sender, EventArgs e) => MostrarDatosZonaYMes();

        private void MostrarDatosZonaYMes()
        {
            try
            {
                if (cbZonas.SelectedValue == null || cbMes.SelectedValue == null)
                    return;

                string zonaSeleccionada = cbZonas.SelectedValue.ToString().Trim();
                int mes = (int)cbMes.SelectedValue;
                int anio = DateTime.Now.Year;

                Console.WriteLine($"🔍 Zona seleccionada: '{zonaSeleccionada}' (Len={zonaSeleccionada.Length})");
                Console.WriteLine($"📅 Mes: {mes}, Año: {anio}");

                var dato = _context.PresupuestosZonales
                    .FromSqlInterpolated($@"
                        SELECT TOP 1 *
                        FROM DimPresupuestoZonal
                        WHERE LTRIM(RTRIM(Zona)) = {zonaSeleccionada}
                        AND Mes = {mes}
                        AND Anio = {anio}")
                    .AsNoTracking()
                    .FirstOrDefault();

                if (dato != null)
                {
                    lblZona.Text = zonaSeleccionada;
                    Console.WriteLine("✅ Registro encontrado.");
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
                    Console.WriteLine("⚠️ No se encontraron datos.");
                    LimpiarCampos();
                    MessageBox.Show("No se encontraron datos para esta combinación de Zona y Mes.", "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error: {ex.Message}");
                LimpiarCampos();
                MessageBox.Show($"Error al buscar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            lblSalarioBasico.Text = lblPrestacional.Text = lblComisiones.Text =
            lblSalarioTotal.Text = lblBonoCumpl.Text = lblBonoBasik.Text = lblBonoCelulares.Text =
            lblBonoBod.Text = lblBonoDulces.Text = lblClientes.Text = lblKPI.Text =
            lblTotalBonos.Text = lblTotalGanado.Text = "-";
        }
    }
}

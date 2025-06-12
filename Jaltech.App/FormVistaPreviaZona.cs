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

                // Cargar zonas
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

                // Seleccionar '01' por defecto
                var index = zonas.FindIndex(z => z.Zona == "01");
                if (index >= 0)
                {
                    cbZonas.SelectedIndex = index;
                }

                // Reasignar eventos
                cbMes.SelectedIndexChanged += cbMes_SelectedIndexChanged;
                cbZonas.SelectedIndexChanged += cbZonas_SelectedIndexChanged;

                // Cargar datos una vez todo esté listo
                MostrarDatosZonaYMes();
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
            if (cbZonas.SelectedItem == null || cbMes.SelectedValue == null)
                return;

            string zona = ((ZonaDto)cbZonas.SelectedItem).Zona;
            int mes = (int)cbMes.SelectedValue;
            int anio = DateTime.Now.Year;

            // Mostrar parámetros para validación
            MessageBox.Show($"Zona seleccionada (raw): '{zona}'", "Debug Zona");

            try
            {
                var dato = _context.PresupuestosZonales
                    .AsEnumerable()  // fuerza evaluación en memoria
                    .FirstOrDefault(p => p.Zona.Trim() == zona.Trim() && p.Mes == mes && p.Anio == anio);


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
                    LimpiarCampos();
                    MessageBox.Show("No se encontraron datos para esta combinación de Zona y Mes.", "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jaltech.Core;
using Jaltech.Data;
using OfficeOpenXml;
using LicenseContext = System.ComponentModel.LicenseContext;

namespace Jaltech.App
{
    public partial class FormPresupuestos : Form
    {
        private readonly JaltechDbContext _context;
        private BindingList<PresupuestoZonal> listaPresupuestos = new();

        public FormPresupuestos(JaltechDbContext context)
        {
            InitializeComponent();
            _context = context;

            // Correcting the error by using the proper namespace for LicenseContext
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
        }

        private void FormPresupuestos_Load(object sender, EventArgs e)
        {
            // Carga inicial si se requiere
        }

        private void InicializarGrid()
        {
            dgvPresupuestos.Dock = DockStyle.Fill;
            dgvPresupuestos.AutoGenerateColumns = true;
            dgvPresupuestos.AllowUserToAddRows = false;
            dgvPresupuestos.AllowUserToDeleteRows = true;
            dgvPresupuestos.ReadOnly = false;
            dgvPresupuestos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            Controls.Add(dgvPresupuestos);
        }

        private void btnCargarExcel_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new()
            {
                Filter = "Excel Files|*.xlsx",
                Title = "Seleccionar archivo de presupuesto"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    listaPresupuestos.Clear();
                    using var package = new ExcelPackage(new FileInfo(ofd.FileName));
                    var worksheet = package.Workbook.Worksheets[0];
                    int rowCount = worksheet.Dimension.Rows;

                    for (int row = 2; row <= rowCount; row++)
                    {
                        var zonaRaw = worksheet.Cells[row, 1].Text?.Trim();
                        Console.WriteLine($"Fila {row}: '{zonaRaw}'"); // Solo para depuración

                        if (string.IsNullOrWhiteSpace(zonaRaw)) continue;

                        if (!zonaRaw.Contains('-')) continue;

                        var zonaCodigo = zonaRaw.Split('-')[0].Trim();

                        decimal.TryParse(worksheet.Cells[row, 2].Text, out var salarioBasico);
                        decimal.TryParse(worksheet.Cells[row, 3].Text, out var prestacional);
                        decimal.TryParse(worksheet.Cells[row, 4].Text, out var promedioComisiones);
                        decimal.TryParse(worksheet.Cells[row, 6].Text, out var bonoVentas);
                        decimal.TryParse(worksheet.Cells[row, 7].Text, out var bonoBasik);
                        decimal.TryParse(worksheet.Cells[row, 8].Text, out var bonoCel);
                        decimal.TryParse(worksheet.Cells[row, 9].Text, out var bonoBod);
                        decimal.TryParse(worksheet.Cells[row, 10].Text, out var bonoDulces);
                        int.TryParse(worksheet.Cells[row, 11].Text, out var clientes);
                        decimal.TryParse(worksheet.Cells[row, 12].Text, out var kpi);

                        var salarioTotal = salarioBasico + prestacional + promedioComisiones;
                        var totalBonos = bonoVentas + bonoBasik + bonoCel + bonoBod + bonoDulces + clientes + kpi;
                        var ganarian = salarioTotal + totalBonos;

                        var p = new PresupuestoZonal
                        {
                            Zona = zonaCodigo,
                            SalarioBasico = salarioBasico,
                            Prestacional = prestacional,
                            PromedioComisiones = promedioComisiones,
                            SalarioPromedioTotal = salarioTotal,
                            BonoCumplVentas = bonoVentas,
                            BonoBasik = bonoBasik,
                            BonoCelulares = bonoCel,
                            BonoBod = bonoBod,
                            BonoDulces = bonoDulces,
                            ClientesActivos = clientes,
                            KPIReguladores = kpi,
                            TotalBonosMes = totalBonos,
                            TotalSalario = ganarian,
                            Anio = DateTime.Now.Year,
                            Mes = DateTime.Now.Month,
                            FechaCarga = DateTime.Now
                        };

                        listaPresupuestos.Add(p);
                    }

                    dgvPresupuestos.DataSource = listaPresupuestos;
                    dgvPresupuestos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                    dgvPresupuestos.AllowUserToResizeColumns = true;

                    MessageBox.Show($"Se cargaron {listaPresupuestos.Count} registros desde el Excel.", "Éxito");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar Excel: {ex.Message}", "Error");
                }
            }
        }

        private void btnGuardarBD_Click(object sender, EventArgs e)
        {
            if (listaPresupuestos.Any())
            {
                try
                {
                    foreach (var nuevoRegistro in listaPresupuestos)
                    {
                        // Buscar si ya existe uno con la misma zona, mes y año
                        var existente = _context.PresupuestosZonales
                            .FirstOrDefault(x => x.Zona == nuevoRegistro.Zona &&
                                                 x.Mes == nuevoRegistro.Mes &&
                                                 x.Anio == nuevoRegistro.Anio);

                        if (existente != null)
                        {
                            // Si existe, actualizar los valores
                            _context.Entry(existente).CurrentValues.SetValues(nuevoRegistro);
                        }
                        else
                        {
                            // Si no existe, agregar
                            _context.PresupuestosZonales.Add(nuevoRegistro);
                        }
                    }

                    _context.SaveChanges();
                    MessageBox.Show("Los presupuestos fueron guardados exitosamente en la base de datos.", "Confirmación");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Hubo un error al guardar los datos. Verifica que no existan registros duplicados (Zona + Año + Mes) o problemas de conexión con la base de datos.\n\nDetalle técnico:\n" + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No hay registros cargados para guardar.", "Aviso");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPresupuestos.SelectedRows.Count > 0)
            {
                // Recolectar los elementos seleccionados y eliminarlos desde la lista
                var filasAEliminar = dgvPresupuestos.SelectedRows
                    .Cast<DataGridViewRow>()
                    .Where(r => r.Index >= 0 && r.Index < listaPresupuestos.Count)
                    .Select(r => listaPresupuestos[r.Index])
                    .ToList();

                foreach (var item in filasAEliminar)
                {
                    listaPresupuestos.Remove(item);
                }
            }
            else
            {
                MessageBox.Show("Selecciona al menos una fila para eliminar.", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FormPresupuestos_Load_1(object sender, EventArgs e)
        {

        }

        private void dgvPresupuestos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}


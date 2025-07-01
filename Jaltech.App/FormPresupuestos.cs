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

            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            btnCargarBD.Click += (s, e) => CargarDesdeBaseDeDatos();

            // Estilo para botones principales
            EstilizarBoton(btnCargarExcel, Color.FromArgb(0, 102, 204));
            EstilizarBoton(btnGuardarBD, Color.FromArgb(0, 153, 76));
            EstilizarBoton(btnEliminar, Color.FromArgb(204, 0, 0));
            // Si tienes btnVistaPrevia:
            // EstilizarBoton(btnVistaPrevia, Color.FromArgb(0, 123, 255), true);

            // Estilizar DataGridView
            dgvPresupuestos.EnableHeadersVisualStyles = false;
            dgvPresupuestos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 51, 102);
            dgvPresupuestos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPresupuestos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dgvPresupuestos.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgvPresupuestos.RowTemplate.Height = 28;
            dgvPresupuestos.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);

            // Configuración adicional para encabezados del DataGridView
            dgvPresupuestos.ColumnHeadersVisible = true;
            dgvPresupuestos.ColumnHeadersHeight = 40;
            dgvPresupuestos.EnableHeadersVisualStyles = false;
            dgvPresupuestos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvPresupuestos.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dgvPresupuestos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPresupuestos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
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
            //dgvPresupuestos.SelectionMode = DataGridViewSelectionMode.CellSelect; // Permite selección por celda
            dgvPresupuestos.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvPresupuestos.TabStop = true;
            dgvPresupuestos.StandardTab = true;
            dgvPresupuestos.RowHeadersVisible = true; // Asegura el selector de fila visible

            // Configuración adicional para encabezados del DataGridView
            dgvPresupuestos.ColumnHeadersVisible = true;
            dgvPresupuestos.ColumnHeadersHeight = 40;
            dgvPresupuestos.EnableHeadersVisualStyles = false;
            dgvPresupuestos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvPresupuestos.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dgvPresupuestos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPresupuestos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

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
                        decimal.TryParse(worksheet.Cells[row, 11].Text, out var clientes);
                        decimal.TryParse(worksheet.Cells[row, 12].Text, out var kpi);
                        decimal.TryParse(worksheet.Cells[row, 13].Text, out var BonoEspecial1);
                        decimal.TryParse(worksheet.Cells[row, 14].Text, out var BonoEspecial2);

                        var salarioTotal = salarioBasico + prestacional + promedioComisiones;
                        var totalBonos = bonoVentas + bonoBasik + bonoCel + bonoBod + bonoDulces + clientes + kpi + BonoEspecial1 + BonoEspecial2;
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
                            BonoEspecial1 = BonoEspecial1,
                            BonoEspecial2 = BonoEspecial2,
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

                    // Refuerza configuración editable y navegación por Tab
                    dgvPresupuestos.ReadOnly = false;
                    dgvPresupuestos.EditMode = DataGridViewEditMode.EditOnEnter;
                    dgvPresupuestos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvPresupuestos.MultiSelect = false;
                    dgvPresupuestos.TabStop = true;
                    dgvPresupuestos.StandardTab = true;

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
                            _context.PresupuestosZonales.Remove(existente);
                            _context.SaveChanges(); // Muy importante: confirmar eliminación
                        }

                        _context.PresupuestosZonales.Add(nuevoRegistro);
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
            if (dgvPresupuestos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona al menos una fila para eliminar.", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirmación
            var confirm = MessageBox.Show("¿Estás seguro de que deseas eliminar esta fila?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes)
                return;

            foreach (DataGridViewRow row in dgvPresupuestos.SelectedRows)
            {
                if (row.Cells["Id"].Value != null && int.TryParse(row.Cells["Id"].Value.ToString(), out int id) && id > 0)
                {
                    var entity = _context.PresupuestosZonales.FirstOrDefault(p => p.Id == id);
                    if (entity != null)
                    {
                        _context.PresupuestosZonales.Remove(entity);
                        _context.SaveChanges(); // Guarda la eliminación en BD
                    }
                }

                // Remueve visualmente del grid (sin importar si era nuevo o con ID)
                dgvPresupuestos.Rows.Remove(row);
            }
        }

        private void CargarDesdeBaseDeDatos()
        {
            try
            {
                int anio = 0;
                int.TryParse(cbAnio.SelectedItem?.ToString(), out anio);

                string zona = cbZona.SelectedItem?.ToString();

                var query = _context.PresupuestosZonales.AsQueryable();

                if (anio > 0)
                    query = query.Where(p => p.Anio == anio);

                if (!string.IsNullOrEmpty(zona))
                    query = query.Where(p => p.Zona == zona);

                var resultados = query.OrderBy(p => p.Anio)
                                      .ThenBy(p => p.Mes)
                                      .ThenBy(p => p.Zona)
                                      .ToList();

                listaPresupuestos = new BindingList<PresupuestoZonal>(resultados);
                dgvPresupuestos.DataSource = listaPresupuestos;

                MessageBox.Show($"Se cargaron {listaPresupuestos.Count} registros.", "Cargar BD");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }
        }

        private void FormPresupuestos_Load_1(object sender, EventArgs e)
        {

        }

        private void dgvPresupuestos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void EstilizarBoton(Button boton, Color fondo, bool bold = false)
        {
            boton.BackColor = fondo;
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 0;
            boton.ForeColor = Color.White;
            boton.Font = new Font("Segoe UI", 10, bold ? FontStyle.Bold : FontStyle.Regular);
        }
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jaltech.Data; // Ajusta el namespace según donde esté JaltechDbContext

namespace Jaltech.App
{
    public partial class FormInicio : Form
    {
        private readonly JaltechDbContext _context;

        public FormInicio(JaltechDbContext context)
        {
            InitializeComponent();
            _context = context;

            // Estilo para botones principales
            EstilizarBoton(btnPresupuestos, Color.FromArgb(0, 102, 204));
            EstilizarBoton(btnSalir, Color.FromArgb(204, 0, 0));
            EstilizarBoton(btnVistaPreviaZona, Color.FromArgb(0, 123, 255), true);

            // Asigna el evento correctamente al botón real
            btnVistaPreviaZona.Click += btnVistaPrevia_Click;

            // Si hay DataGridView, aplica estilo
            // dgvInicio.EnableHeadersVisualStyles = false;
            // dgvInicio.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 51, 102);
            // dgvInicio.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            // dgvInicio.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            // dgvInicio.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            // dgvInicio.RowTemplate.Height = 28;
            // dgvInicio.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
        }

        private void EstilizarBoton(object btnVistaPreviaZona, Color color, bool v)
        {
            throw new NotImplementedException();
        }

        private void btnPresupuestos_Click(object sender, EventArgs e)
        {
            var form = new FormPresupuestos(_context);
            form.ShowDialog(); // Muestra el formulario de presupuestos como un diálogo modalo .Show() si quieres mantener ambos abiertos
        }

        private void btnVistaPrevia_Click(object sender, EventArgs e)
        {
            var form = new FormVistaPreviaZona(_context);
            form.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Cierra la aplicación
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidad de reportes en construcción.", "Jaltech Budget App");
        }

        private void FormInicio_Load(object sender, EventArgs e)
        {

        }

        // Método de utilidad para estilizar botones
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

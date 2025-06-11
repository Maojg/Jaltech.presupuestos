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

       
    }
}

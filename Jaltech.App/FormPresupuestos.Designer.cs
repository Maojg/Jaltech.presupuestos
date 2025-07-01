namespace Jaltech.App
{
    partial class FormPresupuestos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Button btnCargarExcel;
        private System.Windows.Forms.Button btnGuardarBD;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView dgvPresupuestos;
        private System.Windows.Forms.ComboBox cbMes;
        private System.Windows.Forms.ComboBox cbAnio;
        private System.Windows.Forms.ComboBox cbZona;
        private System.Windows.Forms.Button btnCargarBD;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblTitulo;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            // Crear controles
            tableLayoutPanel = new TableLayoutPanel();
            btnCargarExcel = new Button();
            btnGuardarBD = new Button();
            btnEliminar = new Button();
            dgvPresupuestos = new DataGridView();
            cbAnio = new ComboBox();
            cbZona = new ComboBox();
            btnCargarBD = new Button();
            headerPanel = new Panel();
            lblTitulo = new Label();

            // ========== PANEL DEL TÍTULO ==========
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Height = 50;
            headerPanel.BackColor = Color.FromArgb(0, 51, 102);

            lblTitulo.Text = "Gestión de Presupuestos Zonales";
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(10, 10);
            headerPanel.Controls.Add(lblTitulo);

            // ========== PANEL DE BOTONES Y FILTROS ==========
            tableLayoutPanel.ColumnCount = 6;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16F));
            tableLayoutPanel.Dock = DockStyle.Top;
            tableLayoutPanel.Height = 50;
            tableLayoutPanel.Padding = new Padding(5);

            // Botón Cargar Excel
            btnCargarExcel.Dock = DockStyle.Fill;
            btnCargarExcel.Text = "Cargar Excel";
            btnCargarExcel.Click += btnCargarExcel_Click;
            tableLayoutPanel.Controls.Add(btnCargarExcel, 0, 0);

            // Botón Guardar en BD
            btnGuardarBD.Dock = DockStyle.Fill;
            btnGuardarBD.Text = "Guardar en BD";
            btnGuardarBD.Click += btnGuardarBD_Click;
            tableLayoutPanel.Controls.Add(btnGuardarBD, 1, 0);

            // Botón Eliminar Selección
            btnEliminar.Dock = DockStyle.Fill;
            btnEliminar.Text = "Eliminar Selección";
            btnEliminar.Click += btnEliminar_Click;
            tableLayoutPanel.Controls.Add(btnEliminar, 2, 0);

            // Combo Año
            cbAnio.Dock = DockStyle.Fill;
            cbAnio.DropDownStyle = ComboBoxStyle.DropDownList;
            cbAnio.Items.AddRange(new object[] { "", "2023", "2024", "2025", "2026" });
            cbAnio.Font = new Font("Segoe UI", 10F);
            tableLayoutPanel.Controls.Add(cbAnio, 3, 0);

            // Combo Zona
            cbZona.Dock = DockStyle.Fill;
            cbZona.DropDownStyle = ComboBoxStyle.DropDownList;
            cbZona.Items.Add("");
            cbZona.Items.AddRange(Enumerable.Range(1, 65).Select(x => x.ToString("D2")).ToArray());
            cbZona.Font = new Font("Segoe UI", 10F);
            tableLayoutPanel.Controls.Add(cbZona, 4, 0);

            // Botón Cargar desde BD
            btnCargarBD.Dock = DockStyle.Fill;
            btnCargarBD.Text = "Cargar desde BD";
            tableLayoutPanel.Controls.Add(btnCargarBD, 5, 0);

            // ========== GRID ==========
            dgvPresupuestos.Dock = DockStyle.Fill;
            dgvPresupuestos.AllowUserToAddRows = false;
            dgvPresupuestos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPresupuestos.CellContentClick += dgvPresupuestos_CellContentClick;

            // ========== FORMULARIO ==========
            ClientSize = new Size(1000, 600);
            Name = "FormPresupuestos";
            Text = "Gestión de Presupuestos Zonales";

            // Orden de agregado CRÍTICO
            Controls.Add(dgvPresupuestos);     // Primero el grid (ocupará el resto del espacio)
            Controls.Add(tableLayoutPanel);    // Luego panel de botones
            Controls.Add(headerPanel);         // Luego el encabezado
        }

        #endregion
    }
}
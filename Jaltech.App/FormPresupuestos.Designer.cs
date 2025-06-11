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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel = new TableLayoutPanel();
            btnCargarExcel = new Button();
            btnGuardarBD = new Button();
            btnEliminar = new Button();
            dgvPresupuestos = new DataGridView();
            tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPresupuestos).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 3;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34F));
            tableLayoutPanel.Controls.Add(btnCargarExcel, 0, 0);
            tableLayoutPanel.Controls.Add(btnGuardarBD, 1, 0);
            tableLayoutPanel.Controls.Add(btnEliminar, 2, 0);
            tableLayoutPanel.Dock = DockStyle.Top;
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel.Size = new Size(1000, 50);
            tableLayoutPanel.TabIndex = 1;
            // 
            // btnCargarExcel
            // 
            btnCargarExcel.Dock = DockStyle.Fill;
            btnCargarExcel.Location = new Point(3, 3);
            btnCargarExcel.Name = "btnCargarExcel";
            btnCargarExcel.Size = new Size(324, 44);
            btnCargarExcel.TabIndex = 0;
            btnCargarExcel.Text = "Cargar Excel";
            btnCargarExcel.Click += btnCargarExcel_Click;
            // 
            // btnGuardarBD
            // 
            btnGuardarBD.Dock = DockStyle.Fill;
            btnGuardarBD.Location = new Point(333, 3);
            btnGuardarBD.Name = "btnGuardarBD";
            btnGuardarBD.Size = new Size(324, 44);
            btnGuardarBD.TabIndex = 1;
            btnGuardarBD.Text = "Guardar en BD";
            btnGuardarBD.Click += btnGuardarBD_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Dock = DockStyle.Fill;
            btnEliminar.Location = new Point(663, 3);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(334, 44);
            btnEliminar.TabIndex = 2;
            btnEliminar.Text = "Eliminar Selección";
            btnEliminar.Click += btnEliminar_Click;
            // 
            // dgvPresupuestos
            // 
            dgvPresupuestos.AllowUserToAddRows = false;
            dgvPresupuestos.Dock = DockStyle.Fill;
            dgvPresupuestos.Location = new Point(0, 50);
            dgvPresupuestos.Name = "dgvPresupuestos";
            dgvPresupuestos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPresupuestos.Size = new Size(1000, 550);
            dgvPresupuestos.TabIndex = 0;
            dgvPresupuestos.CellContentClick += dgvPresupuestos_CellContentClick;
            // 
            // FormPresupuestos
            // 
            ClientSize = new Size(1000, 600);
            Controls.Add(dgvPresupuestos);
            Controls.Add(tableLayoutPanel);
            Name = "FormPresupuestos";
            Text = "Gestión de Presupuestos Zonales";
            tableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPresupuestos).EndInit();
            ResumeLayout(false);
        }

        #endregion
    }
}
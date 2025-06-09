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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.btnCargarExcel = new System.Windows.Forms.Button();
            this.btnGuardarBD = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.dgvPresupuestos = new System.Windows.Forms.DataGridView();

            this.SuspendLayout();

            // tableLayoutPanel
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel.Height = 50;

            // btnCargarExcel
            this.btnCargarExcel.Text = "Cargar Excel";
            this.btnCargarExcel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCargarExcel.Click += new System.EventHandler(this.btnCargarExcel_Click);

            // btnGuardarBD
            this.btnGuardarBD.Text = "Guardar en BD";
            this.btnGuardarBD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGuardarBD.Click += new System.EventHandler(this.btnGuardarBD_Click);

            // btnEliminar
            this.btnEliminar.Text = "Eliminar Selección";
            this.btnEliminar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            // Agregar botones al panel
            this.tableLayoutPanel.Controls.Add(this.btnCargarExcel, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.btnGuardarBD, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.btnEliminar, 2, 0);

            // dgvPresupuestos
            this.dgvPresupuestos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPresupuestos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.dgvPresupuestos.AllowUserToAddRows = false;
            this.dgvPresupuestos.AllowUserToDeleteRows = true;
            this.dgvPresupuestos.ReadOnly = false;
            this.dgvPresupuestos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            // FormPresupuestos
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.dgvPresupuestos);
            this.Controls.Add(this.tableLayoutPanel);
            this.Text = "Gestión de Presupuestos Zonales";

            this.ResumeLayout(false);
        }

        #endregion
    }
}
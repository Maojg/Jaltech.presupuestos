namespace Jaltech.App
{
    partial class FormInicio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Button btnPresupuestos;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Button btnVistaPreviaZona;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TableLayoutPanel mainLayout;

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
            btnPresupuestos = new Button();
            btnReportes = new Button();
            btnSalir = new Button();
            btnVistaPreviaZona = new Button();
            headerPanel = new System.Windows.Forms.Panel();
            lblTitulo = new System.Windows.Forms.Label();
            mainLayout = new System.Windows.Forms.TableLayoutPanel();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            headerPanel.Height = 50;
            headerPanel.BackColor = System.Drawing.Color.FromArgb(0, 51, 102);
            // 
            // lblTitulo
            // 
            lblTitulo.Text = "Inicio - Panel Principal";
            lblTitulo.ForeColor = System.Drawing.Color.White;
            lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new System.Drawing.Point(10, 10);
            headerPanel.Controls.Add(lblTitulo);
            Controls.Add(headerPanel);
            // 
            // mainLayout
            // 
            mainLayout.ColumnCount = 1;
            mainLayout.RowCount = 4;
            mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            mainLayout.Padding = new Padding(0, 60, 0, 0); // Espacio debajo del header
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            // 
            // btnPresupuestos
            // 
            btnPresupuestos.Dock = DockStyle.None; // Quita Fill para permitir ancho fijo
            btnPresupuestos.Margin = new Padding(60, 10, 60, 10);
            btnPresupuestos.Height = 40;
            btnPresupuestos.Width = 250; // Ancho fijo deseado
            btnPresupuestos.Name = "btnPresupuestos";
            btnPresupuestos.TabIndex = 0;
            btnPresupuestos.Text = "Cargar Presupuestos";
            btnPresupuestos.Click += btnPresupuestos_Click;
            // 
            // btnVistaPreviaZona
            // 
            btnVistaPreviaZona.Dock = DockStyle.None;
            btnVistaPreviaZona.Margin = new Padding(60, 10, 60, 10);
            btnVistaPreviaZona.Height = 40;
            btnVistaPreviaZona.Width = 250;
            btnVistaPreviaZona.Name = "btnVistaPreviaZona";
            btnVistaPreviaZona.TabIndex = 3;
            btnVistaPreviaZona.Text = "Vista Previa Zona";
            btnVistaPreviaZona.Click += new System.EventHandler(this.btnVistaPrevia_Click);
            // 
            // btnReportes
            // 
            btnReportes.Dock = DockStyle.None;
            btnReportes.Margin = new Padding(60, 10, 60, 10);
            btnReportes.Height = 40;
            btnReportes.Width = 250;
            btnReportes.Name = "btnReportes";
            btnReportes.TabIndex = 1;
            btnReportes.Text = "Ver Reportes";
            btnReportes.Click += btnReportes_Click;
            // 
            // btnSalir
            // 
            btnSalir.Dock = DockStyle.None;
            btnSalir.Margin = new Padding(120, 30, 120, 10);
            btnSalir.Height = 40;
            btnSalir.Width = 250;
            btnSalir.Name = "btnSalir";
            btnSalir.TabIndex = 2;
            btnSalir.Text = "Salir";
            btnSalir.Click += btnSalir_Click;
            // 
            // Add buttons to layout
            // 
            mainLayout.Controls.Add(btnPresupuestos, 0, 0);
            mainLayout.Controls.Add(btnVistaPreviaZona, 0, 1);
            mainLayout.Controls.Add(btnReportes, 0, 2);
            mainLayout.Controls.Add(btnSalir, 0, 3);
            Controls.Add(mainLayout);
            // 
            // FormInicio
            // 
            ClientSize = new Size(678, 370);
            Name = "FormInicio";
            Text = "Inicio - Jaltech Budget App";
            Load += FormInicio_Load;
            ResumeLayout(false);
        }

        #endregion
    }
}
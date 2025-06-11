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
        private System.Windows.Forms.Button btnVistaPreviazona;
        private System.Windows.Forms.Button btnSalir;

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
            SuspendLayout();
            // 
            // btnPresupuestos
            // 
            btnPresupuestos.Location = new Point(25, 34);
            btnPresupuestos.Name = "btnPresupuestos";
            btnPresupuestos.Size = new Size(200, 40);
            btnPresupuestos.TabIndex = 0;
            btnPresupuestos.Text = "Cargar Presupuestos";
            btnPresupuestos.Click += btnPresupuestos_Click;
            // 
            // btnReportes
            // 
            btnReportes.Location = new Point(25, 202);
            btnReportes.Name = "btnReportes";
            btnReportes.Size = new Size(200, 40);
            btnReportes.TabIndex = 1;
            btnReportes.Text = "Ver Reportes";
            btnReportes.Click += btnReportes_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(241, 318);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(200, 40);
            btnSalir.TabIndex = 2;
            btnSalir.Text = "Salir";
            btnSalir.Click += btnSalir_Click;
            // 
            // btnVistaPreviaZona
            // 
            btnVistaPreviaZona.Location = new Point(25, 113);
            btnVistaPreviaZona.Name = "btnVistaPreviaZona";
            btnVistaPreviaZona.Size = new Size(200, 40);
            btnVistaPreviaZona.TabIndex = 3;
            btnVistaPreviaZona.Text = "Vista Previa Zona";
            btnVistaPreviaZona.Click += new System.EventHandler(this.btnVistaPrevia_Click);
            // 
            // FormInicio
            // 
            ClientSize = new Size(678, 370);
            Controls.Add(btnVistaPreviaZona);
            Controls.Add(btnPresupuestos);
            Controls.Add(btnReportes);
            Controls.Add(btnSalir);
            Name = "FormInicio";
            Text = "Inicio - Jaltech Budget App";
            Load += FormInicio_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnVistaPreviaZona;
    }
}
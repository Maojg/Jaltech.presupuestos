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
            this.btnPresupuestos = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPresupuestos
            // 
            this.btnPresupuestos.Location = new System.Drawing.Point(100, 30);
            this.btnPresupuestos.Size = new System.Drawing.Size(200, 40);
            this.btnPresupuestos.Text = "Cargar Presupuestos";
            this.btnPresupuestos.Click += new System.EventHandler(this.btnPresupuestos_Click);
            // 
            // btnReportes
            // 
            this.btnReportes.Location = new System.Drawing.Point(100, 80);
            this.btnReportes.Size = new System.Drawing.Size(200, 40);
            this.btnReportes.Text = "Ver Reportes";
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(100, 130);
            this.btnSalir.Size = new System.Drawing.Size(200, 40);
            this.btnSalir.Text = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FormInicio
            // 
            this.ClientSize = new System.Drawing.Size(400, 200);
            this.Controls.Add(this.btnPresupuestos);
            this.Controls.Add(this.btnReportes);
            this.Controls.Add(this.btnSalir);
            this.Text = "Inicio - Jaltech Budget App";
            this.ResumeLayout(false);
        }

        #endregion
    }
}
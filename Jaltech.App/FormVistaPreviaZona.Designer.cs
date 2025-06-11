namespace Jaltech.App
{
   
    partial class FormVistaPreviaZona
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cbZonas;
        private System.Windows.Forms.ComboBox cbMes;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label lblZona;
        private System.Windows.Forms.Label lblSalarioBasico;
        private System.Windows.Forms.Label lblPrestacional;
        private System.Windows.Forms.Label lblComisiones;
        private System.Windows.Forms.Label lblSalarioTotal;
        private System.Windows.Forms.Label lblBonoCumpl;
        private System.Windows.Forms.Label lblBonoBasik;
        private System.Windows.Forms.Label lblBonoCelulares;
        private System.Windows.Forms.Label lblBonoBod;
        private System.Windows.Forms.Label lblBonoDulces;
        private System.Windows.Forms.Label lblClientes;
        private System.Windows.Forms.Label lblKPI;
        private System.Windows.Forms.Label lblTotalBonos;
        private System.Windows.Forms.Label lblTotalGanado;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cbZonas = new System.Windows.Forms.ComboBox();
            this.cbMes = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lblZona = new System.Windows.Forms.Label();
            this.lblSalarioBasico = new System.Windows.Forms.Label();
            this.lblPrestacional = new System.Windows.Forms.Label();
            this.lblComisiones = new System.Windows.Forms.Label();
            this.lblSalarioTotal = new System.Windows.Forms.Label();
            this.lblBonoCumpl = new System.Windows.Forms.Label();
            this.lblBonoBasik = new System.Windows.Forms.Label();
            this.lblBonoCelulares = new System.Windows.Forms.Label();
            this.lblBonoBod = new System.Windows.Forms.Label();
            this.lblBonoDulces = new System.Windows.Forms.Label();
            this.lblClientes = new System.Windows.Forms.Label();
            this.lblKPI = new System.Windows.Forms.Label();
            this.lblTotalBonos = new System.Windows.Forms.Label();
            this.lblTotalGanado = new System.Windows.Forms.Label();
            this.cbMes.SelectedIndexChanged += new System.EventHandler(this.cbMes_SelectedIndexChanged);


            // Formulario
            this.Text = "Vista Previa de Presupuesto por Zona";
            this.ClientSize = new System.Drawing.Size(600, 500);
            this.BackColor = System.Drawing.Color.WhiteSmoke;

            // ComboBox Mes
            this.cbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMes.Items.AddRange(new object[] {
                "1 - Enero", "2 - Febrero", "3 - Marzo", "4 - Abril", "5 - Mayo", "6 - Junio",
                "7 - Julio", "8 - Agosto", "9 - Septiembre", "10 - Octubre", "11 - Noviembre", "12 - Diciembre"
            });
            this.cbMes.SelectedIndex = DateTime.Now.Month - 1;
            this.cbMes.Location = new System.Drawing.Point(340, 20);
            this.cbMes.Width = 150;
            this.cbMes.SelectedIndexChanged += new System.EventHandler(this.cbMes_SelectedIndexChanged);
            this.Controls.Add(this.cbMes);

            // ComboBox Zonas
            this.cbZonas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbZonas.Location = new System.Drawing.Point(20, 20);
            this.cbZonas.Width = 300;
            this.cbZonas.SelectedIndexChanged += new System.EventHandler(this.cbZonas_SelectedIndexChanged);
            this.Controls.Add(this.cbZonas);

            // TableLayoutPanel
            this.tableLayoutPanel.Location = new System.Drawing.Point(20, 60);
            this.tableLayoutPanel.Size = new System.Drawing.Size(550, 400);
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.RowCount = 14;
            this.tableLayoutPanel.AutoSize = true;
            this.tableLayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;

            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));

            string[] etiquetas = {
                "Zona", "Salario Básico", "Prestacional", "Prom. Comisiones", "Salario Total",
                "Bono Cumpl. Ventas", "Bono Basik", "Bono Celulares", "Bono Bod 9-10", "Dulces Alejandro",
                "Clientes Activos", "KPI Temporada", "Total Bonos", "Ganarian Total Salario"
            };

            Label[] valores = {
                lblZona, lblSalarioBasico, lblPrestacional, lblComisiones, lblSalarioTotal,
                lblBonoCumpl, lblBonoBasik, lblBonoCelulares, lblBonoBod, lblBonoDulces,
                lblClientes, lblKPI, lblTotalBonos, lblTotalGanado
            };

            for (int i = 0; i < etiquetas.Length; i++)
            {
                var label = new Label
                {
                    Text = etiquetas[i],
                    Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold),
                    AutoSize = true,
                    Dock = System.Windows.Forms.DockStyle.Fill,
                    TextAlign = System.Drawing.ContentAlignment.MiddleLeft
                };

                valores[i] = new Label
                {
                    Text = "-",
                    Font = new System.Drawing.Font("Segoe UI", 9F),
                    AutoSize = true,
                    Dock = System.Windows.Forms.DockStyle.Fill,
                    TextAlign = System.Drawing.ContentAlignment.MiddleRight,
                    ForeColor = System.Drawing.Color.Navy
                };

                this.tableLayoutPanel.Controls.Add(label, 0, i);
                this.tableLayoutPanel.Controls.Add(valores[i], 1, i);
            }

            this.Controls.Add(this.tableLayoutPanel);
        }
    }
}

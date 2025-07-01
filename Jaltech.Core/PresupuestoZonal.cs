using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Jaltech.Core
{
    public class PresupuestoZonal
    {
        public int Id { get; set; }

        [DisplayName("Año")]
        public int Anio { get; set; }

        [DisplayName("Mes")]
        public int Mes { get; set; }

        [DisplayName("Zona")]
        public string Zona { get; set; } = string.Empty;

        [DisplayName("Salario Básico")]
        public decimal SalarioBasico { get; set; }

        [DisplayName("Prestacional")]
        public decimal Prestacional { get; set; }

        [DisplayName("Promedio Comisiones")]
        public decimal PromedioComisiones { get; set; }

        [DisplayName("Salario Promedio Total")]
        public decimal SalarioPromedioTotal { get; set; }

        [DisplayName("Bono Cumpl. Ventas")]
        public decimal BonoCumplVentas { get; set; }

        [DisplayName("Bono Basik")]
        public decimal BonoBasik { get; set; }

        [DisplayName("Bono Celulares")]
        public decimal BonoCelulares { get; set; }

        [DisplayName("Bono Bod 9-10")]
        public decimal BonoBod { get; set; }

        [DisplayName("Dulces Alejandro")]
        public decimal BonoDulces { get; set; }

        [DisplayName("Clientes Activos")]
        public decimal ClientesActivos { get; set; }

        [DisplayName("KPI Temporada")]
        public decimal KPIReguladores { get; set; }

        [DisplayName("Bono Especial 1")]
        public decimal BonoEspecial1 { get; set; }

        [DisplayName("Bono Especial 2")]
        public decimal BonoEspecial2 { get; set; }

        [DisplayName("Total Bonos Mes")]
        public decimal TotalBonosMes { get; set; }

        [DisplayName("Ganarian Total Salario")]
        public decimal TotalSalario { get; set; }

        [DisplayName("Fecha Carga")]
        public DateTime FechaCarga { get; set; } = DateTime.Now;
    }

    public class VistaPreviaZona
    {
        public string Zona { get; set; } = string.Empty;
        public int Anio { get; set; }
        public int Mes { get; set; }
        public decimal SalarioBasico { get; set; }
        public decimal Prestacional { get; set; }
        public decimal PromedioComisiones { get; set; }
        public decimal SalarioPromedioTotal => SalarioBasico + Prestacional + PromedioComisiones;
        public decimal BonoCumplVentas { get; set; }
        public decimal BonoBasik { get; set; }
        public decimal BonoCelulares { get; set; }
        public decimal BonoBod { get; set; }
        public decimal BonoDulces { get; set; }
        public decimal ClientesActivos { get; set; }
        public decimal KPIReguladores { get; set; }
        public decimal BonoEspecial1 { get; set; }
        public decimal BonoEspecial2 { get; set; }


        public decimal TotalBonosMes => BonoCumplVentas + BonoBasik + BonoCelulares + BonoBod + BonoDulces + ClientesActivos + KPIReguladores + BonoEspecial1 + BonoEspecial2;
        public decimal TotalSalario => SalarioPromedioTotal + TotalBonosMes;
    }
    public class ZonaDto
    {
        public string Zona { get; set; } = string.Empty;
    }


}

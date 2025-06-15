using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Jaltech.Core;

namespace Jaltech.Data
{
    public class JaltechDbContext : DbContext
    {
        public JaltechDbContext(DbContextOptions options) : base(options) { }

        public DbSet<PresupuestoZonal> PresupuestosZonales { get; set; }
        public DbSet<ZonaDto> Zonas { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PresupuestoZonal>(entity =>
            {
                entity.ToTable("DimPresupuestoZonal");

                // Establecer precisión y escala explícita para todos los decimal
                entity.Property(p => p.SalarioBasico).HasPrecision(18, 2);
                entity.Property(p => p.Prestacional).HasPrecision(18, 2);
                entity.Property(p => p.PromedioComisiones).HasPrecision(18, 2);
                entity.Property(p => p.SalarioPromedioTotal).HasPrecision(18, 2);
                entity.Property(p => p.BonoCumplVentas).HasPrecision(18, 2);
                entity.Property(p => p.BonoBasik).HasPrecision(18, 2);
                entity.Property(p => p.BonoCelulares).HasPrecision(18, 2);
                entity.Property(p => p.BonoBod).HasPrecision(18, 2);
                entity.Property(p => p.BonoDulces).HasPrecision(18, 2);
                entity.Property(p => p.KPIReguladores).HasPrecision(18, 2);
                entity.Property(p => p.TotalBonosMes).HasPrecision(18, 2);
                entity.Property(p => p.TotalSalario).HasPrecision(18, 2);
            });

            modelBuilder.Entity<ZonaDto>().HasNoKey();
        }
    }

}
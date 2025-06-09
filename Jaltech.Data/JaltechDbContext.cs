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
    }
}
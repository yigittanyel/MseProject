using Microsoft.EntityFrameworkCore;
using MSE.Entity.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MSE.DataAccess.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Alarm> Alarms { get; set; }
        public DbSet<MaintenancePersonnel> MaintenancePersonnels { get; set; }
        public DbSet<ProductionLine> ProductionLines { get; set; }
        public DbSet<WorkStation> WorkStations { get; set; }
        public DbSet<WorkStationPersonnel> WorkStationPersonnels { get; set; }

    }
}

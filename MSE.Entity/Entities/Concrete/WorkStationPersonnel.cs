using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSE.Entity.Entities.Concrete
{
    public class WorkStationPersonnel
    {
        [Key]
        public int Id { get; set; }
        public int MaintenancePersonnelId { get; set; }
        public int WorkStationId { get; set; }
        public virtual MaintenancePersonnel MaintenancePersonnel { get; set; }
        public virtual WorkStation WorkStation { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSE.Entity.Entities.Concrete
{
    public class WorkStation
    {
        [Key]
        public int WorkStationId { get; set; }

        [MaxLength(100)]
        public string StationName { get; set; }
        public decimal Temperature { get; set; }
        public decimal Pressure { get; set; }
        public bool Status { get; set; }

        public int? ProductionLineId { get; set; }
        public virtual ProductionLine ProductionLine { get; set; }
        public virtual ICollection<MaintenancePersonnel> MaintenancePersonnels { get; set; }
    }
}

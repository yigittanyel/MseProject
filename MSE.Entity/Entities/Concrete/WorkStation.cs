using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSE.Entity.Entities.Concrete
{
    public class WorkStation
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int WorkStationId { get; set; }

        [MaxLength(100)]
        public string? StationName { get; set; }
        public decimal Temperature { get; set; }
        public decimal Pressure { get; set; }
        public bool Status { get; set; }

        public int? ProductionLineId { get; set; }
        public virtual ProductionLine ProductionLine { get; set; }
        public virtual ICollection<MaintenancePersonnel> MaintenancePersonnels { get; set; }
        public virtual ICollection<Alarm> Alarms { get; set; }
    }
}

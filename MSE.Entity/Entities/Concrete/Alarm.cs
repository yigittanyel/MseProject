using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSE.Entity.Entities.Concrete
{
    public class Alarm
    {
        [Key]
        public int AlarmId { get; set; }
        public decimal MaxTemperature { get; set; }
        public decimal MinTemperature{ get; set; }
        public decimal MaxPressure { get; set; }
        public decimal MinPressure { get; set; }
        public int? WorkStationId { get; set; }
        public virtual WorkStation WorkStation { get; set; }


    }
}

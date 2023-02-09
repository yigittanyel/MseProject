using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSE.DTO.DTOs.Alarm
{
    public class AlarmToAddDTO
    {
        public decimal MaxTemperature { get; set; }
        public decimal MinTemperature { get; set; }
        public decimal MaxPressure { get; set; }
        public decimal MinPressure { get; set; }
    }
}

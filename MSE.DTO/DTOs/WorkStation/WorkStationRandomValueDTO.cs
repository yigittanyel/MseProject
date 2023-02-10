using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSE.DTO.DTOs.WorkStation
{
    public class WorkStationRandomValueDTO
    {
        public int WorkStationId { get; set; }
        public decimal Temperature { get; set; }
        public decimal Pressure { get; set; }
        public bool Status { get; set; }
    }
}

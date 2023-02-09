using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSE.DTO.DTOs.ProductionLine
{
    public class ProductionLineToAddDTO
    {
        public string ProductionLineName { get; set; }
        public DateTime FirstProductionDate { get; set; }
        public DateTime LastProductionDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MSE.Entity.Entities.Concrete
{
    public class ProductionLine
    {
        [Key]
        public int ProductionLineId { get; set; }
        [MaxLength(100)]
        public string ProductionLineName { get; set; }
        public DateTime FirstProductionDate { get; set; }
        public DateTime LastProductionDate { get; set; }
        public virtual ICollection<WorkStation> WorkStations { get; set; }
    }
}

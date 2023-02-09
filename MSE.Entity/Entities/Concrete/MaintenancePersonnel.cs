using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSE.Entity.Entities.Concrete
{
    public class MaintenancePersonnel
    {
        [Key]
        public int MaintenancePersonnelId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Surname { get; set; }
        [MaxLength(11)]
        public string PhoneNumber { get; set; }
        [MaxLength(100)]
        public string EmailAdress { get; set; }

        public virtual ICollection<WorkStation> WorkStations { get; set; }
    }
}

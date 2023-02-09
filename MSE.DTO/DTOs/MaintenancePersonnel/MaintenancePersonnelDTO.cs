using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSE.DTO.DTOs.MaintenancePersonnel
{
    public class MaintenancePersonnelDTO
    {
        public int MaintenancePersonnelId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAdress { get; set; }
    }
}

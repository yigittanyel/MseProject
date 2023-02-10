using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSE.Entity.Entities.Concrete
{
    public class EmailData
    {
        [Key]
        public int Id { get; set; }

        public string? From { get; set; }

        public string? To { get; set; }
        public string? Subject { get; set; }

        public string? Body { get; set; }

        public string Password { get; set; }
        public EmailData()
        {
            From = "tanyelyigit@gmail.com";
            Password = "mosmfvafzrcjlsqb";
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GBCSporting2021_PepperoniPizza420.Models
{
    public class Technician
    {
        public int TechnicianId { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$"), Required(ErrorMessage = "Please enter a Name."), StringLength(50)]
        public string Name { get; set; }

#       //TODO: find the Email Address Regex
        [RegularExpression(@"*"), Required(ErrorMessage = "Please enter a Email."), StringLength(50)]
        public string Email { get; set; }

        //TODO: find the Phone Number Regex
        [RegularExpression(@"*"), Required(ErrorMessage = "Please enter a Phone."), StringLength(50)]
        public string Phone { get; set; }
    }
}

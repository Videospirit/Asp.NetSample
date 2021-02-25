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

        //TODO: find the Email Address Regex
        // Maybe: ^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"), Required(ErrorMessage = "Please enter an Email."), StringLength(50)]
        public string Email { get; set; }

        //TODO: find the Phone Number Regex
        // Maybe: ^[\\(]{0,1}([0-9]){3}[\\)]{0,1}[ ]?([^0-1]){1}([0-9]){2}[ ]?[-]?[ ]?([0-9]){4}[ ]*((x){0,1}([0-9]){1,5}){0,1}$
        [RegularExpression(@"^([0-9]( |-)?)?(\(?[0-9]{3}\)?|[0-9]{3})( |-)?([0-9]{3}( |-)?[0-9]{4}|[a-zA-Z0-9]{7})$"), Required(ErrorMessage = "Please enter a Phone Number in this format 647-123-4321."), StringLength(50)]
        public string Phone { get; set; }
    }
}

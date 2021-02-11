using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GBCSporting2021_PepperoniPizza420.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        public Country Country { get; set; }

        [Required(ErrorMessage = "Please enter a Country.")]
        public int CountryId { get; set; }
        public virtual ICollection<Registration> Registrations { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$"), Required(ErrorMessage = "Please enter a FirstName."), StringLength(50)]
        public string FirstName { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$"), Required(ErrorMessage = "Please enter a LastName."), StringLength(50)]

        public string LastName { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$"), Required(ErrorMessage = "Please enter a Address."), StringLength(50)]

        public string Address { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$"), Required(ErrorMessage = "Please enter a City."), StringLength(50)]

        public string City { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$"), Required(ErrorMessage = "Please enter a State."), StringLength(50)]

        public string State { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$"), Required(ErrorMessage = "Please enter a PostalCode."), StringLength(50)]
        public string PostalCode { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$"), Required(ErrorMessage = "Please enter a Email."), StringLength(50)]
        public string Email { get; set; }

        // TODO: find regular expression for Phone number
        [Required(ErrorMessage = "Please enter a Phone Number in this format (647) 123-4321."), StringLength(50)]
        public string Phone { get; set; }


    }
}

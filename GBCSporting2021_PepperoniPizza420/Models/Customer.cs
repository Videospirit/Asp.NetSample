using Microsoft.AspNetCore.Mvc;
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

        [Required(ErrorMessage = "Please enter a First Name."), StringLength(51, MinimumLength = 1, ErrorMessage = "First name should be between 1 and 51 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter a Last Name."), StringLength(51, MinimumLength = 1, ErrorMessage = "Last name should be between 1 and 51 characters")]

        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter a Address."), StringLength(51, MinimumLength = 1, ErrorMessage = "Address should be between 1 and 51 characters")]

        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter a City."), StringLength(51, MinimumLength = 1, ErrorMessage = "City name should be between 1 and 51 characters")]

        public string City { get; set; }

        [Required(ErrorMessage = "Please enter a State."), StringLength(51, MinimumLength = 1, ErrorMessage = "State should be between 1 and 51 characters")]

        public string State { get; set; }

        [Required(ErrorMessage = "Please enter a Postal Code."), StringLength(21, MinimumLength = 1, ErrorMessage = "Postal Code should be between 1 and 21 characters")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Please enter an Email.")]
        [StringLength(51, MinimumLength = 1, ErrorMessage = "Email should be between 1 and 51 characters")]
        [DataType(DataType.EmailAddress)]
        [Remote("CheckEmail", "Customer")]
        public string? Email { get; set; }

        [RegularExpression(@"^\(\d{3}\)\s?\d{3}-\d{4}", ErrorMessage = "Invalid Phone Number, the format should be the following: (999) 999-9999")]
        public string? Phone { get; set; }

    }
}

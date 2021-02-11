using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GBCSporting2021_PepperoniPizza420.Models
{
    public class Country
    {
        public int CountryId { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$"), Required(ErrorMessage = "Please enter a name."), StringLength(50)]
        public string Name { get; set; }
    }
}

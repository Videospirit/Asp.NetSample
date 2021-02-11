using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GBCSporting2021_PepperoniPizza420.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Please enter a Product Code.")]
        public string Code { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$"), Required(ErrorMessage = "Please enter a FirstName."), StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a Product Price."), Range(0.0, 1000000.0)]
        public float Price { get; set; }

        [Required(ErrorMessage = "Please enter a Product ReleaseDate."), Range(typeof(DateTime), "1/2/2000", "3/4/3000")]
        public DateTime ReleaseDate { get; set; }

        public virtual ICollection<Registration> Registrations { get; set; }
    }
}

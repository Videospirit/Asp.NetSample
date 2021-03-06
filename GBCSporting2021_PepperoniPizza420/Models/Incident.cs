using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GBCSporting2021_PepperoniPizza420.Models
{
    public class Incident
    {
        public int IncidentId { get; set; }

        public Customer Customer { get; set; }

        [Required(ErrorMessage = "Please enter a Customer.")]
        public int CustomerId { get; set; }

        public Product Product { get; set; }

        [Required(ErrorMessage = "Please enter a Product.")]
        public int ProductId { get; set; }
        
        public Technician Technician  { get; set; }
               
        public int? TechnicianId  { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z_ ]*$"), Required(ErrorMessage = "Please enter a FirstName."), StringLength(50)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter a Description.")]
        public string Description { get; set; }

        public DateTime? DateOpened { get; set; }
        public DateTime? DateClosed { get; set; }


    }
}

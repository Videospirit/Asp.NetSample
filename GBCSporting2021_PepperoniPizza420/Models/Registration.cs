using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GBCSporting2021_PepperoniPizza420.Models
{
    public class Registration
    {
        public int RegistrationId { get; set; }

        public Customer Customer { get; set; }

        [Key, Column(Order = 1)]
        public int CustomerId { get; set; }

        public Product Product { get; set; }
        
        [Key, Column(Order = 1)]
        public int ProductId { get; set; }
    }
}

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

        private Customer Customer { get; set; }

        [Key, Column(Order = 1)]
        private int CostumerId { get; set; }

        private Product Product { get; set; }
        
        [Key, Column(Order = 1)]
        private int ProductId { get; set; }
    }
}

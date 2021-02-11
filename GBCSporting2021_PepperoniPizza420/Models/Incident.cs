using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GBCSporting2021_PepperoniPizza420.Models
{
    public class Incident
    {
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }

        public Product Product { get; set; }
        public int ProductId { get; set; }

        public Technician Technician { get; set; }
        public int TechnicianId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateOpened { get; set; }
        public DateTime? DateClosed { get; set; }


    }
}

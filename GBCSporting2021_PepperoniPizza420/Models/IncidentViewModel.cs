using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GBCSporting2021_PepperoniPizza420.Models
{
    public class IncidentViewModel 
    {
        public List<Incident> Incidents { get; set; }

        public Incident CurrentIncident { get; set; }

        public List<Customer> Customers { get; set; }

        public List<Product> Products { get; set; }

        public List<Technician> Technicians { get; set; }

        public string Action { get; set; }

        public string Filter { get; set; }
    }
}

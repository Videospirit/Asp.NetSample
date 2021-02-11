using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GBCSporting2021_PepperoniPizza420.Models
{
    public class Product
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public DateTime ReleaseDate { get; set; }

        public virtual ICollection<Registration> Registrations { get; set; }
    }
}

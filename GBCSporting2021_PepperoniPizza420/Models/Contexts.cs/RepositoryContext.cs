using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GBCSporting2021_PepperoniPizza420.Models
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options):
            base(options)
        {

        }
        public DbSet<Product> Product { get; set; }
    }
}

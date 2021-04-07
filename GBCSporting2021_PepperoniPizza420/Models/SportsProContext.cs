using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using GBCSporting2021_PepperoniPizza420.Models.Contexts.cs;
using GBCSporting2021_PepperoniPizza420.DataAccessLayer;

namespace GBCSporting2021_PepperoniPizza420.Models
{
    public class SportsProContext : DbContext
    {
        public SportsProContext(DbContextOptions<SportsProContext> options) : base(options) { }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Technician> Technicians { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {

            modelBuilder.ApplyConfiguration(new SeedCountry());
            modelBuilder.ApplyConfiguration(new SeedCustomer());
            modelBuilder.ApplyConfiguration(new SeedIncident());
            modelBuilder.ApplyConfiguration(new SeedProduct());
            modelBuilder.ApplyConfiguration(new SeedRegistration());
            modelBuilder.ApplyConfiguration(new SeedTechnician());

            modelBuilder.Entity<Registration>().HasKey(r => new { r.CustomerId, r.ProductId });
        }
    }
}

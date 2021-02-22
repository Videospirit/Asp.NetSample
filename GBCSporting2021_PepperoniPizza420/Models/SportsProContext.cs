using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
            modelBuilder.Entity<Country>().HasData(
                new Country { 
                    CountryId = 1,
                    Name = "Canada"
                },
                new Country
                {
                    CountryId = 2,
                    Name = "United States"
                },
                new Country
                {
                    CountryId = 3,
                    Name = "El Salvador"
                });

            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    CustomerId = 1,
                    CountryId = 1,
                    FirstName = "Jeff",
                    LastName = "Bezos",
                    Address = "1 Blue Jays Ways",
                    City = "Jeffville",
                    State = "Ontario",
                    PostalCode = "JEF F10",
                    Email = "jeff@jeff.com",
                    Phone = "+1(123)321-4325"
                },
                new Customer
                {
                    CustomerId = 2,
                    CountryId = 2,
                    FirstName = "Oliver",
                    LastName = "Doe",
                    Address = "2 Blue Jays Ways",
                    City = "Oliviettoville",
                    State = "Ontario",
                    PostalCode = "JEF F10",
                    Email = "o@liver.com",
                    Phone = "+1(122)321-4325"
                }, 
                new Customer
                {
                    CustomerId = 3,
                    CountryId = 3,
                    FirstName = "Francisco",
                    LastName = "Carzone",
                    Address = "3 Blue Jays Ways",
                    City = "Franville",
                    State = "Ontario",
                    PostalCode = "1020",
                    Email = "fran@k.com",
                    Phone = "+1(323)321-4325"
                });

            modelBuilder.Entity<Incident>().HasData(
                new Incident
                {
                    IncidentId = 1,
                    CustomerId = 1,
                    ProductId = 1,
                    TechnicianId = 1,
                    Title = "Title 1",
                    Description = "This is an incident",
                    DateOpened = DateTime.Now,
                    DateClosed = DateTime.Now
                },
                new Incident
                {
                    IncidentId = 2,
                    CustomerId = 2,
                    ProductId = 2,
                    TechnicianId = 2,
                    Title = "Title 2",
                    Description = "This is another incident",
                    DateOpened = DateTime.Now,
                    DateClosed = DateTime.Now
                },
                new Incident
                {
                    IncidentId = 3,
                    CustomerId = 3,
                    ProductId = 3,
                    TechnicianId = 3,
                    Title = "Title 3",
                    Description = "This is not an incident (jk)",
                    DateOpened = DateTime.Now,
                    DateClosed = DateTime.Now
                });

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 1,
                    Code = "H3LL0W0RLD",
                    Name = "Pizza",
                    Price = 4.20,
                    ReleaseDate = DateTime.Now
                },
                new Product
                {
                    ProductId = 2,
                    Code = "W0RLDH3LL0",
                    Name = "Pepperoni",
                    Price = 69.99,
                    ReleaseDate = DateTime.Now
                },
                new Product
                {
                    ProductId = 3,
                    Code = "IDKWTPH",
                    Name = "Ham",
                    Price = 77.7,
                    ReleaseDate = DateTime.Now
                });

            modelBuilder.Entity<Registration>().HasData(
                new Registration
                {
                    RegistrationId = 1,
                    CustomerId = 1,
                    ProductId = 1
                },
                new Registration
                {
                    RegistrationId = 2,
                    CustomerId = 2,
                    ProductId = 2
                }, 
                new Registration
                {
                    RegistrationId = 3,
                    CustomerId = 3,
                    ProductId = 3
                });

            modelBuilder.Entity<Technician>().HasData(
                new Technician
                {
                    TechnicianId = 1,
                    Name = "Brad",
                    Email = "brad@gmai.com",
                    Phone = "+1(111)111-1111"
                },
                new Technician
                {
                    TechnicianId = 2,
                    Name = "Chad",
                    Email = "chad@gmai.com",
                    Phone = "+1(222)222-2222"
                },
                new Technician
                {
                    TechnicianId = 3,
                    Name = "Thad",
                    Email = "thad@gmai.com",
                    Phone = "+1(333)333-3333"
                });

            modelBuilder.Entity<Registration>().HasKey(r => new { r.CustomerId, r.ProductId });
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GBCSporting2021_PepperoniPizza420.Models.Contexts.cs
{
    internal class SeedCustomer : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> entity) {
            
            entity.HasData(
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
        }
    }
}

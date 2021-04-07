using GBCSporting2021_PepperoniPizza420.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace GBCSporting2021_PepperoniPizza420.DataAccessLayer
{
    internal class SeedProduct : IEntityTypeConfiguration<Product>
    {     
        
        
      
            public void Configure(EntityTypeBuilder<Product> entity) { 
            entity.HasData(   
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
        }
    }
}

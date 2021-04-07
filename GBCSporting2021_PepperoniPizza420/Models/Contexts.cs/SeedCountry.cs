using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GBCSporting2021_PepperoniPizza420.Models.Contexts.cs
{
    internal class SeedCountry : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> entity)
        {
            entity.HasData(
            new Country
            {
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
            }


           ); 

        }
    }
}

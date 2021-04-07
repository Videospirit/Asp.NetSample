using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GBCSporting2021_PepperoniPizza420.Models.Contexts.cs
{
    internal class SeedIncident : IEntityTypeConfiguration<Incident>
    {
        public void Configure(EntityTypeBuilder<Incident> entity)
        {

            entity.HasData(
             
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
        }
    }
}

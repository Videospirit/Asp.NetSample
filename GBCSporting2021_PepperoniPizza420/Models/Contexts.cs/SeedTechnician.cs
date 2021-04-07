using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GBCSporting2021_PepperoniPizza420.Models.Contexts.cs
{
    internal class SeedTechnician : IEntityTypeConfiguration<Technician>
    {
        public void Configure(EntityTypeBuilder<Technician> entity)
        {
            entity.HasData(
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
        }

    }
}

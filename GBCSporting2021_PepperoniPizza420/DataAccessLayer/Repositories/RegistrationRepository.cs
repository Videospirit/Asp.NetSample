using GBCSporting2021_PepperoniPizza420.DataAccessLayer.Interfaces;
using GBCSporting2021_PepperoniPizza420.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GBCSporting2021_PepperoniPizza420.DataAccessLayer.Repositories
{
    public class RegistrationRepository : Repository<Registration> , IRegistrationRepository
    {
        public RegistrationRepository(SportsProContext ctx)
           : base(ctx)
        {
        }
    }
}

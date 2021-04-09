
using System.Collections.Generic;
using System.Linq;
using GBCSporting2021_PepperoniPizza420.DataAccessLayer.Repositories;
using GBCSporting2021_PepperoniPizza420.Models;
using Microsoft.EntityFrameworkCore;

namespace GBCSporting2021_PepperoniPizza420.DataAccessLayer
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(SportsProContext ctx)
            :base(ctx)
        {
        }
        
        



    }
}

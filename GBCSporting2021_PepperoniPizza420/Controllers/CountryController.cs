using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GBCSporting2021_PepperoniPizza420.Models;
using Microsoft.AspNetCore.Mvc;

namespace GBCSporting2021_PepperoniPizza420.Controllers
{
    public class CountryController : Controller
    {
        private SportsProContext context { get; set; }

        public CountryController(SportsProContext ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            var countries = context.Countries
                .OrderBy(m => m.Name)
                .ToList();
            return View(countries);
        }
    }
}

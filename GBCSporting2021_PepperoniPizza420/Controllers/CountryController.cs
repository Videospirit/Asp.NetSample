using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GBCSporting2021_PepperoniPizza420.DataAccessLayer.Interfaces;
using GBCSporting2021_PepperoniPizza420.Models;
using Microsoft.AspNetCore.Mvc;

namespace GBCSporting2021_PepperoniPizza420.Controllers
{
    public class CountryController : Controller
    {
        private ICountryRepository countryRepository;
        

        public CountryController(ICountryRepository ctx)
        {
            this.countryRepository = ctx;
        }
        public IActionResult Index()
        {
            var countries = countryRepository.GetAll()
                .OrderBy(m => m.Name)
                .ToList();
            return View(countries);
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GBCSporting2021_PepperoniPizza420.Models
{
    public class About : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

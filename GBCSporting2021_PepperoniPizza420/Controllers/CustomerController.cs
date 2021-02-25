using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GBCSporting2021_PepperoniPizza420.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GBCSporting2021_PepperoniPizza420.Controllers
{
    public class CustomerController : Controller
    {
        private SportsProContext context { get; set; }

        public CustomerController(SportsProContext ctx)
        {
            context = ctx;
        }

        //[HttpGet]
        public IActionResult Index()
        {
            var customers = context.Customers
                .Include(c => c.Country)
                .OrderBy(c => c.FirstName).ToList();
            return View(customers);
        }
        //[HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Countries = context.Countries.OrderBy(c => c.Name).ToList();
            return View("Edit", new Customer());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Countries = context.Countries.OrderBy(c => c.Name).ToList();
            var customer = context.Customers
                .Include(c => c.Country)
                .FirstOrDefault(c => c.CustomerId == id);
            return View(customer);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var customer = context.Customers
                .Include(c => c.Country)
                .FirstOrDefault(c => c.CustomerId == id);
            return View(customer);
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            string action = (customer.CustomerId == 0) ? "Add" : "Edit";

            if (ModelState.IsValid)
            {
                if (action == "Add")
                {
                    context.Customers.Add(customer);
                }
                else
                {
                    context.Customers.Update(customer);
                }
                context.SaveChanges();
                return RedirectToAction("Index", "Customer");
            }
            else
            {
                ViewBag.Action = action;
                ViewBag.Countries = context.Countries.OrderBy(c => c.Name).ToList();
                return View(customer);
            }
        }

        [HttpPost]
        public IActionResult Delete(Customer customer)
        {
            context.Customers.Remove(customer);
            context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }
    }
}


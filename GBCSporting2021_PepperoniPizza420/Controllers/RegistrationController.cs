using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GBCSporting2021_PepperoniPizza420.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GBCSporting2021_PepperoniPizza420.Controllers
{
    public class RegistrationController : Controller
    {

        private SportsProContext context { get; set; }

        public RegistrationController(SportsProContext ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            var customers = context.Customers
                .OrderBy(c => c.FirstName).ToList();
            return View(customers);
        }

        public IActionResult Select(int id)
        {
            var sess = new CustomerSession(HttpContext.Session);
            var customer = context.Customers
                .FirstOrDefault(c => c.CustomerId == id);
            sess.SetCustomer(customer);
            return RedirectToAction("Edit");
        }

        public IActionResult Edit()
        {
            var sess = new CustomerSession(HttpContext.Session);
            var customer = sess.GetCustomer();
            var Registrations = context.Registrations
                .Where(s => s.CustomerId == customer.CustomerId);
            ViewBag.Products = context.Products.OrderBy(c => c.Name).ToList();
            return View(Registrations);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var sess = new CustomerSession(HttpContext.Session);
            var registration = context.Registrations
                .FirstOrDefault(r => r.Product.ProductId == id && r.Customer.CustomerId == sess.GetCustomer().CustomerId);
            context.Registrations.Remove(registration);
            context.SaveChanges();
            return RedirectToAction("Edit");
        }

        [HttpPost]
        public IActionResult Register(int id)
        {
            bool absent = true;
            var sess = new CustomerSession(HttpContext.Session);
            var customer = context.Customers
                 .FirstOrDefault(c => c.CustomerId == sess.GetCustomer().CustomerId);
            var Registrations = context.Registrations
                .Where(s => s.CustomerId == customer.CustomerId);
            foreach(Registration r in Registrations)
            {
                if (r.ProductId == id) { absent = false; }
            }

            if (absent){
                Registration add = new Registration();
                System.Console.WriteLine(add.RegistrationId);
                add.Customer = customer;
                add.CustomerId = customer.CustomerId;
                add.ProductId = id;
                var product = context.Products
                .FirstOrDefault(c => c.ProductId == id);
                add.Product = product;
                context.Registrations.Add(add);
                context.SaveChanges();
            }
            return RedirectToAction("Edit");
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GBCSporting2021_PepperoniPizza420.DataAccessLayer.Interfaces;
using GBCSporting2021_PepperoniPizza420.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GBCSporting2021_PepperoniPizza420.Controllers
{
    public class RegistrationController : Controller
    {
        private IUnitOfWork registrationUnit;

        public RegistrationController(IUnitOfWork ctx)
        {
            this.registrationUnit = ctx;
        }
        public IActionResult Index()
        {
            var customers = registrationUnit.CustomerRepository.GetAll()
                           .OrderBy(c => c.FirstName).ToList();
            return View(customers);
        }

        [HttpPost]
        public IActionResult Select(int id)
        {
            var customer = registrationUnit.CustomerRepository.GetAll()
                 .FirstOrDefault(c => c.CustomerId == id);
            var sess = new CustomerSession(HttpContext.Session);
            sess.SetCustomer(customer);
            return RedirectToAction("Edit");
        }

        public IActionResult Edit()
        {
            var sess = new CustomerSession(HttpContext.Session);
            var customer = sess.GetCustomer();
            var Registrations = registrationUnit.RegistrationRepository.GetAll()
                .Where(s => s.CustomerId == customer.CustomerId);
            ViewBag.Products = registrationUnit.ProductRepository.GetAll().OrderBy(i => i.Name).ToList();
            return View(Registrations);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var sess = new CustomerSession(HttpContext.Session);
            var registration = registrationUnit.RegistrationRepository.GetAll(includeProperties: "Product,Customer")
                .FirstOrDefault(r => r.Product.ProductId == id && r.Customer.CustomerId == sess.GetCustomer().CustomerId);
            registrationUnit.RegistrationRepository.Remove(registration);
            registrationUnit.RegistrationRepository.Save();
            return RedirectToAction("Edit");
        }

        [HttpPost]
        public IActionResult Register(int id)
        {
            bool absent = true;
            var sess = new CustomerSession(HttpContext.Session);
            var customer = registrationUnit.CustomerRepository.GetAll()
                 .FirstOrDefault(c => c.CustomerId == sess.GetCustomer().CustomerId);
            var Registrations = registrationUnit.RegistrationRepository.GetAll()
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
                var product = registrationUnit.ProductRepository.GetAll()
                .FirstOrDefault(c => c.ProductId == id);
                add.Product = product;
                registrationUnit.RegistrationRepository.Add(add);
                registrationUnit.RegistrationRepository.Save();
            }
            return RedirectToAction("Edit");
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GBCSporting2021_PepperoniPizza420.DataAccessLayer;
using GBCSporting2021_PepperoniPizza420.DataAccessLayer.Interfaces;
using GBCSporting2021_PepperoniPizza420.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GBCSporting2021_PepperoniPizza420.Controllers
{
    public class CustomerController : Controller
    {
        public IUnitOfWork customerUnit;
        private string message;

        public CustomerController(IUnitOfWork ctx)
        {
            this.customerUnit = ctx;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var customers = customerUnit.CustomerRepository.GetAll(includeProperties: "Country")                
                .OrderBy(c => c.FirstName).ToList();

            
               
            return View(customers);
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Countries = customerUnit.CountryRepository.GetAll().OrderBy(c =>c.Name).ToList();
            return View("Edit", new Customer());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Countries = customerUnit.CountryRepository.GetAll().OrderBy(c => c.Name).ToList();
            var customers = customerUnit.CustomerRepository.GetAll()    
                 
                 .FirstOrDefault(c => c.CustomerId == id);
            
            return View(customers);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var customers = customerUnit.CustomerRepository.GetAll()
                
                .FirstOrDefault(c => c.CustomerId == id);
            
            return View(customers);
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            string action = (customer.CustomerId == 0) ? "Add" : "Edit";

            if (ModelState.IsValid)
            {
                if (action == "Add")
                {
                    customerUnit.CustomerRepository.Add(customer);
                    message = customer.FirstName + " " + customer.LastName + " has been succesfully added.";
                }
                else
                {
                    customerUnit.CustomerRepository.Update(customer);
                    message = customer.FirstName + " " + customer.LastName + " has been succesfully updated.";
                }
                customerUnit.CustomerRepository.Save();
                TempData["message"] = message;
                return RedirectToAction("Index", "Customer");
            }
            else
            {
                ViewBag.Action = action;
                ViewBag.Countries = customerUnit.CountryRepository.GetAll().OrderBy(c => c.Name).ToList();
                return View(customer);
            }
        }

        [HttpPost]
        public IActionResult Delete(Customer customer)
        {
            customerUnit.CustomerRepository.Remove(customer);
            customerUnit.CustomerRepository.Save();
            message = "Customer has been succesfully deleted";
            TempData["message"] = message;
            return RedirectToAction("Index", "Customer");
        }
    }
}


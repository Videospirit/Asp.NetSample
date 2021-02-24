using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GBCSporting2021_PepperoniPizza420.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GBCSporting2021_PepperoniPizza420.Controllers
{
    public class IncidentController : Controller
    {
        private SportsProContext context { get; set; }
        public IncidentController(SportsProContext ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            var incidents = context.Incidents
                .Include(i => i.Customer)
                .Include(i => i.Product)
                .OrderBy(i => i.DateOpened)
                .ToList();
            return View(incidents);
        }
        public IActionResult Details(int id)
        {
            var incident = context.Incidents
               .Include(i => i.Customer)
               .Include(i => i.Product)
               .FirstOrDefault(i => i.IncidentId == id);

            return View(incident);
        }
        [HttpGet]
        public IActionResult Add()
        {
           
            ViewBag.Action = "Add";
            ViewBag.Customers = context.Customers.OrderBy(i => i.FirstName).ToList();
            ViewBag.Products = context.Products.OrderBy(i => i.Name).ToList();
            ViewBag.Technicians = context.Technicians.OrderBy(i => i.Name).ToList();
            return View("Edit", new Incident());
        }
        
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Customers = context.Customers.OrderBy(i => i.FirstName).ToList();
            ViewBag.Products = context.Products.OrderBy(i => i.Name).ToList();
            ViewBag.Technicians = context.Technicians.OrderBy(i => i.Name).ToList();

            var incident = context.Incidents
              .Include(i => i.Customer)
              .Include(i => i.Product)
              .First(i => i.IncidentId == id);

            return View(incident);
        }

        [HttpPost]
        public IActionResult Edit(Incident inc)
        {
            string action = (inc.IncidentId == 0) ? "Add" : "Edit";
            if (ModelState.IsValid)
            {
                if (action == "Add")
                {
                    
                    context.Incidents.Add(inc);
                }
                else
                {
                    context.Incidents.Update(inc);
                }
                context.SaveChanges();
                return RedirectToAction("Index", "Incident");

            }
            else
            {
                ViewBag.Action = action;
                ViewBag.Incidents = context.Incidents.OrderBy(i => i.Title).ToList();
                return View(inc);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var incident = context.Incidents
              .Include(i => i.Customer)
              .Include(i => i.Product)
              .FirstOrDefault(i => i.IncidentId == id);

            return View(incident);
        }
        [HttpPost]
        public IActionResult Delete(Incident inc)
        {
            context.Incidents.Remove(inc);
            context.SaveChanges();
            return RedirectToAction("Index", "Incident");
        }
    }
}

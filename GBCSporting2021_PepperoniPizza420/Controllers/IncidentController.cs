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
            var filter = HttpContext.Request.Query["Filter"].ToString() ?? "all";
            ViewBag.Filter = filter;
            var incidents = context.Incidents.ToList();

            if (filter == "unassigned")
            {
                incidents = context.Incidents
                    .Where(i => i.Technician == null)
                    .Include(i => i.Customer)
                    .Include(i => i.Product)
                    .OrderBy(i => i.DateOpened)
                    .ToList();
            }
            else if (filter == "open")
            {
                incidents = context.Incidents
                    .Where(i => i.DateClosed == null)
                    .Include(i => i.Customer)
                    .Include(i => i.Product)
                    .OrderBy(i => i.DateOpened)
                    .ToList();
            }
            else 
            {
                incidents = context.Incidents
                    .Include(i => i.Customer)
                    .Include(i => i.Product)
                    .OrderBy(i => i.DateOpened)
                    .ToList();
            }

            var vm = new IncidentViewModel { Incidents = incidents};
            return View(vm.Incidents);
        }
        public IActionResult Details(int id)
        {
            var incident = context.Incidents
               .Include(i => i.Customer)
               .Include(i => i.Product)
               .Include(i => i.Technician)
               .FirstOrDefault(i => i.IncidentId == id);

            return View(incident);
        }
        [HttpGet]
        public IActionResult Add()
        {
            string action = "Add";
            List<Technician> technicians = context.Technicians.OrderBy(i => i.Name).ToList();
            List<Customer> customers = context.Customers.OrderBy(i => i.FirstName).ToList();
            List<Product> products = context.Products.OrderBy(i => i.Name).ToList();

            IncidentViewModel vm = new IncidentViewModel
            {
                Technicians = technicians,
                Customers = customers,
                Products = products,
                Action = action,
                CurrentIncident = new Incident()
            };
            return View("Edit", vm);
        }
        
        [HttpGet]
        public IActionResult Edit(int id)
        {
            string action = "Edit";
            List<Technician> technicians = context.Technicians.OrderBy(i => i.Name).ToList();
            List<Customer> customers = context.Customers.OrderBy(i => i.FirstName).ToList();
            List<Product> products = context.Products.OrderBy(i => i.Name).ToList();

            IncidentViewModel vm = new IncidentViewModel
            {
                Technicians = technicians,
                Customers = customers,
                Products = products,
                Action = action,
                CurrentIncident = new Incident()
            };
            return View("Edit", vm.Incidents);
        }

        [HttpPost]
        public IActionResult Edit(IncidentViewModel vm)
        {
            string action = vm.Action;
            if (ModelState.IsValid)
            {
                if (action == "Add")
                {

                    vm.CurrentIncident.DateOpened = DateTime.Now;
                    context.Incidents.Add(vm.CurrentIncident);
                }
                else
                {
                    context.Incidents.Update(vm.CurrentIncident);
                }
                context.SaveChanges();
                return RedirectToAction("Index", "Incident");

            }
            else
            {
                return View(vm);
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


        public IActionResult Update()
        {
            var technicians = context.Technicians
               .OrderBy(i => i.Name);
            var vm = new IncidentViewModel { Incidents = (List<Incident>)technicians };
            return View(vm.Technician.Name);
        }
    }
}

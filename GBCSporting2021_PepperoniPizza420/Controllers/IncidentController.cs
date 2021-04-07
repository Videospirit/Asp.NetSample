using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GBCSporting2021_PepperoniPizza420.DataAccessLayer.Interfaces;
using GBCSporting2021_PepperoniPizza420.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GBCSporting2021_PepperoniPizza420.Controllers
{
    public class IncidentController : Controller
    {
        private IUnitOfWork incidentUnit;
        public IncidentController(IUnitOfWork ctx)
        {
            this.incidentUnit = ctx;
        }
        public IActionResult Index()
        {
            var filter = HttpContext.Request.Query["Filter"].ToString() == "" ? "all" : HttpContext.Request.Query["Filter"].ToString();
            ViewBag.Filter = filter;

            var incidents = incidentUnit.IncidentRepository.GetAll(includeProperties: "Customer,Technician,Product")
                .OrderBy(i => i.DateOpened)
                .ToList();

            if (filter == "unassigned")
            {
                incidents = incidentUnit.IncidentRepository.GetAll(includeProperties: "Customer,Technician,Product")
                    .Where(i => i.Technician == null)
                    .OrderBy(i => i.DateOpened)
                    .ToList();
            }
            else if (filter == "open")
            {
                incidents = incidentUnit.IncidentRepository.GetAll(includeProperties: "Customer,Technician,Product")
                    .Where(i => i.DateClosed == null)
                    .OrderBy(i => i.DateOpened)
                    .ToList();
            }
            return View(incidents);
        }
        public IActionResult Details(int id)
        {
            var incident = incidentUnit.IncidentRepository.GetAll(includeProperties: "Customer,Product,Technician")
               
               
               .FirstOrDefault(i => i.IncidentId == id);

            return View(incident);
        }
        [HttpGet]
        public IActionResult Add()
            
        {
            ViewBag.Action = "Add";
            ViewBag.Customers = incidentUnit.CustomerRepository.GetAll().OrderBy(c => c.FirstName).ToList();

            ViewBag.Products = incidentUnit.ProductRepository.GetAll().OrderBy(i => i.Name).ToList();
            ViewBag.Technicians = incidentUnit.TechnicianRepository.GetAll().OrderBy(i => i.Name).ToList();
            return View("Edit", new Incident());
        }
        
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Customers = incidentUnit.CustomerRepository.GetAll().OrderBy(c => c.FirstName).ToList();
            ViewBag.Products = incidentUnit.ProductRepository.GetAll().OrderBy(p => p.Name).ToList();           

            ViewBag.Technicians = incidentUnit.TechnicianRepository.GetAll().OrderBy(t => t.Name).ToList();

            var incident = incidentUnit.IncidentRepository.GetAll()              
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
                    
                    incidentUnit.IncidentRepository.Add(inc);
                }
                else
                {
                    incidentUnit.IncidentRepository.Update(inc);
                }
                incidentUnit.IncidentRepository.Save();
                return RedirectToAction("Index", "Incident");

            }
            else
            {
                ViewBag.Action = action;
                ViewBag.Incidents = incidentUnit.IncidentRepository.GetAll(includeProperties: "Product,Customer,Technician").OrderBy(i => i.Title).ToList();
                return View(inc);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var incident = incidentUnit.IncidentRepository.GetAll(includeProperties: "Customer,Product")
              
              .FirstOrDefault(i => i.IncidentId == id);

            return View(incident);
        }
        [HttpPost]
        public IActionResult Delete(Incident inc)
        {
            incidentUnit.IncidentRepository.Remove(inc);
            incidentUnit.IncidentRepository.Save();
            return RedirectToAction("Index", "Incident");
        }
    }
}

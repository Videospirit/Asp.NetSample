using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GBCSporting2021_PepperoniPizza420.DataAccessLayer.Interfaces;
using GBCSporting2021_PepperoniPizza420.DataAccessLayer.Repositories;
using GBCSporting2021_PepperoniPizza420.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GBCSporting2021_PepperoniPizza420.Controllers
{
    public class IncidentController : Controller
    {
        private IUnitOfWork incidentUnit;

        public IncidentController(IUnitOfWork context)
        {
            this.incidentUnit = context;
        }
        
        public IActionResult Index()
        {
            var filter = HttpContext.Request.Query["Filter"].ToString() ?? "all";
            ViewBag.Filter = filter;
            var incidents = incidentUnit.IncidentRepository.GetAll().ToList();

            if (filter == "unassigned")
            {
                incidents = incidentUnit.IncidentRepository.GetAll(includeProperties: "Customer,Product")
                    .Where(i => i.Technician == null)
                    .OrderBy(i => i.DateOpened)
                    .ToList();
            }
            else if (filter == "open")
            {
                incidents = incidentUnit.IncidentRepository.GetAll(includeProperties: "Customer,Product")
                    .Where(i => i.DateClosed == null)
                    .OrderBy(i => i.DateOpened)
                    .ToList();
            }
            else
            {
                incidents = incidentUnit.IncidentRepository.GetAll(includeProperties: "Customer,Product")
                    .OrderBy(i => i.DateOpened)
                    .ToList();
            }

            var vm = new IncidentViewModel { Incidents = incidents};
            return View(vm.Incidents);
        }

        public IActionResult Details(int id)
        {
            var incident = incidentUnit.IncidentRepository.GetAll(includeProperties: "Customer,Product,Technician").FirstOrDefault(i => i.IncidentId == id);
            return View(incident);
        }

        [HttpGet]
        public IActionResult Add()
        {
            string action = "Add";
            List<Technician> technicians = incidentUnit.TechnicianRepository.GetAll().OrderBy(i => i.Name).ToList();
            List<Customer> customers = incidentUnit.CustomerRepository.GetAll().OrderBy(i => i.FirstName).ToList();
            List<Product> products = incidentUnit.ProductRepository.GetAll().OrderBy(i => i.Name).ToList();

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
            var incident = incidentUnit.IncidentRepository.GetAll(includeProperties: "Customer,Product,Technician").FirstOrDefault(i => i.IncidentId == id);

            List<Technician> technicians = incidentUnit.TechnicianRepository.GetAll().OrderBy(i => i.Name).ToList();
            List<Customer> customers = incidentUnit.CustomerRepository.GetAll().OrderBy(i => i.FirstName).ToList();
            List<Product> products = incidentUnit.ProductRepository.GetAll().OrderBy(i => i.Name).ToList();

            IncidentViewModel vm = new IncidentViewModel
            {   
                Technicians = technicians,
                Customers = customers,
                Products = products,
                Action = action,
                CurrentIncident = incident
            };
            return View(vm);
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
                    incidentUnit.IncidentRepository.Add(vm.CurrentIncident);
                }
                else
                {
                    incidentUnit.IncidentRepository.Update(vm.CurrentIncident); 
                }
                incidentUnit.IncidentRepository.Save(); // Wut
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
            var incident = incidentUnit.IncidentRepository.GetAll(includeProperties: "Customer,Product").FirstOrDefault(i => i.IncidentId == id);
            return View(incident);
        }
        [HttpPost]
        public IActionResult Delete(Incident inc)
        {
            incidentUnit.IncidentRepository.Remove(inc);
            incidentUnit.IncidentRepository.Save();
            return RedirectToAction("Index", "Incident");
        }

        [HttpGet]
        public IActionResult Update()
        {    

            List<Technician> technicians = incidentUnit.TechnicianRepository.GetAll().OrderBy(i => i.Name).ToList();
            var vm = new IncidentViewModel { Technicians = technicians};
            return View(vm.Technicians);
        }
        
        [HttpGet]
        public IActionResult TechnicianIncidents(int id)
        {
            ViewBag.Technician = incidentUnit.TechnicianRepository.GetById(id);
            var incidents = incidentUnit.IncidentRepository.GetAll(includeProperties: "Product,Customer,Technician").Where(i => i.TechnicianId == id && i.DateClosed == null).OrderBy(i => i.DateOpened);
            ViewBag.Records = incidents.ToList().Count();           
            return View(incidents);
        }

        [HttpGet]
        public IActionResult UpdateIncident(int id)
        {
            string action = "UpdateIncident";
            var incident = incidentUnit.IncidentRepository.GetAll(includeProperties: "Product,Customer,Technician")
                .FirstOrDefault(i => i.IncidentId == id);

            List<Technician> technicians = incidentUnit.TechnicianRepository.GetAll().OrderBy(i => i.Name).ToList();
            List<Customer> customers = incidentUnit.CustomerRepository.GetAll().OrderBy(i => i.FirstName).ToList();
            List<Product> products = incidentUnit.ProductRepository.GetAll().OrderBy(i => i.Name).ToList();

            IncidentViewModel vm = new IncidentViewModel
            {
                Technicians = technicians,
                Customers = customers,
                Products = products,
                CurrentIncident = incident,
                Action = action
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult UpdateIncident(IncidentViewModel vm)
        {
            if (ModelState.IsValid)
            {
                incidentUnit.IncidentRepository.Update(vm.CurrentIncident);
            }
            incidentUnit.IncidentRepository.Save();
            return RedirectToAction("TechnicianIncidents", new{ id = vm.CurrentIncident.TechnicianId });
        }

        public IActionResult Cancel(IncidentViewModel vm)
        {
            return RedirectToAction("TechnicianIncidents", new { id = vm.CurrentIncident.TechnicianId });
        }
    }
}

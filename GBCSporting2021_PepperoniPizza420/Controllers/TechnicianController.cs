using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GBCSporting2021_PepperoniPizza420.Models;
using Microsoft.AspNetCore.Mvc;

namespace GBCSporting2021_PepperoniPizza420.Controllers
{
    public class TechnicianController : Controller
    {
        private SportsProContext context { get; set; }
        public TechnicianController(SportsProContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var technicians = context.Technicians.ToList();
            return View(technicians);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Technician());
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var technician = context.Technicians.FirstOrDefault(t => t.TechnicianId == id);
            return View(technician);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var technician = context.Technicians.FirstOrDefault(t => t.TechnicianId == id);
            return View(technician);
        }

        [HttpPost]
        public IActionResult Edit(Technician technician)
        {
            string action = (technician.TechnicianId == 0) ? "Add" : "Edit";

            if (ModelState.IsValid)
            {
                if (action == "Add"){
                    context.Technicians.Add(technician);
                    context.SaveChanges();
                }
                else
                {
                    context.Technicians.Update(technician);
                    context.SaveChanges();
                }
                return RedirectToAction("Index", "Technician");
            }
            else
            {
                ViewBag.Action = action;
                return View(technician);
            }
        }

        [HttpPost]
        public IActionResult Delete(Technician technician)
        {
            context.Technicians.Remove(technician);
            context.SaveChanges();
            return RedirectToAction("Index", "Technician");
        }
    }
}

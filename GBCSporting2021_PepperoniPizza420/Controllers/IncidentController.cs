using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GBCSporting2021_PepperoniPizza420.Models;
using Microsoft.AspNetCore.Mvc;

namespace GBCSporting2021_PepperoniPizza420.Controllers
{
    public class IncidentsController : Controller
    {
        private SportsProContext context { get; set; }
        public IncidentsController(SportsProContext ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            var incidents = context.Incidents
                .OrderBy(i => i.DateOpened)
                .ToList();
            return View(incidents);
        }
        public IActionResult Add(Incident inc)
        {
            ViewBag.Action = "Add";
            ViewBag.Incidents = context.Incidents.OrderBy(i => i.DateOpened).ToList();
            return View("Edit", new Incident());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Incidents = context.Incidents.OrderBy(i => i.Title).ToList();
            var inc = context.Incidents.Find(id);
            return View(inc);
        }
        [HttpPost]
        public IActionResult Edit(Incident inc)
        {
            if (ModelState.IsValid)
            {
                if (inc.IncidentId == 0)
                    context.Incidents.Add(inc);
                else
                    context.Incidents.Update(inc);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");

            }
            else
            {
                ViewBag.Action = (inc.IncidentId == 0) ? "Add" : "Edit";
                ViewBag.Incidents = context.Incidents.OrderBy(i => i.Title).ToList();
                return View(inc);
            }
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var inc = context.Incidents.Find(id);
            return View(inc);
        }
        [HttpPost]
        public IActionResult Delete(Incident inc)
        {
            context.Incidents.Remove(inc);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}

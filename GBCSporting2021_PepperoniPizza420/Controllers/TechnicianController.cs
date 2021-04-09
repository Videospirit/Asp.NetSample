using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GBCSporting2021_PepperoniPizza420.DataAccessLayer.Interfaces;
using GBCSporting2021_PepperoniPizza420.Models;
using Microsoft.AspNetCore.Mvc;

namespace GBCSporting2021_PepperoniPizza420.Controllers
{
    public class TechnicianController : Controller
    {
        private ITechnicianRepository technicianRepository;

        private string message;
        public TechnicianController(ITechnicianRepository technicianRepository)
        {
            this.technicianRepository = technicianRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var technicians = technicianRepository.GetAll().ToList();
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
            var technician = technicianRepository.GetAll().FirstOrDefault(t => t.TechnicianId == id);
            return View(technician);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var technician = technicianRepository.GetAll().FirstOrDefault(t => t.TechnicianId == id);
            return View(technician);
        }

        [HttpPost]
        public IActionResult Edit(Technician technician)
        {
            string action = (technician.TechnicianId == 0) ? "Add" : "Edit";

            if (ModelState.IsValid)
            {
                if (action == "Add"){
                    technicianRepository.Add(technician);
                    technicianRepository.Save();
                    message = technician.Name + " has been succesfully added.";
                }
                else
                {
                    technicianRepository.Update(technician);
                    technicianRepository.Save();
                    message = technician.Name + " has been succesfully updated.";
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
            technicianRepository.Remove(technician);
            technicianRepository.Save();
            message = "Technician has been succesfully deleted";
            TempData["message"] = message;
            return RedirectToAction("Index", "Technician");
        }
    }
}

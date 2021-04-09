using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GBCSporting2021_PepperoniPizza420.DataAccessLayer;
using GBCSporting2021_PepperoniPizza420.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace GBCSporting2021_PepperoniPizza420.Controllers
{
    public class ProductController : Controller 
    {
        public IProductRepository productRepository;
        private string message;


        
        public ProductController(IProductRepository productRepo)
        {
            this.productRepository = productRepo;
        }
       
        public IActionResult Index()
        {
            var products = productRepository.GetAll();
            return View(products);
        }

        [HttpGet]
        public IActionResult Add(Product product)
        {
            ViewBag.Action = "Add";
            ViewBag.Product = productRepository.GetAll().OrderBy(p => p.Code).ToList();
            ViewBag.Product = productRepository.GetAll().OrderBy(p => p.Name).ToList();
            ViewBag.Product = productRepository.GetAll().OrderBy(p => p.Price).ToList();
            ViewBag.Product = productRepository.GetAll().OrderBy(p => p.ReleaseDate).ToList();
            productRepository.Add(product);
            return View("Edit", new Product());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Product = productRepository.GetAll().OrderBy(p => p.Code).ToList();
            ViewBag.Product = productRepository.GetAll().OrderBy(p => p.Name).ToList();
            ViewBag.Product = productRepository.GetAll().OrderBy(p => p.Price).ToList();
            ViewBag.Product = productRepository.GetAll().OrderBy(p => p.ReleaseDate).ToList();

            Product product = productRepository.GetById(id);
            return View(product);
        }

        [HttpPost]
        //fix this later
        public IActionResult Edit(Product product)
        {
            string action = (product.ProductId == 0) ? "Add" : "Edit";
            if (ModelState.IsValid)
            {
                if (action == "Add")
                {
                    
                    productRepository.Add(product);
                    productRepository.Save();
                    message = product.Code + " has been added.";
                }
                else
                {
                    productRepository.Update(product);
                    message = product.Code + " has been succesfully updated.";
                }
                productRepository.Save();
                TempData["message"] = message;
                return RedirectToAction("Index", "Product");
            }
            else
            {
                ViewBag.Action = action;
                ViewBag.Products = productRepository.GetAll().OrderBy(p => p.ReleaseDate).ToList();
                return View(product);
            }

        }

        [HttpGet]

        public IActionResult Delete(int id)
        {
            var product = productRepository
                  .GetById(id);
            return View(product);
        }

        [HttpPost]

        public IActionResult Delete(Product product)
        {
            productRepository.Remove(product);
            productRepository.Save();
            message = "Product has been succesfully delete.";
            TempData["message"] = message;
            return RedirectToAction("Index", "Product");
        }



    }
}

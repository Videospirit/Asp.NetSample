using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GBCSporting2021_PepperoniPizza420.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GBCSporting2021_PepperoniPizza420.Controllers
{
    public class ProductController : Controller
    {
        private SportsProContext context { get; set; }

        public ProductController(SportsProContext ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            var products = context.Products
                .OrderBy(p => p.ReleaseDate)
                .ToList();
            return View(products);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Product = context.Products.OrderBy(p => p.Code).ToList();
            ViewBag.Product = context.Products.OrderBy(p => p.Name).ToList();
            ViewBag.Product = context.Products.OrderBy(p => p.Price).ToList();
            ViewBag.Product = context.Products.OrderBy(p => p.ReleaseDate).ToList();
            return View("Edit", new Product());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Product = context.Products.OrderBy(p => p.Code).ToList();
            ViewBag.Product = context.Products.OrderBy(p => p.Name).ToList();
            ViewBag.Product = context.Products.OrderBy(p => p.Price).ToList();
            ViewBag.Product = context.Products.OrderBy(p => p.ReleaseDate).ToList();

            var product = context.Products
               .First(p => p.ProductId == id);
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
                    context.Products.Add(product);
                }
                else
                {
                    context.Products.Update(product);
                }
                context.SaveChanges();
                return RedirectToAction("Index", "Product");
            }
            else
            {
                ViewBag.Action = action;
                ViewBag.Products = context.Products.OrderBy(p => p.ReleaseDate).ToList();
                return View(product);
            }

        }

        [HttpGet]

        public IActionResult Delete(int id)
        {
            var product = context.Products
                  .FirstOrDefault((p => p.ProductId == id));
            return View(product);
        }

        [HttpPost]

        public IActionResult Delete(Product product)
        {
            context.Products.Remove(product);
            context.SaveChanges();
            return RedirectToAction("Index", "Product");
        }



    }
}

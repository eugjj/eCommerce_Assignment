using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommence_Assignment.Models;
using Microsoft.AspNetCore.Mvc;


namespace eCommence_Assignment.Controllers
{
    public class ProductGalleryController : Controller
    {
        private readonly DBContext db;

        public ProductGalleryController(DBContext db)
        {
            this.db = db;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            
            List<Products> test = db.Products.ToList();
            ViewData["data"] = test;

            return View();
        }

        // Detail Page
        public IActionResult ProductDetail(Guid id)
        {
            Products product = db.Products.FirstOrDefault(x => x.Id == id);

            ViewData["product"] = product;

            return View();
        }

        // Search bar
        [HttpPost]
        public IActionResult Search(string search)
        {
            if (search == null)
            {
                search = "";
            }

            List<Products> products = db.Products.Where(x => 
                x.Name.Contains(search) ||
                x.Description.Contains(search) || 
                x.Brand.Contains(search)).ToList();

            ViewData["search"] = search;
            ViewData["data"] = products;
            return View("Index");
        }

        public IActionResult AddtoCart(string productName)
        {
            
            
            return View();
        }
    }
}

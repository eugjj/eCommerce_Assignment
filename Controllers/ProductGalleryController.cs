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
            


            List<Products> testData = db.Products.ToList();
            ViewData["data"] = testData;

            return View();
        }
    }
}

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
            //db.Add(new Products
            //{
            //    Name = "Microsoft Office",
            //    Brand = "Microsoft",
            //    Price = 200,
            //    Description = "Everything you need!..",
            //    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5f/Microsoft_Office_logo_%282019%E2%80%93present%29.svg/1200px-Microsoft_Office_logo_%282019%E2%80%93present%29.svg.png"
            //});
            //db.Add(new Products
            //{
            //    Name = "Adobe",
            //    Brand = "Adobe",
            //    Price = 200,
            //    Description = "Pdf for you!",
            //    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5f/Microsoft_Office_logo_%282019%E2%80%93present%29.svg/1200px-Microsoft_Office_logo_%282019%E2%80%93present%29.svg.png"
            //});
            //db.Add(new Products
            //{
            //    Name = "SAP HR",
            //    Brand = "SAP",
            //    Price = 1000,
            //    Description = "Human Resource solutions",
            //    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5f/Microsoft_Office_logo_%282019%E2%80%93present%29.svg/1200px-Microsoft_Office_logo_%282019%E2%80%93present%29.svg.png"
            //});
            //db.Add(new Products
            //{
            //    Name = "Game",
            //    Brand = "Sony",
            //    Price = 200,
            //    Description = "Let's make it real",
            //    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5f/Microsoft_Office_logo_%282019%E2%80%93present%29.svg/1200px-Microsoft_Office_logo_%282019%E2%80%93present%29.svg.png"
            //});
            //db.Add(new Products
            //{
            //    Name = "Netflix",
            //    Brand = "Netflix",
            //    Price = 100,
            //    Description = "Entertainment for everyone",
            //    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5f/Microsoft_Office_logo_%282019%E2%80%93present%29.svg/1200px-Microsoft_Office_logo_%282019%E2%80%93present%29.svg.png"
            //});

            //db.SaveChanges();

            List<Products> testData = db.Products.ToList();
            ViewData["data"] = testData;

            return View();
        }

        public IActionResult ProductDetail(Guid id)
        {
            Products product = db.Products.FirstOrDefault(x => x.Id == id);

            ViewData["product"] = product;

            return View();
        }
    }
}

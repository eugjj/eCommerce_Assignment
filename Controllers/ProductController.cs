using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommence_Assignment.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eCommence_Assignment.Controllers
{
    public class ProductController : Controller
    {
        private readonly DBContext db;

        public ProductController(DBContext db)
        {
            this.db = db;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            db.Add(new Products
            {
                Name = "M_Office",
                Price = 200,
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5f/Microsoft_Office_logo_%282019%E2%80%93present%29.svg/1200px-Microsoft_Office_logo_%282019%E2%80%93present%29.svg.png",
                Description = "Office, Excel and Powerpoint",
                Brand = "Microsoft"
            }); 

            db.SaveChanges();

            List<Products> testData = db.Products.ToList();
            ViewData["data"] = testData;

            return View();
        }
    }
}

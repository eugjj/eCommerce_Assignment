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

        [HttpPost]
        public IActionResult AddtoCart(Guid id)
        {

            db.Add(new Cart
            {
                ProductId = id
            });
            db.SaveChanges();

            List<Cart> cart_items = db.Cart.ToList();

            int count;
            if (cart_items.Count > 0)
            {
                count = cart_items.Count;
            }
            else
                count = 0;

            ViewData["cart"] = count;
            ViewData["data"] = db.Products.ToList();
            return View("Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommence_Assignment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace eCommence_Assignment.Controllers
{
    public class ProductGalleryController : Controller
    {
        private readonly DBContext db;
        private readonly HttpContext context;
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
            Products p = db.Products.FirstOrDefault(x => x.Id == id);
            Cart productInCart = db.Cart.FirstOrDefault(x => x.ProductId == id);

            //if productId not in Cart then add new product (with qty 1), else update product qty
            if (productInCart == null)
            {
                db.Add(new Cart
                {
                    ProductId = id,
                    ProductPrice = p.Price,
                    ProductQty = 1,
                });
                db.SaveChanges();
            }
            else
            {
                productInCart.ProductQty++;
                db.SaveChanges();
            }

            //count check for the top right total product qty number
            List<Cart> cart_items = db.Cart.ToList();
            int count = 0;
            if (cart_items.Count > 0)
            {
                foreach (Cart item in cart_items)
                {
                    count += item.ProductQty;
                }
            }
            else
                count = 0;

            ViewData["cart"] = count;
            ViewData["data"] = db.Products.ToList();
            return View("Index");
        }
    }
}

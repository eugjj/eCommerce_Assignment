using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommence_Assignment.Models;
using Microsoft.AspNetCore.Mvc;

namespace eCommence_Assignment.Controllers
{
    public class ViewPurchaseController : Controller
    {
        private readonly DBContext db;

        public ViewPurchaseController(DBContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            string userName = Request.Cookies["Username"];
            if (userName == null)                
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                List<transactionID> showPurchase =
                    db.transactionIDs.Where(x => x.Users == userName).ToList();
                List<Products> products = new List<Products>();
                List<ProductKey> Pkeys = db.ProductKeys.ToList();
                foreach (transactionID TID in showPurchase)
                {
                    var productitem = db.Products.FirstOrDefault(x => x.Id == TID.ProductId);
                    products.Add(productitem);
                }
                ViewData["pkeys"] = Pkeys;
                ViewData["showPurchase"] = showPurchase;
                ViewData["productdetails"] = products;
            }
            return View();
        }
            
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommence_Assignment.Models;
using Microsoft.AspNetCore.Mvc;

//Possibly move to another class or controller during combination
namespace eCommence_Assignment.Controllers
{
    public class PurchasePageController : Controller
    {
        private readonly DBContext db;

        public PurchasePageController(DBContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            List<string> myList = new List<string>();
            myList.Add("MsWord");
            myList.Add("MsExcel");

            if (Request.Cookies["Username"] != null)
            {
                string user = Request.Cookies["Username"];
                GenerateKey(myList, user);
                db.SaveChanges();
                //should include housekeeping of the cart entity

                return RedirectToAction("Index", "ViewPurchase");
            }
            else
                return RedirectToAction("Index", "Login");
        }

        //when confirm purchase is executed
        public void GenerateKey(List<string> products, string user)
        {
            foreach (string product in products)
            {
                // generate a product key upon successful purchase
                string key = Guid.NewGuid().ToString();
                // generate ProductKey into our database with timestamp            
                db.ProductKeys.Add(new ProductKey
                {
                    PKey = key,
                    CreateTimestamp = DateTimeOffset.Now.ToUnixTimeSeconds(),
                    Users = user,
                    Products = product
                });
            }

            // ViewData["key"] = key;
            // ViewData["doP"] = time;

        }



    }
}
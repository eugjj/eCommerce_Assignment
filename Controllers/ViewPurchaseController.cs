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
                List<ProductKey> showPurchase =
                    db.ProductKeys.Where(x => x.Users == userName).ToList();
                
                ViewData["showPurchase"] = showPurchase;                
            }
            return View();
        }
            //Method can be called to convert unix time to string format for display in view
        public static string UnixToDateTime(long unixTimeStamp)
            {
                DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
                return dateTime.ToString();
            }


    }
}
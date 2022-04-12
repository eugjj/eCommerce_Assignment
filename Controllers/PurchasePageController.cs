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
        //when confirm purchase is executed
        public IActionResult GenerateKey()
        {
            // to be retrieved from codes in LoginController
            string user = placeholder;
            //to be retrieved from codes in AddToCartController
            string product = placeholder;
            // generate a random string upon successful purchase
            string key = Guid.NewGuid().ToString();

            // generate ProductKey into our database with timestamp, may use foreach loop depending on products added to cart
            
            dbContext.ProductKeys.Add(new ProductKey
            {
                PKey = key,
                CreateTimestamp = DateTimeOffset.Now.ToUnixTimeSeconds(),
                User = user
                Products = product
            });
            dbContext.SaveChanges();    

            ViewData["key"] = key;
            // ViewData["doP"] = time;
            return View();
        }
        //Method can be called to convert unix time to string format for display in view
        public static string UnixTimeStampToDateTime(long unixTimeStamp)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime.ToString();
        }
    }
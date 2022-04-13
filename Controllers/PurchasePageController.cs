using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommence_Assignment.Models;
using Microsoft.AspNetCore.Mvc;

//Possibly move to another class or controller during combination
namespace eCommence_Assignment.Controllers
{/*
    public class PurchasePageController : Controller
    {
        private readonly DBContext db;

        public PurchasePageController(DBContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            Session session = db.Sessions.FirstOrDefault(x => x.Id ==
              Request.Cookies["sessionId"]);

            //check for login status, redirect to login page if login not performed 
            if (session == null)
            {
                return RedirectToAction("Index", "Login");
            }

            else
            {
                GenerateKey(Products product);
                //should include housekeeping of the cart entity
            }

                //when confirm purchase is executed
                public static void GenerateKey(Products product)
        {
            string user = session.user;
                foreach (Products product in cart)
                {
                    string pName = product.name;
                    // generate a random string upon successful purchase
                    string key = Guid.NewGuid().ToString();
                    // generate ProductKey into our database with timestamp            
                    dbContext.ProductKeys.Add(new ProductKey
                    {
                        PKey = key,
                        CreateTimestamp = DateTimeOffset.Now.ToUnixTimeSeconds(),
                        User = user
                        Products = pName
                    });
                }
            dbContext.SaveChanges();    

            // ViewData["key"] = key;
            // ViewData["doP"] = time;
            
        }
            return RedirectToAction("Index", "ViewPurchase");
            //Method can be called to convert unix time to string format for display in view
            
    */
}
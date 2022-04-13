using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommence_Assignment.Models;
using Microsoft.AspNetCore.Mvc;

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

            if (session == null)
            {
                return RedirectToAction("Index", "Login");
            }

            else
            {
                List<ProductKey> showPurchase = 
                    dbContext.ProductKeys.Where(x => x.user = session.user).ToList();
                ViewData["key"] = showPurchase.key;
                ViewData["DateOfPurchase"] = UnixToDateTime(showPurchase.CreateTimeStamp);
                ViewData["product"] = showPurchase.product;
            }

            public static string UnixToDateTime(long unixTimeStamp)
            {
                DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
                return dateTime.ToString();
            */}
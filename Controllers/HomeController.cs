using ecommerce_Assignment.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce_Assignment.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment env;
        private readonly DBContext dbContext;

       

        public HomeController (IWebHostEnvironment env, DBContext dbContext)
        {
            this.env=env;
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            Session session = ValidateSession();
            if (session == null)
            {
                // no session; bring user to Login page
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return RedirectToAction("Index", "ProductGallery");
            }            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        

        private Session ValidateSession()
        {
            // check if there is a SessionId cookie
            if (Request.Cookies["SessionId"] == null)
            {
                return null;
            }

            // convert into a Guid type (from a string type)
            Guid sessionId = Guid.Parse(Request.Cookies["SessionId"]);
            Session session = dbContext.Sessions.FirstOrDefault(x =>
                x.Id == sessionId
            );

            return session;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}

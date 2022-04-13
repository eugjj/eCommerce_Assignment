using eCommence_Assignment.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommence_Assignment.Controllers
{
    public class LogoutController : Controller
    {
        private readonly DBContext dbContext;

        public LogoutController(DBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
           
            if (Request.Cookies["SessionId"] != null)
            {
                Guid sessionId = Guid.Parse(Request.Cookies["sessionId"]);

                Session session = dbContext.Sessions.FirstOrDefault(x => x.Id == sessionId);
                if (session != null)
                {
                    
                    dbContext.Remove(session);

                    
                    dbContext.SaveChanges();
                }
            }

            
            Response.Cookies.Delete("SessionId");
            Response.Cookies.Delete("Username");

            return RedirectToAction("Index", "Login");
        }
    }
}

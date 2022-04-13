using eCommence_Assignment.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommence_Assignment.Middleware
{
    public class CreateGuest
    {
        private readonly RequestDelegate next;
        private DBContext dbContext;
        public CreateGuest(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task Invoke(HttpContext context, [FromServices] DBContext dbContext)
        {
            string sessionId = context.Request.Cookies["sessionId"];
            string newGuestId = context.Request.Cookies["guestId"];

            if (sessionId == null && newGuestId == null)
            {
               
                User guest = new User { Id = Guid.NewGuid() };
                dbContext.Add(guest);
                dbContext.SaveChanges();

                string guestId = guest.Id.ToString();
                context.Response.Cookies.Append("guestId", guestId);
            }
            await next(context);
        }
    }
}

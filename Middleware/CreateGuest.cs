﻿using eCommence_Assignment.Models;
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
        public CreateGuest(RequestDelegate next)
        {
            this.next = next;
            
        }
        public async Task Invoke(HttpContext context, [FromServices] DBContext db)
        {
            string sessionId = context.Request.Cookies["SessionId"];
            string newGuestId = context.Request.Cookies["guestId"];

            if (sessionId == null && newGuestId == null)
            {
                var guest = new User()
                {
                    Id = Guid.NewGuid(),
                    Username = "Guest",
                };
                db.Add(guest);
                db.SaveChanges();

                string guestId = guest.Id.ToString();
                context.Response.Cookies.Append("guestId", guestId);
                context.Response.Cookies.Append("Username", guest.Username);
            }
            await next(context);
        }
    }
}

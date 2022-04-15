using eCommence_Assignment.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace eCommence_Assignment.Controllers
{

    public class CartController : Controller
    {
        private readonly DBContext dbContext;

        public CartController(DBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /*            Session SessionId = dbContext.Sessions.FirstOrDefault(x => x.Id == Request.Cookies["sessionId"]);
                    User guestUser = dbContext.Users.FirstOrDefault(x => x.Id == Request.Cookies["guestId"]);*//*
                    string sessionId = context.Request.Cookies["sessionId"];
                    string newGuestId = context.Request.Cookies["guestId"];
                    Cart existingCart = null;
                    if ((sessionId != null || newGuestId != null) && !(sessionId != null && newGuestId != null))
                    {
                        //logged in user
                        if (sessionId != null)
                        {
                            existingCart = dbContext.Cart.FirstOrDefault(x => (x.UserId == dbContext.Session.UserId));
                            ViewData["username"] = dbContext.Session.User.Username;  //Pass the username 
                        }
                        //guest user
                        else
                        {
                            existingCart = dbContext.Cart.FirstOrDefault(x => (x.UserId == newGuestId));

                        }

                        //cart exists
                        if (existingCart != null)
                        {
                            List<CartDetail> cartDetails = dbContext.CartDetail.Where(x => x.CartId == existingCart.UserId).ToList();
                            ViewData["cart"] = cartDetails;
                        }

                    }
                    return View();
                }*/
        public IActionResult Index()
        {

            //List<Cart> CartItem = dbContext.Cart.ToList();
            List<Cart> a = dbContext.Cart.ToList();
            

            //List<Cart> CartDetails = (List<Cart>)dbContext.Products.Where(x =>
            //x.Id == a.Id);



            ViewData["cartdetail"] = a;
            //ViewData["cart"] = CartItem;

            return View();
        }
    }
}
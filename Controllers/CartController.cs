using eCommence_Assignment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace eCommence_Assignment.Controllers
{
{
    public class CartController : Controller
    {
        private readonly Database db;

        public CartController(Database db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            Session session = db.Sessions.FirstOrDefault(x => x.Id == Request.Cookies["sessionId"]);
            User guestUser = db.Users.FirstOrDefault(x => x.Id == Request.Cookies["guestId"]);
            Cart existingCart = null;
            if ((session != null || guestUser != null) && !(session != null && guestUser != null))
            {
                //logged in user
                if (session != null)
                {
                    existingCart = db.Carts.FirstOrDefault(x => (x.UserId == session.UserId));
                    ViewData["username"] = session.User.Username;  //Pass the username 
                }
                //guest user
                else
                {
                    existingCart = db.Carts.FirstOrDefault(x => (x.UserId == guestUser.Id));

                }

                //cart exists
                if (existingCart != null)
                {
                    List<CartDetail> cartDetails = db.CartDetails.Where(x => x.CartId == existingCart.Id).ToList();
                    ViewData["cart"] = cartDetails;
                }

            }
            return View();
        }

        [HttpPost]
        public IActionResult UpdateQuantityInCart([FromBody] UpdateQuantityInput input)
        {
            Session session = db.Sessions.FirstOrDefault(x => x.Id == Request.Cookies["sessionId"]);
            User guestUser = db.Users.FirstOrDefault(x => x.Id == Request.Cookies["guestId"]);
            Cart existingCart = null;
            if ((session != null || guestUser != null) && !(session != null && guestUser != null))
            {
                //logged in user
                if (session != null)
                {
                    existingCart = db.Carts.FirstOrDefault(x => (x.UserId == session.UserId));
                }
                //guest user
                else
                {
                    existingCart = db.Carts.FirstOrDefault(x => (x.UserId == guestUser.Id));

                }
            }
            List<CartDetail> existingCartDetails = existingCart.CartDetails.ToList();
            CartDetail cartDetailWithThisProduct = existingCartDetails.Find(x => x.ProductId == int.Parse(input.ProductId));

            if (input.Plus)
            {
                cartDetailWithThisProduct.Quantity = cartDetailWithThisProduct.Quantity + 1;
                db.SaveChanges();
            }
            else
            {
                if (cartDetailWithThisProduct.Quantity > 1)
                {
                    cartDetailWithThisProduct.Quantity = cartDetailWithThisProduct.Quantity - 1;
                    db.SaveChanges();
                }
            }

            double TotalPrice = 0.00;
            foreach (CartDetail cd in existingCartDetails)
            {
                TotalPrice = TotalPrice + cd.Quantity * cd.Products.Price;
            }

            string pdtprice = $"${(cartDetailWithThisProduct.Products.Price*cartDetailWithThisProduct.Quantity):#,0.00}";
            string totalprice = $"${TotalPrice:#,0.00}";

            return Json(new { status = "success", productId = input.ProductId, price = pdtprice, quantity = cartDetailWithThisProduct.Quantity, totalprice = totalprice});
        }


        public IActionResult Remove(string productId)
        {
            Session session = db.Sessions.FirstOrDefault(x => x.Id == Request.Cookies["sessionId"]);
            User guestUser = db.Users.FirstOrDefault(x => x.Id == Request.Cookies["guestId"]);
            Cart existingCart = null;

            if ((session != null || guestUser != null) && !(session != null && guestUser != null))
            {
                //logged in user
                if (session != null)
                {
                    existingCart = db.Carts.FirstOrDefault(x => (x.UserId == session.UserId));
                }
                //guest user
                else
                {
                    existingCart = db.Carts.FirstOrDefault(x => (x.UserId == guestUser.Id));

                }
            }

            //retrieve all existing cart items 
            List<CartDetail> existingCartDetails = existingCart.CartDetails.ToList();

            //locate cart item to be removed and remove it
            CartDetail cartDetailWithThisProduct = existingCartDetails.Find(x => x.ProductId == int.Parse(productId));
            db.Remove(cartDetailWithThisProduct);
            db.SaveChanges();

            //check that if cart has no more item, remove cart
            if (existingCart.CartDetails.ToList().Count() == 0)
            {
                db.Remove(existingCart);
                db.SaveChanges();
            }

            return RedirectToAction("Index");

        }
    }
}

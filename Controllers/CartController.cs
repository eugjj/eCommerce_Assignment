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

        public IActionResult Index()
        {

            //List<Cart> CartItem = dbContext.Cart.ToList();
            List<Cart> allitemsInCart = dbContext.Cart.ToList();
            List<Products> products = new List<Products>();
            List<int> qty = new List<int>();

            foreach (Cart cartitem in allitemsInCart)
            {
                var productitem = dbContext.Products.FirstOrDefault(x => x.Id == cartitem.ProductId);

                //group up same products together & qty are added
                if (products.Contains(productitem) == false)
                {
                    products.Add(productitem);
                    qty.Add(cartitem.ProductQty);
                }
                else
                {
                    int lastQty = qty.Last();
                    lastQty += cartitem.ProductQty;
                }
            }

            //List<Cart> CartDetails = (List<Cart>)dbContext.Products.Where(x =>
            //x.Id == a.Id);

            ViewData["cartQty"] = qty;
            ViewData["data"] = products;
            ViewData["cartdetail"] = allitemsInCart;

            return View();
        }

        [HttpPost]
        public IActionResult Remove(Guid removeItem)
        {
            Cart currentCart = dbContext.Cart.FirstOrDefault(x =>
            x.ProductId == removeItem);
            dbContext.Cart.Remove(currentCart);
            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
      
        public IActionResult increaseCartQty(Guid ProductId)
        {
            Cart currentCart = dbContext.Cart.FirstOrDefault(x => x.ProductId ==
            ProductId);
            if (currentCart.ProductQty > 0)
            {
                currentCart.ProductQty++;
            }
            dbContext.SaveChanges();
            return View("Index");
        }
        public IActionResult decreaseCartQty(Guid ProductId)
        {
            Cart currentCart = dbContext.Cart.FirstOrDefault(x => x.ProductId ==
            ProductId);
            if (currentCart.ProductQty > 1)
            {
                currentCart.ProductQty--;
            }
            dbContext.SaveChanges();
            return View("Index");
        }
        public IActionResult ConfirmPurchase()
        {
            List<Cart> allitemsInCart = dbContext.Cart.ToList();
            string user = Request.Cookies["Username"];
            if (user != null)
            {
                GenerateTID(allitemsInCart, user);
                EmptyCart();                        
                return RedirectToAction("Index", "ViewPurchase");
            }
            else
                return RedirectToAction("Index", "Login");
        }

        public IActionResult EmptyCartBtn()
        {
            EmptyCart();
            return RedirectToAction("Index", "ProductGallery");
        }

            public void EmptyCart()
        {
            List<Cart> allitemsInCart = dbContext.Cart.ToList();
            foreach (Cart items in allitemsInCart)
            {
                dbContext.Remove(items);
            }

            dbContext.SaveChanges();
        }

        //when confirm purchase is executed
        public void GenerateTID(List<Cart> itemsincart, string user)
        {
            foreach (Cart item in itemsincart)
            {
                transactionID TID = (new transactionID
                {
                    CreateTimestamp = DateTimeOffset.Now.ToUnixTimeSeconds(),
                    Users = user,
                    ProductId = item.ProductId,
                    qty = item.ProductQty

                });
                // generate a transactionID upon successful purchase     
                dbContext.transactionIDs.Add(TID);

                for (int qty = item.ProductQty; qty > 0; qty--)
                {
                    dbContext.ProductKeys.Add(new ProductKey
                    {
                        PKey = Guid.NewGuid().ToString(),
                        transactionIDs = TID.Id
                    });                    
                }
            }
            dbContext.SaveChanges();
        }        
    }
}
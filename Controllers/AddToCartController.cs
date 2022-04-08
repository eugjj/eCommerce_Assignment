using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommence_Assignment.Controllers
{
    public class AddToCartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

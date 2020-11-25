using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AshrafsSweetShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace AshrafsSweetShop.Controllers
{
    public class CartController : Controller
    {

        private ShopContext _context;

        public CartController(ShopContext shopContext)
        {
            _context = shopContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add(int id)
        {
            var products = _context.Products.Find(id);
            ViewBag.Name = products.Name;
            return View();
        }
    }
}

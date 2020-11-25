using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AshrafsSweetShop.Models;
using Microsoft.EntityFrameworkCore;

namespace AshrafsSweetShop.Controllers
{
    public class ProductController : Controller
    {
        private ShopContext _context;

        public ProductController(ShopContext shopContext)
        {
            _context = shopContext;
        }

        public IActionResult Index()
        {
            return RedirectToAction("List", "Products");
        }
        public IActionResult Detail(int id)
        {
            var product = _context.Products.Include(p => p.Category).FirstOrDefault(c => c.ProductID == id);
            ViewBag.Image = product.Code + "-m.jpg";
            return View(product);
        }

        [Route("[controller]s/{id?}")]
        public IActionResult List(string id = "All")
        {
            var categories = _context.Categories.OrderBy(c => c.Name).ToList();
            ViewBag.Categories = categories;
            List<Product> products;

            if (id == "All")
                products = _context.Products.OrderBy(p => p.Name).ToList();
            else
                products = _context.Products.Where(p => p.Category.Name == id).OrderBy(p => p.Name).ToList();
            return View(products);
        }
    }
}

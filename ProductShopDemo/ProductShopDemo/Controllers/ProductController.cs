using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductShopDemo.Models;

namespace ProductShopDemo.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Details(string slug)
        {
            Product product = Database.GetProduct(slug);
            return View(product);
        }

        public IActionResult List()
        {
            List<Product> products = Database.GetAllProducts();
            return View(products);
        }
    }
}

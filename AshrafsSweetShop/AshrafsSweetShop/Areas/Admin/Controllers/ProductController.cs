using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AshrafsSweetShop.Models;
using AshrafsSweetShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AshrafsSweetShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private ShopContext _context;
        private List<Category> categories;

        public ProductController(ShopContext shopContext)
        {
            _context = shopContext;
            categories = _context.Categories.OrderBy(c => c.CategoryId).ToList();
        }
        public IActionResult Index()
        {
            return RedirectToAction("List", "Product");
        }

        [Route("[area]/[controller]s/{id?}")]
        public IActionResult List(string id = "All")
        {
            List<Product> products;

            if (id == "All")
                products = _context.Products.OrderBy(p => p.Name).ToList();
            else
                products = _context.Products.Where(p => p.Category.Name == id).OrderBy(p => p.Name).ToList();

            var model = new ProductListViewModel
            {
                Categories = categories,
                Products = products,
                SelectedCategory = id
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var product = new Product();
            product.Category = _context.Categories.Find(1);

            var model = new ProductAddUpdateViewModel
            {
                Product = product,
                Categories = categories,
                Action = "Add"
            };

            return View("AddUpdate", model);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var product = _context.Products.Include(p => p.Category).First(p => p.ProductID == id);

            var model = new ProductAddUpdateViewModel
            {
                Product = product,
                Categories = categories,
                Action = "Update"
            };

            return View("AddUpdate", model);
        }

        [HttpPost]
        public IActionResult Save(Product product)
        {
            if (ModelState.IsValid)
            {
                var userMessage = ""; 
                if (product.ProductID == 0)
                {
                    _context.Products.Add(product);
                    userMessage = "Successfully Added " + product.Name;
                }
                else
                {
                    _context.Products.Update(product);
                    userMessage = "Successfully Updated " + product.Name;
                }
                _context.SaveChanges();
                TempData["userMessage"] = userMessage;
                return RedirectToAction("List", "Product");
            }
            else
            {
                var model = new ProductAddUpdateViewModel
                {
                    Product = product,
                    Categories = categories,
                    Action = "Save"
                };
                return View("AddUpdate", model);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Delete(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("List", "Product");
        }
    }
}

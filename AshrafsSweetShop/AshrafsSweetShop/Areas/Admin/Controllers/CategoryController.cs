using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AshrafsSweetShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace AshrafsSweetShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private ShopContext _context;

        public CategoryController(ShopContext shopContext)
        {
            _context = shopContext;
        }
        public IActionResult Index()
        {
            return RedirectToAction("List", "Category");
        }

        [Route("[area]/Categories/{id?}")]
        public IActionResult List()
        {
            var categories = _context.Categories.OrderBy(c => c.CategoryId).ToList();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("AddUpdate", new Category());
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewBag.Action = "Update";
            var category = _context.Categories.Find(id);
            return View("AddUpdate", category);
        }

        [HttpPost]
        public IActionResult Save(Category category)
        {
            if (ModelState.IsValid)
            {
                if (category.CategoryId == 0)
                {
                    _context.Categories.Add(category);
                }
                else
                {
                    _context.Categories.Update(category);
                }
                _context.SaveChanges();
                return RedirectToAction("List", "Category");
            }
            else
            {
                ViewBag.Action = "Save";
                return View("AddUpdate", category);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var category = _context.Categories.Find(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Delete(Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction("List", "Category");
        }
    }
}

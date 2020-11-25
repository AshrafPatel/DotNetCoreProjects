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
            var categories = _context.Categories.OrderBy(c => c.Name).ToList();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("AddUpdate", new Category());
        }
    }
}

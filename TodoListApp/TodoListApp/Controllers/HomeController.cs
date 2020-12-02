using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TodoListApp.Models;
using TodoListApp.ViewModels;
using Task = TodoListApp.Models.Task;

namespace TodoListApp.Controllers
{
    public class HomeController : Controller
    {
        private TodoContext _context;
        public HomeController(TodoContext todoContext) => _context = todoContext;

        public IActionResult Index(string id)
        {
            var model = new TodoViewModel();
            model.Filters = new Filters(id);
            model.Categories = _context.Categories.ToList();
            model.Statuses = _context.Statuses.ToList();
            model.DueDateFilters = Filters.DueDateFilterValues;

            IQueryable<Task> query = _context.Tasks.Include(c => c.Category).Include(s => s.Status);

            if (model.Filters.HasCategoryFilter)
                query = query.Where(t => t.CategoryId == model.Filters.CategoryId);

            if (model.Filters.HasStatusFilter)
                query = query.Where(t => t.StatusId == model.Filters.StatusId);

            if (model.Filters.HasDueDateFilter)
            {
                var today = DateTime.Today;

                if (model.Filters.IsPast)
                    query = query.Where(t => t.DueDate < today);
                else if (model.Filters.IsFuture)
                    query = query.Where(t => t.DueDate > today);
                else if (model.Filters.IsToday)
                    query = query.Where(t => t.DueDate == today);
            }

            var tasks = query.OrderBy(t => t.DueDate).ToList();

            model.Tasks = tasks;

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new TodoViewModel();
            model.Categories = _context.Categories.ToList();
            model.Statuses = _context.Statuses.ToList();

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(TodoViewModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Tasks.Add(model.CurrentTask);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                model.Categories = _context.Categories.ToList();
                model.Statuses = _context.Statuses.ToList();
                return View(model);
            }
        }

        [HttpPost]
        public IActionResult EditDelete([FromRoute] string id, Task selectedTask)
        {
            if (selectedTask.StatusId == null)
                _context.Tasks.Remove(selectedTask);
            else
            {
                string newStatusId = selectedTask.StatusId;
                selectedTask = _context.Tasks.Find(selectedTask.Id);
                selectedTask.StatusId = newStatusId;
                _context.Tasks.Update(selectedTask);
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Home", new { ID = id });
        }

        [HttpPost]
        public IActionResult Filter(string[] filters)
        {
            string id = string.Join('-', filters);
            return RedirectToAction("Index", "Home", new { ID = id });
        }
    }
}

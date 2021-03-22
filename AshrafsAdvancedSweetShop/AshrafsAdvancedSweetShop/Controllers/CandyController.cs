using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AshrafsAdvancedSweetShop.Models;
using AshrafsAdvancedSweetShop.Models.Repos;
using AshrafsAdvancedSweetShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AshrafsAdvancedSweetShop.Controllers
{
    public class CandyController : Controller
    {
        private readonly ICandyRepository _candyRepository;
        private readonly ICategoryRepository _categoryRepository;

        public CandyController(ICandyRepository candyRepo, ICategoryRepository categoryRepo)
        {
            _candyRepository = candyRepo;
            _categoryRepository = categoryRepo;
        }

        /*public IActionResult List()
        {
            //ViewBag.CurrentlyCategory = "Bestsellers";
            //return View(_candyRepository.GetAllCandy);

            var candyListyViewModel = new CandyListViewModel();
            candyListyViewModel.Candies = _candyRepository.GetAllCandy;
            candyListyViewModel.CurrentCategory = "BestSellers";
            return View(candyListyViewModel);
        }*/

        public ViewResult List(string category)
        {
            IEnumerable<Candy> candies;
            string currentCategory;

            if (string.IsNullOrEmpty(category))
            {
                candies = _candyRepository.GetAllCandy.OrderBy(c => c.CandyId);
                currentCategory = "All Candy";
            }
            else
            {
                candies = _candyRepository.GetAllCandy.Where(c => c.Category.CategoryName == category);
                currentCategory = _categoryRepository.GetAllCategories.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }
            return View(new CandyListViewModel
            {
                Candies = candies,
                CurrentCategory = category
            });
        }

        public IActionResult Details(int id)
        {
            var candy = _candyRepository.GetCandyById(id);
            if (candy == null)
                return NotFound();
            return View(candy);
        }
    }
}

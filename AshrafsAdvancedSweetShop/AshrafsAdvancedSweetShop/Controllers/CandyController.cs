using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public IActionResult List()
        {
            var candyListyViewModel = new CandyListViewModel();
            candyListyViewModel.Candies = _candyRepository.GetAllCandy;
            candyListyViewModel.CurrentCategory = "BestSellers";
            return View(candyListyViewModel);
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

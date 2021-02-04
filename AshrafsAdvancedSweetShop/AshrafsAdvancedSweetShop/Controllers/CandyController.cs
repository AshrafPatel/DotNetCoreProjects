using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AshrafsAdvancedSweetShop.Models.Repos;
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

        public ViewResult List()
        {
            return View(_candyRepository.GetAllCandy);
        }
    }
}

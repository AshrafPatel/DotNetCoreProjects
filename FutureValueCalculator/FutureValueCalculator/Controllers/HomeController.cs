using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FutureValueCalculator.Models;
using Microsoft.AspNetCore.Mvc;

namespace FutureValueCalculator.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.FutureValue = "";
            return View();
        }


        [HttpPost]
        public IActionResult Index(FutureValue fv)
        {
            if (ModelState.IsValid)
            {
                ViewBag.FutureValue = fv.CalculateValue();
            } else
            {
                ViewBag.FutureValue = "";
            }
            return View();
        }
    }
}

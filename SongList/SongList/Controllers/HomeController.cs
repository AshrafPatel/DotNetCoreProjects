using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SongList.Models;

namespace SongList.Controllers
{
    public class HomeController : Controller
    {
        private SongContext _context { get; set; }

        public HomeController(SongContext songContext)
        {
            _context = songContext;
        }
        public IActionResult Index()
        {
            var songs = _context.Songs.Include(m => m.Genre).ToList();
            return View(songs);
        }

        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

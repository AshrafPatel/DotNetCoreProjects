using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SongList.Models;

namespace SongList.Controllers
{
    public class SongController : Controller
    {
        private SongContext _context { get; set; }
        public SongController(SongContext songContext)
        {
            _context = songContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Genre = _context.Genres.OrderBy(g => g.Name).ToList();
            return View("Edit", new Song());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Genre = _context.Genres.OrderBy(g => g.Name).ToList();
            var song = _context.Songs.Find(id);
            return View(song);
        }

        [HttpPost]
        public IActionResult Save(Song song)
        {
            if (ModelState.IsValid)
            {
                if (song.SongId == 0)
                    _context.Songs.Add(song);
                else
                    _context.Songs.Update(song);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            } else
            {
                ViewBag.Genre = _context.Genres.OrderBy(g => g.Name).ToList();
                ViewBag.Action = song.SongId == 0 ? "Add" : "Edit";
                return View("Edit");
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var song = _context.Songs.Find(id);
            return View(song);
        }

        [HttpPost]
        public IActionResult Delete(Song song)
        {
            _context.Songs.Remove(song);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}

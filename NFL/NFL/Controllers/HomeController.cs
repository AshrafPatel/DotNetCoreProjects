using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NFL.Models;
using NFL.ViewModel;

namespace NFL.Controllers
{
    public class HomeController : Controller
    {
        private TeamContext _context;
        public HomeController(TeamContext teamContext)
        {
            _context = teamContext;
        }
        public IActionResult Index(string activeConf, string activeDiv)
        {
            var model = new TeamListViewModel
            {
                ActiveConf = (activeConf==null) ? "all" : activeConf,
                ActiveDiv = (activeDiv==null) ? "all" : activeDiv,
                Conferences = _context.Conferences.ToList(),
                Divisions = _context.Divisions.ToList()
            };

            IQueryable<Team> query = _context.Teams;

            if (model.ActiveConf != "all")
                query = query.Where(t => t.Conference.ConferenceId.ToLower() == activeConf.ToLower());

            if (model.ActiveDiv != "all")
                query = query.Where(t => t.Division.DivisionId.ToLower() == activeDiv.ToLower());

            model.Teams = query.ToList();

            return View(model);
        }
    }
}

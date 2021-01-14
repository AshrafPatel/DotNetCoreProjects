using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var session = new NFLSession(HttpContext.Session);
            session.SetActiveConf(activeConf);
            session.SetActiveDiv(activeDiv);

            int? count = session.GetMyTeamCount();

            if (count == null)
            {
                var cookies = new NFLCookies(Request.Cookies);
                string[] ids = cookies.GetMyTeamsIds();

                List<Team> myTeams = new List<Team>();
                if (ids.Length > 0)
                {
                    myTeams = _context.Teams.Include(c => c.Conference).Include(d => d.Division).Where(t => ids.Contains(t.TeamId)).ToList();
                }

                session.SetMyTeams(myTeams);
            }

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

        public IActionResult Details(string id)
        {
            var session = new NFLSession(HttpContext.Session);
            var model = new TeamViewModel
            {
                Team = _context.Teams.Include(d => d.Division).Include(c => c.Conference).FirstOrDefault(t => t.TeamId == id),
                ActiveConf = session.GetActiveConf(),
                ActiveDiv = session.GetActiveDiv()
            };

            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Add(TeamViewModel model)
        {
            model.Team = _context.Teams.Include(c => c.Conference).Include(d => d.Division).FirstOrDefault(t => t.TeamId == model.Team.TeamId);
            var session = new NFLSession(HttpContext.Session);
            var teams = session.GetMyTeams();
            teams.Add(model.Team);
            session.SetMyTeams(teams);

            var cookies = new NFLCookies(Response.Cookies);
            cookies.SetMyTeamIds(teams);

            TempData["message"] = $"{model.Team.Name} wass added to your favourites";

            return RedirectToAction("Index", "Home", new { ActiveConf = session.GetActiveConf(), ActiveDiv = session.GetActiveDiv() });
        }
    }
}

using NFL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFL.ViewModel
{
    public class TeamListViewModel : TeamViewModel
    {
        public List<Team> Teams { get; set; }
        private List<Conference> _conferences { get; set; }
        private List<Division> _divisions { get; set; }

        public List<Conference> Conferences
        {
            get => _conferences;
            set
            {
                _conferences = value;
                _conferences.Insert(0, new Conference { ConferenceId = "all", Name = "All" });
            }
        }

        public List<Division> Divisions 
        {
            get => _divisions; 
            set
            {
                _divisions = value;
                _divisions.Insert(0, new Division { DivisionId = "all", Name = "All" });
            }
        }

        public string isActiveConf(string c) =>
            c.ToLower() == ActiveConf.ToLower() ? "active" : "";

        public string isActiveDiv(string c) =>
            c.ToLower() == ActiveDiv.ToLower() ? "active" : "";
    }
}

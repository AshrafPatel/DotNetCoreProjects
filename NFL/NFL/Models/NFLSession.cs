using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFL.Models
{
    public class NFLSession
    {
        private const string TeamKey = "myteams";
        private const string CountKey = "teamcount";
        private const string ConfKey = "conf";
        private const string DivKey = "div";

        public ISession Session { get; set; }

        public NFLSession(ISession session)
        {
            Session = session;
        }

        public void SetMyTeams(List<Team> teams)
        {
            Session.SetObjects(TeamKey, teams);
            Session.SetInt32(CountKey, teams.Count);
        }

        public List<Team> GetMyTeams() => Session.GetObject <List<Team>>(TeamKey) ?? new List<Team>();
        public int? GetMyTeamCount() => Session.GetInt32(CountKey);

        public void SetActiveConf(string conf) => Session.SetString(ConfKey, conf);
        public string GetActiveConf() => Session.GetString(ConfKey);

        public void SetActiveDiv(string div) => Session.SetString(DivKey, div);
        public string GetActiveDiv() => Session.GetString(DivKey);

        public void RemoveTeam()
        {
            Session.Remove(TeamKey);
            Session.Remove(CountKey);
        }
    }
}

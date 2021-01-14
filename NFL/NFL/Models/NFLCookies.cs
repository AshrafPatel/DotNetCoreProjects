using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFL.Models
{
    public class NFLCookies
    {
        private const string TeamsKey = "myteams";
        private const string Delimiter = "-";
        private IRequestCookieCollection requestCookie { get; set; }
        private IResponseCookies responseCookie { get; set; }

        public NFLCookies(IRequestCookieCollection cookie)
        {
            requestCookie = cookie;
        }

        public NFLCookies(IResponseCookies cookie)
        {
            responseCookie = cookie;
        }

        public void SetMyTeamIds(List<Team> myTeams)
        {
            List<string> ids = myTeams.Select(t => t.TeamId).ToList();
            string idsString = String.Join(Delimiter, ids);
            CookieOptions options = new CookieOptions { Expires = DateTime.Now.AddDays(30) };
            RemoveMyTeamsIds();
            responseCookie.Append(TeamsKey, idsString, options);
        }

        public string[] GetMyTeamsIds()
        {
            string cookie = requestCookie[TeamsKey];
            string[] responseStrArr = string.IsNullOrEmpty(cookie) ? new string[] { } : cookie.Split(Delimiter);
            return responseStrArr;
        }

        public void RemoveMyTeamsIds()
        {
            responseCookie.Delete(TeamsKey);
        }
    }
}

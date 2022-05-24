using FootballTicketOfficeAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballTicketOfficeAPI.Models
{
    public class MatchResponse
    {
        public int Id { get; set; }
        public int FirstTeamId { get; set; }
        public int SecondTeamId { get; set; }
        public System.DateTime Date { get; set; }
        public Team FirstTeam { get; set; }
        public Team SecondTeam { get; set; }
    }
}
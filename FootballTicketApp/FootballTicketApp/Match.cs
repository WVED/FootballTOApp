using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTicketApp
{
    class Match
    {
        public int Id { get; set; }
        public int FirstTeamId { get; set; }
        public int SecondTeamId { get; set; }
        public System.DateTime Date { get; set; }
        public Team Team { get; set; }
        public Team Team1 { get; set; }
    }
}

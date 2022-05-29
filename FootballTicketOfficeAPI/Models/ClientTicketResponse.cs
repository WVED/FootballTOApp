using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballTicketOfficeAPI.Models
{
    public class ClientTicketResponse
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int Sector { get; set; }
        public int Row { get; set; }
        public int Site { get; set; }
        public System.DateTime PurchaseDate { get; set; }
        public int MatchId { get; set; }
        public bool Status { get; set; }
        public MatchResponse match { get; set; }
    }
}
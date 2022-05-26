﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTicketApp
{
    public class Ticket
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int Sector { get; set; }
        public int Row { get; set; }
        public decimal Price { get; set; }
        public int Site { get; set; }
        public System.DateTime PurchaseDate { get; set; }
        public int MatchId { get; set; }
        public bool Status { get; set; }
    }
}

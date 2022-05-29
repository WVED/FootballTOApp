using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTicketApp.Models
{
    public class EditClient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}

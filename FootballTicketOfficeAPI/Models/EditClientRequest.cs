using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballTicketOfficeAPI.Models
{
    public class EditClientRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
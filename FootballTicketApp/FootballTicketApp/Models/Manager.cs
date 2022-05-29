using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FootballTicketApp.Models
{
    public class Manager
    {
        public static Client loginedClient { get; set; }
        public static Boolean isValidPassword(string password)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimum8Chars = new Regex(@".{8,}");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");
            if (password == null)
                return false;
            if (!hasNumber.IsMatch(password))
                return false;
            if (!hasUpperChar.IsMatch(password))
                return false;
            if (!hasMinimum8Chars.IsMatch(password)) 
                return false;
            if (!hasSymbols.IsMatch(password))
                return false;
            return true;
        }
    }
}

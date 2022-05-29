using FootballTicketApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FootballTicketTest
{
    [TestClass]
    public class UnitTestPasswordValidation
    {
        [TestMethod]
        public void TestPasswordValidationPositive()
        {
            string password = "P@ssw0rd_#";
            Assert.AreEqual(true, Manager.isValidPassword(password));
        }

        [TestMethod]
        public void TestPasswordValidationNegative()
        {
            string password = "password";
            Assert.AreEqual(false, Manager.isValidPassword(password));
        }
    }
}

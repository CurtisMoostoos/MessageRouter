using MessageRouter.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace MessageRouter.Domain.Tests.Models
{
    [TestClass]
    public class EmailTests
    {
        [DataTestMethod]
        [DataRow("from@test", "to@test", true)]
        public void IsValid_Test(string from, string to, bool expected)
        {
            //I much prefer using xunit or nunit, but this is illustrative of how I like to write tests.


            //Arrange
            var email = new Email();
            email.From = from;
            email.To = to;


            //Act
            var isValid = email.IsValid;

            //Assert
            Assert.AreEqual(isValid, expected);
        }
    }
}

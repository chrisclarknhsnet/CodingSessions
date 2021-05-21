using LINQExamples;
using LINQExamples.POCOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TestProject1
{
    [TestClass]
    public class RepositoryTests
    {
        private IRepository _repository;
        private IList<UserTakeup> _data;

        [TestInitialize]
        public void TestInitialize()
        {
            _data = new List<UserTakeup>();
            _repository = new Repository(_data);
        }

        [TestMethod]
        public void Get_WhenRegistered_When_Have_User_Returns_Correct_Date()
        {
            // Arrange
            var email = "mr.nobody@somewhere.com";
            var registeredDate = DateTime.Today.AddDays(-3);

            _data.Add(new UserTakeup()
            {
                EmailAddress = email,
                FirstRegistered = registeredDate
            });

            // Act
            var result = _repository.Get_WhenRegistered(email);

            // Assert
            Assert.AreEqual(registeredDate, result);
        }

        [TestMethod]
        public void Get_WhenRegistered_When_No_Match_Returns_Null()
        {
            // Arrange
            var email = "mr.nobody@somewhere.com";
            var registeredDate = DateTime.Today.AddDays(-3);

            _data.Add(new UserTakeup()
            {
                EmailAddress = email + "X",
                FirstRegistered = registeredDate
            });

            // Act
            var result = _repository.Get_WhenRegistered(email);
            
            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void Get_WhenRegistered_When_Have_Duplicate_Emails_Throws_Exception()
        {
            // Arrange
            var email = "mr.nobody@somewhere.com";
            var registeredDate = DateTime.Today.AddDays(-3);

            _data.Add(new UserTakeup()
            {
                EmailAddress = email,
                FirstRegistered = registeredDate
            });
            
            _data.Add(new UserTakeup()
            {
                EmailAddress = email,
                FirstRegistered = DateTime.Today.AddDays(-100)
            });

            // Act
            var result = _repository.Get_WhenRegistered(email);

            // Assert
            Assert.Fail("Expected exception to be thrown");
        }
    }
}

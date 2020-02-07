using System;
using System.Collections.Generic;
using CRUDContacts.API.Controllers;
using CRUDContacts.Core;
using CRUDContacts.Interfaces;
using CRUDContacts.Models;
using CRUDContacts.Tests.Mocks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CRUDContacts.Tests
{
    [TestClass]
    public class ContactTest
    {
        [TestMethod]
        public void Contact_IsAgeCorrect()
        {
            Contact contact = new Contact();

            contact.DateOfBirth = DateTime.Today.AddDays(-1).AddYears(-20);
            Assert.AreEqual(20, contact.Age);

            contact.DateOfBirth = DateTime.Today.AddYears(-20);
            Assert.AreEqual(20, contact.Age);

            contact.DateOfBirth = DateTime.Today.AddDays(+1).AddYears(-20);
            Assert.AreEqual(19, contact.Age);
        }
    }
}

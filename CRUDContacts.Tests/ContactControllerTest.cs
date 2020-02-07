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
    public class ContactControllerTest
    {
        private readonly ServiceProvider serviceProvider;

        public ContactControllerTest()
        {
            var services = new ServiceCollection();
            services.AddScoped<IContactRepository, ContactRepositoryMock>();
            services.AddScoped<IContactCore, ContactCore>();

            serviceProvider = services.BuildServiceProvider();
        }

        private ContactController GetController()
        {
            return new ContactController(serviceProvider.GetService<IContactCore>());
        }

        #region Get All
        [TestMethod]
        public void Get_IsResponseOK()
        {
            ContactController controller = GetController();
            IActionResult result = controller.Get();
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void Get_ReturnsAllItems()
        {
            ContactController controller = GetController();
            OkObjectResult result = controller.Get() as OkObjectResult;
            ICollection<Contact> items = result.Value as ICollection<Contact>;

            Assert.AreEqual(3, items.Count);
        }
        #endregion

        #region Get by Id
        [TestMethod]
        public void GetById_UnknownId_IsResponseNotFound()
        {
            ContactController controller = GetController();
            IActionResult result = controller.Get(99);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void GetById_KnownId_IsResponseOk()
        {
            ContactController controller = GetController();
            IActionResult result = controller.Get(1);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void GetById_KnownId_IsCorrectItem()
        {
            ContactController controller = GetController();
            OkObjectResult result = controller.Get(1) as OkObjectResult;
            Contact contact = result.Value as Contact;

            Assert.AreEqual(1, contact.Id);
            Assert.AreEqual("João", contact.Name);
            Assert.AreEqual(Gender.Male, contact.Gender);
            Assert.AreEqual(new DateTime(1980, 01, 01), contact.DateOfBirth);
        }

        #endregion

        #region Create
        [TestMethod]
        public void Create_InvalidItem_IsResponseBadRequest()
        {
            ContactController controller = GetController();
            IActionResult result = controller.Create(null);
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        [TestMethod]
        public void Create_ValidItem_IsResponseCreated()
        {
            ContactController controller = GetController();
            Contact newContact = new Contact
            {
                Name = "Gabriel",
                DateOfBirth = new DateTime(1998, 11, 23),
                Gender = Gender.Male
            };

            IActionResult result = controller.Create(newContact);
            Assert.IsInstanceOfType(result, typeof(CreatedAtRouteResult));
        }

        [TestMethod]
        public void Create_ValidItem_IsItemPersisted()
        {
            ContactController controller = GetController();
            Contact newContact = new Contact
            {
                Name = "Gabriel",
                DateOfBirth = new DateTime(1998, 11, 23),
                Gender = Gender.Male
            };

            CreatedAtRouteResult result = controller.Create(newContact) as CreatedAtRouteResult;
            Contact createdContact = result.Value as Contact;

            Assert.AreEqual(newContact.Name, createdContact.Name);
            Assert.AreEqual(newContact.DateOfBirth, createdContact.DateOfBirth);
            Assert.AreEqual(newContact.Gender, createdContact.Gender);
        }
        #endregion

        #region Edit
        [TestMethod]
        public void Edit_InvalidItem_IsResponseBadRequest()
        {
            ContactController controller = GetController();
            IActionResult result = controller.Edit(0, null);
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        [TestMethod]
        public void Edit_ValidItem_IsResponseNoContent()
        {
            ContactController controller = GetController();
            OkObjectResult getResult = controller.Get(1) as OkObjectResult;
            Contact contact = getResult.Value as Contact;

            IActionResult result = controller.Edit(contact.Id, contact);
            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }

        [TestMethod]
        public void Edit_ValidItem_IsItemEdited()
        {
            ContactController controller = GetController();
            OkObjectResult getResult = controller.Get(1) as OkObjectResult;
            Contact contact = getResult.Value as Contact;
            contact.Name = "Arnaldo";

            controller.Edit(contact.Id, contact);

            OkObjectResult getEditedResult = controller.Get(1) as OkObjectResult;
            Contact editedContact = getResult.Value as Contact;
            Assert.AreEqual(contact.Name, editedContact.Name);
        }
        #endregion

        #region Delete
        [TestMethod]
        public void Delete_InvalidItem_IsResponseNotFound()
        {
            ContactController controller = GetController();
            IActionResult result = controller.Delete(99);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void Delete_ValidItem_IsResponseNoContent()
        {
            ContactController controller = GetController();
            IActionResult result = controller.Delete(3);
            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }

        [TestMethod]
        public void Delete_ValidItem_IsItemDeleted()
        {
            ContactController controller = GetController();
            controller.Delete(3);
            IActionResult result = controller.Get(3);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
        #endregion
    }
}

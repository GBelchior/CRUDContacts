using System;
using System.Collections.Generic;
using CRUDContacts.Interfaces;
using CRUDContacts.Models;

namespace CRUDContacts.Tests.Mocks
{
    public class ContactRepositoryMock : RepositoryMock<Contact>, IContactRepository
    {
        public ContactRepositoryMock()
        {
            Add(new Contact
            {
                Name = "João",
                Gender = Gender.Male,
                DateOfBirth = new DateTime(1980, 01, 01)
            });

            Add(new Contact
            {
                Name = "Maria",
                Gender = Gender.Female,
                DateOfBirth = new DateTime(1976, 08, 28)
            });

            Add(new Contact
            {
                Name = "Abstract",
                Gender = Gender.Other,
                DateOfBirth = new DateTime(2003, 07, 14)
            });
        }
    }
}
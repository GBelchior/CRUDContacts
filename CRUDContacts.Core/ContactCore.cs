using CRUDContacts.Interfaces;
using CRUDContacts.Models;

namespace CRUDContacts.Core
{
    public class ContactCore : CoreBase<Contact>, IContactCore
    {
        public ContactCore(IRepositoryBase<Contact> repository) : base(repository) { }
    }
}
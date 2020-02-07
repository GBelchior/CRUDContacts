using CRUDContacts.Interfaces;
using CRUDContacts.Models;

namespace CRUDContacts.Core
{
    public class ContactCore : CoreBase<Contact>, IContactCore
    {
        public ContactCore(IContactRepository repository) : base(repository) { }
    }
}
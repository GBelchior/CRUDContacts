using CRUDContacts.Interfaces;
using CRUDContacts.Models;

namespace CRUDContacts.Data
{
    public class ContactRepository : RepositoryBase<Contact>, IContactRepository
    {
        public ContactRepository(CRUDContactsContext ctx) : base(ctx) { }
    }
}
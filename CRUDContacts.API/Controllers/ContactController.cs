using CRUDContacts.Core;
using CRUDContacts.Interfaces;
using CRUDContacts.Models;

namespace CRUDContacts.API.Controllers
{
    public class ContactController : CRUDContactsControllerBase<Contact>
    {
        public ContactController(IContactCore core) : base(core) { }
    }
}
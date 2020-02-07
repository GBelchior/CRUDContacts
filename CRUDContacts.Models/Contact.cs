using System;

namespace CRUDContacts.Models
{
    public class Contact : ModelBase
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
    }
}

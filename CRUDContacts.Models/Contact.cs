using System;

namespace CRUDContacts.Models
{
    public class Contact : ModelBase
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public int Age
        {
            get
            {
                DateTime today = DateTime.Today;
                int years = today.Year - DateOfBirth.Year;
                if (DateOfBirth.Date.AddYears(years) > today)
                {
                    years--;
                }

                return years;
            }
        }
    }
}

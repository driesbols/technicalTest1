using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalTest.Domain;

namespace TechnicalTest.Data.DTO
{
    public class AddContactDataDTO
    {
        public string CustomerId { get; set; }
        private ContactData _contactData;
        public ContactData ContactData {
            get => _contactData ??= new ContactData(); 
            set => _contactData = value ?? new ContactData(); 
        }
    }
}

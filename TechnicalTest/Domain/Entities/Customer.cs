using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnicalTest.Domain
{
    public class Customer
    {
        public string id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        private Address _address;
        public Address Address { 
            get => _address ??= new Address(); 
            set => _address = value ?? new Address(); 
        }
        private List<ContactData> _contactData;
        public List<ContactData> ContactData { 
            get => _contactData ??= new List<ContactData>(); 
            set => _contactData = value ?? new List<ContactData>(); 
        }
    }
}

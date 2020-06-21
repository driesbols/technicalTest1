using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnicalTest.Domain
{
    public class ContactData
    {
        private string _type;
        public string Type
        {
            get => _type;
            set => _type = value.ToUpperInvariant();
        }
        public string Value { get; set; }
    }
}

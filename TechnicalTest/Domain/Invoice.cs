using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace TechnicalTest.Domain
{
    public class Invoice
    {
        public string id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        private Customer _customer;
        public Customer Customer { 
            get => _customer ??= new Customer(); 
            set => _customer = value ?? new Customer(); 
        }
        public decimal TotalAmount { get; set; }
        private List<string> _invoiceLines;
        public List<string> InvoiceLines { 
            get => _invoiceLines??= new List<string>(); 
            set => _invoiceLines = value ?? new List<string>(); 
        }
        public int AmountOfUnits { get; set; }
        public decimal PricePerUnit { get; set; }
        public decimal TotalPrice => AmountOfUnits * PricePerUnit;
        public string Status { get; set; }
    }
}

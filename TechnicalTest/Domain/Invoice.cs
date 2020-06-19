using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnicalTest.Domain
{
    public class Invoice
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public Customer Customer { get; set; }
        public decimal TotalAmount { get; set; }
        public List<string> InvoiceLines { get; set; }
        public int AmountOfUnits { get; set; }
        public decimal PricePerUnit { get; set; }
        public decimal TotalPrice => AmountOfUnits * PricePerUnit;
    }
}

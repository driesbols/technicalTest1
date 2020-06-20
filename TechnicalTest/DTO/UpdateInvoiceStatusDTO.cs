using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnicalTest.Data.DTO
{
    public class UpdateInvoiceStatusDTO
    {
        public string InvoiceId { get; set; }
        public string Status { get; set; }
    }
}

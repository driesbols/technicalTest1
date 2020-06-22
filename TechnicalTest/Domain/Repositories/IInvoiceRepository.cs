using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalTest.Data.DTO;
using TechnicalTest.Domain;

namespace TechnicalTest.Data.Repositories
{
    public interface IInvoiceRepository
    {
        Task CreateInvoice(Invoice invoice);
        Task UpdateInvoiceStatus(UpdateInvoiceStatusDTO invoiceStatusDto); 
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalTest.Data.DTO;
using TechnicalTest.Domain;

namespace TechnicalTest.Data.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly InvoiceMapper _mapper;
        public InvoiceRepository()
        {
            _mapper = new InvoiceMapper();
        }

        public async Task CreateInvoice(Invoice invoice)
        {
            invoice.id = Guid.NewGuid().ToString();
            await _mapper.CreateInvoice(invoice);
        }

        public async Task UpdateInvoiceStatus(UpdateInvoiceStatusDTO invoiceStatusDTO)
        {
            await _mapper.UpdateInvoiceStatus(invoiceStatusDTO);
        }
    }
}

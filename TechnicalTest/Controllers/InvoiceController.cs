using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalTest.Data.DTO;
using TechnicalTest.Data.Repositories;
using TechnicalTest.Domain;

namespace TechnicalTest.Controllers
{
    [ApiController, Route("[controller]")]
    public class InvoiceController
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceController(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        [HttpPost, Route("CreateInvoice")]
        public async Task<IActionResult> CreateInvoice(Invoice invoice)
        {
            await _invoiceRepository.CreateInvoice(invoice);

            return new ObjectResult($"Invoice succesfully created with id '{invoice.id}'");
        }

        [HttpPost, Route("UpdateInvoiceStatus")]
        public async Task<IActionResult> UpdateInvoiceStatus(UpdateInvoiceStatusDTO invoiceStatusDTO)
        {
            try
            {
                await _invoiceRepository.UpdateInvoiceStatus(invoiceStatusDTO);
            }catch (KeyNotFoundException)
            {
                return new BadRequestResult();
            }
            
            return new ObjectResult($"Invoice status succesfully updated  to status '{invoiceStatusDTO.Status}' with invoice id '{invoiceStatusDTO.InvoiceId}'");
        }
    }
}
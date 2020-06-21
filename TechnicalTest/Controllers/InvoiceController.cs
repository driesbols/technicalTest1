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
        private readonly ContactDataValidator contactDataValidator;


        public InvoiceController(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
            contactDataValidator = new ContactDataValidator();
        }

        [HttpPost, Route("CreateInvoice")]
        public async Task<IActionResult> CreateInvoice(Invoice invoice)
        {
            foreach (ContactData contactData in invoice.Customer.ContactData)
            {
                if (!contactDataValidator.Validate(contactData))
                    return new BadRequestObjectResult($"Contact data with type '{contactData.Type}' and value '{contactData.Value}' is invalid");
            }

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
                return new BadRequestObjectResult($"Invoice with id '{invoiceStatusDTO.InvoiceId}' not found");
            }
            
            return new ObjectResult($"Invoice status succesfully updated  to status '{invoiceStatusDTO.Status}' with invoice id '{invoiceStatusDTO.InvoiceId}'");
        }
    }
}
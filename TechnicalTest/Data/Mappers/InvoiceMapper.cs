using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TechnicalTest.Data.DTO;
using TechnicalTest.Domain;

namespace TechnicalTest.Data
{
    public class InvoiceMapper : BaseMapper
    {
        private readonly string _partitionKey;
        public InvoiceMapper() : this("Invoices", "id") { }

        private InvoiceMapper(string containerId, string partitionKey) : base(containerId, "/" + partitionKey)
        {
            _partitionKey = partitionKey;
        }

        public async Task CreateInvoice(Invoice invoice)
        {
            await Container.CreateItemAsync(invoice, new PartitionKey(invoice.id));
        }

        public async Task UpdateInvoiceStatus(UpdateInvoiceStatusDTO invoiceStatusDto)
        {
            try
            {
                ItemResponse<Invoice> invoiceResponse = await Container.ReadItemAsync<Invoice>(invoiceStatusDto.InvoiceId, new PartitionKey(invoiceStatusDto.InvoiceId));

                Invoice itemBody = invoiceResponse.Resource;
                itemBody.Status = invoiceStatusDto.Status;

                invoiceResponse = await Container.ReplaceItemAsync(itemBody, itemBody.id, new PartitionKey(itemBody.id));
            }
            catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                throw new KeyNotFoundException();
            }
        }
    }
}

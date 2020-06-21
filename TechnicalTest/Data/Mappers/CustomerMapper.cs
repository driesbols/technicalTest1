using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TechnicalTest.Data.DTO;
using TechnicalTest.Domain;

namespace TechnicalTest.Data
{
    public class CustomerMapper : BaseMapper
    {
        public CustomerMapper() : base("Customers", "/id") 
        {

        }

        public async Task CreateCustomer(Customer customer)
        {
            await Container.CreateItemAsync(customer, new PartitionKey(customer.id));
        }

        public async Task AddContactDataToCustomer(AddContactDataDTO addContactDataDto)
        {
            Customer customerInDb = await GetCustomer(addContactDataDto.CustomerId);
            customerInDb.ContactData.Add(addContactDataDto.ContactData);

            await Container.ReplaceItemAsync(customerInDb, customerInDb.id, new PartitionKey(customerInDb.id));
        }

        private async Task<Customer> GetCustomer(string customerId)
        {
            try
            {
                ItemResponse<Customer> customerResponse = await Container.ReadItemAsync<Customer>(customerId, new PartitionKey(customerId));
                return customerResponse.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                throw new KeyNotFoundException();
            }
        }
    }
}

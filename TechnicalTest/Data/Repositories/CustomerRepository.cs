using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalTest.Data.DTO;
using TechnicalTest.Domain;

namespace TechnicalTest.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerMapper _mapper;
        public CustomerRepository()
        {
            _mapper = new CustomerMapper();
        }

        public async Task AddContactData(AddContactDataDTO addContactDataDTO)
        {
            await _mapper.AddContactDataToCustomer(addContactDataDTO);
        }

        public async Task CreateCustomer(Customer customer)
        {
            customer.id = Guid.NewGuid().ToString();
            await _mapper.CreateCustomer(customer);
        }
    }
}

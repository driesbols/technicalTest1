using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalTest.Data.DTO;
using TechnicalTest.Domain;

namespace TechnicalTest.Data.Repositories
{
    public interface ICustomerRepository
    {
        Task CreateCustomer(Customer customer);
        Task AddContactData(AddContactDataDTO addContactDataDTO);
    }
}

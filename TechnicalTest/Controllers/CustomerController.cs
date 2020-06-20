using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TechnicalTest.Data.DTO;
using TechnicalTest.Data.Repositories;
using TechnicalTest.Domain;

namespace TechnicalTest.Controllers
{
    [ApiController, Route("[controller]")]
    public class CustomerController
    {
        private readonly ICustomerRepository _repository;
        public CustomerController(ICustomerRepository repository)
        {
            _repository = repository;
        }
        
        [HttpPost, Route("CreateCustomer")]
        public async Task<IActionResult> CreateCustomer(Customer customer)
        {
            foreach(ContactData contactData in customer.ContactData)
            {
                if (!ValidateContactData(contactData))
                    return new BadRequestObjectResult($"Contact data with type '{contactData.Type}' and value '{contactData.Value}' is invalid");
            }

            await _repository.CreateCustomer(customer);

            return new ObjectResult($"Customer succesfully created with id '{customer.id}'");
        }

        [HttpPost, Route("AddContactData")]
        public async Task<IActionResult> AddContactData(AddContactDataDTO contactDataDTO)
        {
            if (!ValidateContactData(contactDataDTO.ContactData))
                return new BadRequestResult();
            try
            {
                await _repository.AddContactData(contactDataDTO);
            }
            catch (KeyNotFoundException)
            {
                return new BadRequestObjectResult($"Customer with id '{contactDataDTO.CustomerId}' not found");
            }
            

            return new ObjectResult($"Contact data succesfully added to customer with id '{contactDataDTO.CustomerId}'");
        }

        private bool ValidateContactData(ContactData contactData)
        {
            if (contactData == null)
                return false;

            bool isEnum = Enum.TryParse(contactData.Type.ToUpperInvariant(), out ContactDataTypes type);

            if (!isEnum)
                return isEnum;

            switch (type)
            {
                case ContactDataTypes.EMAIL:
                    try
                    {
                        MailAddress m = new MailAddress(contactData.Value);
                        return true;
                    }
                    catch (FormatException)
                    {
                        return false;
                    }
                case ContactDataTypes.GSM:
                    return true;
            }

            return false;
        }
    }
}

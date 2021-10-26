using mini.Data.Repositories;
using mini.DTO.Requests;
using mini.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mini.Services.Business
{
    public class CustomerService : ICustomerService
    {
        //SRP: Her class kendi işini yapsın!
        private ICustomerRepository customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public async Task<Guid> AddCustomer(AddCustomerRequest request)
        {
            Customer customer = new Customer
            {
                BirthDate = request.BirthDate,
                Email = request.Email,
                FirstName = request.FirstName,
                Gender = request.Gender,
                LastName  = request.LastName,
                Password = request.Password,
                UserName= request.UserName,
                Role = request.Role               

            };
            var result = await customerRepository.AddEntity(customer);
            return result.Id;

        }

        public async Task<Customer> ValidateCustomer(string userName, string password)
        {
            var customer = await customerRepository.ValidateUser(userName, password);
            return customer;
        }
    }
}

using mini.DTO.Requests;
using mini.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mini.Services.Business
{
   public interface ICustomerService
    {
        Task<Customer> ValidateCustomer(string userName, string password);
        Task<Guid> AddCustomer(AddCustomerRequest request);
    }
}

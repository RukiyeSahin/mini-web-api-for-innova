﻿using mini.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mini.Data.Repositories
{
   public interface ICustomerRepository : IProductRepository<Customer>
    {
        Task<Customer> ValidateUser(string userName, string password);
    }
}

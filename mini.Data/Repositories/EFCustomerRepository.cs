using Microsoft.EntityFrameworkCore;
using mini.Data.Data;
using mini.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace mini.Data.Repositories
{
    public class EFCustomerRepository : ICustomerRepository
    {
        private miniDbContext miniDbContext;

        public EFCustomerRepository(miniDbContext miniDbContext)
        {
            this.miniDbContext = miniDbContext;
        }
        public async Task<Customer> AddEntity(Customer entity)
        {
            
            await miniDbContext.Customers.AddAsync(entity);
            var result = await miniDbContext.SaveChangesAsync();
            return entity;

        }

        public Task<int> Delete(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Task<IAsyncEnumerable<Customer>> GetEntities()
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetEntity<X>(X id)
        {
            throw new NotImplementedException();
        }

        public Task<IAsyncEnumerable<Customer>> GetWihCriteria(Expression<Func<Customer, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsItemExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> Update(Customer entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Customer> ValidateUser(string userName, string password)
        {
            var user = await miniDbContext.Customers.FirstOrDefaultAsync(cust => cust.UserName == userName && cust.Password == password);
            return user;

        }
    }
}

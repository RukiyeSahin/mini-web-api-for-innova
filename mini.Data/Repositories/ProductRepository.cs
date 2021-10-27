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
    public class ProductRepository : IProductRepository
    {

        private readonly miniDbContext miniDbContext;
        public ProductRepository(miniDbContext miniDbContext)
        {
            this.miniDbContext = miniDbContext;
        }
        public Task<Product> AddEntity(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task<IAsyncEnumerable<Product>> GetEntities()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetEntity<X>(X id)
        {
            throw new NotImplementedException();
        }

        public Task<IAsyncEnumerable<Product>> GetWihCriteria(Expression<Func<Product, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsItemExists(int id)
        {
            return await miniDbContext.Products.AnyAsync(x => x.Id == id);
        }

        public Task<Product> SearchProductByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> Update(Product entity)
        {
            miniDbContext.Products.Update(entity);
            await miniDbContext.SaveChangesAsync();
            return entity;
        }
    }
}

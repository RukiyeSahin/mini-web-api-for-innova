using mini.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mini.Data.Repositories
{
    public interface IProductRepository:IProductRepository<Product>
    {
        Task<Product> SearchProductByName(string name);
    }
}

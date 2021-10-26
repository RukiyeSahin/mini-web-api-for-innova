using mini.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace mini.Data.Repositories
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        Task<IAsyncEnumerable<T>> GetEntities();
        Task<IAsyncEnumerable<T>> GetWihCriteria(Expression<Func<T, bool>> predicate);
        Task<T> GetEntity<X>(X id);

        Task<T> AddEntity(T entity);
        Task<T> Update(T entity);

        Task<int> Delete(T entity);






    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public interface IRepository<T> : IDisposable where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task UpdateAsync(T entity, T newEntity);
        Task DeleteAllAsync();
        Task<T> CreateAsync(T entity);
        Task<T> Query(Expression<Func<T, bool>> expression);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceWebAPI.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task<T> InsertAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<List<T>> UpdateRangeAsync(List<T> entities);
        Task DeleteAsync(int id);
        Task DeleteManyAsync(Expression<Func<T, bool>> predicate);
        Task SaveChangesAsync();

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Domain.Repositories
{
    public interface IGenericRepository<T>
    {
        Task<T> GetByAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<bool> UpdateAsync(T entity);
        Task<bool> CreateAsync(T entity);
        Task<bool> DeleteAsync(int id);
    }
}

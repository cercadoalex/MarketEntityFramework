using Market.Persistance;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Market.Domain.Repositories.Products
{
    public interface IProductRepository
    {
        Task<Product> GetByAsync(int id);
        Task<IReadOnlyList<Product>> GetAllAsync();
        Task<bool> UpdateAsync(Product entity);
        Task<bool> CreateAsync(Product entity);
        Task<bool> DeleteAsync(int id);
    }
}

using Market.Domain.Repositories.Products;
using Market.Persistance;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Market.Infrastructure.Service
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;
        public ProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IReadOnlyList<Product>> GetAllAsync()
        {
            return await _productRepository.GetAllAsync();
        }

    }
}

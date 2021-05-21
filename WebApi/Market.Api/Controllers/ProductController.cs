using Market.Domain.Repositories.Products;
using Market.Infrastructure.Service;
using Market.Persistance;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Market.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;
        private readonly IProductRepository _productRepository;
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProducto(int id)
        {
            var products = await _productService.GetAllAsync();
            if (products == null)
            {
                return NotFound("El producto no existe");
            }
            return Ok(products);

        }

    }
}

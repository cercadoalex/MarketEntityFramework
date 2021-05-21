using Market.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Market.Domain.Repositories.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly DB_MARKETContext _context;
        public ProductRepository(DB_MARKETContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(Product entity)
        {
            bool flag = false;
            using (var trans = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Add(entity);
                    await _context.SaveChangesAsync();
                    trans.Commit();
                    flag = true;
                }
                catch (Exception ex)
                {
                    flag = false;
                }
            }
            return flag;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            bool flag = false;
            using (var trans = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Remove(new Product
                    {
                        ProductId = id
                    });
                    await _context.SaveChangesAsync();
                    trans.Commit();
                    flag = true;
                }
                catch (Exception ex)
                {
                    flag = false;
                }
            }
            return flag;
        }

        public async Task<IReadOnlyList<Product>> GetAllAsync()
        {
            return await _context.Products
                .OrderByDescending(x => x.ProductId)
                .ToListAsync();
            //.Include(p => p.Category)
            //.ThenInclude(p=>p.CategoryId)
            //.ToListAsync();
        }

        public async Task<Product> GetByAsync(int id)
        {
            return await _context.Products
                            .Include(p => p.Category)
                            .FirstOrDefaultAsync(p => p.ProductId == id);
        }

        public async Task<bool> UpdateAsync(Product entity)
        {
            bool flag = false;
            using (var trans = _context.Database.BeginTransaction())
            {
                try
                {
                    var originEntity = _context.Products.Single(x => x.ProductId == entity.ProductId);
                    originEntity.ProductName = entity.ProductName;
                    originEntity.UnitPrice = entity.UnitPrice;
                    originEntity.CategoryId = entity.CategoryId;
                    originEntity.UnitsInStock = entity.UnitsInStock;

                    _context.Update(entity);
                    await _context.SaveChangesAsync();
                    trans.Commit();
                    flag = true;
                }
                catch (Exception ex)
                {
                    flag = false;
                }
            }
            return flag;
        }




    }
}

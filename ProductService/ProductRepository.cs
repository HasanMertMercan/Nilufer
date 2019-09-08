using Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ValueTypes.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ProductService
{
    public class ProductRepository : IProductRepository
    {
        private StoreDbContext _dbContext;
        public ProductRepository(StoreDbContext dbContext)
        {
            //Inject StoreDbContext
            _dbContext = dbContext;
        }
        public async Task Delete(List<Product> list)
        {
            _dbContext.Product.RemoveRange(list);
            await Save();
        }

        public Task<Product> GetProductById(int id)
        {
            return _dbContext.Product.Where(q => q.Id == id).SingleAsync();
        }

        public Task<Product> GetProductByName(string name)
        {
            return _dbContext.Product.Where(q => q.Name == name).SingleAsync();
        }

        public Task<Product> GetProductByProductCode(string code)
        {
            return _dbContext.Product.Where(q => q.ProductCode == code).SingleAsync();
        }

        public Task<List<Product>> GetProducts()
        {
            return _dbContext.Product.ToListAsync();
        }

        public async Task Insert(List<Product> list)
        {
            _dbContext.Product.AddRange(list);
            await Save();
        }

        public async Task Update(List<Product> list)
        {
            foreach (var product in list)
            {
                _dbContext.Entry(product).State = EntityState.Modified;
            }
            await Save();
        }
        private async Task Save()
        {
            //Save the changes
            await _dbContext.SaveChangesAsync();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ValueTypes.Entity;

namespace ProductService
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProducts();
        Task<Product> GetProductById(int id);
        Task<Product> GetProductByProductCode(string code);
        Task<Product> GetProductByName(string name);
        Task Insert(Product product);
        Task Update(Product product);
        Task Delete(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ValueTypes.Entity;

namespace ProductService
{
    public interface IProductBusiness
    {
        Task<List<Product>> GetProducts();
        Task<Product> GetProductById(int id);
        Task<Product> GetProductByProductName(string name);
        Task<Product> GetProductByProductCode(string code);
        Task Insert(Product product);
        Task Update(Product product);
        Task Delete(int id);
    }
}

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
        Task Insert(List<Product> list);
        Task Update(List<Product> list);
        Task Delete(List<Product> list);
    }
}

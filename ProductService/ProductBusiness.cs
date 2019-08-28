using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ValueTypes.Entity;

namespace ProductService
{
    public class ProductBusiness : IProductBusiness
    {
        private IProductRepository _repository;
        private ILogger<ProductBusiness> _logger;

        public ProductBusiness(IProductRepository productRepository, ILogger<ProductBusiness> logger)
        {
            _repository = productRepository;
            _logger = logger;
        }

        public Task Delete(List<Product> list)
        {
            try
            {
                _repository.Delete(list);
                return Task.CompletedTask;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }
        
        public Task<Product> GetProductById(int id)
        {
            try
            {
                return _repository.GetProductById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task<Product> GetProductByProductCode(string code)
        {
            try
            {
                return _repository.GetProductByProductCode(code);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task<Product> GetProductByProductName(string name)
        {
            try
            {
                return _repository.GetProductByName(name);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task<List<Product>> GetProducts()
        {
            try
            {
                return _repository.GetProducts();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task Insert(List<Product> list)
        {
            try
            {
                _repository.Insert(list);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task Update(List<Product> list)
        {
            try
            {
                _repository.Update(list);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }
    }
}

using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ValueTypes.Entity;

namespace SupplierService
{
    public class SupplierBusiness : ISupplierBusiness
    {
        private ISupplierRepository _repository;
        private ILogger<SupplierBusiness> _logger;
        public SupplierBusiness(ISupplierRepository repository, ILogger<SupplierBusiness> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public Task Delete(Supplier supplier)
        {
            try
            {
                _repository.Delete(supplier);
                return Task.CompletedTask;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task<List<Supplier>> GetAllSuppliers()
        {
            try
            {
                return _repository.GetAllSuppliers();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task<Supplier> GetSupplierByEmail(string email)
        {
            try
            {
                return _repository.GetSupplierByEmail(email);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task<Supplier> GetSupplierById(int id)
        {
            try
            {
                return _repository.GetSupplierById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task<Supplier> GetSupplierByPhoneNumber(string phoneNumber)
        {
            try
            {
                return _repository.GetSupplierByPhoneNumber(phoneNumber);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task<Supplier> GetSupplierByStoreName(string storeName)
        {
            try
            {
                return _repository.GetSupplierByStoreName(storeName);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task<List<Supplier>> GetSuppliersByTotalBalance(decimal totalBalance)
        {
            try
            {
                return _repository.GetSuppliersByTotalBalance(totalBalance);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task Insert(Supplier supplier)
        {
            try
            {
                _repository.Insert(supplier);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task Update(Supplier supplier)
        {
            try
            {
                _repository.Update(supplier);
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

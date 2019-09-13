using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ValueTypes.Entity;

namespace CustomerService
{
    public class CustomerBusiness : ICustomerBusiness
    {
        private ICustomerRepository _repository;
        private ILogger<CustomerBusiness> _logger;

        public CustomerBusiness(ICustomerRepository repository,
            ILogger<CustomerBusiness> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public Task Delete(int id)
        {
            try
            {
                _repository.Delete(id);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task<Customer> GetCustomerById(int id)
        {
            try
            {
                return _repository.GetCustomerById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task<Customer> GetCustomerByEmail(string email)
        {
            try
            {
                return _repository.GetCustomerByEmail(email);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task<Customer> GetCustomerByPhoneNumber(string phoneNumber)
        {
            try
            {
                return _repository.GetCustomerByPhoneNumber(phoneNumber);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task<List<Customer>> GetCustomers()
        {
            try
            {
                return _repository.GetCustomers();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task Insert(Customer customer)
        {
            try
            {
                _repository.Insert(customer);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task Update(Customer customer)
        {
            try
            {
                _repository.Update(customer);
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

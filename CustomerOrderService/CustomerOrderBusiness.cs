using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ValueTypes.Entity;
using ValueTypes.Enums;

namespace CustomerOrderService
{
    public class CustomerOrderBusiness : ICustomerOrderBusiness
    {
        private ICustomerOrderRepository _repository;
        private ILogger<CustomerOrderBusiness> _logger;

        public CustomerOrderBusiness(ICustomerOrderRepository repository,
            ILogger<CustomerOrderBusiness> logger)
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

        public Task<List<CustomerOrder>> GetCostumerOrdersByProductId(int ProductId)
        {
            try
            {
                return _repository.GetCostumerOrdersByProductId(ProductId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task<CustomerOrder> GetCustomerOrderByOrderNumber(int OrderNumber)
        {
            try
            {
                return _repository.GetCustomerOrderByOrderNumber(OrderNumber);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task<CustomerOrder> GetCustomerOrderById(int id)
        {
            try
            {
                return _repository.GetCustomerOrderById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task<List<CustomerOrder>> GetCustomerOrders()
        {
            try
            {
                return _repository.GetCustomerOrders();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task<List<CustomerOrder>> GetCustomerOrdersByCreatedDate(DateTime date)
        {
            try
            {
                return _repository.GetCustomerOrdersByCreatedDate(date);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task<List<CustomerOrder>> GetCustomerOrdersByCustomerId(int CustomerId)
        {
            try
            {
                return _repository.GetCustomerOrdersByCustomerId(CustomerId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task<List<CustomerOrder>> GetCustomerOrdersByDeliveryDate(DateTime date)
        {
            try
            {
                return _repository.GetCustomerOrdersByDeliveryDate(date);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task<List<CustomerOrder>> GetCustomerOrdersByOrderAmount(int OrderAmount)
        {
            try
            {
                return _repository.GetCustomerOrdersByOrderAmount(OrderAmount);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task<List<CustomerOrder>> GetCustomerOrdersByStatus(IncomingOrderStatus status)
        {
            try
            {
                return _repository.GetCustomerOrdersByStatus(status);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task Insert(CustomerOrder customerOrder)
        {
            try
            {
                _repository.Insert(customerOrder);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task Update(CustomerOrder customerOrder)
        {
            try
            {
                _repository.Update(customerOrder);
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

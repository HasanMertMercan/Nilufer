using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ValueTypes.Entity;
using ValueTypes.Enums;

namespace DealerOrderService
{
    public class DealerOrderBusiness : IDealerOrderBusiness
    {
        private IDealerOrderRepository _repository;
        private ILogger<DealerOrderBusiness> _logger;

        public DealerOrderBusiness(IDealerOrderRepository repository,
            ILogger<DealerOrderBusiness> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public Task Delete(DealerOrder dealerOrder)
        {
            try
            {
                _repository.Delete(dealerOrder);
                return Task.CompletedTask;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task<List<DealerOrder>> GetDealerOrdersByProductId(int ProductId)
        {
            try
            {
                return _repository.GetDealerOrdersByProductId(ProductId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task<List<DealerOrder>> GetDealerOrdersByCreatedDate(DateTime date)
        {
            try
            {
                return _repository.GetDealerOrdersByCreatedDate(date);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task<List<DealerOrder>> GetDealerOrdersByDeliveryDate(DateTime date)
        {
            try
            {
                return _repository.GetDealerOrdersByDeliveryDate(date);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task<List<DealerOrder>> GetDealerOrdersByOrderAmount(int OrderAmount)
        {
            try
            {
                return _repository.GetDealerOrdersByOrderAmount(OrderAmount);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task<List<DealerOrder>> GetDealerOrdersByStatus(Status status)
        {
            try
            {
                return _repository.GetDealerOrdersByStatus(status);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task<DealerOrder> GetDealerOrderById(int orderId)
        {
            try
            {
                return _repository.GetDealerOrderById(orderId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task<List<DealerOrder>> GetDealerOrders()
        {
            try
            {
                return _repository.GetDealerOrders();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task<List<DealerOrder>> GetDealerOrdersByDealerId(int dealerId)
        {
            try
            {
                return _repository.GetDealerOrdersByDealerId(dealerId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task Insert(DealerOrder dealerOrder)
        {
            try
            {
                _repository.Insert(dealerOrder);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task Update(DealerOrder dealerOrder)
        {
            try
            {
                _repository.Update(dealerOrder);
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

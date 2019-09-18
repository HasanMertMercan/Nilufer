using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ValueTypes.Entity;
using ValueTypes.Enums;

namespace OutgoingOrderService
{
    public class OutgoingOrderBusiness : IOutgoingOrderBusiness
    {
        private IOutgoingOrderRepository _repository;
        private ILogger<OutgoingOrderBusiness> _logger;
        public OutgoingOrderBusiness(IOutgoingOrderRepository repository, ILogger<OutgoingOrderBusiness> logger)
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
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task<List<OutgoingOrder>> GetAllOutgoingOrders()
        {
            try
            {
                return _repository.GetAllOutgoingOrders();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task<OutgoingOrder> GetOutgoingOrderById(int id)
        {
            try
            {
                return _repository.GetOutgoingOrderById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task<List<OutgoingOrder>> GetOutgoingOrdersByCreatedDate(DateTime date)
        {
            try
            {
                return _repository.GetOutgoingOrdersByCreatedDate(date);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task<List<OutgoingOrder>> GetOutgoingOrdersByDeliveryDate(DateTime date)
        {
            try
            {
                return _repository.GetOutgoingOrdersByDeliveryDate(date);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task<List<OutgoingOrder>> GetOutgoingOrdersByOrderAmount(int OrderAmount)
        {
            try
            {
                return _repository.GetOutgoingOrdersByOrderAmount(OrderAmount);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task<List<OutgoingOrder>> GetOutgoingOrdersByProductId(int ProductId)
        {
            try
            {
                return _repository.GetOutgoingOrdersByProductId(ProductId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task<List<OutgoingOrder>> GetOutgoingOrdersByStatus(OutgoingOrderStatus status)
        {
            try
            {
                return _repository.GetOutgoingOrdersByStatus(status);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task<List<OutgoingOrder>> GetOutgoingOrdersBySupplierId(int supplierId)
        {
            try
            {
                return _repository.GetOutgoingOrdersBySupplierId(supplierId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task Insert(OutgoingOrder outgoingOrder)
        {
            try
            {
                _repository.Insert(outgoingOrder);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task Update(OutgoingOrder outgoingOrder)
        {
            try
            {
                _repository.Update(outgoingOrder);
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

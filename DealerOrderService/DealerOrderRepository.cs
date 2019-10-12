using Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueTypes.Entity;
using ValueTypes.Enums;

namespace DealerOrderService
{
    public class DealerOrderRepository : IDealerOrderRepository
    {
        private StoreDbContext _dbContext;
        public DealerOrderRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Delete(int id)
        {
            var dealer = await _dbContext.DealerOrder.SingleAsync(q => q.OrderId == id);
            if(dealer != null)
            {
                _dbContext.DealerOrder.Remove(dealer);
            }
            await Save();
        }

        public Task<List<DealerOrder>> GetDealerOrdersByProductId(int ProductId)
        {
            return _dbContext.DealerOrder.Where(q => q.ProductId == ProductId).ToListAsync();
        }

        public Task<DealerOrder> GetDealerOrderByOrderNumber(int OrderNumber)
        {
            return _dbContext.DealerOrder.Where(q => q.OrderNumber == OrderNumber).SingleAsync();
        }
        public Task<List<DealerOrder>> GetDealerOrdersByCreatedDate(DateTime date)
        {
            return _dbContext.DealerOrder.Where(q => q.CreatedDate == date).ToListAsync();
        }

        public Task<List<DealerOrder>> GetDealerOrdersByDeliveryDate(DateTime date)
        {
            return _dbContext.DealerOrder.Where(q => q.DeliveryDate == date).ToListAsync();
        }

        public Task<List<DealerOrder>> GetDealerOrdersByOrderAmount(int OrderAmount)
        {
            return _dbContext.DealerOrder.Where(q => q.OrderAmount == OrderAmount).ToListAsync();
        }

        public Task<List<DealerOrder>> GetDealerOrdersByStatus(IncomingOrderStatus status)
        {
            return _dbContext.DealerOrder.Where(q => q.OrderStatus == status).ToListAsync();
        }

        public Task<DealerOrder> GetDealerOrderById(int orderId)
        {
            return _dbContext.DealerOrder.Where(q => q.OrderId == orderId).SingleAsync();
        }

        public Task<List<DealerOrder>> GetDealerOrders()
        {
            return _dbContext.DealerOrder.ToListAsync();
        }

        public Task<List<DealerOrder>> GetDealerOrdersByDealerId(int dealerId)
        {
            return _dbContext.DealerOrder.Where(q => q.DealerId == dealerId).ToListAsync();
        }

        public async Task Insert(DealerOrder dealerOrder)
        {
            dealerOrder.OrderNumber = OrderNumberGenerator();
            _dbContext.DealerOrder.Add(dealerOrder);
            await Save();
        }

        public async Task Update(DealerOrder dealerOrder)
        {
            _dbContext.Entry(dealerOrder).State = EntityState.Modified;
            await Save();
        }
        private async Task Save()
        {
            //Save the changes
            await _dbContext.SaveChangesAsync();
        }
        private int OrderNumberGenerator()
        {
            int OrderNumber = RandomNumberGenerator();
            bool ValidationResult = ValidateGeneratedOrderNumber(OrderNumber);
            if (ValidationResult == true)
            {
                return OrderNumber;
            }
            else
            {
                while (ValidationResult == false)
                {
                    OrderNumber = RandomNumberGenerator();
                    ValidationResult = ValidateGeneratedOrderNumber(OrderNumber);
                }
                return OrderNumber;
            }
        }

        private int RandomNumberGenerator()
        {
            Random r = new Random();
            int OrderNumber = r.Next(10000000, 99999999);
            return OrderNumber;
        }

        private bool ValidateGeneratedOrderNumber(int OrderNumber)
        {
            var customerOrder = _dbContext.CustomerOrder.Where(q => q.OrderNumber == OrderNumber).SingleAsync();
            var dealerOrder = _dbContext.DealerOrder.Where(q => q.OrderNumber == OrderNumber).SingleAsync();

            if (customerOrder == null && dealerOrder == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

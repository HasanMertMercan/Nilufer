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
        public async Task Delete(DealerOrder dealerOrder)
        {
            _dbContext.DealerOrder.Remove(dealerOrder);
            await Save();
        }

        public Task<List<DealerOrder>> GetDealerOrdersByProductId(int ProductId)
        {
            return _dbContext.DealerOrder.Where(q => q.ProductId == ProductId).ToListAsync();
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
    }
}

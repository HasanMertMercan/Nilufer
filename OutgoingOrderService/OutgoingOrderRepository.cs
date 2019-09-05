using Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueTypes.Entity;
using ValueTypes.Enums;

namespace OutgoingOrderService
{
    public class OutgoingOrderRepository : IOutgoingOrderRepository
    {
        private StoreDbContext _dbContext;
        public OutgoingOrderRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Delete(OutgoingOrder outgoingOrder)
        {
            _dbContext.OutgoingOrderList.Remove(outgoingOrder);
            await Save();
        }

        public Task<List<OutgoingOrder>> GetAllOutgoingOrders()
        {
            return _dbContext.OutgoingOrderList.ToListAsync();
        }

        public Task<OutgoingOrder> GetOutgoingOrderById(int id)
        {
            return _dbContext.OutgoingOrderList.Where(q => q.OrderId == id).SingleAsync();
        }

        public Task<List<OutgoingOrder>> GetOutgoingOrdersByCreatedDate(DateTime date)
        {
            return _dbContext.OutgoingOrderList.Where(q => q.CreatedDate == date).ToListAsync();
        }

        public Task<List<OutgoingOrder>> GetOutgoingOrdersByDeliveryDate(DateTime date)
        {
            return _dbContext.OutgoingOrderList.Where(q => q.DeliveryDate == date).ToListAsync();
        }

        public Task<List<OutgoingOrder>> GetOutgoingOrdersByOrderAmount(int OrderAmount)
        {
            return _dbContext.OutgoingOrderList.Where(q => q.OrderAmount == OrderAmount).ToListAsync();
        }

        public Task<List<OutgoingOrder>> GetOutgoingOrdersByProductId(int ProductId)
        {
            return _dbContext.OutgoingOrderList.Where(q => q.ProductId == ProductId).ToListAsync();
        }

        public Task<List<OutgoingOrder>> GetOutgoingOrdersByStatus(Status status)
        {
            return _dbContext.OutgoingOrderList.Where(q => q.OrderStatus == status).ToListAsync();
        }

        public Task<List<OutgoingOrder>> GetOutgoingOrdersBySupplierId(int supplierId)
        {
            return _dbContext.OutgoingOrderList.Where(q => q.SupplierId == supplierId).ToListAsync();
        }

        public async Task Insert(OutgoingOrder outgoingOrder)
        {
            _dbContext.OutgoingOrderList.Add(outgoingOrder);
            await Save();
        }

        public async Task Update(OutgoingOrder outgoingOrder)
        {
            _dbContext.Entry(outgoingOrder).State = EntityState.Modified;
            await Save();
        }

        private async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}

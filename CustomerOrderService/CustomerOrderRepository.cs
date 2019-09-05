using Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueTypes.Entity;
using ValueTypes.Enums;

namespace CustomerOrderService
{
    class CustomerOrderRepository : ICustomerOrderRepository
    {
        private StoreDbContext _dbContext;
        public CustomerOrderRepository(StoreDbContext dbContext)
        {
            //Inject StoreDbContext
            _dbContext = dbContext;
        }
        public async Task Delete(CustomerOrder customerOrder)
        {
            _dbContext.CustomerOrderList.Remove(customerOrder);
            await Save();
        }

        public Task<List<CustomerOrder>> GetCostumerOrdersByProductId(int ProductId)
        {
            return _dbContext.CustomerOrderList.Where(q => q.ProductId == ProductId).ToListAsync();
        }

        public Task<CustomerOrder> GetCustomerOrderById(int id)
        {
            //Use linq queries to find the customer by id
            return _dbContext.CustomerOrderList.Where(q => q.OrderId == id).SingleAsync();
        }

        public Task<List<CustomerOrder>> GetCustomerOrders()
        {
            return _dbContext.CustomerOrderList.ToListAsync();
        }

        public Task<List<CustomerOrder>> GetCustomerOrdersByCreatedDate(DateTime date)
        {
            return _dbContext.CustomerOrderList.Where(q => q.CreatedDate == date).ToListAsync();
        }

        public Task<List<CustomerOrder>> GetCustomerOrdersByCustomerId(int CustomerId)
        {
            return _dbContext.CustomerOrderList.Where(q => q.CustomerId == CustomerId).ToListAsync();
        }

        public Task<List<CustomerOrder>> GetCustomerOrdersByDeliveryDate(DateTime date)
        {
            return _dbContext.CustomerOrderList.Where(q => q.DeliveryDate == date).ToListAsync();
        }

        public Task<List<CustomerOrder>> GetCustomerOrdersByOrderAmount(int OrderAmount)
        {
            return _dbContext.CustomerOrderList.Where(q => q.OrderAmount == OrderAmount).ToListAsync();
        }

        public Task<List<CustomerOrder>> GetCustomerOrdersByStatus(Status status)
        {
            return _dbContext.CustomerOrderList.Where(q => q.OrderStatus == status).ToListAsync();
        }

        public async Task Insert(CustomerOrder customerOrder)
        {
            _dbContext.CustomerOrderList.Add(customerOrder);
            await Save();
        }

        public async Task Update(CustomerOrder customerOrder)
        {
            _dbContext.Entry(customerOrder).State = EntityState.Modified;
            await Save();
        }
        private async Task Save()
        {
            //Save the changes
            await _dbContext.SaveChangesAsync();
        }
    }
}

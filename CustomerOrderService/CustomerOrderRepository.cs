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
    public class CustomerOrderRepository : ICustomerOrderRepository
    {
        private StoreDbContext _dbContext;
        public CustomerOrderRepository(StoreDbContext dbContext)
        {
            //Inject StoreDbContext
            _dbContext = dbContext;
        }
        public async Task Delete(int id)
        {
            var customerOrder = await _dbContext.CustomerOrder.SingleAsync(q => q.OrderId == id);
            if(customerOrder != null)
            {
                _dbContext.CustomerOrder.Remove(customerOrder);
            }
            await Save();
        }

        public Task<List<CustomerOrder>> GetCostumerOrdersByProductId(int ProductId)
        {
            return _dbContext.CustomerOrder.Where(q => q.ProductId == ProductId).ToListAsync();
        }

        public Task<CustomerOrder> GetCustomerOrderByOrderNumber(int OrderNumber)
        {
            return _dbContext.CustomerOrder.Where(q => q.OrderNumber == OrderNumber).SingleAsync();
        }

        public Task<CustomerOrder> GetCustomerOrderById(int id)
        {
            //Use linq queries to find the customer by id
            return _dbContext.CustomerOrder.Where(q => q.OrderId == id).SingleAsync();
        }

        public Task<List<CustomerOrder>> GetCustomerOrders()
        {
            return _dbContext.CustomerOrder.ToListAsync();
        }

        public Task<List<CustomerOrder>> GetCustomerOrdersByCreatedDate(DateTime date)
        {
            return _dbContext.CustomerOrder.Where(q => q.CreatedDate == date).ToListAsync();
        }

        public Task<List<CustomerOrder>> GetCustomerOrdersByCustomerId(int CustomerId)
        {
            return _dbContext.CustomerOrder.Where(q => q.CustomerId == CustomerId).ToListAsync();
        }

        public Task<List<CustomerOrder>> GetCustomerOrdersByDeliveryDate(DateTime date)
        {
            return _dbContext.CustomerOrder.Where(q => q.DeliveryDate == date).ToListAsync();
        }

        public Task<List<CustomerOrder>> GetCustomerOrdersByOrderAmount(int OrderAmount)
        {
            return _dbContext.CustomerOrder.Where(q => q.OrderAmount == OrderAmount).ToListAsync();
        }

        public Task<List<CustomerOrder>> GetCustomerOrdersByStatus(IncomingOrderStatus status)
        {
            return _dbContext.CustomerOrder.Where(q => q.OrderStatus == status).ToListAsync();
        }

        public async Task Insert(CustomerOrder customerOrder)
        {
            customerOrder.OrderNumber = OrderNumberGenerator();
            _dbContext.CustomerOrder.Add(customerOrder);
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

        private int OrderNumberGenerator()
        {
            int OrderNumber = RandomNumberGenerator();
            bool ValidationResult = false;
            while(ValidationResult == false)
            {
                OrderNumber = RandomNumberGenerator();
                ValidationResult = ValidateGeneratedOrderNumber(OrderNumber);
            }
            return OrderNumber;
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

            if(customerOrder == null && dealerOrder == null)
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

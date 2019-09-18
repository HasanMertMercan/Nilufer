using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ValueTypes.Entity;
using ValueTypes.Enums;

namespace CustomerOrderService
{
    public interface ICustomerOrderRepository
    {
        Task<List<CustomerOrder>> GetCustomerOrders();
        Task<CustomerOrder> GetCustomerOrderById(int id);
        Task<List<CustomerOrder>> GetCustomerOrdersByCustomerId(int CustomerId);
        Task<List<CustomerOrder>> GetCostumerOrdersByProductId(int ProductId);
        Task<List<CustomerOrder>> GetCustomerOrdersByStatus(IncomingOrderStatus status);
        Task<List<CustomerOrder>> GetCustomerOrdersByCreatedDate(DateTime date);
        Task<List<CustomerOrder>> GetCustomerOrdersByDeliveryDate(DateTime date);
        Task<List<CustomerOrder>> GetCustomerOrdersByOrderAmount(int OrderAmount);
        Task Insert(CustomerOrder customerOrder);
        Task Update(CustomerOrder customerOrder);
        Task Delete(int id);
    }
}

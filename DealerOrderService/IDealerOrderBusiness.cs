using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ValueTypes.Entity;
using ValueTypes.Enums;

namespace DealerOrderService
{
    public interface IDealerOrderBusiness
    {
        Task Insert(DealerOrder dealerOrder);
        Task Update(DealerOrder dealerOrder);
        Task Delete(int id);
        Task<List<DealerOrder>> GetDealerOrders();
        Task<DealerOrder> GetDealerOrderById(int orderId);
        Task<DealerOrder> GetDealerOrderByOrderNumber(int OrderNumber);
        Task<List<DealerOrder>> GetDealerOrdersByDealerId(int dealerId);
        Task<List<DealerOrder>> GetDealerOrdersByProductId(int ProductId);
        Task<List<DealerOrder>> GetDealerOrdersByStatus(IncomingOrderStatus status);
        Task<List<DealerOrder>> GetDealerOrdersByCreatedDate(DateTime date);
        Task<List<DealerOrder>> GetDealerOrdersByDeliveryDate(DateTime date);
        Task<List<DealerOrder>> GetDealerOrdersByOrderAmount(int OrderAmount);
    }
}

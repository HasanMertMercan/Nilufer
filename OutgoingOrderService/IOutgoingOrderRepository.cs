using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ValueTypes.Entity;
using ValueTypes.Enums;

namespace OutgoingOrderService
{
    public interface IOutgoingOrderRepository
    {
        Task<List<OutgoingOrder>> GetAllOutgoingOrders();
        Task<OutgoingOrder> GetOutgoingOrderById(int id);
        Task<List<OutgoingOrder>> GetOutgoingOrdersBySupplierId(int supplierId);
        Task<List<OutgoingOrder>> GetOutgoingOrdersByProductId(int ProductId);
        Task<List<OutgoingOrder>> GetOutgoingOrdersByStatus(OutgoingOrderStatus status);
        Task<List<OutgoingOrder>> GetOutgoingOrdersByCreatedDate(DateTime date);
        Task<List<OutgoingOrder>> GetOutgoingOrdersByDeliveryDate(DateTime date);
        Task<List<OutgoingOrder>> GetOutgoingOrdersByOrderAmount(int OrderAmount);
        Task Insert(OutgoingOrder outgoingOrder);
        Task Update(OutgoingOrder outgoingOrder);
        Task Delete(OutgoingOrder outgoingOrder);
    }
}

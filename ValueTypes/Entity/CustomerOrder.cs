using System;
using System.Collections.Generic;
using System.Text;
using ValueTypes.Enums;

namespace ValueTypes.Entity
{
    public class CustomerOrder : Order
    {
        public int OrderId { get; set; }

        public int OrderNumber { get; set; }
        public int CustomerId { get; set; }
        public IncomingOrderStatus OrderStatus { get; set; }
    }
}

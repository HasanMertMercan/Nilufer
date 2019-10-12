using System;
using System.Collections.Generic;
using System.Text;
using ValueTypes.Enums;

namespace ValueTypes.Entity
{
    public class DealerOrder : Order
    {
        public int OrderId { get; set; }
        public int OrderNumber { get; set; }
        public int DealerId { get; set; }
        public IncomingOrderStatus OrderStatus { get; set; }
    }
}

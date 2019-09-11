using System;
using System.Collections.Generic;
using System.Text;
using ValueTypes.Enums;

namespace ValueTypes.Entity
{
    public class OutgoingOrder : Order
    {
        public int OrderId { get; set; }
        public int SupplierId { get; set; }
        public OutgoingOrderStatus OrderStatus { get; set; }
    }
}

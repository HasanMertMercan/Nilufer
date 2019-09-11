using System;
using System.Collections.Generic;
using System.Text;
using ValueTypes.Enums;

namespace ValueTypes.Entity
{
    public abstract class Order
    {
        public DateTime CreatedDate { get; set; }
        public int ProductId { get; set; }
        public int OrderAmount { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal AdvancePayment { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}

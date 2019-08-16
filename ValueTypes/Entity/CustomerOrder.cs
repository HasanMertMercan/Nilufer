using System;
using System.Collections.Generic;
using System.Text;

namespace ValueTypes.Entity
{
    public class CustomerOrder : Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ValueTypes.Entity
{
    public class OutgoingOrder : Order
    {
        public int OrderId { get; set; }
        public int SupplierId { get; set; }
    }
}

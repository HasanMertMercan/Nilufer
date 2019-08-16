using System;
using System.Collections.Generic;
using System.Text;

namespace ValueTypes.Entity
{
    public class DealerOrder : Order
    {
        public int OrderId { get; set; }
        public int DealerId { get; set; }
    }
}

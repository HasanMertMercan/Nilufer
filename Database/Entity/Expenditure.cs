using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Entity
{
    public class Expenditure //Harcamalar
    {
        public int Id { get; set; }
        public int OutgoingOrderId { get; set; }
        public decimal TotalAmount { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}

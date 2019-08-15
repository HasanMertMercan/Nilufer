using System;

namespace ValueTypes.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
    }
}


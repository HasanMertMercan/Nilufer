using System;
using System.Collections.Generic;
using System.Text;

namespace ValueTypes.Entity
{
    public class Customer
    {
        public int Id { get; set; } //NotNull
        public string Name { get; set; } //NotNull
        public string PhoneNumber { get; set; } //NotNull
        public string EmailAddress { get; set; }
        public decimal TotalBalance { get; set; } //NotNull
    }
}

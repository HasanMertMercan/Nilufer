using System;
using System.Collections.Generic;
using System.Text;

namespace ValueTypes.Entity
{
    public class Dealer
    {
        public int Id { get; set; }
        public string StoreName { get; set; } //NotNull
        public string OwnerName { get; set; }
        public string PhoneNumber { get; set; } //NotNull
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public decimal TotalBalance { get; set; } //NotNull
    }
}

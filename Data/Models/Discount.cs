using System;
using System.Collections.Generic;

namespace Data.Models
{
    public class Discount
    {
        public int DiscountId { get; set; }
        public string Code { get; set; }
        public DateTime ExpiredTime { get; set; }
        public decimal Amount { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}

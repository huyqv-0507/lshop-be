using System;
using System.Collections.Generic;

namespace Data.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedTime { get; set; }
        public decimal TotalPrice { get; set; }
        public bool Status { get; set; }
        public string PaymentMethod { get; set; }

        public User User { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    } 
}

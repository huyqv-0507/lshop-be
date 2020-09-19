using System;
namespace Data.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int LaptopId { get; set; }
        public int OrderId { get; set; }
        public int DiscountId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public Order Order { get; set; }
        public Laptop Laptop { get; set; }
        public Discount Discount { get; set; }
    }
}

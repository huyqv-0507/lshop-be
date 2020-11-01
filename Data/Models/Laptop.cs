using System;
using System.Collections.Generic;

namespace Data.Models
{
    public class Laptop
    {
        public int LaptopId { get; set; }
        public string LaptopName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string SeriesCPU { get; set; }
        public string DisplayScreen { get; set; }
        public string GraphicCard { get; set; }
        public string Storage { get; set; }
        public string Pin { get; set; }
        public string Ram { get; set; }
        public decimal Weight { get; set; }
        public string ImageUrl { get; set; }
        public int BrandId { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
        public Brand Brand { get; set; }

    }
}

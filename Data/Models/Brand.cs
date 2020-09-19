using System;
using System.Collections.Generic;

namespace Data.Models
{
    public class Brand
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }

        public ICollection<Laptop> Laptops { get; set; }
    }
}

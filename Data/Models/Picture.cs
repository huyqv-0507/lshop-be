using System;
namespace Data.Models
{
    public class Picture
    {
        public int PictureId { get; set; }
        public string PictureUrl { get; set; }
        public int LaptopId { get; set; }

        public Laptop Laptop { get; set; }
    }
}

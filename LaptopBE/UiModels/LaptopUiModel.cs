using System;
namespace LaptopBE.UiModels
{
    public class LaptopUiModel
    {
        public int LaptopId { get; set; }
        public string LaptopName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string SeriesCPU { get; set; }
        public string DisplayScreen { get; set; }
        public string GraphicCard { get; set; }
        public string Storage { get; set; }
        public string Ram { get; set; }
        public decimal Weight { get; set; }
        public string ImageUrl { get; set; }
        public int BrandId { get; set; }
        public string url { get; set; }
    }
}

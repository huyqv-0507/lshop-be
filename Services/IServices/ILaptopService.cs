using System;
using System.Collections.Generic;
using System.Linq;
using Data.Models;
using Services.ConvertionModels;

namespace Services.IServices
{
    public interface ILaptopService
    {
        void AddLaptop(LaptopModel laptopModel);
        IEnumerable<Laptop> GetLaptops();
        IEnumerable<Laptop> GetLaptopsPaging(int page, int pageSize);
        IEnumerable<Laptop> SearchLaptops(string txtSearch);

        void Save();
    }
}

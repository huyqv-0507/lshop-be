using System;
using System.Collections.Generic;
using System.Linq;
using Data.Models;

namespace Services.IServices
{
    public interface ILaptopService
    {
        IEnumerable<Laptop> GetLaptops();
        IEnumerable<Laptop> GetLaptopsPaging(int page, int pageSize);
        IEnumerable<Laptop> GetManyLaptops(string txtSearch);
        void Save();
    }
}

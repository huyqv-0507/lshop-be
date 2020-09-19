using System;
using Data.Infrastructures.IRepositories;
using Data.Models;

namespace Data.Infrastructures.Repositories
{
    public class LaptopRepository : RepositoryBase<Laptop>, ILaptopRepository
    {
        public LaptopRepository(IDbFactory dbFactory)
             : base(dbFactory)
        {
        }
    }
}

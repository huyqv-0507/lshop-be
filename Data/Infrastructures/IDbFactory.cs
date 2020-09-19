using System;
namespace Data.Infrastructures
{
    public interface IDbFactory
    {
        LaptopDbContext Init();
    }
    public class DbFactory : Disposable, IDbFactory
    {
        LaptopDbContext dbContext;
        public LaptopDbContext Init()
        {
            return dbContext ?? (dbContext = new LaptopDbContext());
        }
        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}

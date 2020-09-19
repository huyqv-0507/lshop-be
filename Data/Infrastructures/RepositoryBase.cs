using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Data.Infrastructures
{
    public abstract class RepositoryBase<T> where T : class
    {
        #region Properties
        private LaptopDbContext dbContext;
        private readonly DbSet<T> dbSet;

        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        protected LaptopDbContext DbContext
        {
            get { return dbContext ?? (dbContext = DbFactory.Init()); }
        }
        #endregion
        protected RepositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            dbSet = DbContext.Set<T>();
        }
        #region Implementation
        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
        }
        public virtual void Update(T entity)
        {

            dbSet.Attach(entity);
            dbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public virtual T GetById(int id)
        {
            return dbSet.Find(id);
        }
        public T Get(Expression<Func<T, bool>> expression)
        {
            return dbSet.Where(expression).FirstOrDefault<T>();
        }
        public virtual IQueryable<T> GetMany(Expression<Func<T, bool>> expression)
        {
            return dbSet.Where(expression);
        }

        public virtual IQueryable<T> GetAll()
        {
            return dbSet;
        }
        public virtual IEnumerable<T> GetPaged(int page, int pageSize)
        {
            return dbSet.Skip(page * pageSize).Take(pageSize).ToList();
        }
        #endregion
    }
}

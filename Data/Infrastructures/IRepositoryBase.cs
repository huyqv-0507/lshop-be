﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Data.Infrastructures
{
    public interface IRepositoryBase<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetById(int id);
        T Get(Expression<Func<T, bool>> expression);
        IQueryable<T> GetAll();
        IQueryable<T> GetMany(Expression<Func<T, bool>> expression);
        IEnumerable<T> GetPaged(int page, int pageSize);
    }
}

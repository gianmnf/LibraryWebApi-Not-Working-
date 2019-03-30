﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Books
{
    public interface IRepositoryBase<T>
    {
        //Criando CRUD
        IEnumerable<T> FindAll();
        IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
    }
}

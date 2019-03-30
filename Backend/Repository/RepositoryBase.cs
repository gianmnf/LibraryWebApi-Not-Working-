using System;
using Books;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Entities;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext RepositoryContext { get; set; }

        public RepositoryBase(RepositoryContext repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
        }

        public IEnumerable<T> FindAll()
        {
            return this.RepositoryContext.Set<T>();
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.RepositoryContext.Set<T>().Where(expression);
        }

        public void Create(T livros)
        {
            this.RepositoryContext.Set<T>().Add(livros);
        }

        public void Update(T livros)
        {
            this.RepositoryContext.Set<T>().Update(livros);
        }

        public void Delete(T livros)
        {
            this.RepositoryContext.Set<T>().Remove(livros);
        }

        public void Save()
        {
            this.RepositoryContext.SaveChanges();
        }
    }
}

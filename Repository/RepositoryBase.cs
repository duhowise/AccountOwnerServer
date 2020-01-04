using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Contracts;
using Entities;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class RepositoryBase<T>: IRepositoryBase<T> where T : class
    {
        protected RepositoryContext RepositoryContext { get; set; }

        public RepositoryBase(RepositoryContext repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
        }

        public  IQueryable<T> FindAll()
        {
           return  this.RepositoryContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return  RepositoryContext.Set<T>().Where(expression);
        }

        public Task Create(T entity)
        {
            return Task.FromResult(RepositoryContext.Set<T>().Add(entity));
        }

        public Task Update(T entity)
        {
            return Task.FromResult(RepositoryContext.Set<T>().Update(entity));
        }

        public Task Delete(T entity)
        {
            return Task.FromResult(this.RepositoryContext.Set<T>().Remove(entity))
            ;
        }

        public Task Save()
        {
           return Task.FromResult(this.RepositoryContext.SaveChanges());
        }
    }
}
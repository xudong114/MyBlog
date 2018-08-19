using Blog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class, IAggregateRoot
    {
        public Repository(IRepositoryContext iRepositoryContext)
        {
            Context = iRepositoryContext;
        }

        public IRepositoryContext Context { get; }

        public abstract IQueryable<T> Data { get; }

        public void Add(T aggregateRoot)
        {
            this.DoAdd(aggregateRoot);
        }

        public void Delete(T aggregateRoot)
        {
            this.DoDelete(aggregateRoot);
        }

        public T GetByKey(Guid id)
        {
            return this.DoGetByKey(id);
        }

        public void Update(T aggregateRoot)
        {
            this.DoUpdate(aggregateRoot);
        }

        protected abstract void DoAdd(T aggregateRoot);
        protected abstract void DoUpdate(T aggregateRoot);
        protected abstract void DoDelete(T aggregateRoot);
        protected abstract T DoGetByKey(Guid key);
    }
}

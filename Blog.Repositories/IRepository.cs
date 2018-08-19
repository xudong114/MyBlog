using Blog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Repositories
{
    public interface IRepository<T> where T : class, IAggregateRoot
    {
        IRepositoryContext Context { get; }
        void Add(T aggregateRoot);
        void Update(T aggregateRoot);
        void Delete(T aggregateRoot);
        T GetByKey(Guid id);
        IQueryable<T> Data { get; }
    }
}

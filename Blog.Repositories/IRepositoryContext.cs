using Blog.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Repositories
{
    public interface IRepositoryContext : IUnitOfWork, IDisposable
    {
        Guid Id { get; }

        void RegisterNew<T>(T obj) where T : class, IAggregateRoot;

        void RegisterModified<T>(T obj) where T : class, IAggregateRoot;

        void RegisterDeleted<T>(T obj) where T : class, IAggregateRoot;
    }
}

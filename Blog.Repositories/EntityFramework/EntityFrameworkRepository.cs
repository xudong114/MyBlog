using Blog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Repositories.EntityFramework
{
    public class EntityFrameworkRepository<T> : Repository<T> where T : class, IAggregateRoot
    {
        private readonly IEntityFrameworkRepositoryContext _EFContext;
        protected IEntityFrameworkRepositoryContext EFContext
        {
            get
            {
                return this._EFContext;
            }
        }

        public EntityFrameworkRepository(IRepositoryContext iRepositoryContext) :base(iRepositoryContext)
        {
            if (iRepositoryContext is IEntityFrameworkRepositoryContext)
            {
                this._EFContext = iRepositoryContext as IEntityFrameworkRepositoryContext;
            }
        }

        public override IQueryable<T> Data => throw new NotImplementedException();



        protected override void DoAdd(T aggregateRoot)
        {
            this._EFContext.RegisterNew<T>(aggregateRoot);
        }

        protected override void DoDelete(T aggregateRoot)
        {
            this._EFContext.RegisterDeleted(aggregateRoot);
        }

        protected override T DoGetByKey(Guid key)
        {
            return this._EFContext.Context.Set<T>().Find(key);
        }

        protected override void DoUpdate(T aggregateRoot)
        {
            this._EFContext.RegisterModified(aggregateRoot);
        }
    }
}

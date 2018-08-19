using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Blog.Repositories.EntityFramework
{
    public class EntityFrameworkRepositoryContext : RepositoryContext, IEntityFrameworkRepositoryContext, IDisposable
    {
        public BlogDbContext blogDbContext { get; set; }

        public EntityFrameworkRepositoryContext(IConfiguration iConfiguration)
        {
            blogDbContext = new BlogDbContext(iConfiguration);
        }

        public DbContext Context
        {
            get { return blogDbContext; }
        }

        public override void RegisterNew<T>(T obj)
        {
            this.Context.Set<T>().Add(obj);
            this.Committed = false;
        }

        public override void RegisterModified<T>(T obj)
        {
            this.Context.Set<T>().Attach(obj);
            this.Context.Entry(obj).State = EntityState.Modified;
            this.Committed = false;
        }

        public override void RegisterDeleted<T>(T obj)
        {
            this.Context.Set<T>().Remove(obj);
            this.Committed = false;
        }

        public override void Commit()
        {
            if (!Committed)
            {
                this.Context.SaveChanges();
                this.Committed = true;
            }
        }

        public override void Rollback()
        {
            this.Committed = false;
        }
    }
}

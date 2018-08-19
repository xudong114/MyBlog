using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Repositories.EntityFramework
{
    public interface IEntityFrameworkRepositoryContext : IRepositoryContext
    {
        DbContext Context { get; }
    }
}

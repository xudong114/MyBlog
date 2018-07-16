using System;

namespace Blog.Domain
{
    /// <summary>
    /// 领域对象聚合根约束
    /// </summary>
    public interface IAggregateRoot : IEntity
    {
        Guid Id { get; }
    }
}

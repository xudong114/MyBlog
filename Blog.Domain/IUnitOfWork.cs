using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        bool Committed { get; }
        /// <summary>
        /// 提交事务
        /// </summary>
        void Commit();
        /// <summary>
        /// 失败回滚
        /// </summary>
        void Rollback();
    }
}

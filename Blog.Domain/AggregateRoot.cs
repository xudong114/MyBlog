using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain
{
    /// <summary>
    /// 领域对象聚合根
    /// </summary>
    public class AggregateRoot : IAggregateRoot
    {
        /// <summary>
        /// 数据唯一标识
        /// </summary>
        public Guid Id { get; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 创建者
        /// </summary>
        public Guid CreateBy { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime ModifyTime { get; set; }
        /// <summary>
        /// 数据状态
        /// </summary>
        public bool IsActive { get; set; }
    }
}

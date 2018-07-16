using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain.Models
{
    /// <summary>
    /// 频道
    /// </summary>
    public class Channel : AggregateRoot
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain.Models
{
    public class News : AggregateRoot
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 关联频道Id
        /// </summary>
        public Guid ChannelId { get; set; }
        /// <summary>
        /// 关联频道
        /// </summary>
        public Channel Channel { get; set; }
    }
}

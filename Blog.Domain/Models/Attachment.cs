using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain.Models
{
    /// <summary>
    /// 附件
    /// </summary>
    public class Attachment : AggregateRoot
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 文件流
        /// </summary>
        public byte[] FileByte { get; set; }
        /// <summary>
        /// 关联Id
        /// </summary>
        public Guid ReferenceId { get; set; }
        /// <summary>
        /// 文件扩展名
        /// </summary>
        public string FileExt { get; set; }
    }
}

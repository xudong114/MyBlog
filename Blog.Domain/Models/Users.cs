using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain.Models
{
    /// <summary>
    /// 用户
    /// </summary>
    public class Users : AggregateRoot
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string Password { get; set; }
    }
}

using Blog.Domain.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Repositories
{
    public class BlogDbContext : DbContext
    {
        /// <summary>
        /// 声明配置
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// 初始化配置appsettings
        /// </summary>
        /// <param name="iConfiguration"></param>
        public BlogDbContext(IConfiguration iConfiguration)
        {
            this.Configuration = iConfiguration;
        }

        /// <summary>
        /// 获取数据库链接
        /// </summary>
        /// <param name="dbContextOptionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer("");
        }

        #region DbBase
        /// <summary>
        /// 
        /// </summary>
        public DbSet<News> News { get; set; }

        #endregion
    }
}

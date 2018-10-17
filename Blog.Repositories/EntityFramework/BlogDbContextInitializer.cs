using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Repositories.EntityFramework
{
    public class BlogDbContextInitializer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "Users",
                columns: p => new
                {
                    Username = p.Column<string>(nullable: false),
                    Password = p.Column<string>(nullable: false)
                });
        }
    }
}

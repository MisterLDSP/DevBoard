using DevBoard.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbServices
{
    public class DbModel : DbContext
    {
        public DbSet<Work> Works { get; set; }
        private string DbPath { get; set; }

        public DbModel(DbContextOptions options) : base(options)
        {
            DbPath = $"Data Source={Path.Combine(Directory.GetCurrentDirectory())}\\devboard.db";
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite(DbPath);
    }
}

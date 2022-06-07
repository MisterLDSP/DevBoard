using DevBoard.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DevBoard.Server
{
    public class DbModel : DbContext
    {
        public DbSet<Work> Works { get; set; }
        private string DbPath { get; set; }

        public DbModel(DbContextOptions options) : base(options)
        {
            DbPath = Helper.GetPCS();
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseNpgsql(DbPath);
    }
}

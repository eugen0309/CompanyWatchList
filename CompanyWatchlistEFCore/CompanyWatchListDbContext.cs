using CompanyWatchList.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace CompanyWatchlistEFCore
{
    public class CompanyWatchListDbContext : DbContext
    {
        protected readonly IConfiguration _config;
        public CompanyWatchListDbContext(IConfiguration config)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(_config.GetConnectionString("CompanyWatchListDb"));
        }

        public DbSet<User> Users { get; set; }
    }
}

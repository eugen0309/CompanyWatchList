using CompanyWatchList.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CompanyWatchList.Helpers
{
    public class CompanyWatchlistContext : DbContext
    {
        public CompanyWatchlistContext(DbContextOptions<CompanyWatchlistContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            byte[] adminPwdHash, adminPwdSalt;
            Hashing.CreatePasswordHash("qwerty123", out adminPwdHash, out adminPwdSalt);
            builder.Entity<User>().HasData(new User()
            {
                Id = 1,
                FirstName = "Eugen",
                LastName = "Stancioiu",
                UserName = "admin",
                PasswordHash = adminPwdHash,
                PasswordSalt = adminPwdSalt
            });
        }

        public DbSet<User> Users { get; set; }
    }
}

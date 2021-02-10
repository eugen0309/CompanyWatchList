﻿using CompanyWatchList.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

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

            builder.Entity<UserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });
                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId);

                userRole.HasOne(ur => ur.User)
                    .WithMany(u => u.UserRoles)
                    .HasForeignKey(ur => ur.UserId);
            });

            builder.Entity<Role>().HasData(new Role[]
            {
                new Role()
                {
                    Id = 1,
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper()
                },
                new Role()
                {
                    Id = 2,
                    Name = "User",
                    NormalizedName = "User".ToUpper()
                }
            });

            byte[] adminPwdHash, adminPwdSalt;
            Hashing.CreatePasswordHash("qwerty123", out adminPwdHash, out adminPwdSalt);

             builder.Entity<User>(b =>
             {
                 b.HasData(new User()
                 {
                     Id = 1,
                     FirstName = "Eugen",
                     LastName = "Stancioiu",
                     UserName = "admin",
                     PasswordHash = adminPwdHash,
                     PasswordSalt = adminPwdSalt,
                 });               
             });

            builder.Entity<UserRole>().HasData(new UserRole()
            {
                RoleId = 1,
                UserId = 1
            });
               
                
             

        }
               
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}

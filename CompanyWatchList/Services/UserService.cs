﻿using CompanyWatchList.Entities;
using CompanyWatchList.Helpers;
using static CompanyWatchList.Helpers.Hashing;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CompanyWatchList.Services
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _config;
        private CompanyWatchlistContext _context;
        private readonly IRoleService _roleService;

        public UserService(IConfiguration config, CompanyWatchlistContext context, IRoleService roleService)
        {
            _config = config;
            _context = context;
            _roleService = roleService;
        }

        public User Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = _context.Users
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .SingleOrDefault(u => u.UserName == username);
            if (user == null)
                return null;

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

          
            return user;
        }


        public async Task<User> CreateAsync(User user, string password, ICollection<string> roles)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("Password is required");
            if (_context.Users.Any(u => u.UserName == user.UserName))
                throw new Exception($"User name {user.UserName} is already taken");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;


            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            await AddUserRoles(user, roles);

            return user;
        }        

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User GetById(int id)
        {
            return _context.Users.Find(id);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        private async Task AddUserRoles(User user, ICollection<string> roles)
        {
            if (roles == null || roles.Count == 0)
            {
                await _roleService.AddUserToRoleAsync(user.Id, "User");
            }
            else
            {
                foreach (var roleName in roles)
                {
                    await _roleService.AddUserToRoleAsync(user.Id, roleName);
                }
            }
        }
    }
}

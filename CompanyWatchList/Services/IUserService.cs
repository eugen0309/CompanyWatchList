using CompanyWatchList.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyWatchList.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
        User GetById(int id);
        Task<User> CreateAsync(User user, string password);
        Task<bool> DeleteAsync(int id);
    }
}

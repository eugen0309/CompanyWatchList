using CompanyWatchListEF.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyWatchListCore.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
        User GetById(int id);
        User GetByUserName(string userName);
        Task<User> CreateAsync(User user, string password, ICollection<string> roles);
        Task<bool> DeleteAsync(int id);
    }
}

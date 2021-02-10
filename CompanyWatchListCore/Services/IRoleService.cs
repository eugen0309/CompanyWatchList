using CompanyWatchListCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyWatchListCore.Services
{
    public interface IRoleService
    {        
        IEnumerable<Role> GetAll();
        Role GetById(int id);
        Role GetByName(string name);
        Task AddUserToRoleAsync(int userId, string roleName);
    }
}

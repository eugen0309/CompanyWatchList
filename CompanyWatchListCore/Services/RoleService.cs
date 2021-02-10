using CompanyWatchListCore.Entities;
using CompanyWatchListEF;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyWatchListCore.Services
{
    public class RoleService : IRoleService
    {
        CompanyWatchlistContext _context;
        public RoleService(CompanyWatchlistContext context)
        {
            _context = context;
        }

        public async Task AddUserToRoleAsync(int userId, string roleName)
        {
            var role = _context.Roles.FirstOrDefault(r => r.NormalizedName == roleName.ToUpper());
            await _context.UserRoles.AddAsync(new UserRole()
            {
                RoleId = role.Id,
                UserId = userId
            });
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Role> GetAll()
        {
            return _context.Roles;
        }

        public Role GetById(int id)
        {
            return _context.Roles.FirstOrDefault(r => r.Id == id);
        }

        public Role GetByName(string name)
        {
            return _context.Roles.FirstOrDefault(r => r.NormalizedName == name.ToUpper());
        }
    }
}

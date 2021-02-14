using CompanyWatchListEF;
using CompanyWatchListEF.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyWatchListCore.Services
{
    public class WatchlistService : IWatchlistService
    {
        CompanyWatchlistContext _context;
        public WatchlistService(CompanyWatchlistContext context)
        {
            _context = context;
        }
        public IEnumerable<Company> GetUserWatchlist(int userId)
        {
            return _context.UserWatchlists.Where(wl => wl.User.Id == userId).Select(wl => wl.Company).ToList();            
        }

        public async Task<Company> AddCompanyToWatchListAsync(int userId, string companyName, string symbol)
        {
            var company = _context.Companies.FirstOrDefault(c => c.Symbol == symbol);
            if (company == null)
            {
                company = new Company()
                {
                    Name = companyName,
                    Symbol = symbol,
                };
                await _context.Companies.AddAsync(company);
                await _context.SaveChangesAsync();                
            }
            
            await _context.UserWatchlists.AddAsync(new UserWatchlist()
            {
                UserId = userId,
                CompanyId = company.Id
            });
            await _context.SaveChangesAsync();
            return company;
        }

        public async Task RemoveCompanyFromWatchlistAsync(int userId, int companyId)
        {
            var userWatchlistItem = _context.UserWatchlists.First(uw => uw.UserId == userId && uw.CompanyId == companyId);
            _context.UserWatchlists.Remove(userWatchlistItem);
            await _context.SaveChangesAsync();
        }
    }
}

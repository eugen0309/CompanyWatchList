using CompanyWatchListEF.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyWatchListCore.Services
{
    public interface IWatchlistService
    {
        IEnumerable<Company> GetUserWatchlist(int userId);
        Task<Company> AddCompanyToWatchListAsync(int userId, string companyName, string symbol);
        Task RemoveCompanyFromWatchlistAsync(int userId, int companyId);
    }
}

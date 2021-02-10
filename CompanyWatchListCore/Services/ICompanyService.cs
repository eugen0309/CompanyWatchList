using CompanyWatchListEF.Entities;
using System.Collections.Generic;

namespace CompanyWatchListCore.Services
{
    public interface ICompanyService
    {
        IEnumerable<Company> GetUserWatchlist(int userId);
    }
}

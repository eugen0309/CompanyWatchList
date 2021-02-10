using CompanyWatchListEF;
using CompanyWatchListEF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanyWatchListCore.Services
{
    public class CompanyService : ICompanyService
    {
        CompanyWatchlistContext _context;
        public CompanyService(CompanyWatchlistContext context)
        {
            _context = context;
        }
        public IEnumerable<Company> GetUserWatchlist(int userId)
        {
            return _context.UserWatchlists.Where(wl => wl.User.Id == userId).Select(wl => wl.Company).ToList();            
        }

    }
}

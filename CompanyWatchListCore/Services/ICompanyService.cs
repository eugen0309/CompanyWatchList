using CompanyWatchListCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyWatchListCore.Services
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanySearchResultModel>> SearchCompanies(string keywords);
    }
}
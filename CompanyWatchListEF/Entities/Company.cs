using System.Collections.Generic;

namespace CompanyWatchListEF.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }       
        public ICollection<UserWatchlist> UserWatchlist { get; set; }
    }
}

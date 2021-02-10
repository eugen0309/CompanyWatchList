namespace CompanyWatchListEF.Entities
{
    public class UserWatchlist
    {
        public virtual User User { get; set; }
        public virtual Company Company { get; set; }
    }
}

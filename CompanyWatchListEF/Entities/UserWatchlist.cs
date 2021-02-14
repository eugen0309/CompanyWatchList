namespace CompanyWatchListEF.Entities
{
    public class UserWatchlist
    {
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public virtual User User { get; set; }
        public virtual Company Company { get; set; }
    }
}

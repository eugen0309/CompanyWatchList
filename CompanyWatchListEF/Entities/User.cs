using System.Collections.Generic;

namespace CompanyWatchListEF.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<UserWatchlist> UserWatchlist { get; set; }
        public string Token { get; set; }
    }
}

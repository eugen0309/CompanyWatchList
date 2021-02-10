using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace CompanyWatchList.Entities
{
    public class Role : IdentityRole<int>
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}

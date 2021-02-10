
using CompanyWatchList.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CompanyWatchList.Models
{
    public class RegistrationModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Password { get; set; }        
        public ICollection<string> UserRoles { get; set; }
    }
}

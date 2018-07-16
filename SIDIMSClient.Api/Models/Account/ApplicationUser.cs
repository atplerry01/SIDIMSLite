using Microsoft.AspNetCore.Identity;
using SIDIMSClient.Api.Models.Account;

namespace SIDIMSClient.Api.Models.Account
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsEnabled { get; set; }
    }
}
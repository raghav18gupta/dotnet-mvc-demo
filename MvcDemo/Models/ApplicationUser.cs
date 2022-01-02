using Microsoft.AspNetCore.Identity;

namespace MvcDemo.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string City { get; set;}
    }
}

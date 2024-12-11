using Microsoft.AspNetCore.Identity;

namespace MicroserviceArchitecture.Services.AuthAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }     
    }
}
